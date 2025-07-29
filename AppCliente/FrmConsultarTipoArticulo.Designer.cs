namespace AppCliente
{
    partial class FrmConsultarTipoArticulo
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
            lblTipoArticulo = new Label();
            dgvTiposArticulo = new DataGridView();
            btnVolver = new Button();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTiposArticulo).BeginInit();
            SuspendLayout();
            // 
            // lblTipoArticulo
            // 
            lblTipoArticulo.AutoSize = true;
            lblTipoArticulo.Location = new Point(371, 50);
            lblTipoArticulo.Name = "lblTipoArticulo";
            lblTipoArticulo.Size = new Size(218, 25);
            lblTipoArticulo.TabIndex = 0;
            lblTipoArticulo.Text = "Consultar Tipo de Artículo";
            // 
            // dgvTiposArticulo
            // 
            dgvTiposArticulo.AllowUserToAddRows = false;
            dgvTiposArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiposArticulo.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colDescripcion });
            dgvTiposArticulo.Location = new Point(220, 151);
            dgvTiposArticulo.Name = "dgvTiposArticulo";
            dgvTiposArticulo.ReadOnly = true;
            dgvTiposArticulo.RowHeadersWidth = 62;
            dgvTiposArticulo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiposArticulo.Size = new Size(513, 232);
            dgvTiposArticulo.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(371, 530);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(247, 117);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "MENU PRINCIPAL";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 150;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 8;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 150;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripcion";
            colDescripcion.MinimumWidth = 8;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            colDescripcion.Width = 150;
            // 
            // FrmConsultarTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 701);
            Controls.Add(btnVolver);
            Controls.Add(dgvTiposArticulo);
            Controls.Add(lblTipoArticulo);
            Name = "FrmConsultarTipoArticulo";
            Text = "Form1";
            Load += FrmConsultarTipoArticulo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTiposArticulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipoArticulo;
        private DataGridView dgvTiposArticulo;
        private Button btnVolver;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
    }
}