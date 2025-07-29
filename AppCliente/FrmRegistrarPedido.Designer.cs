namespace AppCliente
{
    partial class FrmRegistrarPedido
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
            lblNumeroPedido = new Label();
            txtNumeroPedido = new TextBox();
            lblFechaPedido = new Label();
            dtpFechaPedido = new DateTimePicker();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            lblRepartidor = new Label();
            cmbRepartidor = new ComboBox();
            lblEntrega = new Label();
            txtDireccion = new TextBox();
            lblArticulo = new Label();
            cmbArticulo = new ComboBox();
            label1 = new Label();
            txtCantidad = new TextBox();
            btnAgregarArticulo = new Button();
            dgvDetallePedido = new DataGridView();
            IDArticulo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            TipoArticulo = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            btnGuardarPedido = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).BeginInit();
            SuspendLayout();
            // 
            // lblNumeroPedido
            // 
            lblNumeroPedido.AutoSize = true;
            lblNumeroPedido.Location = new Point(73, 67);
            lblNumeroPedido.Name = "lblNumeroPedido";
            lblNumeroPedido.Size = new Size(83, 25);
            lblNumeroPedido.TabIndex = 0;
            lblNumeroPedido.Text = "Pedido #";
            // 
            // txtNumeroPedido
            // 
            txtNumeroPedido.Location = new Point(162, 62);
            txtNumeroPedido.Name = "txtNumeroPedido";
            txtNumeroPedido.Size = new Size(150, 31);
            txtNumeroPedido.TabIndex = 1;
            // 
            // lblFechaPedido
            // 
            lblFechaPedido.AutoSize = true;
            lblFechaPedido.Location = new Point(333, 65);
            lblFechaPedido.Name = "lblFechaPedido";
            lblFechaPedido.Size = new Size(150, 25);
            lblFechaPedido.TabIndex = 2;
            lblFechaPedido.Text = "Fecha del Pedido:";
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(479, 62);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(300, 31);
            dtpFechaPedido.TabIndex = 3;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(804, 67);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(69, 25);
            lblCliente.TabIndex = 4;
            lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(879, 62);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(182, 33);
            cmbCliente.TabIndex = 5;
            // 
            // lblRepartidor
            // 
            lblRepartidor.AutoSize = true;
            lblRepartidor.Location = new Point(1088, 65);
            lblRepartidor.Name = "lblRepartidor";
            lblRepartidor.Size = new Size(99, 25);
            lblRepartidor.TabIndex = 6;
            lblRepartidor.Text = "Repartidor:";
            // 
            // cmbRepartidor
            // 
            cmbRepartidor.FormattingEnabled = true;
            cmbRepartidor.Location = new Point(1193, 62);
            cmbRepartidor.Name = "cmbRepartidor";
            cmbRepartidor.Size = new Size(182, 33);
            cmbRepartidor.TabIndex = 7;
            // 
            // lblEntrega
            // 
            lblEntrega.AutoSize = true;
            lblEntrega.Location = new Point(1401, 64);
            lblEntrega.Name = "lblEntrega";
            lblEntrega.Size = new Size(175, 25);
            lblEntrega.TabIndex = 8;
            lblEntrega.Text = "Direccion de Entrega";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(1582, 62);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(409, 31);
            txtDireccion.TabIndex = 9;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Location = new Point(445, 203);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(77, 25);
            lblArticulo.TabIndex = 10;
            lblArticulo.Text = "Artículo:";
            // 
            // cmbArticulo
            // 
            cmbArticulo.FormattingEnabled = true;
            cmbArticulo.Location = new Point(540, 200);
            cmbArticulo.Name = "cmbArticulo";
            cmbArticulo.Size = new Size(182, 33);
            cmbArticulo.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(786, 203);
            label1.Name = "label1";
            label1.Size = new Size(87, 25);
            label1.TabIndex = 12;
            label1.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(888, 200);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(150, 31);
            txtCantidad.TabIndex = 13;
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.Location = new Point(1133, 198);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(242, 35);
            btnAgregarArticulo.TabIndex = 14;
            btnAgregarArticulo.Text = "AGREGAR ARTICULO";
            btnAgregarArticulo.UseVisualStyleBackColor = true;
            // 
            // dgvDetallePedido
            // 
            dgvDetallePedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallePedido.Columns.AddRange(new DataGridViewColumn[] { IDArticulo, Nombre, TipoArticulo, Cantidad, Monto });
            dgvDetallePedido.Location = new Point(581, 293);
            dgvDetallePedido.Name = "dgvDetallePedido";
            dgvDetallePedido.RowHeadersWidth = 62;
            dgvDetallePedido.Size = new Size(775, 251);
            dgvDetallePedido.TabIndex = 15;
            // 
            // IDArticulo
            // 
            IDArticulo.HeaderText = "ID Artículo";
            IDArticulo.MinimumWidth = 8;
            IDArticulo.Name = "IDArticulo";
            IDArticulo.Width = 150;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 8;
            Nombre.Name = "Nombre";
            Nombre.Width = 150;
            // 
            // TipoArticulo
            // 
            TipoArticulo.HeaderText = "Tipo Artículo";
            TipoArticulo.MinimumWidth = 8;
            TipoArticulo.Name = "TipoArticulo";
            TipoArticulo.Width = 150;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 8;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 150;
            // 
            // Monto
            // 
            Monto.HeaderText = "Monto";
            Monto.MinimumWidth = 8;
            Monto.Name = "Monto";
            Monto.Width = 150;
            // 
            // btnGuardarPedido
            // 
            btnGuardarPedido.Location = new Point(384, 609);
            btnGuardarPedido.Name = "btnGuardarPedido";
            btnGuardarPedido.Size = new Size(254, 106);
            btnGuardarPedido.TabIndex = 16;
            btnGuardarPedido.Text = "GUARDAR PEDIDO";
            btnGuardarPedido.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(1250, 609);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(259, 106);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FrmRegistrarPedido
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2048, 785);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardarPedido);
            Controls.Add(dgvDetallePedido);
            Controls.Add(btnAgregarArticulo);
            Controls.Add(txtCantidad);
            Controls.Add(label1);
            Controls.Add(cmbArticulo);
            Controls.Add(lblArticulo);
            Controls.Add(txtDireccion);
            Controls.Add(lblEntrega);
            Controls.Add(cmbRepartidor);
            Controls.Add(lblRepartidor);
            Controls.Add(cmbCliente);
            Controls.Add(lblCliente);
            Controls.Add(dtpFechaPedido);
            Controls.Add(lblFechaPedido);
            Controls.Add(txtNumeroPedido);
            Controls.Add(lblNumeroPedido);
            Name = "FrmRegistrarPedido";
            Text = "Form1";
            Load += FrmRegistrarPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumeroPedido;
        private TextBox txtNumeroPedido;
        private Label lblFechaPedido;
        private DateTimePicker dtpFechaPedido;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblRepartidor;
        private ComboBox cmbRepartidor;
        private Label lblEntrega;
        private TextBox txtDireccion;
        private Label lblArticulo;
        private ComboBox cmbArticulo;
        private Label label1;
        private TextBox txtCantidad;
        private Button btnAgregarArticulo;
        private DataGridView dgvDetallePedido;
        private DataGridViewTextBoxColumn IDArticulo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn TipoArticulo;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Monto;
        private Button btnGuardarPedido;
        private Button btnLimpiar;
    }
}