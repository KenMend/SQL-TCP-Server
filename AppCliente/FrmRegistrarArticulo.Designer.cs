namespace AppCliente
{
    partial class FrmRegistrarArticulo
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
            cmbTipoArticulo = new ComboBox();
            txtValor = new TextBox();
            txtInventario = new TextBox();
            cmbActivo = new ComboBox();
            btnGuardar = new Button();
            lblTitulo = new Label();
            lblId = new Label();
            lblNombre = new Label();
            lblTipoArticulo = new Label();
            lblValor = new Label();
            lblInventario = new Label();
            lblActivo = new Label();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(426, 116);
            txtId.Name = "txtId";
            txtId.Size = new Size(182, 31);
            txtId.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(426, 191);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(380, 31);
            txtNombre.TabIndex = 1;
            // 
            // cmbTipoArticulo
            // 
            cmbTipoArticulo.FormattingEnabled = true;
            cmbTipoArticulo.Location = new Point(426, 272);
            cmbTipoArticulo.Name = "cmbTipoArticulo";
            cmbTipoArticulo.Size = new Size(182, 33);
            cmbTipoArticulo.TabIndex = 2;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(426, 352);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(182, 31);
            txtValor.TabIndex = 3;
            // 
            // txtInventario
            // 
            txtInventario.Location = new Point(426, 421);
            txtInventario.Name = "txtInventario";
            txtInventario.Size = new Size(182, 31);
            txtInventario.TabIndex = 4;
            // 
            // cmbActivo
            // 
            cmbActivo.FormattingEnabled = true;
            cmbActivo.Location = new Point(426, 499);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(182, 33);
            cmbActivo.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(577, 617);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(264, 115);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(634, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(172, 25);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Registrar un Articulo";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(294, 116);
            lblId.Name = "lblId";
            lblId.Size = new Size(123, 25);
            lblId.TabIndex = 8;
            lblId.Text = "Id del Articulo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(244, 191);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(173, 25);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre del Artículo";
            // 
            // lblTipoArticulo
            // 
            lblTipoArticulo.AutoSize = true;
            lblTipoArticulo.Location = new Point(279, 272);
            lblTipoArticulo.Name = "lblTipoArticulo";
            lblTipoArticulo.Size = new Size(138, 25);
            lblTipoArticulo.TabIndex = 10;
            lblTipoArticulo.Text = "Tipo de Artículo";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(270, 355);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(147, 25);
            lblValor.TabIndex = 11;
            lblValor.Text = "Valor del Artículo";
            // 
            // lblInventario
            // 
            lblInventario.AutoSize = true;
            lblInventario.Location = new Point(326, 421);
            lblInventario.Name = "lblInventario";
            lblInventario.Size = new Size(91, 25);
            lblInventario.TabIndex = 12;
            lblInventario.Text = "Inventario";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Location = new Point(347, 499);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(70, 25);
            lblActivo.TabIndex = 13;
            lblActivo.Text = "Activo?";
            // 
            // FrmRegistrarArticulo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1402, 809);
            Controls.Add(lblActivo);
            Controls.Add(lblInventario);
            Controls.Add(lblValor);
            Controls.Add(lblTipoArticulo);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Controls.Add(lblTitulo);
            Controls.Add(btnGuardar);
            Controls.Add(cmbActivo);
            Controls.Add(txtInventario);
            Controls.Add(txtValor);
            Controls.Add(cmbTipoArticulo);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Name = "FrmRegistrarArticulo";
            Text = "Form1";
            Load += this.FrmRegistrarArticulo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtNombre;
        private ComboBox cmbTipoArticulo;
        private TextBox txtValor;
        private TextBox txtInventario;
        private ComboBox cmbActivo;
        private Button btnGuardar;
        private Label lblTitulo;
        private Label lblId;
        private Label lblNombre;
        private Label lblTipoArticulo;
        private Label lblValor;
        private Label lblInventario;
        private Label lblActivo;
    }
}