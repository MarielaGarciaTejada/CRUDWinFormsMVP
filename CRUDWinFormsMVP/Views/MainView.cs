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
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            // ─── FONDO DEL PANEL LATERAL ────────────────────────────────────────
            panel1.BackColor = Color.FromArgb(22, 22, 35);

            // ─── BOTÓN: Pets List ────────────────────────────────────────────────
            btnPets.Text = "🐶  Pets List";
            btnPets.BackColor = Color.FromArgb(52, 152, 219);   // Azul
            btnPets.ForeColor = Color.White;
            btnPets.FlatStyle = FlatStyle.Flat;
            btnPets.FlatAppearance.BorderSize = 0;
            btnPets.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPets.Cursor = Cursors.Hand;
            btnPets.Size = new Size(180, 40);
            btnPets.Location = new Point(10, 70);

            // ─── BOTÓN: Pets Details ─────────────────────────────────────────────
            btnPetDetail.Text = "📋  Pets Details";
            btnPetDetail.BackColor = Color.FromArgb(39, 174, 96); // Verde
            btnPetDetail.ForeColor = Color.White;
            btnPetDetail.FlatStyle = FlatStyle.Flat;
            btnPetDetail.FlatAppearance.BorderSize = 0;
            btnPetDetail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPetDetail.Cursor = Cursors.Hand;
            btnPetDetail.Size = new Size(180, 40);
            btnPetDetail.Location = new Point(10, 120);

            btnPets.Click += delegate { ShowPetView?.Invoke(this, EventArgs.Empty); };
            btnPetDetail.Click += delegate { ShowPetDetailView?.Invoke(this, EventArgs.Empty); };

        }

        public event EventHandler ShowPetView;
        public event EventHandler ShowOwnerView;
        public event EventHandler ShowVetsView;

        // Implementación de la propiedad de la interfaz
        public event EventHandler ShowPetDetailView;
    }
}
