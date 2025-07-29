namespace AppCliente
{
    partial class FrmMenuPrincipal
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
            lblTitulo = new Label();
            btnRegistrarTipoArticulo = new Button();
            btnRegistrarArticulo = new Button();
            btnRegistrarCliente = new Button();
            btnRegistrarRepartidor = new Button();
            btnRegistrarPedido = new Button();
            btnConsultarTipoArticulo = new Button();
            btnConsultarArticulo = new Button();
            btnConsultarCliente = new Button();
            btnConsultarRepartidor = new Button();
            btnConsultarPedido = new Button();
            btnSalir = new Button();
            lblNombreCliente = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(725, 43);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(151, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MENU PRINCIPAL";
            // 
            // btnRegistrarTipoArticulo
            // 
            btnRegistrarTipoArticulo.Location = new Point(177, 216);
            btnRegistrarTipoArticulo.Name = "btnRegistrarTipoArticulo";
            btnRegistrarTipoArticulo.Size = new Size(176, 73);
            btnRegistrarTipoArticulo.TabIndex = 1;
            btnRegistrarTipoArticulo.Text = "REGISTRAR TIPO ARTICULO";
            btnRegistrarTipoArticulo.UseVisualStyleBackColor = true;
            btnRegistrarTipoArticulo.Click += btnRegistrarTipoArticulo_Click;
            // 
            // btnRegistrarArticulo
            // 
            btnRegistrarArticulo.Location = new Point(449, 216);
            btnRegistrarArticulo.Name = "btnRegistrarArticulo";
            btnRegistrarArticulo.Size = new Size(180, 73);
            btnRegistrarArticulo.TabIndex = 2;
            btnRegistrarArticulo.Text = "REGISTRAR ARTICULO";
            btnRegistrarArticulo.UseVisualStyleBackColor = true;
            btnRegistrarArticulo.Click += btnRegistrarArticulo_Click;
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.Location = new Point(703, 216);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(173, 73);
            btnRegistrarCliente.TabIndex = 3;
            btnRegistrarCliente.Text = "REGISTRAR CLIENTE";
            btnRegistrarCliente.UseVisualStyleBackColor = true;
            btnRegistrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // btnRegistrarRepartidor
            // 
            btnRegistrarRepartidor.Location = new Point(977, 216);
            btnRegistrarRepartidor.Name = "btnRegistrarRepartidor";
            btnRegistrarRepartidor.Size = new Size(172, 73);
            btnRegistrarRepartidor.TabIndex = 4;
            btnRegistrarRepartidor.Text = "REGISTRAR REPARTIDOR";
            btnRegistrarRepartidor.UseVisualStyleBackColor = true;
            btnRegistrarRepartidor.Click += btnRegistrarRepartidor_Click;
            // 
            // btnRegistrarPedido
            // 
            btnRegistrarPedido.Location = new Point(1250, 216);
            btnRegistrarPedido.Name = "btnRegistrarPedido";
            btnRegistrarPedido.Size = new Size(160, 73);
            btnRegistrarPedido.TabIndex = 5;
            btnRegistrarPedido.Text = "REGISTRAR PEDIDO";
            btnRegistrarPedido.UseVisualStyleBackColor = true;
            btnRegistrarPedido.Click += btnRegistrarPedido_Click;
            // 
            // btnConsultarTipoArticulo
            // 
            btnConsultarTipoArticulo.Location = new Point(177, 530);
            btnConsultarTipoArticulo.Name = "btnConsultarTipoArticulo";
            btnConsultarTipoArticulo.Size = new Size(176, 75);
            btnConsultarTipoArticulo.TabIndex = 6;
            btnConsultarTipoArticulo.Text = "CONSULTAR TIPO ARTICULO";
            btnConsultarTipoArticulo.UseVisualStyleBackColor = true;
            btnConsultarTipoArticulo.Click += btnConsultarTipoArticulo_Click;
            // 
            // btnConsultarArticulo
            // 
            btnConsultarArticulo.Location = new Point(449, 530);
            btnConsultarArticulo.Name = "btnConsultarArticulo";
            btnConsultarArticulo.Size = new Size(180, 75);
            btnConsultarArticulo.TabIndex = 7;
            btnConsultarArticulo.Text = "CONSULTAR ARTICULO";
            btnConsultarArticulo.UseVisualStyleBackColor = true;
            btnConsultarArticulo.Click += btnConsultarArticulo_Click;
            // 
            // btnConsultarCliente
            // 
            btnConsultarCliente.Location = new Point(703, 530);
            btnConsultarCliente.Name = "btnConsultarCliente";
            btnConsultarCliente.Size = new Size(173, 75);
            btnConsultarCliente.TabIndex = 8;
            btnConsultarCliente.Text = "CONSULTAR CLIENTE";
            btnConsultarCliente.UseVisualStyleBackColor = true;
            btnConsultarCliente.Click += btnConsultarCliente_Click;
            // 
            // btnConsultarRepartidor
            // 
            btnConsultarRepartidor.Location = new Point(977, 530);
            btnConsultarRepartidor.Name = "btnConsultarRepartidor";
            btnConsultarRepartidor.Size = new Size(172, 75);
            btnConsultarRepartidor.TabIndex = 9;
            btnConsultarRepartidor.Text = "CONSULTAR REPARTIDOR";
            btnConsultarRepartidor.UseVisualStyleBackColor = true;
            btnConsultarRepartidor.Click += btnConsultarRepartidor_Click;
            // 
            // btnConsultarPedido
            // 
            btnConsultarPedido.Location = new Point(1250, 530);
            btnConsultarPedido.Name = "btnConsultarPedido";
            btnConsultarPedido.Size = new Size(160, 75);
            btnConsultarPedido.TabIndex = 10;
            btnConsultarPedido.Text = "CONSULTAR PEDIDOS";
            btnConsultarPedido.UseVisualStyleBackColor = true;
            btnConsultarPedido.Click += btnConsultarPedido_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(597, 689);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(291, 108);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(1083, 720);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(136, 25);
            lblNombreCliente.TabIndex = 12;
            lblNombreCliente.Text = "Nombre Cliente";
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1753, 853);
            Controls.Add(lblNombreCliente);
            Controls.Add(btnSalir);
            Controls.Add(btnConsultarPedido);
            Controls.Add(btnConsultarRepartidor);
            Controls.Add(btnConsultarCliente);
            Controls.Add(btnConsultarArticulo);
            Controls.Add(btnConsultarTipoArticulo);
            Controls.Add(btnRegistrarPedido);
            Controls.Add(btnRegistrarRepartidor);
            Controls.Add(btnRegistrarCliente);
            Controls.Add(btnRegistrarArticulo);
            Controls.Add(btnRegistrarTipoArticulo);
            Controls.Add(lblTitulo);
            Name = "FrmMenuPrincipal";
            Text = "Form1";
            Load += FrmMenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnConsultarRepartidor_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblTitulo;
        private Button btnRegistrarTipoArticulo;
        private Button btnRegistrarArticulo;
        private Button btnRegistrarCliente;
        private Button btnRegistrarRepartidor;
        private Button btnRegistrarPedido;
        private Button btnConsultarTipoArticulo;
        private Button btnConsultarArticulo;
        private Button btnConsultarCliente;
        private Button btnConsultarRepartidor;
        private Button btnConsultarPedido;
        private Button btnSalir;
        private Label lblNombreCliente;
    }
}