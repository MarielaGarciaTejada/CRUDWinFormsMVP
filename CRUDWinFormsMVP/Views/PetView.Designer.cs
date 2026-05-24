namespace CRUDWinFormsMVP.Views
{
    partial class PetView
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
            label1 = new Label();
            panel1 = new Panel();
            btnClose = new Button();
            tabControl1 = new TabControl();
            tabPagePetList = new TabPage();
            dgvPets = new DataGridView();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAddNew = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label6 = new Label();
            tabPagePetDetail = new TabPage();
            btnCancel = new Button();
            btnSave = new Button();
            txtPetColour = new TextBox();
            txtPetType = new TextBox();
            txtPetName = new TextBox();
            txtPetId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPagePetList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPets).BeginInit();
            tabPagePetDetail.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 15F);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(648, 50);
            label1.TabIndex = 0;
            label1.Text = "PETS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(648, 48);
            panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(614, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 23);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPagePetList);
            tabControl1.Controls.Add(tabPagePetDetail);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 48);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(648, 326);
            tabControl1.TabIndex = 2;
            // 
            // tabPagePetList
            // 
            tabPagePetList.Controls.Add(dgvPets);
            tabPagePetList.Controls.Add(btnDelete);
            tabPagePetList.Controls.Add(btnEdit);
            tabPagePetList.Controls.Add(btnAddNew);
            tabPagePetList.Controls.Add(btnSearch);
            tabPagePetList.Controls.Add(txtSearch);
            tabPagePetList.Controls.Add(label6);
            tabPagePetList.Location = new Point(4, 24);
            tabPagePetList.Name = "tabPagePetList";
            tabPagePetList.Padding = new Padding(3);
            tabPagePetList.Size = new Size(640, 298);
            tabPagePetList.TabIndex = 0;
            tabPagePetList.Text = "Pet List";
            tabPagePetList.UseVisualStyleBackColor = true;
            // 
            // dgvPets
            // 
            dgvPets.AllowUserToAddRows = false;
            dgvPets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPets.Location = new Point(19, 79);
            dgvPets.Name = "dgvPets";
            dgvPets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPets.Size = new Size(526, 213);
            dgvPets.TabIndex = 6;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(557, 143);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Location = new Point(557, 104);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            btnAddNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNew.Location = new Point(557, 65);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(75, 23);
            btnAddNew.TabIndex = 3;
            btnAddNew.Text = "Add New";
            btnAddNew.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(470, 38);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(21, 38);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(443, 23);
            txtSearch.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 14);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 0;
            label6.Text = "Search Pet:";
            // 
            // tabPagePetDetail
            // 
            tabPagePetDetail.Controls.Add(btnCancel);
            tabPagePetDetail.Controls.Add(btnSave);
            tabPagePetDetail.Controls.Add(txtPetColour);
            tabPagePetDetail.Controls.Add(txtPetType);
            tabPagePetDetail.Controls.Add(txtPetName);
            tabPagePetDetail.Controls.Add(txtPetId);
            tabPagePetDetail.Controls.Add(label5);
            tabPagePetDetail.Controls.Add(label4);
            tabPagePetDetail.Controls.Add(label3);
            tabPagePetDetail.Controls.Add(label2);
            tabPagePetDetail.Location = new Point(4, 24);
            tabPagePetDetail.Name = "tabPagePetDetail";
            tabPagePetDetail.Padding = new Padding(3);
            tabPagePetDetail.Size = new Size(640, 298);
            tabPagePetDetail.TabIndex = 1;
            tabPagePetDetail.Text = "Pet Detail";
            tabPagePetDetail.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(272, 217);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 32);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(72, 217);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 32);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtPetColour
            // 
            txtPetColour.Location = new Point(62, 160);
            txtPetColour.Name = "txtPetColour";
            txtPetColour.Size = new Size(367, 23);
            txtPetColour.TabIndex = 7;
            // 
            // txtPetType
            // 
            txtPetType.Location = new Point(292, 106);
            txtPetType.Name = "txtPetType";
            txtPetType.Size = new Size(137, 23);
            txtPetType.TabIndex = 6;
            // 
            // txtPetName
            // 
            txtPetName.Location = new Point(62, 106);
            txtPetName.Name = "txtPetName";
            txtPetName.Size = new Size(183, 23);
            txtPetName.TabIndex = 5;
            // 
            // txtPetId
            // 
            txtPetId.Location = new Point(62, 45);
            txtPetId.Name = "txtPetId";
            txtPetId.ReadOnly = true;
            txtPetId.Size = new Size(100, 23);
            txtPetId.TabIndex = 4;
            txtPetId.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 142);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 3;
            label5.Text = "Pet Colour:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(292, 82);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 2;
            label4.Text = "Pet Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 82);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 1;
            label3.Text = "Pet Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 27);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 0;
            label2.Text = "Pet ID:";
            // 
            // PetView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 374);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "PetView";
            Text = "PetView";
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPagePetList.ResumeLayout(false);
            tabPagePetList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPets).EndInit();
            tabPagePetDetail.ResumeLayout(false);
            tabPagePetDetail.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPagePetList;
        private TabPage tabPagePetDetail;
        private TextBox txtPetName;
        private TextBox txtPetId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAddNew;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label label6;
        private Button btnCancel;
        private Button btnSave;
        private TextBox txtPetColour;
        private TextBox txtPetType;
        private DataGridView dgvPets;
        private Button btnClose;
    }
}