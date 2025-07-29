namespace AppCliente
{
    partial class FrmRegistrarRepartidor
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
            txtIdentificacion = new TextBox();
            txtNombre = new TextBox();
            txtPrimerApellido = new TextBox();
            txtSegundoApellido = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            dtpFechaContratacion = new DateTimePicker();
            cmbActivo = new ComboBox();
            btnGuardar = new Button();
            lblIdentificacion = new Label();
            lblNombre = new Label();
            lblPrimerApellido = new Label();
            lblSegundoApellido = new Label();
            label5 = new Label();
            lblFechaContratacion = new Label();
            lblActivo = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(275, 92);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(252, 31);
            txtIdentificacion.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(275, 155);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(255, 31);
            txtNombre.TabIndex = 1;
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(275, 230);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(252, 31);
            txtPrimerApellido.TabIndex = 2;
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(275, 307);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(252, 31);
            txtSegundoApellido.TabIndex = 3;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(275, 382);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(300, 31);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Location = new Point(275, 469);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(300, 31);
            dtpFechaContratacion.TabIndex = 5;
            // 
            // cmbActivo
            // 
            cmbActivo.FormattingEnabled = true;
            cmbActivo.Location = new Point(275, 567);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(182, 33);
            cmbActivo.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(359, 659);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(263, 107);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblIdentificacion
            // 
            lblIdentificacion.AutoSize = true;
            lblIdentificacion.Location = new Point(127, 92);
            lblIdentificacion.Name = "lblIdentificacion";
            lblIdentificacion.Size = new Size(121, 25);
            lblIdentificacion.TabIndex = 8;
            lblIdentificacion.Text = "Identificacion:";
            
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(171, 161);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre:";
            // 
            // lblPrimerApellido
            // 
            lblPrimerApellido.AutoSize = true;
            lblPrimerApellido.Location = new Point(110, 236);
            lblPrimerApellido.Name = "lblPrimerApellido";
            lblPrimerApellido.Size = new Size(138, 25);
            lblPrimerApellido.TabIndex = 10;
            lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // lblSegundoApellido
            // 
            lblSegundoApellido.AutoSize = true;
            lblSegundoApellido.Location = new Point(110, 307);
            lblSegundoApellido.Name = "lblSegundoApellido";
            lblSegundoApellido.Size = new Size(159, 25);
            lblSegundoApellido.TabIndex = 11;
            lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(113, 382);
            label5.Name = "label5";
            label5.Size = new Size(156, 25);
            label5.TabIndex = 12;
            label5.Text = "Fecha Nacimiento:";
            // 
            // lblFechaContratacion
            // 
            lblFechaContratacion.AutoSize = true;
            lblFechaContratacion.Location = new Point(102, 469);
            lblFechaContratacion.Name = "lblFechaContratacion";
            lblFechaContratacion.Size = new Size(167, 25);
            lblFechaContratacion.TabIndex = 13;
            lblFechaContratacion.Text = "Fecha Contratacion:";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Location = new Point(171, 575);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(74, 25);
            lblActivo.TabIndex = 14;
            lblActivo.Text = "Activo?:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(361, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(169, 25);
            lblTitulo.TabIndex = 15;
            lblTitulo.Text = "Registrar Repartidor";
            // 
            // FrmRegistrarRepartidor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 812);
            Controls.Add(lblTitulo);
            Controls.Add(lblActivo);
            Controls.Add(lblFechaContratacion);
            Controls.Add(label5);
            Controls.Add(lblSegundoApellido);
            Controls.Add(lblPrimerApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblIdentificacion);
            Controls.Add(btnGuardar);
            Controls.Add(cmbActivo);
            Controls.Add(dtpFechaContratacion);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtSegundoApellido);
            Controls.Add(txtPrimerApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtIdentificacion);
            Name = "FrmRegistrarRepartidor";
            Text = "Form1";
            Load += this.FrmRegistrarRepartidor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdentificacion;
        private TextBox txtNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private DateTimePicker dtpFechaNacimiento;
        private DateTimePicker dtpFechaContratacion;
        private ComboBox cmbActivo;
        private Button btnGuardar;
        private Label lblIdentificacion;
        private Label lblNombre;
        private Label lblPrimerApellido;
        private Label lblSegundoApellido;
        private Label label5;
        private Label lblFechaContratacion;
        private Label lblActivo;
        private Label lblTitulo;
    }
}