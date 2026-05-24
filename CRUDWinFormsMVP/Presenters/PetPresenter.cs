using CRUDWinFormsMVP._Repositories;
using CRUDWinFormsMVP.Models; //referencia del modelo y de la vista
using CRUDWinFormsMVP.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CRUDWinFormsMVP.Presenters
{
    /// <summary>
    /// Actúa como el intermediario (Presenter) entre la vista de mascotas y su repositorio de datos.
    /// Maneja la lógica de presentación y responde a las acciones del usuario.
    /// </summary>
    public class PetPresenter
    {
        // Campos Privados
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petsBindingSource;
        private IEnumerable<PetModel> petList;

        // Constructor
        /// <summary>
        /// Inicializa el presentador vinculando la vista y el repositorio, y suscribe los eventos de la vista.
        /// </summary>
        public PetPresenter(IPetView view, IPetRepository repository)
        {
            this.petsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Suscribir métodos de controlador de eventos para ver eventos
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;

            //Establecer fuente de enlace de mascotas
            //Set pets bindind source
            this.view.SetPetListBindingSource(petsBindingSource);
            //Load pet list view
            LoadAllPetList();
            //Show view
            this.view.Show();


        }

        // Métodos

        /// <summary>
        /// Consulta todas las mascotas en el repositorio y actualiza el origen de datos de la vista.
        /// </summary>
        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petsBindingSource.DataSource = petList;
        }

        /// <summary>
        /// Cancela la acción actual (ya sea agregar o editar) y limpia los campos de texto de la vista.
        /// </summary>
        /// <param name="sender">El origen del evento (generalmente el botón Cancelar).</param>
        /// <param name="e">Los datos del evento.</param>
        private void CancelAction(object? sender, EventArgs e)
        {
            CleanviewFields();
        }

        /// <summary>
        /// Valida el modelo actual y ejecuta la inserción o actualización en la base de datos.
        /// </summary>
        private void SavePet(object? sender, EventArgs e)
        {
            var model = new PetModel();
            model.Id = Convert.ToInt32(view.PetId);
            model.Name = view.PetName;
            model.Type = view.PetType;
            model.Colour = view.PetColour;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if(view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Pet edited successfuly";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Pet added successfuly";
                }
                view.IsSuccessful = true;
                LoadAllPetList();
                CleanviewFields();


            }
            catch(Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        /// <summary>
        /// Limpia los campos de entrada de texto en la vista.
        /// </summary>
        private void CleanviewFields()
        {
            view.PetId = "0";
            view.PetName = "";
            view.PetType = "";
            view.PetColour = "";
            
        }

        /// <summary>
        /// Elimina la mascota que está seleccionada actualmente en la lista.
        /// Intenta borrar el registro en la base de datos y actualiza el mensaje de la vista 
        /// indicando si la operación fue exitosa o si ocurrió un error.
        /// </summary>
        /// <param name="sender">El origen del evento (generalmente el botón Eliminar).</param>
        /// <param name="e">Los datos del evento.</param>
        private void DeleteSelectedPet(object? sender, EventArgs e)
        {
            try
            {
                var pet = (PetModel)petsBindingSource.Current;
                repository.Delete(pet.Id);
                view.IsSuccessful = true;
                view.Message = "Pet deleted successfully";
                LoadAllPetList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message= "An error ocurred, could not delete pet";
            }
        }

        /// <summary>
        /// Toma los datos de la mascota seleccionada en la cuadrícula (DataGrid) y los carga 
        /// en los campos de texto de la vista para que puedan ser modificados.
        /// Cambia el estado interno de la vista a "Modo Edición" (IsEdit = true).
        /// </summary>
        /// <param name="sender">El origen del evento (generalmente el botón Editar).</param>
        /// <param name="e">Los datos del evento.</param>
        private void LoadSelectedPetToEdit(object? sender, EventArgs e)
        {
            var pet = (PetModel)petsBindingSource.Current;
            view.PetId = pet.Id.ToString();
            view.PetName = pet.Name;
            view.PetType = pet.Type;
            view.PetColour = pet.Colour;
            view.IsEdit = true;
        }

        /// <summary>
        /// Prepara la vista para registrar una nueva mascota.
        /// Cambia el estado interno de la vista a "Modo Agregar" estableciendo IsEdit en falso.
        /// </summary>
        /// <param name="sender">El origen del evento (generalmente el botón Agregar Nuevo).</param>
        /// <param name="e">Los datos del evento.</param>
        private void AddNewPet(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        /// <summary>
        /// Realiza una búsqueda de mascotas en la base de datos basándose en el texto introducido en la vista.
        /// Si el campo de búsqueda está vacío, recarga la lista completa de todas las mascotas.
        /// Actualiza el origen de datos (DataSource) para reflejar los resultados en la pantalla.
        /// </summary>
        /// <param name="sender">El origen del evento (el botón Buscar o la tecla Enter en el cuadro de texto).</param>
        /// <param name="e">Los datos del evento.</param>
        private void SearchPet(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if(emptyValue == false)
            {
                petList = repository.GetByValue(this.view.SearchValue);
            }
            else petList = repository.GetAll();
            petsBindingSource.DataSource= petList;
        }
    }
}
