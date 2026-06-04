namespace iShopping.Views
{
    partial class FormGestaoUtilizadores
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitulo = new System.Windows.Forms.Label();
            this.groupBoxDados = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.groupBoxLista = new System.Windows.Forms.GroupBox();
            this.dataGridViewUtilizadores = new System.Windows.Forms.DataGridView();
            this.groupBoxDados.SuspendLayout();
            this.groupBoxLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUtilizadores)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(20, 18);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(356, 45);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Gestão de Utilizadores";
            // 
            // groupBoxDados
            // 
            this.groupBoxDados.Controls.Add(this.textBoxPassword);
            this.groupBoxDados.Controls.Add(this.labelPassword);
            this.groupBoxDados.Controls.Add(this.textBoxUsername);
            this.groupBoxDados.Controls.Add(this.labelUsername);
            this.groupBoxDados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxDados.Location = new System.Drawing.Point(25, 65);
            this.groupBoxDados.Name = "groupBoxDados";
            this.groupBoxDados.Size = new System.Drawing.Size(520, 105);
            this.groupBoxDados.TabIndex = 1;
            this.groupBoxDados.TabStop = false;
            this.groupBoxDados.Text = "Dados do utilizador";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(120, 62);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(360, 31);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(22, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(91, 25);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(120, 30);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(360, 31);
            this.textBoxUsername.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(22, 33);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(95, 25);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonGuardar.Location = new System.Drawing.Point(570, 65);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(260, 42);
            this.buttonGuardar.TabIndex = 3;
            this.buttonGuardar.Text = "Guardar Dados";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEliminar.Location = new System.Drawing.Point(570, 125);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 45);
            this.buttonEliminar.TabIndex = 4;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonLimpar.Location = new System.Drawing.Point(708, 125);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(122, 45);
            this.buttonLimpar.TabIndex = 5;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            // 
            // groupBoxLista
            // 
            this.groupBoxLista.Controls.Add(this.dataGridViewUtilizadores);
            this.groupBoxLista.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBoxLista.Location = new System.Drawing.Point(25, 190);
            this.groupBoxLista.Name = "groupBoxLista";
            this.groupBoxLista.Size = new System.Drawing.Size(805, 285);
            this.groupBoxLista.TabIndex = 6;
            this.groupBoxLista.TabStop = false;
            this.groupBoxLista.Text = "Lista de utilizadores";
            // 
            // dataGridViewUtilizadores
            // 
            this.dataGridViewUtilizadores.AllowUserToAddRows = false;
            this.dataGridViewUtilizadores.AllowUserToDeleteRows = false;
            this.dataGridViewUtilizadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUtilizadores.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewUtilizadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUtilizadores.Location = new System.Drawing.Point(15, 25);
            this.dataGridViewUtilizadores.MultiSelect = false;
            this.dataGridViewUtilizadores.Name = "dataGridViewUtilizadores";
            this.dataGridViewUtilizadores.ReadOnly = true;
            this.dataGridViewUtilizadores.RowHeadersVisible = false;
            this.dataGridViewUtilizadores.RowHeadersWidth = 62;
            this.dataGridViewUtilizadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUtilizadores.Size = new System.Drawing.Size(775, 245);
            this.dataGridViewUtilizadores.TabIndex = 0;
            // 
            // FormGestaoUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(854, 501);
            this.Controls.Add(this.groupBoxLista);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBoxDados);
            this.Controls.Add(this.labelTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGestaoUtilizadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Utilizadores";
            this.groupBoxDados.ResumeLayout(false);
            this.groupBoxDados.PerformLayout();
            this.groupBoxLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUtilizadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.GroupBox groupBoxDados;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.GroupBox groupBoxLista;
        private System.Windows.Forms.DataGridView dataGridViewUtilizadores;
    }
}