using System;
using System.Windows.Forms;
using CapaAccesoDatosSql;
using CapaEntidades;


namespace AppCliente
{
    public partial class FrmRegistrarCliente : Form
    {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            cmbActivo = new ComboBox();
            btnGuardar = new Button();
            txtPrimerApellido = new TextBox();
            txtSegundoApellido = new TextBox();
            label1 = new Label();
            lblNombre = new Label();
            lblPrimerApellido = new Label();
            lblSegundoApellido = new Label();
            label2 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(338, 80);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(380, 31);
            txtNombre.TabIndex = 0;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(338, 329);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(353, 31);
            dtpFechaNacimiento.TabIndex = 1;
            // 
            // cmbActivo
            // 
            cmbActivo.FormattingEnabled = true;
            cmbActivo.Location = new Point(338, 427);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(182, 33);
            cmbActivo.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(439, 589);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(297, 105);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += this.btnGuardar_Click;
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(338, 161);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(380, 31);
            txtPrimerApellido.TabIndex = 4;
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(338, 243);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(380, 31);
            txtSegundoApellido.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(457, 24);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 6;
            label1.Text = "Registro de Clientes";
            
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(157, 86);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre:";
            
            // 
            // lblPrimerApellido
            // 
            lblPrimerApellido.AutoSize = true;
            lblPrimerApellido.Location = new Point(157, 161);
            lblPrimerApellido.Name = "lblPrimerApellido";
            lblPrimerApellido.Size = new Size(138, 25);
            lblPrimerApellido.TabIndex = 8;
            lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // lblSegundoApellido
            // 
            lblSegundoApellido.AutoSize = true;
            lblSegundoApellido.Location = new Point(157, 249);
            lblSegundoApellido.Name = "lblSegundoApellido";
            lblSegundoApellido.Size = new Size(159, 25);
            lblSegundoApellido.TabIndex = 9;
            lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(151, 329);
            label2.Name = "label2";
            label2.Size = new Size(181, 25);
            label2.TabIndex = 10;
            label2.Text = "Fecha de Nacimiento:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(165, 435);
            label5.Name = "label5";
            label5.Size = new Size(74, 25);
            label5.TabIndex = 11;
            label5.Text = "Activo?:";
            // 
            // RegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 781);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(lblSegundoApellido);
            Controls.Add(lblPrimerApellido);
            Controls.Add(lblNombre);
            Controls.Add(label1);
            Controls.Add(txtSegundoApellido);
            Controls.Add(txtPrimerApellido);
            Controls.Add(btnGuardar);
            Controls.Add(cmbActivo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtNombre);
            Name = "FrmRegistrarCliente";
            Text = "Form1";
            Load += FrmRegistrarCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cmbActivo;
        private Button btnGuardar;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private Label label1;
        private Label lblNombre;
        private Label lblPrimerApellido;
        private Label lblSegundoApellido;
        private Label label2;
        private Label label5;
    }
}
