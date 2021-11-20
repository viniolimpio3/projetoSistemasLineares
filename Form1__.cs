using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoSistemasLineares {

    public partial class frmPrincipal : Form {

        const int QTD_VARS_DEFAULT = 3;
        const string DADOS_FILENAME = "";
        const int QTD_MAX_SISTEMAS = 100;

        struct Sistema {
            public int qtd_var;
            public Linha[] linhas;
        }

        struct Linha {
            public int indice;
            //is resulta
            public double valor;
        }

        public frmPrincipal() {
            InitializeComponent();

            //Inicializando a quantidade de variáveis de acordo com a constante setada acima
            txtQtdVars.Value = QTD_VARS_DEFAULT;

            this.setGridVars(Convert.ToInt32(txtQtdVars.Value));
        }

        /// <summary>
        /// Seta A quantidade de Variáveis no grid de acord com qtd passada!
        /// </summary>
        public void setGridVars(int qtd) {
                        
            //Remove Todas as Colunas
            gridSistema.Columns.Clear();

            //Adiciona Colunas de acordo com a qtd de variáveis solicitadas
            for(int i = 1; i <= qtd; i++) {
                gridSistema.Columns.Add($"x{i}", $"X{i}");
                gridSistema.Rows.Add();
            }


            //Seta a última coluna "Resultado"
            gridSistema.Columns.Add("result", "Resultado");
        }

        //CONTINUAR
        private Sistema[] leArquivo() {
            Sistema[] sistemas = new Sistema[QTD_MAX_SISTEMAS];

            OpenFileDialog dialog = new OpenFileDialog();



            if (dialog.ShowDialog() == DialogResult.OK) {
                string filename = dialog.FileName;

            }

            return sistemas;
        }
           
        //CONTINUAR
        private void calcula(Sistema[] sistemas) {

            for(int i =0; i < sistemas.Length; i++) {

                Sistema s = sistemas[i];

                double[,] matrix = new double[s.qtd_var, s.qtd_var + 1];


                for(int j=0; j < s.linhas.Length; j++) {
                    Linha l = s.linhas[j];
                    

                }



            }
            foreach(Sistema sistema in sistemas) {
                foreach(Linha linha in sistema.linhas) {

                }
            }
        }

        private void txtQtdVars_ValueChanged(object sender, EventArgs e) {

            int value = 0;
            bool isValido = Int32.TryParse(txtQtdVars.Value.ToString(), out value);


            if(isValido && value > 0) 
                this.setGridVars(value);
             else 
                MessageBox.Show("Erro!", "Digite um número de variáveis válido!");
            

        }

        private void btnImportarSistemas_Click(object sender, EventArgs e) {
            Sistema[] sistemas = this.leArquivo();


        }
    }
}
