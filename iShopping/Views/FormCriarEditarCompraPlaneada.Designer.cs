namespace iShopping.Views
{
    partial class FormCriarEditarCompraPlaneada
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
            this.labelNomeCompra = new System.Windows.Forms.Label();
            this.labelTipoArtigo = new System.Windows.Forms.Label();
            this.labelArtigo = new System.Windows.Forms.Label();
            this.labelQuantidade = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAdicionarItem = new System.Windows.Forms.Button();
            this.buttonEditarItem = new System.Windows.Forms.Button();
            this.buttonEliminarItem = new System.Windows.Forms.Button();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.buttonGuardarCompra = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.listBoxItensCompra = new System.Windows.Forms.ListBox();
            this.comboBoxArtigo = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoArtigo = new System.Windows.Forms.ComboBox();
            this.textBoxNomeCompra = new System.Windows.Forms.TextBox();
            this.numericQuantidadePrevista = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantidadePrevista)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNomeCompra
            // 
            this.labelNomeCompra.AutoSize = true;
            this.labelNomeCompra.Location = new System.Drawing.Point(43, 50);
            this.labelNomeCompra.Name = "labelNomeCompra";
            this.labelNomeCompra.Size = new System.Drawing.Size(137, 20);
            this.labelNomeCompra.TabIndex = 0;
            this.labelNomeCompra.Text = "Nome da Compra:";
            // 
            // labelTipoArtigo
            // 
            this.labelTipoArtigo.AutoSize = true;
            this.labelTipoArtigo.Location = new System.Drawing.Point(43, 87);
            this.labelTipoArtigo.Name = "labelTipoArtigo";
            this.labelTipoArtigo.Size = new System.Drawing.Size(111, 20);
            this.labelTipoArtigo.TabIndex = 1;
            this.labelTipoArtigo.Text = "Tipo de Artigo:";
            // 
            // labelArtigo
            // 
            this.labelArtigo.AutoSize = true;
            this.labelArtigo.Location = new System.Drawing.Point(43, 120);
            this.labelArtigo.Name = "labelArtigo";
            this.labelArtigo.Size = new System.Drawing.Size(55, 20);
            this.labelArtigo.TabIndex = 2;
            this.labelArtigo.Text = "Artigo:";
            // 
            // labelQuantidade
            // 
            this.labelQuantidade.AutoSize = true;
            this.labelQuantidade.Location = new System.Drawing.Point(43, 154);
            this.labelQuantidade.Name = "labelQuantidade";
            this.labelQuantidade.Size = new System.Drawing.Size(96, 20);
            this.labelQuantidade.TabIndex = 3;
            this.labelQuantidade.Text = "Quantidade:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Itens da Compra";
            // 
            // buttonAdicionarItem
            // 
            this.buttonAdicionarItem.Location = new System.Drawing.Point(47, 204);
            this.buttonAdicionarItem.Name = "buttonAdicionarItem";
            this.buttonAdicionarItem.Size = new System.Drawing.Size(123, 43);
            this.buttonAdicionarItem.TabIndex = 6;
            this.buttonAdicionarItem.Text = "Adicionar Item";
            this.buttonAdicionarItem.UseVisualStyleBackColor = true;
            this.buttonAdicionarItem.Click += new System.EventHandler(this.buttonAdicionarItem_Click);
            // 
            // buttonEditarItem
            // 
            this.buttonEditarItem.Location = new System.Drawing.Point(186, 204);
            this.buttonEditarItem.Name = "buttonEditarItem";
            this.buttonEditarItem.Size = new System.Drawing.Size(136, 43);
            this.buttonEditarItem.TabIndex = 7;
            this.buttonEditarItem.Text = "Editar Item";
            this.buttonEditarItem.UseVisualStyleBackColor = true;
            this.buttonEditarItem.Click += new System.EventHandler(this.buttonEditarItem_Click);
            // 
            // buttonEliminarItem
            // 
            this.buttonEliminarItem.Location = new System.Drawing.Point(47, 253);
            this.buttonEliminarItem.Name = "buttonEliminarItem";
            this.buttonEliminarItem.Size = new System.Drawing.Size(123, 47);
            this.buttonEliminarItem.TabIndex = 8;
            this.buttonEliminarItem.Text = "Eliminar Item";
            this.buttonEliminarItem.UseVisualStyleBackColor = true;
            this.buttonEliminarItem.Click += new System.EventHandler(this.buttonRemoverItem_Click);
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(186, 253);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(136, 47);
            this.buttonLimpar.TabIndex = 9;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            //
            // buttonGuardarCompra
            // 
            this.buttonGuardarCompra.Location = new System.Drawing.Point(47, 565);
            this.buttonGuardarCompra.Name = "buttonGuardarCompra";
            this.buttonGuardarCompra.Size = new System.Drawing.Size(154, 45);
            this.buttonGuardarCompra.TabIndex = 10;
            this.buttonGuardarCompra.Text = "Guardar Compra";
            this.buttonGuardarCompra.UseVisualStyleBackColor = true;
            this.buttonGuardarCompra.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(207, 564);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(124, 46);
            this.buttonVoltar.TabIndex = 11;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            //
            // listBoxItensCompra
            // 
            this.listBoxItensCompra.FormattingEnabled = true;
            this.listBoxItensCompra.ItemHeight = 20;
            this.listBoxItensCompra.Location = new System.Drawing.Point(47, 344);
            this.listBoxItensCompra.Name = "listBoxItensCompra";
            this.listBoxItensCompra.Size = new System.Drawing.Size(336, 204);
            this.listBoxItensCompra.TabIndex = 12;
            // 
            // comboBoxArtigo
            // 
            this.comboBoxArtigo.FormattingEnabled = true;
            this.comboBoxArtigo.Location = new System.Drawing.Point(186, 121);
            this.comboBoxArtigo.Name = "comboBoxArtigo";
            this.comboBoxArtigo.Size = new System.Drawing.Size(136, 28);
            this.comboBoxArtigo.TabIndex = 14;
            // 
            // comboBoxTipoArtigo
            // 
            this.comboBoxTipoArtigo.FormattingEnabled = true;
            this.comboBoxTipoArtigo.Location = new System.Drawing.Point(186, 87);
            this.comboBoxTipoArtigo.Name = "comboBoxTipoArtigo";
            this.comboBoxTipoArtigo.Size = new System.Drawing.Size(136, 28);
            this.comboBoxTipoArtigo.TabIndex = 15;
            this.comboBoxTipoArtigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoArtigo_SelectedIndexChanged);
            // 
            // textBoxNomeCompra
            // 
            this.textBoxNomeCompra.Location = new System.Drawing.Point(186, 47);
            this.textBoxNomeCompra.Name = "textBoxNomeCompra";
            this.textBoxNomeCompra.Size = new System.Drawing.Size(136, 26);
            this.textBoxNomeCompra.TabIndex = 16;
            // 
            // numericQuantidadePrevista
            // 
            this.numericQuantidadePrevista.Location = new System.Drawing.Point(186, 155);
            this.numericQuantidadePrevista.Name = "numericQuantidadePrevista";
            this.numericQuantidadePrevista.Size = new System.Drawing.Size(136, 26);
            this.numericQuantidadePrevista.TabIndex = 17;
            // 
            // FormCriarEditarCompraPlaneada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 641);
            this.Controls.Add(this.numericQuantidadePrevista);
            this.Controls.Add(this.textBoxNomeCompra);
            this.Controls.Add(this.comboBoxTipoArtigo);
            this.Controls.Add(this.comboBoxArtigo);
            this.Controls.Add(this.listBoxItensCompra);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonGuardarCompra);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.buttonEliminarItem);
            this.Controls.Add(this.buttonEditarItem);
            this.Controls.Add(this.buttonAdicionarItem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelQuantidade);
            this.Controls.Add(this.labelArtigo);
            this.Controls.Add(this.labelTipoArtigo);
            this.Controls.Add(this.labelNomeCompra);
            this.Name = "FormCriarEditarCompraPlaneada";
            this.Text = "FormCriarEditarCompraPlaneada";
            this.Load += new System.EventHandler(this.FormCriarEditarCompraPlaneada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantidadePrevista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNomeCompra;
        private System.Windows.Forms.Label labelTipoArtigo;
        private System.Windows.Forms.Label labelArtigo;
        private System.Windows.Forms.Label labelQuantidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAdicionarItem;
        private System.Windows.Forms.Button buttonEditarItem;
        private System.Windows.Forms.Button buttonEliminarItem;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Button buttonGuardarCompra;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.ListBox listBoxItensCompra;
        private System.Windows.Forms.ComboBox comboBoxArtigo;
        private System.Windows.Forms.ComboBox comboBoxTipoArtigo;
        private System.Windows.Forms.TextBox textBoxNomeCompra;
        private System.Windows.Forms.NumericUpDown numericQuantidadePrevista;
    }
}