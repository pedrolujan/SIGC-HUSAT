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
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.cboSucursal = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.siticoneControlBox1 = new Siticone.Desktop.UI.WinForms.SiticoneControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.chkVerContraseña = new Siticone.Desktop.UI.WinForms.SiticoneCheckBox();
            this.txtUser = new Guna.UI.WinForms.GunaLineTextBox();
            this.siticonePanel2 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClave = new Guna.UI.WinForms.GunaLineTextBox();
            this.iconVerContrasena = new FontAwesome.Sharp.IconPictureBox();
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
            this.lblVersion.Location = new System.Drawing.Point(459, 437);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(114, 15);
            this.lblVersion.TabIndex = 22;
            this.lblVersion.Text = "Versión del Sistema :";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.siticonePanel1.Size = new System.Drawing.Size(585, 183);
            this.siticonePanel1.TabIndex = 28;
            // 
            // cboSucursal
            // 
            this.cboSucursal.BackColor = System.Drawing.Color.Transparent;
            this.cboSucursal.BorderRadius = 5;
            this.cboSucursal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboSucursal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.cboSucursal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSucursal.ItemHeight = 30;
            this.cboSucursal.Location = new System.Drawing.Point(157, 137);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(277, 36);
            this.cboSucursal.TabIndex = 33;
            this.cboSucursal.SelectedIndexChanged += new System.EventHandler(this.cboSucursal_SelectedIndexChanged);
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
            this.siticoneControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.siticoneControlBox1.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox1.Location = new System.Drawing.Point(540, 0);
            this.siticoneControlBox1.Name = "siticoneControlBox1";
            this.siticoneControlBox1.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox1.TabIndex = 73;
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
            // siticoneButton1
            // 
            this.siticoneButton1.BorderRadius = 10;
            this.siticoneButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siticoneButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.Image = global::wfaIntegradoCom.Properties.Resources.login_32px;
            this.siticoneButton1.Location = new System.Drawing.Point(210, 377);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.Size = new System.Drawing.Size(180, 45);
            this.siticoneButton1.TabIndex = 30;
            this.siticoneButton1.Text = "Iniciar Sesión";
            this.siticoneButton1.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // chkVerContraseña
            // 
            this.chkVerContraseña.CheckedState.BorderColor = System.Drawing.Color.White;
            this.chkVerContraseña.CheckedState.BorderRadius = 0;
            this.chkVerContraseña.CheckedState.BorderThickness = 0;
            this.chkVerContraseña.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.chkVerContraseña.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkVerContraseña.Location = new System.Drawing.Point(567, 434);
            this.chkVerContraseña.Name = "chkVerContraseña";
            this.chkVerContraseña.Size = new System.Drawing.Size(15, 21);
            this.chkVerContraseña.TabIndex = 3;
            this.chkVerContraseña.Text = "Ver Contraseña";
            this.chkVerContraseña.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkVerContraseña.UncheckedState.BorderRadius = 0;
            this.chkVerContraseña.UncheckedState.BorderThickness = 0;
            this.chkVerContraseña.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkVerContraseña.Visible = false;
            this.chkVerContraseña.CheckedChanged += new System.EventHandler(this.chkVerContraseña_CheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Gray;
            this.txtUser.LineColor = System.Drawing.Color.Silver;
            this.txtUser.LineSize = 2;
            this.txtUser.Location = new System.Drawing.Point(159, 235);
            this.txtUser.MaxLength = 45;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.Size = new System.Drawing.Size(277, 34);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            this.txtUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyUp);
            // 
            // siticonePanel2
            // 
            this.siticonePanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.siticonePanel2.BorderThickness = 1;
            this.siticonePanel2.Controls.Add(this.label2);
            this.siticonePanel2.Controls.Add(this.txtUser);
            this.siticonePanel2.Controls.Add(this.lblVersion);
            this.siticonePanel2.Controls.Add(this.txtClave);
            this.siticonePanel2.Controls.Add(this.chkVerContraseña);
            this.siticonePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticonePanel2.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel2.Name = "siticonePanel2";
            this.siticonePanel2.Size = new System.Drawing.Size(585, 455);
            this.siticonePanel2.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(68)))), ((int)(((byte)(29)))));
            this.label2.Location = new System.Drawing.Point(4, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 22;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.txtClave.Location = new System.Drawing.Point(159, 313);
            this.txtClave.MaxLength = 45;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '\0';
            this.txtClave.Size = new System.Drawing.Size(277, 34);
            this.txtClave.TabIndex = 2;
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // iconVerContrasena
            // 
            this.iconVerContrasena.BackColor = System.Drawing.Color.White;
            this.iconVerContrasena.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconVerContrasena.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconVerContrasena.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconVerContrasena.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconVerContrasena.IconSize = 25;
            this.iconVerContrasena.Location = new System.Drawing.Point(411, 318);
            this.iconVerContrasena.Name = "iconVerContrasena";
            this.iconVerContrasena.Size = new System.Drawing.Size(25, 25);
            this.iconVerContrasena.TabIndex = 35;
            this.iconVerContrasena.TabStop = false;
            this.iconVerContrasena.Click += new System.EventHandler(this.iconVerContrasena_Click);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 455);
            this.Controls.Add(this.iconVerContrasena);
            this.Controls.Add(this.siticoneButton1);
            this.Controls.Add(this.siticonePanel1);
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
            this.Activated += new System.EventHandler(this.frmUsuario_Activated);
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
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private Siticone.Desktop.UI.WinForms.SiticoneCheckBox chkVerContraseña;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox cboSucursal;
        private Guna.UI.WinForms.GunaLineTextBox txtUser;
        private Siticone.Desktop.UI.WinForms.SiticoneControlBox siticoneControlBox1;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel2;
        private FontAwesome.Sharp.IconPictureBox iconVerContrasena;
        internal System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaLineTextBox txtClave;
        private System.Windows.Forms.Label label2;
    }
}