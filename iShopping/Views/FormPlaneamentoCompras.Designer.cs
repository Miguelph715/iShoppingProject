namespace iShopping.Views
{
    partial class FormPlaneamentoCompras
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
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.listBoxCompras = new System.Windows.Forms.ListBox();
            this.buttonNovaCompra = new System.Windows.Forms.Button();
            this.labelCompras = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.buttonEditarCompra = new System.Windows.Forms.Button();
            this.buttonLimparCompras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Location = new System.Drawing.Point(127, 52);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(121, 28);
            this.comboBoxEstado.TabIndex = 0;
            // 
            // listBoxCompras
            // 
            this.listBoxCompras.FormattingEnabled = true;
            this.listBoxCompras.ItemHeight = 20;
            this.listBoxCompras.Location = new System.Drawing.Point(46, 148);
            this.listBoxCompras.Name = "listBoxCompras";
            this.listBoxCompras.Size = new System.Drawing.Size(259, 224);
            this.listBoxCompras.TabIndex = 1;
            // 
            // buttonNovaCompra
            // 
            this.buttonNovaCompra.Location = new System.Drawing.Point(46, 377);
            this.buttonNovaCompra.Name = "buttonNovaCompra";
            this.buttonNovaCompra.Size = new System.Drawing.Size(124, 61);
            this.buttonNovaCompra.TabIndex = 17;
            this.buttonNovaCompra.Text = "Nova Compra";
            this.buttonNovaCompra.UseVisualStyleBackColor = true;
            // 
            // labelCompras
            // 
            this.labelCompras.AutoSize = true;
            this.labelCompras.Location = new System.Drawing.Point(42, 119);
            this.labelCompras.Name = "labelCompras";
            this.labelCompras.Size = new System.Drawing.Size(73, 20);
            this.labelCompras.TabIndex = 25;
            this.labelCompras.Text = "Compras";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(42, 52);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(64, 20);
            this.labelEstado.TabIndex = 26;
            this.labelEstado.Text = "Estado:";
            // 
            // buttonEditarCompra
            // 
            this.buttonEditarCompra.Location = new System.Drawing.Point(193, 377);
            this.buttonEditarCompra.Name = "buttonEditarCompra";
            this.buttonEditarCompra.Size = new System.Drawing.Size(112, 61);
            this.buttonEditarCompra.TabIndex = 18;
            this.buttonEditarCompra.Text = "Editar Compra";
            this.buttonEditarCompra.UseVisualStyleBackColor = true;
            // 
            // buttonLimparCompras
            // 
            this.buttonLimparCompras.Location = new System.Drawing.Point(322, 148);
            this.buttonLimparCompras.Name = "buttonLimparCompras";
            this.buttonLimparCompras.Size = new System.Drawing.Size(106, 63);
            this.buttonLimparCompras.TabIndex = 24;
            this.buttonLimparCompras.Text = "Limpar";
            this.buttonLimparCompras.UseVisualStyleBackColor = true;
            this.buttonLimparCompras.Click += new System.EventHandler(this.buttonLimparCompras_Click);
            // 
            // FormPlaneamentoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 457);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.labelCompras);
            this.Controls.Add(this.buttonLimparCompras);
            this.Controls.Add(this.buttonEditarCompra);
            this.Controls.Add(this.buttonNovaCompra);
            this.Controls.Add(this.listBoxCompras);
            this.Controls.Add(this.comboBoxEstado);
            this.Name = "FormPlaneamentoCompras";
            this.Text = "FormPlaneamentoCompras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.ListBox listBoxCompras;
        private System.Windows.Forms.Button buttonNovaCompra;
        private System.Windows.Forms.Label labelCompras;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Button buttonEditarCompra;
        private System.Windows.Forms.Button buttonLimparCompras;
    }
}