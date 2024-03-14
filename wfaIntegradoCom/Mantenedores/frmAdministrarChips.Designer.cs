namespace wfaIntegradoCom.Mantenedores
{
    partial class frmAdministrarChips
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gbChkBuscar = new System.Windows.Forms.Label();
            this.lblNumRecibo = new System.Windows.Forms.Label();
            this.pbNumRecibo = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pSupeior = new Guna.UI.WinForms.GunaPanel();
            this.gunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.dgChips = new Guna.UI.WinForms.GunaDataGridView();
            this.btnContadorRegistros = new Guna.UI.WinForms.GunaCircleButton();
            this.chkBuscar = new Guna.UI.WinForms.GunaCheckBox();
            this.cboNumRecibo = new Guna.UI.WinForms.GunaComboBox();
            this.btnNuevo = new Guna.UI.WinForms.GunaButton();
            this.btnSalir = new Guna.UI.WinForms.GunaButton();
            this.btnGuardar = new Guna.UI.WinForms.GunaButton();
            this.btnEditar = new Guna.UI.WinForms.GunaButton();
            this.dcMoverFormulario = new Guna.UI.WinForms.GunaDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbNumRecibo)).BeginInit();
            this.pSupeior.SuspendLayout();
            this.gunaPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChips)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.BackColor = System.Drawing.Color.DimGray;
            this.lblCantRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRegistros.ForeColor = System.Drawing.Color.White;
            this.lblCantRegistros.Location = new System.Drawing.Point(15, 10);
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(448, 40);
            this.lblCantRegistros.TabIndex = 106;
            this.lblCantRegistros.Text = "Estos son los numeros de chips";
            this.lblCantRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCantRegistros.Click += new System.EventHandler(this.lblCantRegistros_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 21);
            this.label2.TabIndex = 121;
            this.label2.Text = "Administrar chips a sus respectivas cuentas";
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(728, 3);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox2.TabIndex = 1;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(767, 3);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 0;
            // 
            // gbChkBuscar
            // 
            this.gbChkBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbChkBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gbChkBuscar.Location = new System.Drawing.Point(679, 4);
            this.gbChkBuscar.Name = "gbChkBuscar";
            this.gbChkBuscar.Size = new System.Drawing.Size(122, 33);
            this.gbChkBuscar.TabIndex = 111;
            // 
            // lblNumRecibo
            // 
            this.lblNumRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecibo.Location = new System.Drawing.Point(545, 112);
            this.lblNumRecibo.Name = "lblNumRecibo";
            this.lblNumRecibo.Size = new System.Drawing.Size(219, 19);
            this.lblNumRecibo.TabIndex = 119;
            // 
            // pbNumRecibo
            // 
            this.pbNumRecibo.BackColor = System.Drawing.Color.Transparent;
            this.pbNumRecibo.BaseColor = System.Drawing.Color.Transparent;
            this.pbNumRecibo.Location = new System.Drawing.Point(779, 82);
            this.pbNumRecibo.Name = "pbNumRecibo";
            this.pbNumRecibo.Size = new System.Drawing.Size(22, 22);
            this.pbNumRecibo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbNumRecibo.TabIndex = 118;
            this.pbNumRecibo.TabStop = false;
            this.pbNumRecibo.UseTransfarantBackground = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(537, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 117;
            this.label1.Text = "Numero de cuenta (*)";
            // 
            // pSupeior
            // 
            this.pSupeior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.pSupeior.Controls.Add(this.label2);
            this.pSupeior.Controls.Add(this.gunaControlBox1);
            this.pSupeior.Controls.Add(this.gunaControlBox2);
            this.pSupeior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSupeior.Location = new System.Drawing.Point(0, 0);
            this.pSupeior.Name = "pSupeior";
            this.pSupeior.Size = new System.Drawing.Size(815, 34);
            this.pSupeior.TabIndex = 110;
            // 
            // gunaPanel2
            // 
            this.gunaPanel2.BackColor = System.Drawing.Color.White;
            this.gunaPanel2.Controls.Add(this.dgChips);
            this.gunaPanel2.Controls.Add(this.btnContadorRegistros);
            this.gunaPanel2.Controls.Add(this.chkBuscar);
            this.gunaPanel2.Controls.Add(this.cboNumRecibo);
            this.gunaPanel2.Controls.Add(this.btnNuevo);
            this.gunaPanel2.Controls.Add(this.btnSalir);
            this.gunaPanel2.Controls.Add(this.btnGuardar);
            this.gunaPanel2.Controls.Add(this.btnEditar);
            this.gunaPanel2.Controls.Add(this.lblCantRegistros);
            this.gunaPanel2.Controls.Add(this.lblNumRecibo);
            this.gunaPanel2.Controls.Add(this.gbChkBuscar);
            this.gunaPanel2.Controls.Add(this.pbNumRecibo);
            this.gunaPanel2.Controls.Add(this.label1);
            this.gunaPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaPanel2.Location = new System.Drawing.Point(0, 34);
            this.gunaPanel2.Name = "gunaPanel2";
            this.gunaPanel2.Size = new System.Drawing.Size(815, 511);
            this.gunaPanel2.TabIndex = 111;
            // 
            // dgChips
            // 
            this.dgChips.AllowUserToAddRows = false;
            this.dgChips.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgChips.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgChips.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgChips.BackgroundColor = System.Drawing.Color.White;
            this.dgChips.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgChips.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgChips.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgChips.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgChips.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgChips.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgChips.EnableHeadersVisualStyles = false;
            this.dgChips.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgChips.Location = new System.Drawing.Point(16, 53);
            this.dgChips.Name = "dgChips";
            this.dgChips.RowHeadersVisible = false;
            this.dgChips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgChips.Size = new System.Drawing.Size(447, 374);
            this.dgChips.TabIndex = 128;
            this.dgChips.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgChips.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgChips.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgChips.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgChips.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgChips.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgChips.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgChips.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgChips.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgChips.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgChips.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgChips.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgChips.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgChips.ThemeStyle.HeaderStyle.Height = 30;
            this.dgChips.ThemeStyle.ReadOnly = false;
            this.dgChips.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgChips.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgChips.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgChips.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgChips.ThemeStyle.RowsStyle.Height = 22;
            this.dgChips.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgChips.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgChips.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgChips_CellContentClick);
            // 
            // btnContadorRegistros
            // 
            this.btnContadorRegistros.AnimationHoverSpeed = 0.07F;
            this.btnContadorRegistros.AnimationSpeed = 0.03F;
            this.btnContadorRegistros.BackColor = System.Drawing.Color.DimGray;
            this.btnContadorRegistros.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnContadorRegistros.BorderColor = System.Drawing.Color.Black;
            this.btnContadorRegistros.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnContadorRegistros.FocusedColor = System.Drawing.Color.Empty;
            this.btnContadorRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContadorRegistros.ForeColor = System.Drawing.Color.White;
            this.btnContadorRegistros.Image = null;
            this.btnContadorRegistros.ImageSize = new System.Drawing.Size(52, 52);
            this.btnContadorRegistros.Location = new System.Drawing.Point(427, 13);
            this.btnContadorRegistros.Name = "btnContadorRegistros";
            this.btnContadorRegistros.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.btnContadorRegistros.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnContadorRegistros.OnHoverForeColor = System.Drawing.Color.White;
            this.btnContadorRegistros.OnHoverImage = null;
            this.btnContadorRegistros.OnPressedColor = System.Drawing.Color.Black;
            this.btnContadorRegistros.Size = new System.Drawing.Size(32, 34);
            this.btnContadorRegistros.TabIndex = 127;
            // 
            // chkBuscar
            // 
            this.chkBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBuscar.BaseColor = System.Drawing.Color.White;
            this.chkBuscar.CheckedOffColor = System.Drawing.Color.White;
            this.chkBuscar.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkBuscar.FillColor = System.Drawing.Color.White;
            this.chkBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.chkBuscar.ForeColor = System.Drawing.Color.White;
            this.chkBuscar.Location = new System.Drawing.Point(689, 10);
            this.chkBuscar.Name = "chkBuscar";
            this.chkBuscar.Size = new System.Drawing.Size(75, 20);
            this.chkBuscar.TabIndex = 126;
            this.chkBuscar.Text = "Buscar";
            this.chkBuscar.CheckedChanged += new System.EventHandler(this.chkBuscar_CheckedChanged);
            // 
            // cboNumRecibo
            // 
            this.cboNumRecibo.BackColor = System.Drawing.Color.Transparent;
            this.cboNumRecibo.BaseColor = System.Drawing.Color.White;
            this.cboNumRecibo.BorderColor = System.Drawing.Color.Silver;
            this.cboNumRecibo.BorderSize = 1;
            this.cboNumRecibo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNumRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumRecibo.FocusedColor = System.Drawing.Color.Empty;
            this.cboNumRecibo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNumRecibo.ForeColor = System.Drawing.Color.Black;
            this.cboNumRecibo.FormattingEnabled = true;
            this.cboNumRecibo.Location = new System.Drawing.Point(540, 82);
            this.cboNumRecibo.Name = "cboNumRecibo";
            this.cboNumRecibo.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboNumRecibo.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboNumRecibo.Radius = 4;
            this.cboNumRecibo.Size = new System.Drawing.Size(233, 26);
            this.cboNumRecibo.TabIndex = 125;
            this.cboNumRecibo.SelectedIndexChanged += new System.EventHandler(this.cboNumRecibo_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AnimationHoverSpeed = 0.07F;
            this.btnNuevo.AnimationSpeed = 0.03F;
            this.btnNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevo.BorderColor = System.Drawing.Color.Black;
            this.btnNuevo.BorderSize = 1;
            this.btnNuevo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNuevo.FocusedColor = System.Drawing.Color.Empty;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = null;
            this.btnNuevo.ImageSize = new System.Drawing.Size(20, 20);
            this.btnNuevo.Location = new System.Drawing.Point(274, 445);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevo.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnNuevo.OnHoverForeColor = System.Drawing.Color.White;
            this.btnNuevo.OnHoverImage = null;
            this.btnNuevo.OnPressedColor = System.Drawing.Color.Black;
            this.btnNuevo.Radius = 3;
            this.btnNuevo.Size = new System.Drawing.Size(105, 42);
            this.btnNuevo.TabIndex = 124;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnNuevo.TextOffsetX = 10;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.AnimationHoverSpeed = 0.07F;
            this.btnSalir.AnimationSpeed = 0.03F;
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.BorderSize = 1;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSalir.FocusedColor = System.Drawing.Color.Empty;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSalir.Location = new System.Drawing.Point(496, 445);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSalir.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSalir.OnHoverImage = null;
            this.btnSalir.OnPressedColor = System.Drawing.Color.Black;
            this.btnSalir.Radius = 3;
            this.btnSalir.Size = new System.Drawing.Size(105, 42);
            this.btnSalir.TabIndex = 123;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AnimationHoverSpeed = 0.07F;
            this.btnGuardar.AnimationSpeed = 0.03F;
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.BorderSize = 1;
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGuardar.FocusedColor = System.Drawing.Color.Empty;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = null;
            this.btnGuardar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnGuardar.Location = new System.Drawing.Point(385, 445);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnGuardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnGuardar.OnHoverImage = null;
            this.btnGuardar.OnPressedColor = System.Drawing.Color.Black;
            this.btnGuardar.Radius = 3;
            this.btnGuardar.Size = new System.Drawing.Size(105, 42);
            this.btnGuardar.TabIndex = 122;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AnimationHoverSpeed = 0.07F;
            this.btnEditar.AnimationSpeed = 0.03F;
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditar.BorderColor = System.Drawing.Color.Black;
            this.btnEditar.BorderSize = 1;
            this.btnEditar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditar.FocusedColor = System.Drawing.Color.Empty;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = null;
            this.btnEditar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnEditar.Location = new System.Drawing.Point(274, 445);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEditar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEditar.OnHoverImage = null;
            this.btnEditar.OnPressedColor = System.Drawing.Color.Black;
            this.btnEditar.Radius = 3;
            this.btnEditar.Size = new System.Drawing.Size(105, 42);
            this.btnEditar.TabIndex = 121;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dcMoverFormulario
            // 
            this.dcMoverFormulario.TargetControl = this.pSupeior;
            // 
            // frmAdministrarChips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 545);
            this.Controls.Add(this.gunaPanel2);
            this.Controls.Add(this.pSupeior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdministrarChips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdministrarChips";
            this.Load += new System.EventHandler(this.frmAdministrarChips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNumRecibo)).EndInit();
            this.pSupeior.ResumeLayout(false);
            this.pSupeior.PerformLayout();
            this.gunaPanel2.ResumeLayout(false);
            this.gunaPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChips)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblCantRegistros;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumRecibo;
        private Guna.UI.WinForms.GunaCirclePictureBox pbNumRecibo;
        private System.Windows.Forms.Label gbChkBuscar;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaPanel pSupeior;
        private Guna.UI.WinForms.GunaPanel gunaPanel2;
        private Guna.UI.WinForms.GunaButton btnNuevo;
        private Guna.UI.WinForms.GunaButton btnSalir;
        private Guna.UI.WinForms.GunaButton btnGuardar;
        private Guna.UI.WinForms.GunaButton btnEditar;
        private Guna.UI.WinForms.GunaCheckBox chkBuscar;
        private Guna.UI.WinForms.GunaComboBox cboNumRecibo;
        private Guna.UI.WinForms.GunaCircleButton btnContadorRegistros;
        private Guna.UI.WinForms.GunaDataGridView dgChips;
        private Guna.UI.WinForms.GunaDragControl dcMoverFormulario;
    }
}