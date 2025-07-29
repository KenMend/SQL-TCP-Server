namespace AppCliente
{
    partial class FrmRegistrarTipoArticulo
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
            txtId = new TextBox();
            txtNombre = new TextBox();
            TxtDescripcion = new TextBox();
            btnGuardar = new Button();
            lblId = new Label();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblTituloTipoArticulo = new Label();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(415, 130);
            txtId.Name = "txtId";
            txtId.Size = new Size(358, 31);
            txtId.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(415, 210);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(358, 31);
            txtNombre.TabIndex = 1;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.Location = new Point(415, 294);
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(358, 31);
            TxtDescripcion.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(483, 435);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(211, 96);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(262, 136);
            lblId.Name = "lblId";
            lblId.Size = new Size(120, 25);
            lblId.TabIndex = 4;
            lblId.Text = "Id del artículo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(181, 210);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(213, 25);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre del Tipo Artículo";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(155, 294);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(239, 25);
            lblDescripcion.TabIndex = 6;
            lblDescripcion.Text = "Descripcion del Tipo Artículo";
            // 
            // lblTituloTipoArticulo
            // 
            lblTituloTipoArticulo.AutoSize = true;
            lblTituloTipoArticulo.Location = new Point(483, 29);
            lblTituloTipoArticulo.Name = "lblTituloTipoArticulo";
            lblTituloTipoArticulo.Size = new Size(187, 25);
            lblTituloTipoArticulo.TabIndex = 7;
            lblTituloTipoArticulo.Text = "Registrar Tipo Artículo";
            // 
            // FrmRegistrarTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1252, 639);
            Controls.Add(lblTituloTipoArticulo);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Controls.Add(btnGuardar);
            Controls.Add(TxtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Name = "FrmRegistrarTipoArticulo";
            Text = "Form1";
            this.Load += new System.EventHandler(this.FrmRegistrarTipoArticulo_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox TxtDescripcion;
        private Button btnGuardar;
        private Label lblId;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblTituloTipoArticulo;
    }
}