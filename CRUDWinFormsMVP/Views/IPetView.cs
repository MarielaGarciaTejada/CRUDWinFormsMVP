using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Views
{
    public interface IPetView
    {
        //Propiedades - Fields
        string PetId {  get; set; }
        string PetName { get; set; }
        string PetType { get; set; }
        string PetColour {  get; set; }

        string SearchValue {  get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message {  get; set; }

        // EVENTOS PARA BUSQUEDA, AGREGAR, EDITAR, ELIMINAR, GUARDAR CAMBIOS Y CANCELAR
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Metodos
        void SetPetListBindingSource(BindingSource petList);
        void Show();

        //Mostrar Pestaña Detalle Y Lista
        void ShowDetailTab();
        void ShowListTab();


    }
}
