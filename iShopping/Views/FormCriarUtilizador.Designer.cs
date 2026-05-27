namespace iShopping.Views
{
    partial class FormCriarUtilizador
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCriarUtilizador = new System.Windows.Forms.Button();
            this.buttonHideShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(29, 38);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(33, 71);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(90, 38);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(114, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(90, 71);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(114, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonCriarUtilizador
            // 
            this.buttonCriarUtilizador.Location = new System.Drawing.Point(36, 136);
            this.buttonCriarUtilizador.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCriarUtilizador.Name = "buttonCriarUtilizador";
            this.buttonCriarUtilizador.Size = new System.Drawing.Size(187, 31);
            this.buttonCriarUtilizador.TabIndex = 4;
            this.buttonCriarUtilizador.Text = "Criar Utilizador";
            this.buttonCriarUtilizador.UseVisualStyleBackColor = true;
            this.buttonCriarUtilizador.Click += new System.EventHandler(this.buttonCriarUtilizador_Click);
            // 
            // buttonHideShow
            // 
            this.buttonHideShow.Location = new System.Drawing.Point(90, 96);
            this.buttonHideShow.Name = "buttonHideShow";
            this.buttonHideShow.Size = new System.Drawing.Size(114, 20);
            this.buttonHideShow.TabIndex = 7;
            this.buttonHideShow.Text = "Mostrar/Ocultar";
            this.buttonHideShow.UseVisualStyleBackColor = true;
            this.buttonHideShow.Click += new System.EventHandler(this.buttonHideShow_Click);
            // 
            // FormCriarUtilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 195);
            this.Controls.Add(this.buttonHideShow);
            this.Controls.Add(this.buttonCriarUtilizador);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCriarUtilizador";
            this.Text = "FormCriarUtilizador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCriarUtilizador;
        private System.Windows.Forms.Button buttonHideShow;
    }
}