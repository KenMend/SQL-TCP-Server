namespace AppCliente
{
    partial class FrmConsultarPedidos
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
            lblPedidos = new Label();
            dgvPedidos = new DataGridView();
            colNumeroPedido = new DataGridViewTextBoxColumn();
            colFechaPedido = new DataGridViewTextBoxColumn();
            colIdCliente = new DataGridViewTextBoxColumn();
            colNombreCliente = new DataGridViewTextBoxColumn();
            colPrimerApellido = new DataGridViewTextBoxColumn();
            colSegundoApellido = new DataGridViewTextBoxColumn();
            colIDRepartidor = new DataGridViewTextBoxColumn();
            colNombreRepartidor = new DataGridViewTextBoxColumn();
            colPrimerApellidoRepartidor = new DataGridViewTextBoxColumn();
            colSegundoApellidoRepartidor = new DataGridViewTextBoxColumn();
            colDireccionEntrega = new DataGridViewTextBoxColumn();
            dgvDetallePedido = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).BeginInit();
            SuspendLayout();
            // 
            // lblPedidos
            // 
            lblPedidos.AutoSize = true;
            lblPedidos.Location = new Point(780, 40);
            lblPedidos.Name = "lblPedidos";
            lblPedidos.Size = new Size(155, 25);
            lblPedidos.TabIndex = 0;
            lblPedidos.Text = "Consultar Pedidos";
            // 
            // dgvPedidos
            // 
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Columns.AddRange(new DataGridViewColumn[] { colNumeroPedido, colFechaPedido, colIdCliente, colNombreCliente, colPrimerApellido, colSegundoApellido, colIDRepartidor, colNombreRepartidor, colPrimerApellidoRepartidor, colSegundoApellidoRepartidor, colDireccionEntrega });
            dgvPedidos.Location = new Point(36, 79);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowHeadersWidth = 62;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(1714, 316);
            dgvPedidos.TabIndex = 1;
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            // 
            // colNumeroPedido
            // 
            colNumeroPedido.HeaderText = "Numero Pedido";
            colNumeroPedido.MinimumWidth = 8;
            colNumeroPedido.Name = "colNumeroPedido";
            colNumeroPedido.ReadOnly = true;
            colNumeroPedido.Width = 150;
            // 
            // colFechaPedido
            // 
            colFechaPedido.HeaderText = "Fecha Pedido";
            colFechaPedido.MinimumWidth = 8;
            colFechaPedido.Name = "colFechaPedido";
            colFechaPedido.ReadOnly = true;
            colFechaPedido.Width = 150;
            // 
            // colIdCliente
            // 
            colIdCliente.HeaderText = "Id Cliente";
            colIdCliente.MinimumWidth = 8;
            colIdCliente.Name = "colIdCliente";
            colIdCliente.ReadOnly = true;
            colIdCliente.Width = 150;
            // 
            // colNombreCliente
            // 
            colNombreCliente.HeaderText = "Nombre Cliente";
            colNombreCliente.MinimumWidth = 8;
            colNombreCliente.Name = "colNombreCliente";
            colNombreCliente.ReadOnly = true;
            colNombreCliente.Width = 150;
            // 
            // colPrimerApellido
            // 
            colPrimerApellido.HeaderText = "Primer Apellido";
            colPrimerApellido.MinimumWidth = 8;
            colPrimerApellido.Name = "colPrimerApellido";
            colPrimerApellido.ReadOnly = true;
            colPrimerApellido.Width = 150;
            // 
            // colSegundoApellido
            // 
            colSegundoApellido.HeaderText = "Segundo Apellido";
            colSegundoApellido.MinimumWidth = 8;
            colSegundoApellido.Name = "colSegundoApellido";
            colSegundoApellido.ReadOnly = true;
            colSegundoApellido.Width = 150;
            // 
            // colIDRepartidor
            // 
            colIDRepartidor.HeaderText = "Id Repartidor";
            colIDRepartidor.MinimumWidth = 8;
            colIDRepartidor.Name = "colIDRepartidor";
            colIDRepartidor.ReadOnly = true;
            colIDRepartidor.Width = 150;
            // 
            // colNombreRepartidor
            // 
            colNombreRepartidor.HeaderText = "Nombre Repartidor";
            colNombreRepartidor.MinimumWidth = 8;
            colNombreRepartidor.Name = "colNombreRepartidor";
            colNombreRepartidor.ReadOnly = true;
            colNombreRepartidor.Width = 150;
            // 
            // colPrimerApellidoRepartidor
            // 
            colPrimerApellidoRepartidor.HeaderText = "Primer Apellido Repartidor";
            colPrimerApellidoRepartidor.MinimumWidth = 8;
            colPrimerApellidoRepartidor.Name = "colPrimerApellidoRepartidor";
            colPrimerApellidoRepartidor.ReadOnly = true;
            colPrimerApellidoRepartidor.Width = 150;
            // 
            // colSegundoApellidoRepartidor
            // 
            colSegundoApellidoRepartidor.HeaderText = "Segundo Apellido Repartidor";
            colSegundoApellidoRepartidor.MinimumWidth = 8;
            colSegundoApellidoRepartidor.Name = "colSegundoApellidoRepartidor";
            colSegundoApellidoRepartidor.ReadOnly = true;
            colSegundoApellidoRepartidor.Width = 150;
            // 
            // colDireccionEntrega
            // 
            colDireccionEntrega.HeaderText = "Direccion Entrega";
            colDireccionEntrega.MinimumWidth = 8;
            colDireccionEntrega.Name = "colDireccionEntrega";
            colDireccionEntrega.ReadOnly = true;
            colDireccionEntrega.Width = 150;
            // 
            // dgvDetallePedido
            // 
            dgvDetallePedido.AllowUserToAddRows = false;
            dgvDetallePedido.AllowUserToDeleteRows = false;
            dgvDetallePedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallePedido.Location = new Point(443, 444);
            dgvDetallePedido.Name = "dgvDetallePedido";
            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.RowHeadersWidth = 62;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallePedido.Size = new Size(815, 285);
            dgvDetallePedido.TabIndex = 2;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(709, 764);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(238, 89);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "MENU PRINCIPAL";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmConsultarPedidos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1783, 906);
            Controls.Add(btnVolver);
            Controls.Add(dgvDetallePedido);
            Controls.Add(dgvPedidos);
            Controls.Add(lblPedidos);
            Name = "FrmConsultarPedidos";
            Text = "Form1";
            Load += FrmConsultarPedidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPedidos;
        private DataGridView dgvPedidos;
        private DataGridViewTextBoxColumn colNumeroPedido;
        private DataGridViewTextBoxColumn colFechaPedido;
        private DataGridViewTextBoxColumn colIdCliente;
        private DataGridViewTextBoxColumn colNombreCliente;
        private DataGridViewTextBoxColumn colPrimerApellido;
        private DataGridViewTextBoxColumn colSegundoApellido;
        private DataGridViewTextBoxColumn colIDRepartidor;
        private DataGridViewTextBoxColumn colNombreRepartidor;
        private DataGridViewTextBoxColumn colPrimerApellidoRepartidor;
        private DataGridViewTextBoxColumn colSegundoApellidoRepartidor;
        private DataGridViewTextBoxColumn colDireccionEntrega;
        private DataGridView dgvDetallePedido;
        private Button btnVolver;
    }
}