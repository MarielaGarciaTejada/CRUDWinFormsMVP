using CRUDWinFormsMVP._Repositories;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Presenters.Common;
using CRUDWinFormsMVP.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUDWinFormsMVP.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        private PetPresenter? petPresenter; //////////////

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowPetView += ShowPetsView;

            this.mainView.ShowPetDetailView += ShowPetsDetailView; // <-- Suscribir el nuevo evento
        }

        private PetPresenter GetOrCreatePetPresenter(IPetView view)
        {
            if (petPresenter == null || ((Form)view).IsDisposed)
            {
                IPetRepository repository = new PetRepository(sqlConnectionString);
                petPresenter = new PetPresenter(view, repository);
            }
            return petPresenter;
        }

        /// <summary>
        /// Maneja el evento del menú para mostrar el apartado general de mascotas.
        /// Obtiene la instancia única del formulario, reutiliza o inicializa su presentador 
        /// y fuerza a la vista a mostrar la pestaña de la lista de registros, 
        /// asegurando que la ventana se muestre al frente del usuario.
        /// </summary>
        /// <param name="sender">El origen del evento (generalmente el botón "Pets" del menú principal).</param>
        /// <param name="e">Los datos del evento.</param>
        private void ShowPetsView(object? sender, EventArgs e)
        {
            IPetView view = PetView.GetInstance((Form)mainView);
            GetOrCreatePetPresenter(view);        // ← reutiliza si ya existe
            view.ShowListTab();
            ((Form)view).Show();
            ((Form)view).BringToFront();
        }

        /// <summary>
        /// Maneja el evento del menú para abrir directamente el formulario de detalles.
        /// Utiliza la misma instancia del formulario y presentador de mascotas, pero cambia 
        /// visualmente a la pestaña de detalles (preparando la interfaz para un nuevo registro) 
        /// y trae la ventana al primer plano.
        /// </summary>
        /// <param name="sender">El origen del evento (generalmente el botón "Pet Detail" del menú principal).</param>
        /// <param name="e">Los datos del evento.</param>
        private void ShowPetsDetailView(object? sender, EventArgs e)
        {
            PetView view = PetView.GetInstance((Form)mainView);
            GetOrCreatePetPresenter(view);        // ← reutiliza si ya existe
            view.ShowDetailTab();
            ((Form)view).Show();                  // ← también se agregó esto
            ((Form)view).BringToFront();          // ← y esto (para consistencia)
        }
  
    }
}
