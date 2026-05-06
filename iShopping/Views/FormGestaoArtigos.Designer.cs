namespace iShopping.Views
{
    partial class FormGestaoArtigos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFiltroTipo = new System.Windows.Forms.ComboBox();
            this.textBoxNomeArtigo = new System.Windows.Forms.TextBox();
            this.comboBoxTipoArtigo = new System.Windows.Forms.ComboBox();
            this.buttonAdicionarArtigo = new System.Windows.Forms.Button();
            this.buttonEditarArtigo = new System.Windows.Forms.Button();
            this.buttonEliminarArtigo = new System.Windows.Forms.Button();
            this.listBoxArtigos = new System.Windows.Forms.ListBox();
            this.buttonLimparArtigo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtrar por Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome do Artigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Artigo:";
            // 
            // comboBoxFiltroTipo
            // 
            this.comboBoxFiltroTipo.FormattingEnabled = true;
            this.comboBoxFiltroTipo.Location = new System.Drawing.Point(171, 42);
            this.comboBoxFiltroTipo.Name = "comboBoxFiltroTipo";
            this.comboBoxFiltroTipo.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFiltroTipo.TabIndex = 10;
            // 
            // textBoxNomeArtigo
            // 
            this.textBoxNomeArtigo.Location = new System.Drawing.Point(171, 95);
            this.textBoxNomeArtigo.Name = "textBoxNomeArtigo";
            this.textBoxNomeArtigo.Size = new System.Drawing.Size(121, 26);
            this.textBoxNomeArtigo.TabIndex = 13;
            // 
            // comboBoxTipoArtigo
            // 
            this.comboBoxTipoArtigo.FormattingEnabled = true;
            this.comboBoxTipoArtigo.Location = new System.Drawing.Point(171, 144);
            this.comboBoxTipoArtigo.Name = "comboBoxTipoArtigo";
            this.comboBoxTipoArtigo.Size = new System.Drawing.Size(121, 28);
            this.comboBoxTipoArtigo.TabIndex = 14;
            // 
            // buttonAdicionarArtigo
            // 
            this.buttonAdicionarArtigo.Location = new System.Drawing.Point(37, 204);
            this.buttonAdicionarArtigo.Name = "buttonAdicionarArtigo";
            this.buttonAdicionarArtigo.Size = new System.Drawing.Size(107, 41);
            this.buttonAdicionarArtigo.TabIndex = 15;
            this.buttonAdicionarArtigo.Text = "Adicionar";
            this.buttonAdicionarArtigo.UseVisualStyleBackColor = true;
            // 
            // buttonEditarArtigo
            // 
            this.buttonEditarArtigo.Location = new System.Drawing.Point(171, 204);
            this.buttonEditarArtigo.Name = "buttonEditarArtigo";
            this.buttonEditarArtigo.Size = new System.Drawing.Size(108, 41);
            this.buttonEditarArtigo.TabIndex = 16;
            this.buttonEditarArtigo.Text = "Editar";
            this.buttonEditarArtigo.UseVisualStyleBackColor = true;
            // 
            // buttonEliminarArtigo
            // 
            this.buttonEliminarArtigo.Location = new System.Drawing.Point(306, 204);
            this.buttonEliminarArtigo.Name = "buttonEliminarArtigo";
            this.buttonEliminarArtigo.Size = new System.Drawing.Size(102, 41);
            this.buttonEliminarArtigo.TabIndex = 17;
            this.buttonEliminarArtigo.Text = "Eliminar";
            this.buttonEliminarArtigo.UseVisualStyleBackColor = true;
            // 
            // listBoxArtigos
            // 
            this.listBoxArtigos.FormattingEnabled = true;
            this.listBoxArtigos.ItemHeight = 20;
            this.listBoxArtigos.Location = new System.Drawing.Point(37, 269);
            this.listBoxArtigos.Name = "listBoxArtigos";
            this.listBoxArtigos.Size = new System.Drawing.Size(371, 244);
            this.listBoxArtigos.TabIndex = 19;
            // 
            // buttonLimparArtigo
            // 
            this.buttonLimparArtigo.Location = new System.Drawing.Point(306, 80);
            this.buttonLimparArtigo.Name = "buttonLimparArtigo";
            this.buttonLimparArtigo.Size = new System.Drawing.Size(102, 84);
            this.buttonLimparArtigo.TabIndex = 18;
            this.buttonLimparArtigo.Text = "Limpar";
            this.buttonLimparArtigo.UseVisualStyleBackColor = true;
            // 
            // FormGestaoArtigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 545);
            this.Controls.Add(this.listBoxArtigos);
            this.Controls.Add(this.buttonLimparArtigo);
            this.Controls.Add(this.buttonEliminarArtigo);
            this.Controls.Add(this.buttonEditarArtigo);
            this.Controls.Add(this.buttonAdicionarArtigo);
            this.Controls.Add(this.comboBoxTipoArtigo);
            this.Controls.Add(this.textBoxNomeArtigo);
            this.Controls.Add(this.comboBoxFiltroTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormGestaoArtigos";
            this.Text = "FormGestaoArtigos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxFiltroTipo;
        private System.Windows.Forms.TextBox textBoxNomeArtigo;
        private System.Windows.Forms.ComboBox comboBoxTipoArtigo;
        private System.Windows.Forms.Button buttonAdicionarArtigo;
        private System.Windows.Forms.Button buttonEditarArtigo;
        private System.Windows.Forms.Button buttonEliminarArtigo;
        private System.Windows.Forms.ListBox listBoxArtigos;
        private System.Windows.Forms.Button buttonLimparArtigo;
    }
}