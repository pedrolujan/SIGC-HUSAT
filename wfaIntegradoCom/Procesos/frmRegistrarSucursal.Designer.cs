namespace wfaIntegradoCom.Procesos
{
    partial class frmRegistrarSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarSucursal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.tsbGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListadoSucursal = new System.Windows.Forms.DataGridView();
            this.idSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomDist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDepa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoSucursal = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSucursal)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.toolStrip6);
            this.groupBox5.Location = new System.Drawing.Point(411, 89);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(94, 85);
            this.groupBox5.TabIndex = 17;
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
            this.toolStrip6.Size = new System.Drawing.Size(86, 64);
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
            this.tsbGrabar.Size = new System.Drawing.Size(84, 28);
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
            this.tsbCancelar.Size = new System.Drawing.Size(84, 28);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNombreSucursal.ForeColor = System.Drawing.Color.Black;
            this.txtNombreSucursal.Location = new System.Drawing.Point(94, 64);
            this.txtNombreSucursal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(411, 20);
            this.txtNombreSucursal.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
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
            this.label1.TabIndex = 11;
            this.label1.Text = "Descripción de Sucursal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.Location = new System.Drawing.Point(156, 89);
            this.rbInactivo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbInactivo.TabIndex = 20;
            this.rbInactivo.Text = "Inactivo";
            this.rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Checked = true;
            this.rbActivo.Location = new System.Drawing.Point(93, 89);
            this.rbActivo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(55, 17);
            this.rbActivo.TabIndex = 19;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Estado";
            // 
            // dgvListadoSucursal
            // 
            this.dgvListadoSucursal.AllowUserToAddRows = false;
            this.dgvListadoSucursal.AllowUserToDeleteRows = false;
            this.dgvListadoSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoSucursal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSucursal,
            this.cNombreSucursal,
            this.cNomDist,
            this.cNomProv,
            this.cNomDep,
            this.cDireccion,
            this.bEstado,
            this.idDist,
            this.idProv,
            this.idDepa});
            this.dgvListadoSucursal.Location = new System.Drawing.Point(15, 209);
            this.dgvListadoSucursal.Name = "dgvListadoSucursal";
            this.dgvListadoSucursal.Size = new System.Drawing.Size(491, 134);
            this.dgvListadoSucursal.TabIndex = 21;
            this.dgvListadoSucursal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoSucursal_CellDoubleClick);
            // 
            // idSucursal
            // 
            this.idSucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idSucursal.DataPropertyName = "idSucursal";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.idSucursal.DefaultCellStyle = dataGridViewCellStyle1;
            this.idSucursal.HeaderText = "Codigo Sucursal";
            this.idSucursal.Name = "idSucursal";
            this.idSucursal.ReadOnly = true;
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
            // cNomDist
            // 
            this.cNomDist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNomDist.DataPropertyName = "cNomDist";
            this.cNomDist.HeaderText = "Distrito";
            this.cNomDist.Name = "cNomDist";
            this.cNomDist.ReadOnly = true;
            this.cNomDist.Width = 64;
            // 
            // cNomProv
            // 
            this.cNomProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNomProv.DataPropertyName = "cNomProv";
            this.cNomProv.HeaderText = "Provincia";
            this.cNomProv.Name = "cNomProv";
            this.cNomProv.ReadOnly = true;
            this.cNomProv.Width = 76;
            // 
            // cNomDep
            // 
            this.cNomDep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNomDep.DataPropertyName = "cNomDep";
            this.cNomDep.HeaderText = "Departamento";
            this.cNomDep.Name = "cNomDep";
            this.cNomDep.ReadOnly = true;
            this.cNomDep.Width = 99;
            // 
            // cDireccion
            // 
            this.cDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDireccion.DataPropertyName = "cDireccion";
            this.cDireccion.HeaderText = "Direccion";
            this.cDireccion.Name = "cDireccion";
            this.cDireccion.ReadOnly = true;
            this.cDireccion.Width = 77;
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
            // idDist
            // 
            this.idDist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDist.DataPropertyName = "idDist";
            this.idDist.HeaderText = "idDist";
            this.idDist.Name = "idDist";
            this.idDist.ReadOnly = true;
            this.idDist.Visible = false;
            // 
            // idProv
            // 
            this.idProv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idProv.DataPropertyName = "idProv";
            this.idProv.HeaderText = "idProv";
            this.idProv.Name = "idProv";
            this.idProv.ReadOnly = true;
            this.idProv.Visible = false;
            // 
            // idDepa
            // 
            this.idDepa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDepa.DataPropertyName = "idDepa";
            this.idDepa.HeaderText = "idDepa";
            this.idDepa.Name = "idDepa";
            this.idDepa.ReadOnly = true;
            this.idDepa.Visible = false;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(93, 158);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(228, 21);
            this.cboDistrito.TabIndex = 15;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(94, 135);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(227, 21);
            this.cboProvincia.TabIndex = 14;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(94, 112);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(227, 21);
            this.cboDepartamento.TabIndex = 13;
            this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Distrito";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Provincia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Departamento";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Dirección";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtDireccion.Location = new System.Drawing.Point(93, 184);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(411, 20);
            this.txtDireccion.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Codigo Sucursal";
            // 
            // txtCodigoSucursal
            // 
            this.txtCodigoSucursal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodigoSucursal.Enabled = false;
            this.txtCodigoSucursal.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoSucursal.Location = new System.Drawing.Point(95, 40);
            this.txtCodigoSucursal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoSucursal.Name = "txtCodigoSucursal";
            this.txtCodigoSucursal.Size = new System.Drawing.Size(97, 20);
            this.txtCodigoSucursal.TabIndex = 14;
            // 
            // frmRegistrarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 350);
            this.Controls.Add(this.cboDistrito);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.cboDepartamento);
            this.Controls.Add(this.dgvListadoSucursal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rbInactivo);
            this.Controls.Add(this.rbActivo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCodigoSucursal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreSucursal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucursales";
            this.Load += new System.EventHandler(this.frmRegistrarSucursal_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoSucursal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton tsbGrabar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListadoSucursal;
        private System.Windows.Forms.ComboBox cboDistrito;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomDist;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn bEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDist;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDepa;
    }
}