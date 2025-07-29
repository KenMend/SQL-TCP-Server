namespace AppCliente
{
    partial class FrmLogin
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
            lblIdentificacion = new Label();
            txtIdentificacion = new TextBox();
            btnIngresar = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblIdentificacion
            // 
            lblIdentificacion.AutoSize = true;
            lblIdentificacion.Location = new Point(207, 92);
            lblIdentificacion.Name = "lblIdentificacion";
            lblIdentificacion.Size = new Size(88, 25);
            lblIdentificacion.TabIndex = 0;
            lblIdentificacion.Text = "ID Cliente";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(301, 89);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(150, 31);
            txtIdentificacion.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(301, 201);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(145, 107);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(355, 379);
            lblError.Name = "lblError";
            lblError.Size = new Size(26, 25);
            lblError.TabIndex = 3;
            lblError.Text = "\"\"";
            lblError.Visible = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(btnIngresar);
            Controls.Add(txtIdentificacion);
            Controls.Add(lblIdentificacion);
            Name = "FrmLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdentificacion;
        private TextBox txtIdentificacion;
        private Button btnIngresar;
        private Label lblError;
    }
}