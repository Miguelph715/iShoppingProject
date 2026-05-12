namespace iShopping.Views
{
    partial class FormEstatisticas
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
            this.tabControlEstatisticas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxOrcamentosComprasMes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxPercentagemArtigos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonGerarSugestoes = new System.Windows.Forms.Button();
            this.listBoxSugestoes = new System.Windows.Forms.ListBox();
            this.tabControlEstatisticas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEstatisticas
            // 
            this.tabControlEstatisticas.Controls.Add(this.tabPage1);
            this.tabControlEstatisticas.Controls.Add(this.tabPage2);
            this.tabControlEstatisticas.Location = new System.Drawing.Point(43, 41);
            this.tabControlEstatisticas.Name = "tabControlEstatisticas";
            this.tabControlEstatisticas.SelectedIndex = 0;
            this.tabControlEstatisticas.Size = new System.Drawing.Size(697, 377);
            this.tabControlEstatisticas.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxPercentagemArtigos);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listBoxOrcamentosComprasMes);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(689, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxSugestoes);
            this.tabPage2.Controls.Add(this.buttonGerarSugestoes);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(689, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orçamentos e Compras por Mês";
            // 
            // listBoxOrcamentosComprasMes
            // 
            this.listBoxOrcamentosComprasMes.FormattingEnabled = true;
            this.listBoxOrcamentosComprasMes.ItemHeight = 20;
            this.listBoxOrcamentosComprasMes.Location = new System.Drawing.Point(10, 65);
            this.listBoxOrcamentosComprasMes.Name = "listBoxOrcamentosComprasMes";
            this.listBoxOrcamentosComprasMes.Size = new System.Drawing.Size(246, 204);
            this.listBoxOrcamentosComprasMes.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Percentagem de artigos previstos e não previstos";
            // 
            // listBoxPercentagemArtigos
            // 
            this.listBoxPercentagemArtigos.FormattingEnabled = true;
            this.listBoxPercentagemArtigos.ItemHeight = 20;
            this.listBoxPercentagemArtigos.Location = new System.Drawing.Point(314, 63);
            this.listBoxPercentagemArtigos.Name = "listBoxPercentagemArtigos";
            this.listBoxPercentagemArtigos.Size = new System.Drawing.Size(352, 204);
            this.listBoxPercentagemArtigos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sugestões de orçamento e lista de compras";
            // 
            // buttonGerarSugestoes
            // 
            this.buttonGerarSugestoes.Location = new System.Drawing.Point(19, 56);
            this.buttonGerarSugestoes.Name = "buttonGerarSugestoes";
            this.buttonGerarSugestoes.Size = new System.Drawing.Size(141, 32);
            this.buttonGerarSugestoes.TabIndex = 1;
            this.buttonGerarSugestoes.Text = "Gerar Sugestões";
            this.buttonGerarSugestoes.UseVisualStyleBackColor = true;
            // 
            // listBoxSugestoes
            // 
            this.listBoxSugestoes.FormattingEnabled = true;
            this.listBoxSugestoes.ItemHeight = 20;
            this.listBoxSugestoes.Location = new System.Drawing.Point(19, 115);
            this.listBoxSugestoes.Name = "listBoxSugestoes";
            this.listBoxSugestoes.Size = new System.Drawing.Size(321, 204);
            this.listBoxSugestoes.TabIndex = 2;
            // 
            // FormEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlEstatisticas);
            this.Name = "FormEstatisticas";
            this.Text = "FormEstatisticas";
            this.tabControlEstatisticas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlEstatisticas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxPercentagemArtigos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxOrcamentosComprasMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxSugestoes;
        private System.Windows.Forms.Button buttonGerarSugestoes;
        private System.Windows.Forms.Label label3;
    }
}