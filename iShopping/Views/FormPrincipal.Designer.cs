namespace iShopping
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeArtigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeArtigosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orçamentosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planeamentoDeComprasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modoCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTítulo = new System.Windows.Forms.Label();
            this.labelUtilizador = new System.Windows.Forms.Label();
            this.labelComprasAbertas = new System.Windows.Forms.Label();
            this.listBoxComprasAbertas = new System.Windows.Forms.ListBox();
            this.buttonAbrirModoCompra = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem,
            this.tiposDeArtigosToolStripMenuItem,
            this.artigosToolStripMenuItem,
            this.estatísticasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.utilizadoresToolStripMenuItem.Text = "Sair";
            // 
            // tiposDeArtigosToolStripMenuItem
            // 
            this.tiposDeArtigosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposToolStripMenuItem,
            this.artigosToolStripMenuItem1,
            this.tiposDeArtigosToolStripMenuItem1,
            this.orçamentosToolStripMenuItem1});
            this.tiposDeArtigosToolStripMenuItem.Name = "tiposDeArtigosToolStripMenuItem";
            this.tiposDeArtigosToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.tiposDeArtigosToolStripMenuItem.Text = "Gestão";
            // 
            // tiposToolStripMenuItem
            // 
            this.tiposToolStripMenuItem.Name = "tiposToolStripMenuItem";
            this.tiposToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.tiposToolStripMenuItem.Text = "Utilizadores";
            // 
            // artigosToolStripMenuItem1
            // 
            this.artigosToolStripMenuItem1.Name = "artigosToolStripMenuItem1";
            this.artigosToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.artigosToolStripMenuItem1.Text = "Artigos";
            // 
            // tiposDeArtigosToolStripMenuItem1
            // 
            this.tiposDeArtigosToolStripMenuItem1.Name = "tiposDeArtigosToolStripMenuItem1";
            this.tiposDeArtigosToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.tiposDeArtigosToolStripMenuItem1.Text = "Tipos de Artigos";
            this.tiposDeArtigosToolStripMenuItem1.Click += new System.EventHandler(this.tiposDeArtigosToolStripMenuItem1_Click);
            // 
            // orçamentosToolStripMenuItem1
            // 
            this.orçamentosToolStripMenuItem1.Name = "orçamentosToolStripMenuItem1";
            this.orçamentosToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.orçamentosToolStripMenuItem1.Text = "Orçamentos";
            // 
            // artigosToolStripMenuItem
            // 
            this.artigosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planeamentoDeComprasToolStripMenuItem1,
            this.modoCompraToolStripMenuItem});
            this.artigosToolStripMenuItem.Name = "artigosToolStripMenuItem";
            this.artigosToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.artigosToolStripMenuItem.Text = "Compras";
            // 
            // planeamentoDeComprasToolStripMenuItem1
            // 
            this.planeamentoDeComprasToolStripMenuItem1.Name = "planeamentoDeComprasToolStripMenuItem1";
            this.planeamentoDeComprasToolStripMenuItem1.Size = new System.Drawing.Size(319, 34);
            this.planeamentoDeComprasToolStripMenuItem1.Text = "Planeamento de Compras";
            // 
            // modoCompraToolStripMenuItem
            // 
            this.modoCompraToolStripMenuItem.Name = "modoCompraToolStripMenuItem";
            this.modoCompraToolStripMenuItem.Size = new System.Drawing.Size(319, 34);
            this.modoCompraToolStripMenuItem.Text = "Modo Compra";
            // 
            // estatísticasToolStripMenuItem
            // 
            this.estatísticasToolStripMenuItem.Name = "estatísticasToolStripMenuItem";
            this.estatísticasToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
            this.estatísticasToolStripMenuItem.Text = "Estatísticas";
            this.estatísticasToolStripMenuItem.Click += new System.EventHandler(this.estatísticasToolStripMenuItem_Click);
            // 
            // labelTítulo
            // 
            this.labelTítulo.AutoSize = true;
            this.labelTítulo.Location = new System.Drawing.Point(12, 59);
            this.labelTítulo.Name = "labelTítulo";
            this.labelTítulo.Size = new System.Drawing.Size(80, 20);
            this.labelTítulo.TabIndex = 1;
            this.labelTítulo.Text = "iShopping";
            // 
            // labelUtilizador
            // 
            this.labelUtilizador.AutoSize = true;
            this.labelUtilizador.Location = new System.Drawing.Point(13, 113);
            this.labelUtilizador.Name = "labelUtilizador";
            this.labelUtilizador.Size = new System.Drawing.Size(79, 20);
            this.labelUtilizador.TabIndex = 2;
            this.labelUtilizador.Text = "Utilizador:";
            // 
            // labelComprasAbertas
            // 
            this.labelComprasAbertas.AutoSize = true;
            this.labelComprasAbertas.Location = new System.Drawing.Point(13, 149);
            this.labelComprasAbertas.Name = "labelComprasAbertas";
            this.labelComprasAbertas.Size = new System.Drawing.Size(151, 20);
            this.labelComprasAbertas.TabIndex = 3;
            this.labelComprasAbertas.Text = "Compras em Aberto";
            // 
            // listBoxComprasAbertas
            // 
            this.listBoxComprasAbertas.FormattingEnabled = true;
            this.listBoxComprasAbertas.ItemHeight = 20;
            this.listBoxComprasAbertas.Location = new System.Drawing.Point(17, 185);
            this.listBoxComprasAbertas.Name = "listBoxComprasAbertas";
            this.listBoxComprasAbertas.Size = new System.Drawing.Size(217, 144);
            this.listBoxComprasAbertas.TabIndex = 4;
            // 
            // buttonAbrirModoCompra
            // 
            this.buttonAbrirModoCompra.Location = new System.Drawing.Point(18, 358);
            this.buttonAbrirModoCompra.Name = "buttonAbrirModoCompra";
            this.buttonAbrirModoCompra.Size = new System.Drawing.Size(177, 59);
            this.buttonAbrirModoCompra.TabIndex = 5;
            this.buttonAbrirModoCompra.Text = "Abrir Modo Compra";
            this.buttonAbrirModoCompra.UseVisualStyleBackColor = true;
            this.buttonAbrirModoCompra.Click += new System.EventHandler(this.buttonAbrirModoCompra_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAbrirModoCompra);
            this.Controls.Add(this.listBoxComprasAbertas);
            this.Controls.Add(this.labelComprasAbertas);
            this.Controls.Add(this.labelUtilizador);
            this.Controls.Add(this.labelTítulo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label labelTítulo;
        private System.Windows.Forms.Label labelUtilizador;
        private System.Windows.Forms.Label labelComprasAbertas;
        private System.Windows.Forms.ListBox listBoxComprasAbertas;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeArtigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tiposDeArtigosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem orçamentosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planeamentoDeComprasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modoCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatísticasToolStripMenuItem;
        private System.Windows.Forms.Button buttonAbrirModoCompra;
    }
}

