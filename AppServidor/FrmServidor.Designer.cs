namespace AppServidor
{
    partial class FrmServidor
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
            this.txtBitacora = new System.Windows.Forms.TextBox();
            this.lblClientes = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            //SuspendLayout();
            // 
            // txtBitacora
            // 
            this.txtBitacora.Multiline = true;
            this.txtBitacora.ScrollBars = ScrollBars.Vertical;
            this.txtBitacora.ReadOnly = true;
            this.txtBitacora.Location = new Point(12, 12);
            this.txtBitacora.Size = new Size(460, 250);


            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Location = new Point(12, 270);
            this.lblClientes.Size = new Size(200, 23);
            this.lblClientes.Text = "Clientes conectados: 0";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new Point(12, 310);
            this.btnIniciar.Size = new Size(100, 30);
            this.btnIniciar.Text = "Iniciar servidor";
            this.btnIniciar.Click += new EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new Point(130, 310);
            this.btnDetener.Size = new Size(100, 30);
            this.btnDetener.Text = "Detener servidor";
            this.btnDetener.Click += new EventHandler(this.btnDetener_Click);
            // 
            // FrmServidor
            // 
            this.ClientSize = new Size(500, 360);
            this.Controls.Add(this.txtBitacora);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnDetener);
            this.Text = "Servidor Central";
        }

        #endregion

        private TextBox txtBitacora;
        private Label lblClientes;
        private Button btnIniciar;
        private Button btnDetener;
    }
}