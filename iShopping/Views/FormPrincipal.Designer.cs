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
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeArtigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orçamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeArtigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeArtigosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orçamentosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.estatísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTítulo = new System.Windows.Forms.Label();
            this.labelUtilizador = new System.Windows.Forms.Label();
            this.labelComprasAbertas = new System.Windows.Forms.Label();
            this.listBoxComprasAbertas = new System.Windows.Forms.ListBox();
            this.buttonAbrirModoCompra = new System.Windows.Forms.Button();
            this.groupBoxAcessosRapidos = new System.Windows.Forms.GroupBox();
            this.buttonOrcamentos = new System.Windows.Forms.Button();
            this.buttonArtigos = new System.Windows.Forms.Button();
            this.buttonModoCompra = new System.Windows.Forms.Button();
            this.buttonPlaneamento = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxAcessosRapidos.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.geralToolStripMenuItem,
            this.tiposDeArtigosToolStripMenuItem,
            this.estatísticasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // geralToolStripMenuItem
            // 
            this.geralToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem,
            this.artigosToolStripMenuItem,
            this.tipoDeArtigosToolStripMenuItem,
            this.orçamentosToolStripMenuItem});
            this.geralToolStripMenuItem.Name = "geralToolStripMenuItem";
            this.geralToolStripMenuItem.Size = new System.Drawing.Size(55, 22);
            this.geralToolStripMenuItem.Text = "Gestão";
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            // 
            // artigosToolStripMenuItem
            // 
            this.artigosToolStripMenuItem.Name = "artigosToolStripMenuItem";
            this.artigosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.artigosToolStripMenuItem.Text = "Compras";
            this.artigosToolStripMenuItem.Click += new System.EventHandler(this.artigosToolStripMenuItem_Click);
            // 
            // tipoDeArtigosToolStripMenuItem
            // 
            this.tipoDeArtigosToolStripMenuItem.Name = "tipoDeArtigosToolStripMenuItem";
            this.tipoDeArtigosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tipoDeArtigosToolStripMenuItem.Text = "Tipo de Artigos";
            this.tipoDeArtigosToolStripMenuItem.Click += new System.EventHandler(this.tipoDeArtigosToolStripMenuItem_Click);
            // 
            // orçamentosToolStripMenuItem
            // 
            this.orçamentosToolStripMenuItem.Name = "orçamentosToolStripMenuItem";
            this.orçamentosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.orçamentosToolStripMenuItem.Text = "Orçamentos";
            this.orçamentosToolStripMenuItem.Click += new System.EventHandler(this.orçamentosToolStripMenuItem_Click);
            // 
            // tiposDeArtigosToolStripMenuItem
            // 
            this.tiposDeArtigosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposToolStripMenuItem,
            this.artigosToolStripMenuItem1,
            this.tiposDeArtigosToolStripMenuItem1,
            this.orçamentosToolStripMenuItem1});
            this.tiposDeArtigosToolStripMenuItem.Name = "tiposDeArtigosToolStripMenuItem";
            this.tiposDeArtigosToolStripMenuItem.Size = new System.Drawing.Size(12, 22);
            // 
            // tiposToolStripMenuItem
            // 
            this.tiposToolStripMenuItem.Name = "tiposToolStripMenuItem";
            this.tiposToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tiposToolStripMenuItem.Text = "Utilizadores";
            // 
            // artigosToolStripMenuItem1
            // 
            this.artigosToolStripMenuItem1.Name = "artigosToolStripMenuItem1";
            this.artigosToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.artigosToolStripMenuItem1.Text = "Artigos";
            this.artigosToolStripMenuItem1.Click += new System.EventHandler(this.artigosToolStripMenuItem1_Click);
            // 
            // tiposDeArtigosToolStripMenuItem1
            // 
            this.tiposDeArtigosToolStripMenuItem1.Name = "tiposDeArtigosToolStripMenuItem1";
            this.tiposDeArtigosToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.tiposDeArtigosToolStripMenuItem1.Text = "Tipos de Artigos";
            // 
            // orçamentosToolStripMenuItem1
            // 
            this.orçamentosToolStripMenuItem1.Name = "orçamentosToolStripMenuItem1";
            this.orçamentosToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.orçamentosToolStripMenuItem1.Text = "Orçamentos";
            // 
            // estatísticasToolStripMenuItem
            // 
            this.estatísticasToolStripMenuItem.Name = "estatísticasToolStripMenuItem";
            this.estatísticasToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.estatísticasToolStripMenuItem.Text = "Estatísticas";
            this.estatísticasToolStripMenuItem.Click += new System.EventHandler(this.estatísticasToolStripMenuItem_Click);
            // 
            // labelTítulo
            // 
            this.labelTítulo.AutoSize = true;
            this.labelTítulo.Location = new System.Drawing.Point(8, 38);
            this.labelTítulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTítulo.Name = "labelTítulo";
            this.labelTítulo.Size = new System.Drawing.Size(54, 13);
            this.labelTítulo.TabIndex = 1;
            this.labelTítulo.Text = "iShopping";
            // 
            // labelUtilizador
            // 
            this.labelUtilizador.AutoSize = true;
            this.labelUtilizador.Location = new System.Drawing.Point(9, 73);
            this.labelUtilizador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUtilizador.Name = "labelUtilizador";
            this.labelUtilizador.Size = new System.Drawing.Size(53, 13);
            this.labelUtilizador.TabIndex = 2;
            this.labelUtilizador.Text = "Utilizador:";
            // 
            // labelComprasAbertas
            // 
            this.labelComprasAbertas.AutoSize = true;
            this.labelComprasAbertas.Location = new System.Drawing.Point(9, 97);
            this.labelComprasAbertas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelComprasAbertas.Name = "labelComprasAbertas";
            this.labelComprasAbertas.Size = new System.Drawing.Size(99, 13);
            this.labelComprasAbertas.TabIndex = 3;
            this.labelComprasAbertas.Text = "Compras em Aberto";
            // 
            // listBoxComprasAbertas
            // 
            this.listBoxComprasAbertas.FormattingEnabled = true;
            this.listBoxComprasAbertas.Location = new System.Drawing.Point(11, 120);
            this.listBoxComprasAbertas.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxComprasAbertas.Name = "listBoxComprasAbertas";
            this.listBoxComprasAbertas.Size = new System.Drawing.Size(146, 95);
            this.listBoxComprasAbertas.TabIndex = 4;
            // 
            // buttonAbrirModoCompra
            // 
            this.buttonAbrirModoCompra.Location = new System.Drawing.Point(25, 232);
            this.buttonAbrirModoCompra.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAbrirModoCompra.Name = "buttonAbrirModoCompra";
            this.buttonAbrirModoCompra.Size = new System.Drawing.Size(118, 38);
            this.buttonAbrirModoCompra.TabIndex = 5;
            this.buttonAbrirModoCompra.Text = "Abrir Modo Compra";
            this.buttonAbrirModoCompra.UseVisualStyleBackColor = true;
            this.buttonAbrirModoCompra.Click += new System.EventHandler(this.buttonAbrirModoCompra_Click);
            // 
            // groupBoxAcessosRapidos
            // 
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonOrcamentos);
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonArtigos);
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonModoCompra);
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonPlaneamento);
            this.groupBoxAcessosRapidos.Location = new System.Drawing.Point(206, 12);
            this.groupBoxAcessosRapidos.Name = "groupBoxAcessosRapidos";
            this.groupBoxAcessosRapidos.Size = new System.Drawing.Size(246, 243);
            this.groupBoxAcessosRapidos.TabIndex = 6;
            this.groupBoxAcessosRapidos.TabStop = false;
            this.groupBoxAcessosRapidos.Text = "Acessos Rápidos";
            // 
            // buttonOrcamentos
            // 
            this.buttonOrcamentos.Location = new System.Drawing.Point(11, 177);
            this.buttonOrcamentos.Name = "buttonOrcamentos";
            this.buttonOrcamentos.Size = new System.Drawing.Size(125, 46);
            this.buttonOrcamentos.TabIndex = 3;
            this.buttonOrcamentos.Text = "Orçamentos";
            this.buttonOrcamentos.UseVisualStyleBackColor = true;
            this.buttonOrcamentos.Click += new System.EventHandler(this.buttonOrcamentos_Click);
            // 
            // buttonArtigos
            // 
            this.buttonArtigos.Location = new System.Drawing.Point(11, 122);
            this.buttonArtigos.Name = "buttonArtigos";
            this.buttonArtigos.Size = new System.Drawing.Size(125, 49);
            this.buttonArtigos.TabIndex = 2;
            this.buttonArtigos.Text = "Artigos";
            this.buttonArtigos.UseVisualStyleBackColor = true;
            this.buttonArtigos.Click += new System.EventHandler(this.buttonArtigos_Click);
            // 
            // buttonModoCompra
            // 
            this.buttonModoCompra.Location = new System.Drawing.Point(11, 70);
            this.buttonModoCompra.Name = "buttonModoCompra";
            this.buttonModoCompra.Size = new System.Drawing.Size(125, 46);
            this.buttonModoCompra.TabIndex = 1;
            this.buttonModoCompra.Text = "Modo Compra";
            this.buttonModoCompra.UseVisualStyleBackColor = true;
            this.buttonModoCompra.Click += new System.EventHandler(this.buttonModoCompra_Click);
            // 
            // buttonPlaneamento
            // 
            this.buttonPlaneamento.Location = new System.Drawing.Point(11, 25);
            this.buttonPlaneamento.Name = "buttonPlaneamento";
            this.buttonPlaneamento.Size = new System.Drawing.Size(125, 39);
            this.buttonPlaneamento.TabIndex = 0;
            this.buttonPlaneamento.Text = "Planeamento";
            this.buttonPlaneamento.UseVisualStyleBackColor = true;
            this.buttonPlaneamento.Click += new System.EventHandler(this.buttonPlaneamento_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxAcessosRapidos);
            this.Controls.Add(this.buttonAbrirModoCompra);
            this.Controls.Add(this.listBoxComprasAbertas);
            this.Controls.Add(this.labelComprasAbertas);
            this.Controls.Add(this.labelUtilizador);
            this.Controls.Add(this.labelTítulo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxAcessosRapidos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label labelTítulo;
        private System.Windows.Forms.Label labelUtilizador;
        private System.Windows.Forms.Label labelComprasAbertas;
        private System.Windows.Forms.ListBox listBoxComprasAbertas;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeArtigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tiposDeArtigosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem orçamentosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem estatísticasToolStripMenuItem;
        private System.Windows.Forms.Button buttonAbrirModoCompra;
        private System.Windows.Forms.GroupBox groupBoxAcessosRapidos;
        private System.Windows.Forms.Button buttonOrcamentos;
        private System.Windows.Forms.Button buttonArtigos;
        private System.Windows.Forms.Button buttonModoCompra;
        private System.Windows.Forms.Button buttonPlaneamento;
        private System.Windows.Forms.ToolStripMenuItem geralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeArtigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orçamentosToolStripMenuItem;
    }
}

