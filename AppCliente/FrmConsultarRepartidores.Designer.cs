namespace AppCliente
{
    partial class FrmConsultarRepartidores
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
            lblRepartidores = new Label();
            dgvRepartidores = new DataGridView();
            colIdentificacion = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colPrimerApellido = new DataGridViewTextBoxColumn();
            colSegundoApellido = new DataGridViewTextBoxColumn();
            colFechaNacimiento = new DataGridViewTextBoxColumn();
            colFechaContratacion = new DataGridViewTextBoxColumn();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRepartidores).BeginInit();
            SuspendLayout();
            // 
            // lblRepartidores
            // 
            lblRepartidores.AutoSize = true;
            lblRepartidores.Location = new Point(406, 34);
            lblRepartidores.Name = "lblRepartidores";
            lblRepartidores.Size = new Size(192, 25);
            lblRepartidores.TabIndex = 0;
            lblRepartidores.Text = "Consultar Repartidores";
            // 
            // dgvRepartidores
            // 
            dgvRepartidores.AllowUserToAddRows = false;
            dgvRepartidores.AllowUserToDeleteRows = false;
            dgvRepartidores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepartidores.Columns.AddRange(new DataGridViewColumn[] { colIdentificacion, colNombre, colPrimerApellido, colSegundoApellido, colFechaNacimiento, colFechaContratacion });
            dgvRepartidores.Location = new Point(42, 76);
            dgvRepartidores.Name = "dgvRepartidores";
            dgvRepartidores.ReadOnly = true;
            dgvRepartidores.RowHeadersWidth = 62;
            dgvRepartidores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRepartidores.Size = new Size(965, 480);
            dgvRepartidores.TabIndex = 1;
            // 
            // colIdentificacion
            // 
            colIdentificacion.HeaderText = "Identificación";
            colIdentificacion.MinimumWidth = 8;
            colIdentificacion.Name = "colIdentificacion";
            colIdentificacion.ReadOnly = true;
            colIdentificacion.Width = 150;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 8;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 150;
            // 
            // colPrimerApellido
            // 
            colPrimerApellido.HeaderText = "Primer Apellido";
            colPrimerApellido.MinimumWidth = 8;
            colPrimerApellido.Name = "colPrimerApellido";
            colPrimerApellido.ReadOnly = true;
            colPrimerApellido.Width = 150;
            // 
            // colSegundoApellido
            // 
            colSegundoApellido.HeaderText = "Segundo Apellido";
            colSegundoApellido.MinimumWidth = 8;
            colSegundoApellido.Name = "colSegundoApellido";
            colSegundoApellido.ReadOnly = true;
            colSegundoApellido.Width = 150;
            // 
            // colFechaNacimiento
            // 
            colFechaNacimiento.HeaderText = "Fecha Nacimiento";
            colFechaNacimiento.MinimumWidth = 8;
            colFechaNacimiento.Name = "colFechaNacimiento";
            colFechaNacimiento.ReadOnly = true;
            colFechaNacimiento.Width = 150;
            // 
            // colFechaContratacion
            // 
            colFechaContratacion.HeaderText = "Fecha Contratación";
            colFechaContratacion.MinimumWidth = 8;
            colFechaContratacion.Name = "colFechaContratacion";
            colFechaContratacion.ReadOnly = true;
            colFechaContratacion.Width = 150;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(364, 622);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(279, 119);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "MENU PRINCIPAL";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // FrmConsultarRepartidores
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 802);
            Controls.Add(btnVolver);
            Controls.Add(dgvRepartidores);
            Controls.Add(lblRepartidores);
            Name = "FrmConsultarRepartidores";
            Text = "Form1";
            Load += this.FrmConsultarRepartidores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRepartidores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRepartidores;
        private DataGridView dgvRepartidores;
        private DataGridViewTextBoxColumn colIdentificacion;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colPrimerApellido;
        private DataGridViewTextBoxColumn colSegundoApellido;
        private DataGridViewTextBoxColumn colFechaNacimiento;
        private DataGridViewTextBoxColumn colFechaContratacion;
        private Button btnVolver;
    }
}