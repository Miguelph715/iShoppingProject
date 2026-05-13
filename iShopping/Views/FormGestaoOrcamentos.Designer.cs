namespace iShopping.Views
{
    partial class FormGestaoOrcamentos
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
            this.textBoxMes = new System.Windows.Forms.TextBox();
            this.textBoxAno = new System.Windows.Forms.TextBox();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.listBoxOrcamentos = new System.Windows.Forms.ListBox();
            this.buttonAdicionarOrcamento = new System.Windows.Forms.Button();
            this.buttonEditarOrcamento = new System.Windows.Forms.Button();
            this.buttonEliminarOrcamento = new System.Windows.Forms.Button();
            this.labelMes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLimparOrcamento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMes
            // 
            this.textBoxMes.Location = new System.Drawing.Point(108, 62);
            this.textBoxMes.Name = "textBoxMes";
            this.textBoxMes.Size = new System.Drawing.Size(100, 26);
            this.textBoxMes.TabIndex = 0;
            // 
            // textBoxAno
            // 
            this.textBoxAno.Location = new System.Drawing.Point(108, 102);
            this.textBoxAno.Name = "textBoxAno";
            this.textBoxAno.Size = new System.Drawing.Size(100, 26);
            this.textBoxAno.TabIndex = 1;
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(108, 144);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(100, 26);
            this.textBoxValor.TabIndex = 2;
            // 
            // listBoxOrcamentos
            // 
            this.listBoxOrcamentos.FormattingEnabled = true;
            this.listBoxOrcamentos.ItemHeight = 20;
            this.listBoxOrcamentos.Location = new System.Drawing.Point(43, 276);
            this.listBoxOrcamentos.Name = "listBoxOrcamentos";
            this.listBoxOrcamentos.Size = new System.Drawing.Size(237, 224);
            this.listBoxOrcamentos.TabIndex = 3;
            // 
            // buttonAdicionarOrcamento
            // 
            this.buttonAdicionarOrcamento.Location = new System.Drawing.Point(43, 190);
            this.buttonAdicionarOrcamento.Name = "buttonAdicionarOrcamento";
            this.buttonAdicionarOrcamento.Size = new System.Drawing.Size(107, 41);
            this.buttonAdicionarOrcamento.TabIndex = 16;
            this.buttonAdicionarOrcamento.Text = "Adicionar";
            this.buttonAdicionarOrcamento.UseVisualStyleBackColor = true;
            this.buttonAdicionarOrcamento.Click += new System.EventHandler(this.buttonAdicionarOrcamento_Click);
            // 
            // buttonEditarOrcamento
            // 
            this.buttonEditarOrcamento.Location = new System.Drawing.Point(172, 190);
            this.buttonEditarOrcamento.Name = "buttonEditarOrcamento";
            this.buttonEditarOrcamento.Size = new System.Drawing.Size(108, 41);
            this.buttonEditarOrcamento.TabIndex = 17;
            this.buttonEditarOrcamento.Text = "Editar";
            this.buttonEditarOrcamento.UseVisualStyleBackColor = true;
            // 
            // buttonEliminarOrcamento
            // 
            this.buttonEliminarOrcamento.Location = new System.Drawing.Point(307, 190);
            this.buttonEliminarOrcamento.Name = "buttonEliminarOrcamento";
            this.buttonEliminarOrcamento.Size = new System.Drawing.Size(102, 41);
            this.buttonEliminarOrcamento.TabIndex = 18;
            this.buttonEliminarOrcamento.Text = "Eliminar";
            this.buttonEliminarOrcamento.UseVisualStyleBackColor = true;
            // 
            // labelMes
            // 
            this.labelMes.AutoSize = true;
            this.labelMes.Location = new System.Drawing.Point(39, 62);
            this.labelMes.Name = "labelMes";
            this.labelMes.Size = new System.Drawing.Size(43, 20);
            this.labelMes.TabIndex = 19;
            this.labelMes.Text = "Mês:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ano:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Valor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Orçamentos:";
            // 
            // buttonLimparOrcamento
            // 
            this.buttonLimparOrcamento.Location = new System.Drawing.Point(254, 87);
            this.buttonLimparOrcamento.Name = "buttonLimparOrcamento";
            this.buttonLimparOrcamento.Size = new System.Drawing.Size(106, 63);
            this.buttonLimparOrcamento.TabIndex = 23;
            this.buttonLimparOrcamento.Text = "Limpar";
            this.buttonLimparOrcamento.UseVisualStyleBackColor = true;
            // 
            // FormGestaoOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 511);
            this.Controls.Add(this.buttonLimparOrcamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMes);
            this.Controls.Add(this.buttonEliminarOrcamento);
            this.Controls.Add(this.buttonEditarOrcamento);
            this.Controls.Add(this.buttonAdicionarOrcamento);
            this.Controls.Add(this.listBoxOrcamentos);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.textBoxAno);
            this.Controls.Add(this.textBoxMes);
            this.Name = "FormGestaoOrcamentos";
            this.Text = "FormGestaoOrcamentos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMes;
        private System.Windows.Forms.TextBox textBoxAno;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.ListBox listBoxOrcamentos;
        private System.Windows.Forms.Button buttonAdicionarOrcamento;
        private System.Windows.Forms.Button buttonEditarOrcamento;
        private System.Windows.Forms.Button buttonEliminarOrcamento;
        private System.Windows.Forms.Label labelMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLimparOrcamento;
    }
}