namespace wfaIntegradoCom
{
    partial class frmUsuario
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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtUser = new Siticone.UI.WinForms.SiticoneMaterialTextBox();
            this.siticonePanel1 = new Siticone.UI.WinForms.SiticonePanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.siticoneControlBox1 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.siticoneButton1 = new Siticone.UI.WinForms.SiticoneButton();
            this.chkVerContraseña = new Siticone.UI.WinForms.SiticoneCheckBox();
            this.dateTimePicker1 = new Siticone.UI.WinForms.SiticoneDateTimePicker();
            this.cboSucursal = new Siticone.UI.WinForms.SiticoneComboBox();
            this.txtClave = new Guna.UI.WinForms.GunaLineTextBox();
            this.siticonePanel2 = new Siticone.UI.WinForms.SiticonePanel();
            this.iconVerContrasena = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.siticonePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.siticonePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconVerContrasena)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.Gray;
            this.UsernameLabel.Location = new System.Drawing.Point(159, 211);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(73, 21);
            this.UsernameLabel.TabIndex = 17;
            this.UsernameLabel.Text = "Usuario:";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Gray;
            this.PasswordLabel.Location = new System.Drawing.Point(159, 284);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(100, 21);
            this.PasswordLabel.TabIndex = 18;
            this.PasswordLabel.Text = "Contraseña:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Calibri Light", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.lblVersion.Location = new System.Drawing.Point(449, 429);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(114, 15);
            this.lblVersion.TabIndex = 22;
            this.lblVersion.Text = "Versión del Sistema :";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUser
            // 
            this.txtUser.Animated = false;
            this.txtUser.BorderColor = System.Drawing.Color.Silver;
            this.txtUser.BorderThickness = 2;
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultText = "";
            this.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.DisabledState.Parent = this.txtUser;
            this.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtUser.FocusedState.Parent = this.txtUser;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Gray;
            this.txtUser.HoveredState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtUser.HoveredState.Parent = this.txtUser;
            this.txtUser.Location = new System.Drawing.Point(159, 233);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.PlaceholderText = "";
            this.txtUser.SelectedText = "";
            this.txtUser.ShadowDecoration.Parent = this.txtUser;
            this.txtUser.Size = new System.Drawing.Size(277, 36);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel1.Controls.Add(this.cboSucursal);
            this.siticonePanel1.Controls.Add(this.pictureBox1);
            this.siticonePanel1.Controls.Add(this.siticoneControlBox1);
            this.siticonePanel1.Controls.Add(this.label1);
            this.siticonePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.siticonePanel1.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
            this.siticonePanel1.Size = new System.Drawing.Size(585, 183);
            this.siticonePanel1.TabIndex = 28;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfaIntegradoCom.Properties.Resources.logo_husat;
            this.pictureBox1.Location = new System.Drawing.Point(183, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // siticoneControlBox1
            // 
            this.siticoneControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticoneControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneControlBox1.HoveredState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(540, 0);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
            this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox1.TabIndex = 73;
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.BorderRadius = 10;
            this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
            this.siticoneButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
            this.siticoneButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
            this.siticoneButton1.Image = global::wfaIntegradoCom.Properties.Resources.login_32px;
            this.siticoneButton1.Location = new System.Drawing.Point(210, 377);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
            this.siticoneButton1.Size = new System.Drawing.Size(180, 45);
            this.siticoneButton1.TabIndex = 30;
            this.siticoneButton1.Text = "Iniciar Sesión";
            this.siticoneButton1.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // chkVerContraseña
            // 
            this.chkVerContraseña.AutoSize = true;
            this.chkVerContraseña.CheckedState.BorderColor = System.Drawing.Color.White;
            this.chkVerContraseña.CheckedState.BorderRadius = 0;
            this.chkVerContraseña.CheckedState.BorderThickness = 0;
            this.chkVerContraseña.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkVerContraseña.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkVerContraseña.Location = new System.Drawing.Point(466, 392);
            this.chkVerContraseña.Name = "chkVerContraseña";
            this.chkVerContraseña.Size = new System.Drawing.Size(116, 21);
            this.chkVerContraseña.TabIndex = 3;
            this.chkVerContraseña.Text = "Ver Contraseña";
            this.chkVerContraseña.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkVerContraseña.UncheckedState.BorderRadius = 0;
            this.chkVerContraseña.UncheckedState.BorderThickness = 0;
            this.chkVerContraseña.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkVerContraseña.Visible = false;
            this.chkVerContraseña.CheckedChanged += new System.EventHandler(this.chkVerContraseña_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CheckedState.Parent = this.dateTimePicker1;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dateTimePicker1.ForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateTimePicker1.HoveredState.Parent = this.dateTimePicker1;
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 377);
            this.dateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShadowDecoration.Parent = this.dateTimePicker1;
            this.dateTimePicker1.Size = new System.Drawing.Size(103, 36);
            this.dateTimePicker1.TabIndex = 32;
            this.dateTimePicker1.Value = new System.DateTime(2021, 3, 14, 17, 59, 26, 640);
            this.dateTimePicker1.Visible = false;
            // 
            // cboSucursal
            // 
            this.cboSucursal.BackColor = System.Drawing.Color.Transparent;
            this.cboSucursal.BorderRadius = 5;
            this.cboSucursal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboSucursal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSucursal.HoveredState.Parent = this.cboSucursal;
            this.cboSucursal.ItemHeight = 30;
            this.cboSucursal.ItemsAppearance.Parent = this.cboSucursal;
            this.cboSucursal.Location = new System.Drawing.Point(157, 137);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.ShadowDecoration.Parent = this.cboSucursal;
            this.cboSucursal.Size = new System.Drawing.Size(277, 36);
            this.cboSucursal.TabIndex = 33;
            this.cboSucursal.SelectedIndexChanged += new System.EventHandler(this.cboSucursal_SelectedIndexChanged);
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClave.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.Gray;
            this.txtClave.LineColor = System.Drawing.Color.Silver;
            this.txtClave.LineSize = 2;
            this.txtClave.Location = new System.Drawing.Point(159, 306);
            this.txtClave.MaxLength = 45;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '\0';
            this.txtClave.Size = new System.Drawing.Size(277, 34);
            this.txtClave.TabIndex = 2;
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // siticonePanel2
            // 
            this.siticonePanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel2.BorderThickness = 1;
            this.siticonePanel2.Controls.Add(this.lblVersion);
            this.siticonePanel2.Controls.Add(this.chkVerContraseña);
            this.siticonePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel2.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel2.Name = "siticonePanel2";
            this.siticonePanel2.ShadowDecoration.Parent = this.siticonePanel2;
            this.siticonePanel2.Size = new System.Drawing.Size(585, 455);
            this.siticonePanel2.TabIndex = 34;
            // 
            // iconVerContrasena
            // 
            this.iconVerContrasena.BackColor = System.Drawing.Color.White;
            this.iconVerContrasena.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconVerContrasena.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconVerContrasena.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconVerContrasena.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconVerContrasena.IconSize = 25;
            this.iconVerContrasena.Location = new System.Drawing.Point(411, 313);
            this.iconVerContrasena.Name = "iconVerContrasena";
            this.iconVerContrasena.Size = new System.Drawing.Size(25, 25);
            this.iconVerContrasena.TabIndex = 35;
            this.iconVerContrasena.TabStop = false;
            this.iconVerContrasena.Click += new System.EventHandler(this.iconVerContrasena_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(260, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Sucursal:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 455);
            this.Controls.Add(this.iconVerContrasena);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.siticoneButton1);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.siticonePanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuario";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar al Sistema";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.siticonePanel2.ResumeLayout(false);
            this.siticonePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconVerContrasena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label UsernameLabel;
        internal System.Windows.Forms.Label PasswordLabel;
        internal System.Windows.Forms.Label lblVersion;
        private Siticone.UI.WinForms.SiticoneMaterialTextBox txtUser;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Siticone.UI.WinForms.SiticoneButton siticoneButton1;
        private Siticone.UI.WinForms.SiticoneCheckBox chkVerContraseña;
        private Siticone.UI.WinForms.SiticoneDateTimePicker dateTimePicker1;
        private Siticone.UI.WinForms.SiticoneComboBox cboSucursal;
        private Guna.UI.WinForms.GunaLineTextBox txtClave;
        private Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;
        private Siticone.UI.WinForms.SiticonePanel siticonePanel2;
        private FontAwesome.Sharp.IconPictureBox iconVerContrasena;
        internal System.Windows.Forms.Label label1;
    }
}