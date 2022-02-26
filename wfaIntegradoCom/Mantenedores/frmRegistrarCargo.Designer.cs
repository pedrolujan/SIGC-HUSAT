namespace wfaIntegradoCom.Mantenedores
{
    partial class frmRegistrarCargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarCargo));
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.gbUsuario = new System.Windows.Forms.GroupBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtIdCargo = new System.Windows.Forms.TextBox();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.dgvCargo = new System.Windows.Forms.DataGridView();
            this.cCodTabDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomTabDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEstadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.epUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.epControlOk = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsBotonera.SuspendLayout();
            this.gbUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).BeginInit();
            this.SuspendLayout();
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
            this.tsBotonera.Location = new System.Drawing.Point(129, 318);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(147, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 5;
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
            // gbUsuario
            // 
            this.gbUsuario.Controls.Add(this.chkEstado);
            this.gbUsuario.Controls.Add(this.label1);
            this.gbUsuario.Controls.Add(this.txtCargo);
            this.gbUsuario.Controls.Add(this.lblUsuario);
            this.gbUsuario.Controls.Add(this.txtIdCargo);
            this.gbUsuario.Controls.Add(this.lblIdUsuario);
            this.gbUsuario.Location = new System.Drawing.Point(23, 226);
            this.gbUsuario.Name = "gbUsuario";
            this.gbUsuario.Size = new System.Drawing.Size(403, 79);
            this.gbUsuario.TabIndex = 4;
            this.gbUsuario.TabStop = false;
            this.gbUsuario.Text = "Datos de Usuario";
            this.gbUsuario.Enter += new System.EventHandler(this.gbUsuario_Enter);
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(314, 40);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 7;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCargo
            // 
            this.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCargo.Location = new System.Drawing.Point(112, 38);
            this.txtCargo.MaxLength = 100;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(172, 20);
            this.txtCargo.TabIndex = 3;
            this.txtCargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCargo_KeyPress);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(109, 22);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(93, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Nombre de Cargo:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIdCargo
            // 
            this.txtIdCargo.Location = new System.Drawing.Point(28, 38);
            this.txtIdCargo.Name = "txtIdCargo";
            this.txtIdCargo.ReadOnly = true;
            this.txtIdCargo.Size = new System.Drawing.Size(58, 20);
            this.txtIdCargo.TabIndex = 1;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(25, 22);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(50, 13);
            this.lblIdUsuario.TabIndex = 0;
            this.lblIdUsuario.Text = "Id. Cargo";
            this.lblIdUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvCargo
            // 
            this.dgvCargo.AllowUserToAddRows = false;
            this.dgvCargo.AllowUserToDeleteRows = false;
            this.dgvCargo.AllowUserToResizeColumns = false;
            this.dgvCargo.AllowUserToResizeRows = false;
            this.dgvCargo.AutoGenerateColumns = false;
            this.dgvCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCodTabDataGridViewTextBoxColumn,
            this.cNomTabDataGridViewTextBoxColumn,
            this.bEstadoDataGridViewCheckBoxColumn});
            this.dgvCargo.DataSource = this.cargoBindingSource;
            this.dgvCargo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCargo.Location = new System.Drawing.Point(23, 15);
            this.dgvCargo.MultiSelect = false;
            this.dgvCargo.Name = "dgvCargo";
            this.dgvCargo.ReadOnly = true;
            this.dgvCargo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCargo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargo.Size = new System.Drawing.Size(403, 205);
            this.dgvCargo.TabIndex = 3;
            this.dgvCargo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargo_CellDoubleClick);
            this.dgvCargo.SelectionChanged += new System.EventHandler(this.dgvCargo_SelectionChanged);
            // 
            // cCodTabDataGridViewTextBoxColumn
            // 
            this.cCodTabDataGridViewTextBoxColumn.DataPropertyName = "cCodTab";
            this.cCodTabDataGridViewTextBoxColumn.HeaderText = "Código";
            this.cCodTabDataGridViewTextBoxColumn.Name = "cCodTabDataGridViewTextBoxColumn";
            this.cCodTabDataGridViewTextBoxColumn.ReadOnly = true;
            this.cCodTabDataGridViewTextBoxColumn.Width = 80;
            // 
            // cNomTabDataGridViewTextBoxColumn
            // 
            this.cNomTabDataGridViewTextBoxColumn.DataPropertyName = "cNomTab";
            this.cNomTabDataGridViewTextBoxColumn.HeaderText = "Cargo";
            this.cNomTabDataGridViewTextBoxColumn.Name = "cNomTabDataGridViewTextBoxColumn";
            this.cNomTabDataGridViewTextBoxColumn.ReadOnly = true;
            this.cNomTabDataGridViewTextBoxColumn.Width = 220;
            // 
            // bEstadoDataGridViewCheckBoxColumn
            // 
            this.bEstadoDataGridViewCheckBoxColumn.DataPropertyName = "bEstado";
            this.bEstadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            this.bEstadoDataGridViewCheckBoxColumn.Name = "bEstadoDataGridViewCheckBoxColumn";
            this.bEstadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.bEstadoDataGridViewCheckBoxColumn.Width = 60;
            // 
            // cargoBindingSource
            // 
            this.cargoBindingSource.DataSource = typeof(CapaEntidad.Cargo);
            // 
            // epUsuario
            // 
            this.epUsuario.ContainerControl = this;
            // 
            // epControlOk
            // 
            this.epControlOk.BlinkRate = 0;
            this.epControlOk.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epControlOk.ContainerControl = this;
            this.epControlOk.Icon = ((System.Drawing.Icon)(resources.GetObject("epControlOk.Icon")));
            // 
            // frmRegistrarCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 365);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.gbUsuario);
            this.Controls.Add(this.dgvCargo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Cargo";
            this.Load += new System.EventHandler(this.frmRegistrarCargo_Load);
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.gbUsuario.ResumeLayout(false);
            this.gbUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epControlOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.GroupBox gbUsuario;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtIdCargo;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.DataGridView dgvCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodTabDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomTabDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bEstadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource cargoBindingSource;
        private System.Windows.Forms.ErrorProvider epUsuario;
        private System.Windows.Forms.ErrorProvider epControlOk;
    }
}