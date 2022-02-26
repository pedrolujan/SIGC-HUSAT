namespace wfaIntegradoCom.Procesos
{
    partial class frmRegistroAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroAlmacen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.tsbGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.txtNombreAlmacen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.dgvListadoAlmacen = new System.Windows.Forms.DataGridView();
            this.idAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoAlmacen = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.Location = new System.Drawing.Point(164, 108);
            this.rbInactivo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbInactivo.TabIndex = 27;
            this.rbInactivo.Text = "Inactivo";
            this.rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Checked = true;
            this.rbActivo.Location = new System.Drawing.Point(101, 108);
            this.rbActivo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(55, 17);
            this.rbActivo.TabIndex = 26;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Estado";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.toolStrip6);
            this.groupBox5.Location = new System.Drawing.Point(399, 35);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(106, 82);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            // 
            // toolStrip6
            // 
            this.toolStrip6.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGrabar,
            this.tsbCancelar});
            this.toolStrip6.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip6.Location = new System.Drawing.Point(4, 16);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(98, 64);
            this.toolStrip6.Stretch = true;
            this.toolStrip6.TabIndex = 0;
            // 
            // tsbGrabar
            // 
            this.tsbGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.tsbGrabar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGrabar.Image")));
            this.tsbGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGrabar.Name = "tsbGrabar";
            this.tsbGrabar.Size = new System.Drawing.Size(96, 28);
            this.tsbGrabar.Text = "Guardar";
            this.tsbGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbGrabar.Click += new System.EventHandler(this.tsbGrabar_Click);
            // 
            // tsbCancelar
            // 
            this.tsbCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.tsbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelar.Image")));
            this.tsbCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(96, 28);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
            // 
            // txtNombreAlmacen
            // 
            this.txtNombreAlmacen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNombreAlmacen.Location = new System.Drawing.Point(102, 61);
            this.txtNombreAlmacen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreAlmacen.Name = "txtNombreAlmacen";
            this.txtNombreAlmacen.Size = new System.Drawing.Size(290, 20);
            this.txtNombreAlmacen.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Descripción de Almacén";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Sucursal";
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(102, 81);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(215, 21);
            this.cboSucursal.TabIndex = 28;
            // 
            // dgvListadoAlmacen
            // 
            this.dgvListadoAlmacen.AllowUserToAddRows = false;
            this.dgvListadoAlmacen.AllowUserToDeleteRows = false;
            this.dgvListadoAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAlmacen,
            this.cNomAlmacen,
            this.cNombreSucursal,
            this.bEstado,
            this.idSucursal});
            this.dgvListadoAlmacen.Location = new System.Drawing.Point(14, 131);
            this.dgvListadoAlmacen.Name = "dgvListadoAlmacen";
            this.dgvListadoAlmacen.Size = new System.Drawing.Size(495, 121);
            this.dgvListadoAlmacen.TabIndex = 29;
            this.dgvListadoAlmacen.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoAlmacen_CellDoubleClick);
            // 
            // idAlmacen
            // 
            this.idAlmacen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idAlmacen.DataPropertyName = "idAlmacen";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.idAlmacen.DefaultCellStyle = dataGridViewCellStyle1;
            this.idAlmacen.HeaderText = "Codigo Almacen";
            this.idAlmacen.Name = "idAlmacen";
            this.idAlmacen.ReadOnly = true;
            // 
            // cNomAlmacen
            // 
            this.cNomAlmacen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNomAlmacen.DataPropertyName = "cNomAlmacen";
            this.cNomAlmacen.HeaderText = "Nombre Almacen";
            this.cNomAlmacen.Name = "cNomAlmacen";
            this.cNomAlmacen.ReadOnly = true;
            this.cNomAlmacen.Width = 104;
            // 
            // cNombreSucursal
            // 
            this.cNombreSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombreSucursal.DataPropertyName = "cNombreSucursal";
            this.cNombreSucursal.HeaderText = "Nombre Sucursal";
            this.cNombreSucursal.Name = "cNombreSucursal";
            this.cNombreSucursal.ReadOnly = true;
            this.cNombreSucursal.Width = 104;
            // 
            // bEstado
            // 
            this.bEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bEstado.DataPropertyName = "bEstado";
            this.bEstado.HeaderText = "Estado";
            this.bEstado.Name = "bEstado";
            this.bEstado.ReadOnly = true;
            this.bEstado.Width = 65;
            // 
            // idSucursal
            // 
            this.idSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idSucursal.DataPropertyName = "idSucursal";
            this.idSucursal.HeaderText = "idSucursal";
            this.idSucursal.Name = "idSucursal";
            this.idSucursal.ReadOnly = true;
            this.idSucursal.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Codigo Almacen";
            // 
            // txtCodigoAlmacen
            // 
            this.txtCodigoAlmacen.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodigoAlmacen.Enabled = false;
            this.txtCodigoAlmacen.Location = new System.Drawing.Point(102, 39);
            this.txtCodigoAlmacen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoAlmacen.Name = "txtCodigoAlmacen";
            this.txtCodigoAlmacen.Size = new System.Drawing.Size(93, 20);
            this.txtCodigoAlmacen.TabIndex = 23;
            // 
            // frmRegistroAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 257);
            this.Controls.Add(this.dgvListadoAlmacen);
            this.Controls.Add(this.cboSucursal);
            this.Controls.Add(this.rbInactivo);
            this.Controls.Add(this.rbActivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtCodigoAlmacen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreAlmacen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRegistroAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Almacén";
            this.Load += new System.EventHandler(this.frmRegistroAlmacen_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoAlmacen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton tsbGrabar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        private System.Windows.Forms.TextBox txtNombreAlmacen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.DataGridView dgvListadoAlmacen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn bEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSucursal;
    }
}