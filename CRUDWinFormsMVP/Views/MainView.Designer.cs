namespace CRUDWinFormsMVP.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnPetDetail = new Button();
            btnPets = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPetDetail);
            panel1.Controls.Add(btnPets);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 450);
            panel1.TabIndex = 0;
            // 
            // btnPetDetail
            // 
            btnPetDetail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPetDetail.Location = new Point(3, 79);
            btnPetDetail.Name = "btnPetDetail";
            btnPetDetail.Size = new Size(194, 34);
            btnPetDetail.TabIndex = 1;
            btnPetDetail.Text = "Pets Details";
            btnPetDetail.UseVisualStyleBackColor = true;
            // 
            // btnPets
            // 
            btnPets.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPets.Location = new Point(3, 39);
            btnPets.Name = "btnPets";
            btnPets.Size = new Size(194, 34);
            btnPets.TabIndex = 0;
            btnPets.Text = "Pets List";
            btnPets.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 450);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Name = "MainView";
            Text = "MainView";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnPets;
        private Button btnPetDetail;
    }
}