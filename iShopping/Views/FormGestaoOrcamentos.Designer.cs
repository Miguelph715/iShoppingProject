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
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.listBoxOrcamentos = new System.Windows.Forms.ListBox();
            this.buttonAdicionarOrcamento = new System.Windows.Forms.Button();
            this.buttonEditarOrcamento = new System.Windows.Forms.Button();
            this.buttonEliminarOrcamento = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLimparOrcamento = new System.Windows.Forms.Button();
            this.dateTimePickerDataOrcamento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(95, 93);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(148, 26);
            this.textBoxValor.TabIndex = 2;
            // 
            // listBoxOrcamentos
            // 
            this.listBoxOrcamentos.FormattingEnabled = true;
            this.listBoxOrcamentos.ItemHeight = 20;
            this.listBoxOrcamentos.Location = new System.Drawing.Point(43, 260);
            this.listBoxOrcamentos.Name = "listBoxOrcamentos";
            this.listBoxOrcamentos.Size = new System.Drawing.Size(237, 224);
            this.listBoxOrcamentos.TabIndex = 3;
            this.listBoxOrcamentos.SelectedIndexChanged += new System.EventHandler(this.listBoxOrcamentos_SelectedIndexChanged);
            // 
            // buttonAdicionarOrcamento
            // 
            this.buttonAdicionarOrcamento.Location = new System.Drawing.Point(59, 162);
            this.buttonAdicionarOrcamento.Name = "buttonAdicionarOrcamento";
            this.buttonAdicionarOrcamento.Size = new System.Drawing.Size(107, 41);
            this.buttonAdicionarOrcamento.TabIndex = 16;
            this.buttonAdicionarOrcamento.Text = "Adicionar";
            this.buttonAdicionarOrcamento.UseVisualStyleBackColor = true;
            this.buttonAdicionarOrcamento.Click += new System.EventHandler(this.buttonAdicionarOrcamento_Click);
            // 
            // buttonEditarOrcamento
            // 
            this.buttonEditarOrcamento.Location = new System.Drawing.Point(172, 162);
            this.buttonEditarOrcamento.Name = "buttonEditarOrcamento";
            this.buttonEditarOrcamento.Size = new System.Drawing.Size(108, 41);
            this.buttonEditarOrcamento.TabIndex = 17;
            this.buttonEditarOrcamento.Text = "Editar";
            this.buttonEditarOrcamento.UseVisualStyleBackColor = true;
            this.buttonEditarOrcamento.BackgroundImageLayoutChanged += new System.EventHandler(this.buttonEditarOrcamento_Click);
            this.buttonEditarOrcamento.Click += new System.EventHandler(this.buttonEditarOrcamento_Click);
            // 
            // buttonEliminarOrcamento
            // 
            this.buttonEliminarOrcamento.Location = new System.Drawing.Point(299, 162);
            this.buttonEliminarOrcamento.Name = "buttonEliminarOrcamento";
            this.buttonEliminarOrcamento.Size = new System.Drawing.Size(102, 41);
            this.buttonEliminarOrcamento.TabIndex = 18;
            this.buttonEliminarOrcamento.Text = "Eliminar";
            this.buttonEliminarOrcamento.UseVisualStyleBackColor = true;
            this.buttonEliminarOrcamento.Click += new System.EventHandler(this.buttonEliminarOrcamento_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Valor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Orçamentos:";
            // 
            // buttonLimparOrcamento
            // 
            this.buttonLimparOrcamento.Location = new System.Drawing.Point(260, 41);
            this.buttonLimparOrcamento.Name = "buttonLimparOrcamento";
            this.buttonLimparOrcamento.Size = new System.Drawing.Size(106, 63);
            this.buttonLimparOrcamento.TabIndex = 23;
            this.buttonLimparOrcamento.Text = "Limpar";
            this.buttonLimparOrcamento.UseVisualStyleBackColor = true;
            this.buttonLimparOrcamento.Click += new System.EventHandler(this.buttonLimparOrcamento_Click);
            // 
            // dateTimePickerDataOrcamento
            // 
            this.dateTimePickerDataOrcamento.Location = new System.Drawing.Point(43, 41);
            this.dateTimePickerDataOrcamento.Name = "dateTimePickerDataOrcamento";
            this.dateTimePickerDataOrcamento.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerDataOrcamento.TabIndex = 24;
            // 
            // FormGestaoOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 511);
            this.Controls.Add(this.dateTimePickerDataOrcamento);
            this.Controls.Add(this.buttonLimparOrcamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonEliminarOrcamento);
            this.Controls.Add(this.buttonEditarOrcamento);
            this.Controls.Add(this.buttonAdicionarOrcamento);
            this.Controls.Add(this.listBoxOrcamentos);
            this.Controls.Add(this.textBoxValor);
            this.Name = "FormGestaoOrcamentos";
            this.Text = "FormGestaoOrcamentos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.ListBox listBoxOrcamentos;
        private System.Windows.Forms.Button buttonAdicionarOrcamento;
        private System.Windows.Forms.Button buttonEditarOrcamento;
        private System.Windows.Forms.Button buttonEliminarOrcamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLimparOrcamento;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataOrcamento;
    }
}