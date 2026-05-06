namespace iShopping.Views
{
    partial class FormGestaoTiposArtigo
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
            this.labelTituloTipoArtigo = new System.Windows.Forms.Label();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNomeArtigo = new System.Windows.Forms.TextBox();
            this.listBoxTiposArtigos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelTituloTipoArtigo
            // 
            this.labelTituloTipoArtigo.AutoSize = true;
            this.labelTituloTipoArtigo.Location = new System.Drawing.Point(32, 30);
            this.labelTituloTipoArtigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTituloTipoArtigo.Name = "labelTituloTipoArtigo";
            this.labelTituloTipoArtigo.Size = new System.Drawing.Size(83, 13);
            this.labelTituloTipoArtigo.TabIndex = 0;
            this.labelTituloTipoArtigo.Text = "Nome do Artigo:";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(35, 232);
            this.buttonAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(69, 22);
            this.buttonAdicionar.TabIndex = 1;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(131, 232);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(56, 22);
            this.buttonEditar.TabIndex = 2;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(215, 232);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(68, 22);
            this.buttonEliminar.TabIndex = 3;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(311, 232);
            this.buttonLimpar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(61, 22);
            this.buttonLimpar.TabIndex = 4;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipos de Artigo:";
            // 
            // textBoxNomeArtigo
            // 
            this.textBoxNomeArtigo.Location = new System.Drawing.Point(131, 30);
            this.textBoxNomeArtigo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNomeArtigo.Name = "textBoxNomeArtigo";
            this.textBoxNomeArtigo.Size = new System.Drawing.Size(87, 20);
            this.textBoxNomeArtigo.TabIndex = 6;
            // 
            // listBoxTiposArtigos
            // 
            this.listBoxTiposArtigos.FormattingEnabled = true;
            this.listBoxTiposArtigos.Location = new System.Drawing.Point(35, 82);
            this.listBoxTiposArtigos.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTiposArtigos.Name = "listBoxTiposArtigos";
            this.listBoxTiposArtigos.Size = new System.Drawing.Size(111, 82);
            this.listBoxTiposArtigos.TabIndex = 7;
            this.listBoxTiposArtigos.SelectedIndexChanged += new System.EventHandler(this.listBoxTiposArtigos_SelectedIndexChanged);
            // 
            // FormGestaoTiposArtigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.listBoxTiposArtigos);
            this.Controls.Add(this.textBoxNomeArtigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.labelTituloTipoArtigo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormGestaoTiposArtigo";
            this.Text = "FormGestaoTiposArtigo";
            this.Load += new System.EventHandler(this.FormGestaoTiposArtigo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTituloTipoArtigo;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNomeArtigo;
        private System.Windows.Forms.ListBox listBoxTiposArtigos;
    }
}