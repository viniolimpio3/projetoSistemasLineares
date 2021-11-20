using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            public double[] valores;
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

                if (File.Exists(dialog.FileName)) {
                    string[] linhas = File.ReadAllLines(dialog.FileName);

                    bool newSistema = true;
                    int countSis = 0;
                    int countLinhas = 0;
                    Sistema lastSistema = new Sistema();

                    for(int i=0; i < linhas.Length; i++) {


                        if (newSistema) {
                            lastSistema = new Sistema();
                            newSistema = false;
                            countLinhas = 0;
                        } else {
                            countLinhas++;
                            if (countLinhas == lastSistema.qtd_var - 1) {
                                newSistema = true;
                                countSis++;
                            }
                        }

                        string[] arr = linhas[i].Split(';');

                        lastSistema.qtd_var = arr.Length - 1;

                        if (countLinhas == 0) {
                            lastSistema.linhas = new Linha[lastSistema.qtd_var + 1];
                        }

                        lastSistema.linhas[countLinhas].valores = new double[lastSistema.qtd_var + 1];

                        for(int j=0; j < arr.Length; j++) {
                            lastSistema.linhas[countLinhas].valores[j] = double.Parse(arr[j]);
                        }

                        sistemas[countSis] = lastSistema;

                    }

                }
            }

            return sistemas;
        }
           
        //CONTINUAR
        private void calcula(Sistema[] sistemas) {

            for(int i =0; i < sistemas.Length; i++) {

                Linha[] linhas = sistemas[i].linhas;

                //Linhas
                for(int j=0; j < linhas.Length; j++) {

                    
                   //se não for a última linha, verificar o valor da mesma coluna na próxima linha
                   //Caso tenha o mesmo valor, só inverter os sinas da próxima linha e somar na matrix
                   if(j != (linhas.Length - 1)) {
                        //Linha x Coluna

                        int indexNotZero = Array.IndexOf(linhas[j].valores, 0) + 1;

                        if(indexNotZero == sistemas[i].qtd_var) {
                            //chegou na última linha, sem mais somas pra fazer - 
                        }

                        //linha auxiliar  - para não modificar a Linha Final
                        Linha lSoma = linhas[j];
                        Linha lSomaProx = linhas[j + 1];

                        double valor_atual = lSoma.valores[indexNotZero];
                        double valor_prox_col = lSomaProx.valores[indexNotZero];

                        if (valor_atual == valor_prox_col) {

                            for (int v = 0; v <= sistemas[i].qtd_var; v++)
                                lSoma.valores[v] = -lSoma.valores[v];



                        } else if (valor_atual == -valor_prox_col) {
                            //caso sejam iguais, com sinais diferentes, apenas somar linha

                        } else if(valor_atual % valor_prox_col == 0 || valor_prox_col % valor_atual == 0) {
                            //Valores diferentes - mas a divisão é resto zero - só multiplica a linha do menor número

                            if(valor_atual > valor_prox_col) {
                                //multiplicar a proxima linha pelo valor atual

                                double multiplicador = valor_atual;
                                if (!(valor_atual > 0 && valor_prox_col < 0) || !(valor_atual < 0 && valor_prox_col > 0))
                                    multiplicador = -valor_atual;

                                for (int v = 0; v <= sistemas[i].qtd_var; v++)
                                    lSomaProx.valores[v] *= multiplicador;

                            } else {
                                //multiplicar esta linha pelo prox col

                                double multiplicador = valor_prox_col;

                                //se são sinais diferentes
                                if (!(valor_atual > 0 && valor_prox_col < 0) || !(valor_atual < 0 && valor_prox_col > 0))
                                    multiplicador = -valor_prox_col;

                                for (int v = 0; v <= sistemas[i].qtd_var; v++)
                                    lSoma.valores[v] *= multiplicador;

                            }

                        } else { //Valores diferentes com resto != 0 - multiplicar as duas linhas pelos valores


                            for (int v = 0; v <= sistemas[i].qtd_var; v++) {

                                double multiplicador = valor_prox_col;
                                double multiplicador2 = valor_atual;

                                if (!(valor_atual > 0 && valor_prox_col < 0) || !(valor_atual < 0 && valor_prox_col > 0))
                                    multiplicador2 = -multiplicador2;


                                lSoma.valores[v] *= multiplicador;
                                lSomaProx.valores[v] *= multiplicador2;
                            }

                        }
                        
                        linhas[j + 1] = somarLinhas(lSoma, lSomaProx, sistemas[i].qtd_var);
                    }
                    
                    sistemas[i].linhas = linhas;
                    exibeEtapa(sistemas[i], i);//exibe como o sistema ficou após a soma!
                }

            }
        }


        private Linha somarLinhas(Linha l, Linha l2, int qtd_vars) {

            Linha res = new Linha();
            res.valores = new double[qtd_vars + 1];

            for(int i = 0; i <= qtd_vars; i++) 
                res.valores[i] = l.valores[i] + l2.valores[i];

            return res;
        }

        /// <summary>
        /// Exibe no txtbox o resultado da soma da linha
        /// </summary>
        /// <param name="s"></param>
        private void exibeEtapa(Sistema s, int i) {

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

            calcula(sistemas);
        }

        private void button2_Click(object sender, EventArgs e) {

            Sistema[] s = new Sistema[1];

            s[0].linhas = new Linha[(int)this.txtQtdVars.Value];

            for(int i=1; i <= (int) this.txtQtdVars.Value; i++) {

                s[0].linhas[i - 1].valores = new double[(int)this.txtQtdVars.Value + 1];


                for (int j = 0; j <= this.txtQtdVars.Value; j++) {
                    
                    s[0].linhas[i - 1].valores[j] = double.Parse(gridSistema.Rows[i - 1].Cells[j].Value.ToString());
                }
            }
            s[0].qtd_var = (int) this.txtQtdVars.Value;

            calcula(s);
        }

    }
}
