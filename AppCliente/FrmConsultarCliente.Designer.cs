namespace AppCliente
{
    partial class FrmConsultarCliente
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
            lblConsultarCliente = new Label();
            dgvClientes = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblConsultarCliente
            // 
            lblConsultarCliente.AutoSize = true;
            lblConsultarCliente.Location = new Point(491, 63);
            lblConsultarCliente.Name = "lblConsultarCliente";
            lblConsultarCliente.Size = new Size(153, 25);
            lblConsultarCliente.TabIndex = 0;
            lblConsultarCliente.Text = "Consultar Clientes";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(102, 137);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 62;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(969, 390);
            dgvClientes.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(420, 563);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(224, 99);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "MENU PRINCIPAL";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmConsultarCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 748);
            Controls.Add(btnVolver);
            Controls.Add(dgvClientes);
            Controls.Add(lblConsultarCliente);
            Name = "FrmConsultarCliente";
            Text = "Form1";
            Load += FrmConsultarCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConsultarCliente;
        private DataGridView dgvClientes;
        private Button btnVolver;
        private DataGridViewTextBoxColumn colIdentificacion;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colPrimerApellido;
        private DataGridViewTextBoxColumn colSegundoApellido;
        private DataGridViewTextBoxColumn colFechaNacimiento;
        private DataGridViewTextBoxColumn colActivo;
    }
}