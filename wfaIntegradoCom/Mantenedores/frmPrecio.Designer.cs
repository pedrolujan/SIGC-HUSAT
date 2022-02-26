namespace wfaIntegradoCom.Mantenedores
{
    partial class frmPrecio
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrecio));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPrecioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUnidaMedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precioBindingSource)).BeginInit();
            this.tsBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPrecioDataGridViewTextBoxColumn,
            this.idProductoDataGridViewTextBoxColumn,
            this.intIdUnidaMedidaDataGridViewTextBoxColumn,
            this.strDescripcionDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.PrecioActual});
            this.dataGridView1.DataSource = this.precioBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(588, 198);
            this.dataGridView1.TabIndex = 85;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // idPrecioDataGridViewTextBoxColumn
            // 
            this.idPrecioDataGridViewTextBoxColumn.DataPropertyName = "idPrecio";
            this.idPrecioDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.idPrecioDataGridViewTextBoxColumn.Name = "idPrecioDataGridViewTextBoxColumn";
            this.idPrecioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPrecioDataGridViewTextBoxColumn.Width = 70;
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "idProducto";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "Codigo de Producto";
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProductoDataGridViewTextBoxColumn.Width = 70;
            // 
            // intIdUnidaMedidaDataGridViewTextBoxColumn
            // 
            this.intIdUnidaMedidaDataGridViewTextBoxColumn.DataPropertyName = "intIdUnidaMedida";
            this.intIdUnidaMedidaDataGridViewTextBoxColumn.HeaderText = "intIdUnidaMedida";
            this.intIdUnidaMedidaDataGridViewTextBoxColumn.Name = "intIdUnidaMedidaDataGridViewTextBoxColumn";
            this.intIdUnidaMedidaDataGridViewTextBoxColumn.Visible = false;
            // 
            // strDescripcionDataGridViewTextBoxColumn
            // 
            this.strDescripcionDataGridViewTextBoxColumn.DataPropertyName = "strDescripcion";
            this.strDescripcionDataGridViewTextBoxColumn.FillWeight = 10F;
            this.strDescripcionDataGridViewTextBoxColumn.HeaderText = "Producto x UM";
            this.strDescripcionDataGridViewTextBoxColumn.Name = "strDescripcionDataGridViewTextBoxColumn";
            this.strDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.strDescripcionDataGridViewTextBoxColumn.Width = 230;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Nuevo Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.Width = 80;
            // 
            // PrecioActual
            // 
            this.PrecioActual.DataPropertyName = "PrecioActual";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PrecioActual.DefaultCellStyle = dataGridViewCellStyle1;
            this.PrecioActual.HeaderText = "Precio Actual";
            this.PrecioActual.Name = "PrecioActual";
            this.PrecioActual.ReadOnly = true;
            this.PrecioActual.Width = 80;
            // 
            // precioBindingSource
            // 
            this.precioBindingSource.DataSource = typeof(CapaEntidad.Precio);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.MidnightBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(589, 23);
            this.label9.TabIndex = 84;
            this.label9.Text = "Lista de Precios por Unidad de Medida";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardar,
            this.toolStripSeparator2,
            this.tsbSalir});
            this.tsBotonera.Location = new System.Drawing.Point(237, 236);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(95, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 86;
            this.tsBotonera.TabStop = true;
            this.tsBotonera.Text = "toolStrip1";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardar.Image")));
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(53, 35);
            this.tsbGuardar.Text = "&Guardar";
            this.tsbGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(33, 35);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.ToolTipText = "Salir de Formulario";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // frmPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 283);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Precio por Producto y Unidad de Medida";
            this.Load += new System.EventHandler(this.frmPrecio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precioBindingSource)).EndInit();
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource precioBindingSource;
        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrecioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUnidaMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn strDescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioActual;
    }
}