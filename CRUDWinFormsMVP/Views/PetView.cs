using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    /// <summary>
    /// Representa la interfaz gráfica de usuario para la gestión de mascotas. 
    /// Implementa el patrón Singleton para asegurar una única instancia en formularios MDI.
    /// </summary>
    public partial class PetView : Form, IPetView
    {
        // Fields - Campos
        private string message;
        private bool isSuccessful;
        private bool isEdit;


        //Constructor
        public PetView()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(22, 22, 35);
            label1.Text = "🐾 PET MANAGER";
            // Cambiar colores y estilo de btnSave
            btnSave.BackColor = Color.MediumSeaGreen;      // Color de fondo
            btnSave.ForeColor = Color.White;               // Color del texto
            btnSave.FlatStyle = FlatStyle.Flat;            // Quita el borde 3D tradicional
            btnSave.FlatAppearance.BorderSize = 0;         // Quita el borde negro
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Cambia la fuente

            // Cambiar colores y estilo de btnCancel
            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Cambiar colores y estilo de btnClose
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Cambiar colores y estilo de btnAddNew
            btnAddNew.BackColor = Color.Teal;
            btnAddNew.ForeColor = Color.White;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Cambiar colores y estilo de btnEdit
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Cambiar colores y estilo de btnDelete
            btnDelete.BackColor = Color.SlateGray;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPagePetDetail);
            //tabControl1.TabPages.Remove(tabPagePetList);
            btnClose.Click += delegate { this.Close(); };
        }

        /// <summary>
        /// Representa la interfaz gráfica de usuario para la gestión de mascotas. 
        /// Implementa el patrón Singleton para asegurar una única instancia en formularios MDI.
        /// </summary>
        private void AssociateAndRaiseViewEvents()
        {
            //Search - Buscar
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            //Add New - btn agg
            btnAddNew.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetList);
                tabControl1.TabPages.Add(tabPagePetDetail);
                tabPagePetDetail.Text = "Add new pet";
            };

            //Edit - btn Editar
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetList);
                tabControl1.TabPages.Add(tabPagePetDetail);
                tabPagePetDetail.Text = "Edit pet";
            };

            //Save Changes - btn guardar
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPagePetDetail);
                    tabControl1.TabPages.Add(tabPagePetList);
                }
                MessageBox.Show(Message);
            };



            //Cancel - btn cancelar
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPagePetDetail);
                tabControl1.TabPages.Add(tabPagePetList);
            };

            //Delete - btn eliminar
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected pet?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PetId
        {
            get { return txtPetId.Text; }
            set { txtPetId.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PetName
        {
            get { return txtPetName.Text; }
            set { txtPetName.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PetType
        {
            get { return txtPetType.Text; }
            set { txtPetType.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PetColour
        {
            get { return txtPetColour.Text; }
            set { txtPetColour.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPetListBindingSource(BindingSource petList)
        {
            dgvPets.DataSource = petList;
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        //Singleton pattern (Open a single form instance)
        private static PetView instance;

        /// <summary>
        /// Implementa el patrón Singleton para abrir una única instancia de este formulario dentro de un contenedor padre MDI.
        /// </summary>
        /// <param name="parentContainer">El formulario principal que actuará como contenedor.</param>
        /// <returns>La instancia única de PetView.</returns>
        public static PetView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PetView();
                instance.MdiParent = parentContainer;

                //quitar el estilo de borde y para que se acople
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        //Mostrar Pestañas

        /// <summary>
        /// Cambia la interfaz para mostrar la pestaña de detalles de la mascota.
        /// Configura el estado de la vista en modo de creación (IsEdit = false), 
        /// remueve temporalmente la pestaña de la lista e inserta la pestaña de detalles,
        /// actualizando su título correspondiente.
        /// </summary>
        public void ShowDetailTab()
        {
            // Cambiamos el modo a "Agregar" (IsEdit = false)
            this.isEdit = false;

            // Intercambiamos las pestañas exactamente como en los otros botones
            tabControl1.TabPages.Remove(tabPagePetList);

            if (!tabControl1.TabPages.Contains(tabPagePetDetail))
            {
                tabControl1.TabPages.Add(tabPagePetDetail);
            }

            tabPagePetDetail.Text = "Add new pet";
        }

        /// <summary>
        /// Cambia la interfaz para regresar al apartado de la lista general de mascotas.
        /// Restaura la pestaña de la lista si había sido removida previamente, oculta la 
        /// pestaña de detalles, selecciona visualmente la cuadrícula de datos y fuerza 
        /// el refresco gráfico del formulario para evitar errores visuales.
        /// </summary>
        public void ShowListTab()
        {
            // Primero agregamos la pestaña de la lista si fue removida antes
            if (!tabControl1.TabPages.Contains(tabPagePetList))
            {
                tabControl1.TabPages.Add(tabPagePetList);
            }

            // 2. Removemos la pestaña de detalles
            tabControl1.TabPages.Remove(tabPagePetDetail);

            // 3. Seleccionamos visualmente la lista y refrescamos la pantalla
            tabControl1.SelectedTab = tabPagePetList;
            this.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
