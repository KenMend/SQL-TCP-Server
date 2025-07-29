namespace AppCliente
{
    partial class FrmConsultarArticulos
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
            lblConsultarArticulos = new Label();
            dgvArticulos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colValor = new DataGridViewTextBoxColumn();
            conInventario = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewTextBoxColumn();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            SuspendLayout();
            // 
            // lblConsultarArticulos
            // 
            lblConsultarArticulos.AutoSize = true;
            lblConsultarArticulos.Location = new Point(436, 48);
            lblConsultarArticulos.Name = "lblConsultarArticulos";
            lblConsultarArticulos.Size = new Size(161, 25);
            lblConsultarArticulos.TabIndex = 0;
            lblConsultarArticulos.Text = "Consultar Artículos";
            // 
            // dgvArticulos
            // 
            dgvArticulos.AllowUserToAddRows = false;
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArticulos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colTipo, colValor, conInventario, colActivo });
            dgvArticulos.Location = new Point(89, 139);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.ReadOnly = true;
            dgvArticulos.RowHeadersWidth = 62;
            dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArticulos.Size = new Size(922, 484);
            dgvArticulos.TabIndex = 1;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 8;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo Artículo";
            colTipo.MinimumWidth = 8;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colValor
            // 
            colValor.HeaderText = "Valor";
            colValor.MinimumWidth = 8;
            colValor.Name = "colValor";
            colValor.ReadOnly = true;
            // 
            // conInventario
            // 
            conInventario.HeaderText = "Inventario";
            conInventario.MinimumWidth = 8;
            conInventario.Name = "conInventario";
            conInventario.ReadOnly = true;
            // 
            // colActivo
            // 
            colActivo.HeaderText = "Activo";
            colActivo.MinimumWidth = 8;
            colActivo.Name = "colActivo";
            colActivo.ReadOnly = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(385, 674);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(235, 105);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "MENU PRINCIPAL";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmConsultarArticulos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 856);
            Controls.Add(btnVolver);
            Controls.Add(dgvArticulos);
            Controls.Add(lblConsultarArticulos);
            Name = "FrmConsultarArticulos";
            Text = "Form1";
            Load += FrmConsultarArticulos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConsultarArticulos;
        private DataGridView dgvArticulos;
        private Button btnVolver;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colValor;
        private DataGridViewTextBoxColumn conInventario;
        private DataGridViewTextBoxColumn colActivo;
    }
}