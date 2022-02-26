
namespace wfaIntegradoCom.Mantenedores
{
    partial class frmRegistrarPerioricidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarPerioricidad));
            this.lvPerio = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbBuscar = new System.Windows.Forms.GroupBox();
            this.rbNombrePerio = new System.Windows.Forms.RadioButton();
            this.tsBotonera = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.txtBuscarPerio = new System.Windows.Forms.TextBox();
            this.gbPerio = new System.Windows.Forms.GroupBox();
            this.imgPerio = new System.Windows.Forms.PictureBox();
            this.erPerio = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombrePerio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdPerio = new System.Windows.Forms.TextBox();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.gbBuscar.SuspendLayout();
            this.tsBotonera.SuspendLayout();
            this.gbPerio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPerio)).BeginInit();
            this.SuspendLayout();
            // 
            // lvPerio
            // 
            this.lvPerio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPerio.FullRowSelect = true;
            this.lvPerio.GridLines = true;
            this.lvPerio.HideSelection = false;
            this.lvPerio.Location = new System.Drawing.Point(183, 43);
            this.lvPerio.MultiSelect = false;
            this.lvPerio.Name = "lvPerio";
            this.lvPerio.Size = new System.Drawing.Size(518, 50);
            this.lvPerio.TabIndex = 29;
            this.lvPerio.UseCompatibleStateImageBehavior = false;
            this.lvPerio.View = System.Windows.Forms.View.Details;
            this.lvPerio.Visible = false;
            this.lvPerio.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPerio_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre Perioricidad";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Estado";
            this.columnHeader3.Width = 137;
            // 
            // gbBuscar
            // 
            this.gbBuscar.Controls.Add(this.rbNombrePerio);
            this.gbBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscar.Location = new System.Drawing.Point(16, 14);
            this.gbBuscar.Name = "gbBuscar";
            this.gbBuscar.Size = new System.Drawing.Size(161, 57);
            this.gbBuscar.TabIndex = 31;
            this.gbBuscar.TabStop = false;
            this.gbBuscar.Text = "Buscar por:";
            // 
            // rbNombrePerio
            // 
            this.rbNombrePerio.AutoSize = true;
            this.rbNombrePerio.Checked = true;
            this.rbNombrePerio.Location = new System.Drawing.Point(13, 23);
            this.rbNombrePerio.Name = "rbNombrePerio";
            this.rbNombrePerio.Size = new System.Drawing.Size(75, 20);
            this.rbNombrePerio.TabIndex = 1;
            this.rbNombrePerio.TabStop = true;
            this.rbNombrePerio.Text = "Nombre";
            this.rbNombrePerio.UseVisualStyleBackColor = true;
            // 
            // tsBotonera
            // 
            this.tsBotonera.BackColor = System.Drawing.SystemColors.Control;
            this.tsBotonera.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBotonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBotonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.toolStripEditar,
            this.toolStripSeparator1,
            this.saveToolStripButton,
            this.toolStripSeparator2,
            this.tsSalir});
            this.tsBotonera.Location = new System.Drawing.Point(281, 214);
            this.tsBotonera.Name = "tsBotonera";
            this.tsBotonera.Size = new System.Drawing.Size(188, 38);
            this.tsBotonera.Stretch = true;
            this.tsBotonera.TabIndex = 32;
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
            // toolStripEditar
            // 
            this.toolStripEditar.Image = global::wfaIntegradoCom.Properties.Resources.editar;
            this.toolStripEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEditar.Name = "toolStripEditar";
            this.toolStripEditar.Size = new System.Drawing.Size(41, 35);
            this.toolStripEditar.Text = "Editar";
            this.toolStripEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // txtBuscarPerio
            // 
            this.txtBuscarPerio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarPerio.Location = new System.Drawing.Point(183, 23);
            this.txtBuscarPerio.MaxLength = 20;
            this.txtBuscarPerio.Name = "txtBuscarPerio";
            this.txtBuscarPerio.Size = new System.Drawing.Size(518, 20);
            this.txtBuscarPerio.TabIndex = 28;
            this.txtBuscarPerio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarPerio_KeyPress);
            // 
            // gbPerio
            // 
            this.gbPerio.Controls.Add(this.imgPerio);
            this.gbPerio.Controls.Add(this.erPerio);
            this.gbPerio.Controls.Add(this.chkEstado);
            this.gbPerio.Controls.Add(this.label1);
            this.gbPerio.Controls.Add(this.txtNombrePerio);
            this.gbPerio.Controls.Add(this.label6);
            this.gbPerio.Controls.Add(this.txtIdPerio);
            this.gbPerio.Controls.Add(this.lblIdUsuario);
            this.gbPerio.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPerio.Location = new System.Drawing.Point(16, 91);
            this.gbPerio.Name = "gbPerio";
            this.gbPerio.Size = new System.Drawing.Size(685, 90);
            this.gbPerio.TabIndex = 30;
            this.gbPerio.TabStop = false;
            this.gbPerio.Text = "Datos Principales";
            // 
            // imgPerio
            // 
            this.imgPerio.BackColor = System.Drawing.Color.White;
            this.imgPerio.Location = new System.Drawing.Point(316, 42);
            this.imgPerio.Name = "imgPerio";
            this.imgPerio.Size = new System.Drawing.Size(20, 20);
            this.imgPerio.TabIndex = 48;
            this.imgPerio.TabStop = false;
            // 
            // erPerio
            // 
            this.erPerio.AutoSize = true;
            this.erPerio.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erPerio.ForeColor = System.Drawing.Color.Red;
            this.erPerio.Location = new System.Drawing.Point(134, 66);
            this.erPerio.Name = "erPerio";
            this.erPerio.Size = new System.Drawing.Size(0, 14);
            this.erPerio.TabIndex = 47;
            this.erPerio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Location = new System.Drawing.Point(381, 39);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(62, 20);
            this.chkEstado.TabIndex = 8;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNombrePerio
            // 
            this.txtNombrePerio.Location = new System.Drawing.Point(137, 40);
            this.txtNombrePerio.MaxLength = 20;
            this.txtNombrePerio.Name = "txtNombrePerio";
            this.txtNombrePerio.Size = new System.Drawing.Size(202, 24);
            this.txtNombrePerio.TabIndex = 7;
            this.txtNombrePerio.TextChanged += new System.EventHandler(this.txtNombrePerio_TextChanged);
            this.txtNombrePerio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombrePerio_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Perioricidad";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIdPerio
            // 
            this.txtIdPerio.Location = new System.Drawing.Point(28, 38);
            this.txtIdPerio.Name = "txtIdPerio";
            this.txtIdPerio.ReadOnly = true;
            this.txtIdPerio.Size = new System.Drawing.Size(58, 24);
            this.txtIdPerio.TabIndex = 1;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(25, 22);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(54, 16);
            this.lblIdUsuario.TabIndex = 0;
            this.lblIdUsuario.Text = "Codigo:";
            this.lblIdUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmRegistrarPerioricidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 296);
            this.Controls.Add(this.lvPerio);
            this.Controls.Add(this.gbBuscar);
            this.Controls.Add(this.tsBotonera);
            this.Controls.Add(this.txtBuscarPerio);
            this.Controls.Add(this.gbPerio);
            this.Name = "frmRegistrarPerioricidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPerioricidad";
            this.Load += new System.EventHandler(this.frmRegistrarPerioricidad_Load);
            this.gbBuscar.ResumeLayout(false);
            this.gbBuscar.PerformLayout();
            this.tsBotonera.ResumeLayout(false);
            this.tsBotonera.PerformLayout();
            this.gbPerio.ResumeLayout(false);
            this.gbPerio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPerio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvPerio;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox gbBuscar;
        private System.Windows.Forms.RadioButton rbNombrePerio;
        private System.Windows.Forms.ToolStrip tsBotonera;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.TextBox txtBuscarPerio;
        private System.Windows.Forms.GroupBox gbPerio;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombrePerio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdPerio;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox imgPerio;
        private System.Windows.Forms.Label erPerio;
        private System.Windows.Forms.ToolStripButton toolStripEditar;
    }
}