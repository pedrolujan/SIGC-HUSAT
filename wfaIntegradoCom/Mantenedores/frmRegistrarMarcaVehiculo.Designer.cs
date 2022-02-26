namespace wfaIntegradoCom.Mantenedores
{
    partial class frmRegistrarMarcaVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarMarcaVehiculo));
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.epVehiculo = new System.Windows.Forms.ErrorProvider(this.components);
            this.lvMarca = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBuscarMarca = new System.Windows.Forms.TextBox();
            this.gbBuscarMarca = new System.Windows.Forms.GroupBox();
            this.rbNomMarca = new System.Windows.Forms.RadioButton();
            this.rbCodigoMarca = new System.Windows.Forms.RadioButton();
            this.gbMarca = new System.Windows.Forms.GroupBox();
            this.txtMarca2 = new System.Windows.Forms.TextBox();
            this.pbMarca = new System.Windows.Forms.PictureBox();
            this.lblCboMarca = new System.Windows.Forms.Label();
            this.pbClase = new System.Windows.Forms.PictureBox();
            this.lblCboClase = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboClaseV = new System.Windows.Forms.ComboBox();
            this.chkEstadoMarca = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodMarca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.blResulBusqueda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVehiculo)).BeginInit();
            this.gbBuscarMarca.SuspendLayout();
            this.gbMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClase)).BeginInit();
            this.tsBotonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // epControlOk
            // 
            this.epControlOk.BlinkRate = 0;
            this.epControlOk.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epControlOk.ContainerControl = this;
            this.epControlOk.Icon = ((System.Drawing.Icon)(resources.GetObject("epControlOk.Icon")));
            // 
            // epVehiculo
            // 
            this.epVehiculo.ContainerControl = this;
            // 
            // lvMarca
            // 
            this.lvMarca.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader6});
            this.lvMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMarca.FullRowSelect = true;
            this.lvMarca.GridLines = true;
            this.lvMarca.HideSelection = false;
            this.lvMarca.Location = new System.Drawing.Point(123, 61);
            this.lvMarca.MultiSelect = false;
            this.lvMarca.Name = "lvMarca";
            this.lvMarca.Size = new System.Drawing.Size(382, 78);
            this.lvMarca.TabIndex = 20;
            this.lvMarca.UseCompatibleStateImageBehavior = false;
            this.lvMarca.View = System.Windows.Forms.View.Details;
            this.lvMarca.Visible = false;
            this.lvMarca.DoubleClick += new System.EventHandler(this.lvMarca_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Codigo";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Marca";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Clase";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Estado";
            // 
            // txtBuscarMarca
            // 
            this.txtBuscarMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarMarca.Location = new System.Drawing.Point(123, 41);
            this.txtBuscarMarca.Name = "txtBuscarMarca";
            this.txtBuscarMarca.Size = new System.Drawing.Size(382, 22);
            this.txtBuscarMarca.TabIndex = 16;
            this.txtBuscarMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarMarca_KeyPress);
            // 
            // gbBuscarMarca
            // 
            this.gbBuscarMarca.Controls.Add(this.rbNomMarca);
            this.gbBuscarMarca.Controls.Add(this.rbCodigoMarca);
            this.gbBuscarMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscarMarca.Location = new System.Drawing.Point(19, 34);
            this.gbBuscarMarca.Name = "gbBuscarMarca";
            this.gbBuscarMarca.Size = new System.Drawing.Size(98, 82);
            this.gbBuscarMarca.TabIndex = 18;
            this.gbBuscarMarca.TabStop = false;
            this.gbBuscarMarca.Text = "Buscar por:";
            // 
            // rbNomMarca
            // 
            this.rbNomMarca.AutoSize = true;
            this.rbNomMarca.Checked = true;
            this.rbNomMarca.Location = new System.Drawing.Point(6, 21);
            this.rbNomMarca.Name = "rbNomMarca";
            this.rbNomMarca.Size = new System.Drawing.Size(75, 20);
            this.rbNomMarca.TabIndex = 16;
            this.rbNomMarca.TabStop = true;
            this.rbNomMarca.Text = "Nombre";
            this.rbNomMarca.UseVisualStyleBackColor = true;
            // 
            // rbCodigoMarca
            // 
            this.rbCodigoMarca.AutoSize = true;
            this.rbCodigoMarca.Location = new System.Drawing.Point(6, 47);
            this.rbCodigoMarca.Name = "rbCodigoMarca";
            this.rbCodigoMarca.Size = new System.Drawing.Size(70, 20);
            this.rbCodigoMarca.TabIndex = 15;
            this.rbCodigoMarca.Text = "Código";
            this.rbCodigoMarca.UseVisualStyleBackColor = true;
            // 
            // gbMarca
            // 
            this.gbMarca.Controls.Add(this.txtMarca2);
            this.gbMarca.Controls.Add(this.pbMarca);
            this.gbMarca.Controls.Add(this.lblCboMarca);
            this.gbMarca.Controls.Add(this.pbClase);
            this.gbMarca.Controls.Add(this.lblCboClase);
            this.gbMarca.Controls.Add(this.label1);
            this.gbMarca.Controls.Add(this.cboClaseV);
            this.gbMarca.Controls.Add(this.chkEstadoMarca);
            this.gbMarca.Controls.Add(this.label13);
            this.gbMarca.Controls.Add(this.txtMarca);
            this.gbMarca.Controls.Add(this.label2);
            this.gbMarca.Controls.Add(this.txtCodMarca);
            this.gbMarca.Controls.Add(this.label3);
            this.gbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMarca.Location = new System.Drawing.Point(19, 122);
            this.gbMarca.Name = "gbMarca";
            this.gbMarca.Size = new System.Drawing.Size(486, 181);
            this.gbMarca.TabIndex = 12;
            this.gbMarca.TabStop = false;
            // 
            // txtMarca2
            // 
            this.txtMarca2.Location = new System.Drawing.Point(159, 61);
            this.txtMarca2.Name = "txtMarca2";
            this.txtMarca2.Size = new System.Drawing.Size(100, 22);
            this.txtMarca2.TabIndex = 84;
            this.txtMarca2.Visible = false;
            // 
            // pbMarca
            // 
            this.pbMarca.BackColor = System.Drawing.SystemColors.Control;
            this.pbMarca.Location = new System.Drawing.Point(372, 108);
            this.pbMarca.Name = "pbMarca";
            this.pbMarca.Size = new System.Drawing.Size(20, 20);
            this.pbMarca.TabIndex = 83;
            this.pbMarca.TabStop = false;
            // 
            // lblCboMarca
            // 
            this.lblCboMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCboMarca.ForeColor = System.Drawing.Color.Red;
            this.lblCboMarca.Location = new System.Drawing.Point(94, 132);
            this.lblCboMarca.Name = "lblCboMarca";
            this.lblCboMarca.Size = new System.Drawing.Size(272, 46);
            this.lblCboMarca.TabIndex = 82;
            this.lblCboMarca.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbClase
            // 
            this.pbClase.BackColor = System.Drawing.SystemColors.Control;
            this.pbClase.Location = new System.Drawing.Point(372, 35);
            this.pbClase.Name = "pbClase";
            this.pbClase.Size = new System.Drawing.Size(20, 20);
            this.pbClase.TabIndex = 81;
            this.pbClase.TabStop = false;
            // 
            // lblCboClase
            // 
            this.lblCboClase.AutoSize = true;
            this.lblCboClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCboClase.ForeColor = System.Drawing.Color.Red;
            this.lblCboClase.Location = new System.Drawing.Point(16, 59);
            this.lblCboClase.Name = "lblCboClase";
            this.lblCboClase.Size = new System.Drawing.Size(0, 13);
            this.lblCboClase.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Clase (*)";
            // 
            // cboClaseV
            // 
            this.cboClaseV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClaseV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClaseV.FormattingEnabled = true;
            this.cboClaseV.Location = new System.Drawing.Point(11, 34);
            this.cboClaseV.Name = "cboClaseV";
            this.cboClaseV.Size = new System.Drawing.Size(355, 23);
            this.cboClaseV.TabIndex = 15;
            this.cboClaseV.SelectedIndexChanged += new System.EventHandler(this.cboClaseV_SelectedIndexChanged);
            // 
            // chkEstadoMarca
            // 
            this.chkEstadoMarca.AutoSize = true;
            this.chkEstadoMarca.Checked = true;
            this.chkEstadoMarca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstadoMarca.Location = new System.Drawing.Point(408, 111);
            this.chkEstadoMarca.Name = "chkEstadoMarca";
            this.chkEstadoMarca.Size = new System.Drawing.Size(64, 20);
            this.chkEstadoMarca.TabIndex = 14;
            this.chkEstadoMarca.Text = "Activo";
            this.chkEstadoMarca.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(405, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "Estado";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(94, 108);
            this.txtMarca.MaxLength = 45;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(272, 22);
            this.txtMarca.TabIndex = 10;
            this.txtMarca.TextChanged += new System.EventHandler(this.txtMarca_TextChanged);
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarca_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Codigo:";
            // 
            // txtCodMarca
            // 
            this.txtCodMarca.Enabled = false;
            this.txtCodMarca.Location = new System.Drawing.Point(11, 108);
            this.txtCodMarca.Name = "txtCodMarca";
            this.txtCodMarca.ReadOnly = true;
            this.txtCodMarca.Size = new System.Drawing.Size(68, 22);
            this.txtCodMarca.TabIndex = 8;
            this.txtCodMarca.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Marca (*)";
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.toolStripSeparator1,
            this.saveToolStripButton,
            this.toolStripSeparator2,
            this.tsSalir});
            this.tsBotonera.Location = new System.Drawing.Point(178, 315);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(147, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 11;
            this.tsBotonera.TabStop = true;
            this.tsBotonera.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(46, 35);
            this.newToolStripButton.Text = "&Nuevo";
            this.newToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(53, 35);
            this.saveToolStripButton.Text = "&Guardar";
            this.saveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tsSalir
            // 
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(33, 35);
            this.tsSalir.Text = "Salir";
            this.tsSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSalir.ToolTipText = "Salir de Formulario";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // blResulBusqueda
            // 
            this.blResulBusqueda.Location = new System.Drawing.Point(192, 18);
            this.blResulBusqueda.Name = "blResulBusqueda";
            this.blResulBusqueda.Size = new System.Drawing.Size(313, 20);
            this.blResulBusqueda.TabIndex = 90;
            this.blResulBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmRegistrarMarcaVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 362);
            this.Controls.Add(this.blResulBusqueda);
            this.Controls.Add(this.lvMarca);
            this.Controls.Add(this.txtBuscarMarca);
            this.Controls.Add(this.gbBuscarMarca);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.gbMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarMarcaVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRAR MARCA DE VEHICULO";
            this.Load += new System.EventHandler(this.frmRegistrarAttrVehiculo_Load);
            this.Click += new System.EventHandler(this.frmRegistrarMarcaVehiculo_Click);
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVehiculo)).EndInit();
            this.gbBuscarMarca.ResumeLayout(false);
            this.gbBuscarMarca.PerformLayout();
            this.gbMarca.ResumeLayout(false);
            this.gbMarca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClase)).EndInit();
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epControlOk;
        private System.Windows.Forms.ErrorProvider epVehiculo;
        private System.Windows.Forms.ListView lvMarca;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtBuscarMarca;
        private System.Windows.Forms.GroupBox gbBuscarMarca;
        private System.Windows.Forms.RadioButton rbNomMarca;
        private System.Windows.Forms.RadioButton rbCodigoMarca;
        private System.Windows.Forms.GroupBox gbMarca;
        private System.Windows.Forms.CheckBox chkEstadoMarca;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClaseV;
        private System.Windows.Forms.PictureBox pbClase;
        private System.Windows.Forms.Label lblCboClase;
        private System.Windows.Forms.PictureBox pbMarca;
        private System.Windows.Forms.Label lblCboMarca;
        private System.Windows.Forms.TextBox txtMarca2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label blResulBusqueda;
    }
}