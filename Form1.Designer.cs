
namespace projetoSistemasLineares {
    partial class frmPrincipal {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gridSistema = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQtdVars = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnImportarSistemas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdVars)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSistema
            // 
            this.gridSistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSistema.Location = new System.Drawing.Point(164, 12);
            this.gridSistema.Name = "gridSistema";
            this.gridSistema.Size = new System.Drawing.Size(675, 199);
            this.gridSistema.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Variáveis";
            // 
            // txtQtdVars
            // 
            this.txtQtdVars.Location = new System.Drawing.Point(12, 160);
            this.txtQtdVars.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtQtdVars.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQtdVars.Name = "txtQtdVars";
            this.txtQtdVars.Size = new System.Drawing.Size(57, 20);
            this.txtQtdVars.TabIndex = 2;
            this.txtQtdVars.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtQtdVars.ValueChanged += new System.EventHandler(this.txtQtdVars_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Exemplo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Calcular";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnImportarSistemas
            // 
            this.btnImportarSistemas.Location = new System.Drawing.Point(12, 91);
            this.btnImportarSistemas.Name = "btnImportarSistemas";
            this.btnImportarSistemas.Size = new System.Drawing.Size(133, 23);
            this.btnImportarSistemas.TabIndex = 5;
            this.btnImportarSistemas.Text = "Importar e Calcular";
            this.btnImportarSistemas.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 436);
            this.Controls.Add(this.btnImportarSistemas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtQtdVars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridSistema);
            this.Name = "frmPrincipal";
            this.Text = "Sistemas Lineares - Gauss";
            ((System.ComponentModel.ISupportInitialize)(this.gridSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdVars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtQtdVars;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnImportarSistemas;
    }
}

