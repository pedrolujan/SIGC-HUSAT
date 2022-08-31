namespace wfaIntegradoCom.Procesos
{
    partial class frmAnularVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnularVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBuscar = new Siticone.UI.WinForms.SiticoneTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dgVentas = new Siticone.UI.WinForms.SiticoneDataGridView();
            this.CodDocVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VEHICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAnularVenta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarRegistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.gbBuscarListaVentas = new System.Windows.Forms.GroupBox();
            this.dtpFechaFinalBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.dtpFechaInicialBus = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.label13 = new System.Windows.Forms.Label();
            this.siticonePanel2 = new Siticone.UI.WinForms.SiticonePanel();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.cbF0 = new System.Windows.Forms.CheckBox();
            this.cbR0 = new System.Windows.Forms.CheckBox();
            this.cbFechas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).BeginInit();
            this.cmsAnularVenta.SuspendLayout();
            this.gbBuscarListaVentas.SuspendLayout();
            this.siticonePanel2.SuspendLayout();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Animated = false;
            this.txtBuscar.BorderColor = System.Drawing.Color.Silver;
            this.txtBuscar.BorderRadius = 3;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.Parent = this.txtBuscar;
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtBuscar.FocusedState.Parent = this.txtBuscar;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBuscar.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.HoveredState.Parent = this.txtBuscar;
            this.txtBuscar.Location = new System.Drawing.Point(483, 35);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBuscar.PlaceholderText = "INGRESE COD VENTA...";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.ShadowDecoration.Parent = this.txtBuscar;
            this.txtBuscar.Size = new System.Drawing.Size(424, 36);
            this.txtBuscar.TabIndex = 189;
            this.txtBuscar.TextOffset = new System.Drawing.Point(30, 0);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(486, 40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 190;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // dgVentas
            // 
            this.dgVentas.AllowUserToAddRows = false;
            this.dgVentas.AllowUserToDeleteRows = false;
            this.dgVentas.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgVentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgVentas.ColumnHeadersHeight = 30;
            this.dgVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodDocVenta,
            this.CLIENTE,
            this.VEHICULO,
            this.FECHA,
            this.USUARIO});
            this.dgVentas.ContextMenuStrip = this.cmsAnularVenta;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVentas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVentas.EnableHeadersVisualStyles = false;
            this.dgVentas.GridColor = System.Drawing.Color.Silver;
            this.dgVentas.Location = new System.Drawing.Point(0, 160);
            this.dgVentas.Name = "dgVentas";
            this.dgVentas.ReadOnly = true;
            this.dgVentas.RowHeadersVisible = false;
            this.dgVentas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgVentas.Size = new System.Drawing.Size(975, 377);
            this.dgVentas.TabIndex = 195;
            this.dgVentas.Theme = Siticone.UI.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgVentas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgVentas.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.dgVentas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.dgVentas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgVentas.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVentas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgVentas.ThemeStyle.HeaderStyle.Height = 30;
            this.dgVentas.ThemeStyle.ReadOnly = true;
            this.dgVentas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgVentas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgVentas.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVentas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgVentas.ThemeStyle.RowsStyle.Height = 22;
            this.dgVentas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgVentas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            // 
            // CodDocVenta
            // 
            this.CodDocVenta.FillWeight = 99.57375F;
            this.CodDocVenta.HeaderText = "CodDocVenta";
            this.CodDocVenta.Name = "CodDocVenta";
            this.CodDocVenta.ReadOnly = true;
            // 
            // CLIENTE
            // 
            this.CLIENTE.FillWeight = 100.3033F;
            this.CLIENTE.HeaderText = "CLIENTE";
            this.CLIENTE.Name = "CLIENTE";
            this.CLIENTE.ReadOnly = true;
            // 
            // VEHICULO
            // 
            this.VEHICULO.FillWeight = 99.57738F;
            this.VEHICULO.HeaderText = "VEHICULO";
            this.VEHICULO.Name = "VEHICULO";
            this.VEHICULO.ReadOnly = true;
            // 
            // FECHA
            // 
            this.FECHA.FillWeight = 100.2235F;
            this.FECHA.HeaderText = "FECHA VENTA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            // 
            // USUARIO
            // 
            this.USUARIO.FillWeight = 100.2454F;
            this.USUARIO.HeaderText = "USUARIO";
            this.USUARIO.Name = "USUARIO";
            this.USUARIO.ReadOnly = true;
            // 
            // cmsAnularVenta
            // 
            this.cmsAnularVenta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarRegistroToolStripMenuItem});
            this.cmsAnularVenta.Name = "cmsAnularVenta";
            this.cmsAnularVenta.Size = new System.Drawing.Size(184, 26);
            // 
            // eliminarRegistroToolStripMenuItem
            // 
            this.eliminarRegistroToolStripMenuItem.Name = "eliminarRegistroToolStripMenuItem";
            this.eliminarRegistroToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.eliminarRegistroToolStripMenuItem.Text = "Eliminar Documento";
            this.eliminarRegistroToolStripMenuItem.Click += new System.EventHandler(this.eliminarRegistroToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(425, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 196;
            this.label1.Text = "BUSCAR";
            // 
            // gbBuscarListaVentas
            // 
            this.gbBuscarListaVentas.BackColor = System.Drawing.Color.Transparent;
            this.gbBuscarListaVentas.Controls.Add(this.dtpFechaFinalBus);
            this.gbBuscarListaVentas.Controls.Add(this.dtpFechaInicialBus);
            this.gbBuscarListaVentas.Controls.Add(this.label35);
            this.gbBuscarListaVentas.Controls.Add(this.label14);
            this.gbBuscarListaVentas.Enabled = false;
            this.gbBuscarListaVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbBuscarListaVentas.Location = new System.Drawing.Point(15, 6);
            this.gbBuscarListaVentas.Name = "gbBuscarListaVentas";
            this.gbBuscarListaVentas.Size = new System.Drawing.Size(268, 117);
            this.gbBuscarListaVentas.TabIndex = 225;
            this.gbBuscarListaVentas.TabStop = false;
            // 
            // dtpFechaFinalBus
            // 
            this.dtpFechaFinalBus.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtpFechaFinalBus.BorderRadius = 3;
            this.dtpFechaFinalBus.BorderThickness = 1;
            this.dtpFechaFinalBus.CheckedState.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.FillColor = System.Drawing.Color.White;
            this.dtpFechaFinalBus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaFinalBus.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaFinalBus.HoveredState.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.Location = new System.Drawing.Point(8, 77);
            this.dtpFechaFinalBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaFinalBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFinalBus.Name = "dtpFechaFinalBus";
            this.dtpFechaFinalBus.ShadowDecoration.Parent = this.dtpFechaFinalBus;
            this.dtpFechaFinalBus.Size = new System.Drawing.Size(254, 36);
            this.dtpFechaFinalBus.TabIndex = 233;
            this.dtpFechaFinalBus.Value = new System.DateTime(2022, 4, 8, 18, 42, 0, 0);
            // 
            // dtpFechaInicialBus
            // 
            this.dtpFechaInicialBus.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtpFechaInicialBus.BorderRadius = 3;
            this.dtpFechaInicialBus.BorderThickness = 1;
            this.dtpFechaInicialBus.CheckedState.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.FillColor = System.Drawing.Color.White;
            this.dtpFechaInicialBus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpFechaInicialBus.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaInicialBus.HoveredState.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.Location = new System.Drawing.Point(8, 25);
            this.dtpFechaInicialBus.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFechaInicialBus.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicialBus.Name = "dtpFechaInicialBus";
            this.dtpFechaInicialBus.ShadowDecoration.Parent = this.dtpFechaInicialBus;
            this.dtpFechaInicialBus.Size = new System.Drawing.Size(254, 36);
            this.dtpFechaInicialBus.TabIndex = 231;
            this.dtpFechaInicialBus.Value = new System.DateTime(2021, 4, 8, 18, 42, 48, 690);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label35.Location = new System.Drawing.Point(8, 60);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(74, 17);
            this.label35.TabIndex = 232;
            this.label35.Text = "Fecha Final:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(8, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 17);
            this.label14.TabIndex = 227;
            this.label14.Text = "Fecha Inicial:";
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(930, 0);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 76;
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(883, 0);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 77;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 141;
            this.label13.Text = "Anular Venta";
            // 
            // siticonePanel2
            // 
            this.siticonePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel2.Controls.Add(this.label13);
            this.siticonePanel2.Controls.Add(this.gunaControlBox2);
            this.siticonePanel2.Controls.Add(this.gunaControlBox1);
            this.siticonePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticonePanel2.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel2.Name = "siticonePanel2";
            this.siticonePanel2.ShadowDecoration.Parent = this.siticonePanel2;
            this.siticonePanel2.Size = new System.Drawing.Size(975, 25);
            this.siticonePanel2.TabIndex = 79;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BackColor = System.Drawing.Color.White;
            this.siticonePanel1.Controls.Add(this.cbF0);
            this.siticonePanel1.Controls.Add(this.cbR0);
            this.siticonePanel1.Controls.Add(this.cbFechas);
            this.siticonePanel1.Controls.Add(this.label1);
            this.siticonePanel1.Controls.Add(this.pictureBox4);
            this.siticonePanel1.Controls.Add(this.txtBuscar);
            this.siticonePanel1.Controls.Add(this.gbBuscarListaVentas);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 25);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(975, 135);
            this.siticonePanel1.TabIndex = 226;
            // 
            // cbF0
            // 
            this.cbF0.AutoSize = true;
            this.cbF0.Location = new System.Drawing.Point(686, 92);
            this.cbF0.Name = "cbF0";
            this.cbF0.Size = new System.Drawing.Size(83, 17);
            this.cbF0.TabIndex = 228;
            this.cbF0.Text = "F001-00000";
            this.cbF0.UseVisualStyleBackColor = true;
            this.cbF0.CheckedChanged += new System.EventHandler(this.cbF0_CheckedChanged);
            // 
            // cbR0
            // 
            this.cbR0.AutoSize = true;
            this.cbR0.Location = new System.Drawing.Point(515, 92);
            this.cbR0.Name = "cbR0";
            this.cbR0.Size = new System.Drawing.Size(85, 17);
            this.cbR0.TabIndex = 227;
            this.cbR0.Text = "R001-00000";
            this.cbR0.UseVisualStyleBackColor = true;
            this.cbR0.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // cbFechas
            // 
            this.cbFechas.AutoSize = true;
            this.cbFechas.Location = new System.Drawing.Point(289, 15);
            this.cbFechas.Name = "cbFechas";
            this.cbFechas.Size = new System.Drawing.Size(97, 17);
            this.cbFechas.TabIndex = 226;
            this.cbFechas.Text = "Activar Fechas";
            this.cbFechas.UseVisualStyleBackColor = true;
            this.cbFechas.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmAnularVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 537);
            this.Controls.Add(this.dgVentas);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.siticonePanel2);
            this.Name = "frmAnularVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAnularVenta";
            this.Load += new System.EventHandler(this.frmAnularVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentas)).EndInit();
            this.cmsAnularVenta.ResumeLayout(false);
            this.gbBuscarListaVentas.ResumeLayout(false);
            this.gbBuscarListaVentas.PerformLayout();
            this.siticonePanel2.ResumeLayout(false);
            this.siticonePanel2.PerformLayout();
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Siticone.UI.WinForms.SiticoneTextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Siticone.UI.WinForms.SiticoneDataGridView dgVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodDocVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VEHICULO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIO;
        private System.Windows.Forms.GroupBox gbBuscarListaVentas;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaFinalBus;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dtpFechaInicialBus;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label14;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private System.Windows.Forms.Label label13;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel2;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private System.Windows.Forms.CheckBox cbFechas;
        private System.Windows.Forms.ContextMenuStrip cmsAnularVenta;
        private System.Windows.Forms.ToolStripMenuItem eliminarRegistroToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbF0;
        private System.Windows.Forms.CheckBox cbR0;
    }
}