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
            this.tipoDeArtigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orçamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTítulo = new System.Windows.Forms.Label();
            this.labelUtilizador = new System.Windows.Forms.Label();
            this.labelComprasAbertas = new System.Windows.Forms.Label();
            this.listBoxComprasAbertas = new System.Windows.Forms.ListBox();
            this.buttonAbrirModoCompra = new System.Windows.Forms.Button();
            this.groupBoxAcessosRapidos = new System.Windows.Forms.GroupBox();
            this.buttonOrcamentos = new System.Windows.Forms.Button();
            this.buttonArtigos = new System.Windows.Forms.Button();
            this.buttonPlanearCompra = new System.Windows.Forms.Button();
            this.buttonPlaneamentoCompras = new System.Windows.Forms.Button();
            this.buttonExportarComprasFechadasCsv = new System.Windows.Forms.Button();
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
            this.estatísticasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(815, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // geralToolStripMenuItem
            // 
            this.geralToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem,
            this.tipoDeArtigosToolStripMenuItem,
            this.orçamentosToolStripMenuItem});
            this.geralToolStripMenuItem.Name = "geralToolStripMenuItem";
            this.geralToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.geralToolStripMenuItem.Text = "Gestão";
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem.Click += new System.EventHandler(this.utilizadoresToolStripMenuItem_Click);
            // 
            // tipoDeArtigosToolStripMenuItem
            // 
            this.tipoDeArtigosToolStripMenuItem.Name = "tipoDeArtigosToolStripMenuItem";
            this.tipoDeArtigosToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.tipoDeArtigosToolStripMenuItem.Text = "Tipo de Artigos";
            this.tipoDeArtigosToolStripMenuItem.Click += new System.EventHandler(this.tipoDeArtigosToolStripMenuItem_Click);
            // 
            // orçamentosToolStripMenuItem
            // 
            this.orçamentosToolStripMenuItem.Name = "orçamentosToolStripMenuItem";
            this.orçamentosToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.orçamentosToolStripMenuItem.Text = "Orçamentos";
            this.orçamentosToolStripMenuItem.Click += new System.EventHandler(this.orçamentosToolStripMenuItem_Click);
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
            this.labelTítulo.Location = new System.Drawing.Point(12, 58);
            this.labelTítulo.Name = "labelTítulo";
            this.labelTítulo.Size = new System.Drawing.Size(80, 20);
            this.labelTítulo.TabIndex = 1;
            this.labelTítulo.Text = "iShopping";
            // 
            // labelUtilizador
            // 
            this.labelUtilizador.AutoSize = true;
            this.labelUtilizador.Location = new System.Drawing.Point(14, 112);
            this.labelUtilizador.Name = "labelUtilizador";
            this.labelUtilizador.Size = new System.Drawing.Size(79, 20);
            this.labelUtilizador.TabIndex = 2;
            this.labelUtilizador.Text = "Utilizador:";
            // 
            // labelComprasAbertas
            // 
            this.labelComprasAbertas.AutoSize = true;
            this.labelComprasAbertas.Location = new System.Drawing.Point(14, 149);
            this.labelComprasAbertas.Name = "labelComprasAbertas";
            this.labelComprasAbertas.Size = new System.Drawing.Size(151, 20);
            this.labelComprasAbertas.TabIndex = 3;
            this.labelComprasAbertas.Text = "Compras em Aberto";
            // 
            // listBoxComprasAbertas
            // 
            this.listBoxComprasAbertas.FormattingEnabled = true;
            this.listBoxComprasAbertas.ItemHeight = 20;
            this.listBoxComprasAbertas.Location = new System.Drawing.Point(18, 191);
            this.listBoxComprasAbertas.Name = "listBoxComprasAbertas";
            this.listBoxComprasAbertas.Size = new System.Drawing.Size(250, 224);
            this.listBoxComprasAbertas.TabIndex = 4;
            // 
            // buttonAbrirModoCompra
            // 
            this.buttonAbrirModoCompra.Location = new System.Drawing.Point(50, 420);
            this.buttonAbrirModoCompra.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAbrirModoCompra.Name = "buttonAbrirModoCompra";
            this.buttonAbrirModoCompra.Size = new System.Drawing.Size(177, 58);
            this.buttonAbrirModoCompra.TabIndex = 5;
            this.buttonAbrirModoCompra.Text = "Abrir Modo Compra";
            this.buttonAbrirModoCompra.UseVisualStyleBackColor = true;
            this.buttonAbrirModoCompra.Click += new System.EventHandler(this.buttonAbrirModoCompra_Click);
            // 
            // groupBoxAcessosRapidos
            // 
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonOrcamentos);
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonArtigos);
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonPlanearCompra);
            this.groupBoxAcessosRapidos.Controls.Add(this.buttonPlaneamentoCompras);
            this.groupBoxAcessosRapidos.Location = new System.Drawing.Point(300, 185);
            this.groupBoxAcessosRapidos.Name = "groupBoxAcessosRapidos";
            this.groupBoxAcessosRapidos.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxAcessosRapidos.Size = new System.Drawing.Size(303, 312);
            this.groupBoxAcessosRapidos.TabIndex = 6;
            this.groupBoxAcessosRapidos.TabStop = false;
            this.groupBoxAcessosRapidos.Text = "Acessos Rápidos";
            // 
            // buttonOrcamentos
            // 
            this.buttonOrcamentos.Location = new System.Drawing.Point(16, 234);
            this.buttonOrcamentos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOrcamentos.Name = "buttonOrcamentos";
            this.buttonOrcamentos.Size = new System.Drawing.Size(160, 58);
            this.buttonOrcamentos.TabIndex = 3;
            this.buttonOrcamentos.Text = "Orçamentos";
            this.buttonOrcamentos.UseVisualStyleBackColor = true;
            this.buttonOrcamentos.Click += new System.EventHandler(this.buttonOrcamentos_Click);
            // 
            // buttonArtigos
            // 
            this.buttonArtigos.Location = new System.Drawing.Point(16, 166);
            this.buttonArtigos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonArtigos.Name = "buttonArtigos";
            this.buttonArtigos.Size = new System.Drawing.Size(160, 58);
            this.buttonArtigos.TabIndex = 2;
            this.buttonArtigos.Text = "Artigos";
            this.buttonArtigos.UseVisualStyleBackColor = true;
            this.buttonArtigos.Click += new System.EventHandler(this.buttonArtigos_Click);
            // 
            // buttonPlanearCompra
            // 
            this.buttonPlanearCompra.Location = new System.Drawing.Point(16, 98);
            this.buttonPlanearCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPlanearCompra.Name = "buttonPlanearCompra";
            this.buttonPlanearCompra.Size = new System.Drawing.Size(160, 57);
            this.buttonPlanearCompra.TabIndex = 1;
            this.buttonPlanearCompra.Text = "Planear Compra";
            this.buttonPlanearCompra.UseVisualStyleBackColor = true;
            this.buttonPlanearCompra.Click += new System.EventHandler(this.buttonPlaneamentoCompras_Click);
            // 
            // buttonPlaneamentoCompras
            // 
            this.buttonPlaneamentoCompras.Location = new System.Drawing.Point(16, 29);
            this.buttonPlaneamentoCompras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPlaneamentoCompras.Name = "buttonPlaneamentoCompras";
            this.buttonPlaneamentoCompras.Size = new System.Drawing.Size(160, 60);
            this.buttonPlaneamentoCompras.TabIndex = 0;
            this.buttonPlaneamentoCompras.Text = "Planeamento Compras";
            this.buttonPlaneamentoCompras.UseVisualStyleBackColor = true;
            this.buttonPlaneamentoCompras.Click += new System.EventHandler(this.buttonCompra_Click);
            // 
            // buttonExportarComprasFechadasCsv
            // 
            this.buttonExportarComprasFechadasCsv.Location = new System.Drawing.Point(18, 483);
            this.buttonExportarComprasFechadasCsv.Name = "buttonExportarComprasFechadasCsv";
            this.buttonExportarComprasFechadasCsv.Size = new System.Drawing.Size(250, 53);
            this.buttonExportarComprasFechadasCsv.TabIndex = 7;
            this.buttonExportarComprasFechadasCsv.Text = "Exportar Compras Fechadas para CSV";
            this.buttonExportarComprasFechadasCsv.UseVisualStyleBackColor = true;
            this.buttonExportarComprasFechadasCsv.Click += new System.EventHandler(this.buttonExportarComprasFechadasCsv_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 548);
            this.Controls.Add(this.buttonExportarComprasFechadasCsv);
            this.Controls.Add(this.groupBoxAcessosRapidos);
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
        private System.Windows.Forms.ToolStripMenuItem estatísticasToolStripMenuItem;
        private System.Windows.Forms.Button buttonAbrirModoCompra;
        private System.Windows.Forms.GroupBox groupBoxAcessosRapidos;
        private System.Windows.Forms.Button buttonOrcamentos;
        private System.Windows.Forms.Button buttonArtigos;
        private System.Windows.Forms.Button buttonPlanearCompra;
        private System.Windows.Forms.Button buttonPlaneamentoCompras;
        private System.Windows.Forms.ToolStripMenuItem geralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeArtigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orçamentosToolStripMenuItem;
        private System.Windows.Forms.Button buttonExportarComprasFechadasCsv;
    }
}

