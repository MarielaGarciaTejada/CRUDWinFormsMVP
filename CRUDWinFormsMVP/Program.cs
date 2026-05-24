using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Presenters;
using CRUDWinFormsMVP._Repositories;
using CRUDWinFormsMVP.Views;
using System.Configuration;

namespace CRUDWinFormsMVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            ApplicationConfiguration.Initialize();

            //Injeccion de dependencias - manualmente o explicitamente
            IMainView view = new MainView();
            new MainPresenter(view, sqlConnectionString);
            // Aquí llamas al formulario real (PetView) que creaste en tu carpeta Views
            //IPetView view = new PetView();
            // Aquí llamas a la clase real (PetRepository) donde escribiste tu código SQL
            //IPetRepository repository = new PetRepository(sqlConnectionString);
            //IPetView view = new IPetView();
            //IPetRepository repository = new IPetRepository(sqlConnectionString);
            //new PetPresenter(view, repository);

            Application.Run((Form)view);
        }
    }
}