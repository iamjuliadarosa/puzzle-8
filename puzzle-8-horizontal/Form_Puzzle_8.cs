using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle_8_horizontal {
    public partial class Form_Puzzle_8:Form {
        public Form_Puzzle_8() {
            InitializeComponent();
        }

        private void Form1_Load(object sender,EventArgs e) {

        }
        private void Btn_Resolver_Click(object sender,EventArgs e) {

            string EstadoFinal = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",EF1.Text,EF2.Text,EF3.Text,EF4.Text,EF5.Text,EF6.Text,EF7.Text,EF8.Text,EF9.Text);
            string EstadoInicial = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",ES1.Text,ES2.Text,ES3.Text,ES4.Text,ES5.Text,ES6.Text,ES7.Text,ES8.Text,ES9.Text);
            string relatorio = string.Format("Puzzle inicial: {0} \n Puzzle Final: {1}",EstadoInicial,EstadoFinal);
            Puzzle puzzle = new Puzzle(EstadoInicial);
            if(BuscaHorizontal.Checked) {
                relatorio += "\n Tipo de Busca: Busca Horizontal";
                PuzzleHorizontal ph = new PuzzleHorizontal(puzzle);
                DateTime tempoInicial = DateTime.Now;
                DateTime tempoFinal = DateTime.Now;
                //void execute() {
                tempoInicial = DateTime.Now;
                ph.resolvePuzzle();
                tempoFinal = DateTime.Now;
                //}
                //Thread T = new Thread(execute);
                //T.Start();


                relatorio += "Tempo de execução: " + (tempoFinal - tempoInicial);
                //Puzzle nodoFinal = caminho.get(0);
                //inicial11.setText("" + nodoFinal.getPuzzle()[0][0]);
                //inicial12.setText("" + nodoFinal.getPuzzle()[0][1]);
                //inicial13.setText("" + nodoFinal.getPuzzle()[0][2]);
                //inicial21.setText("" + nodoFinal.getPuzzle()[1][0]);
                //inicial22.setText("" + nodoFinal.getPuzzle()[1][1]);
                //inicial23.setText("" + nodoFinal.getPuzzle()[1][2]);
                //inicial31.setText("" + nodoFinal.getPuzzle()[2][0]);
                //inicial32.setText("" + nodoFinal.getPuzzle()[2][1]);
                //inicial33.setText("" + nodoFinal.getPuzzle()[2][2]);
                //Deque<String> caminho = new ArrayDeque<String>();
                //do {
                //    caminho.add(nodoFinal.getAcao());
                //    nodoFinal = nodoFinal.getPai();
                //} while(nodoFinal != null);
                //System.out.print("Busca Horizontal: Nodos Gerados - " + nodosGerados + " | Nodos Visitados: " + nodosVisitados + " | Tempo de execução: " + (tempoFinal - tempoInicial) + "ms\n");
                //System.out.print("Caminho da resolução:");
                //while(caminho.size() != 0) {
                //    System.out.print(caminho.pollLast() + "\n");
                //}
            } else if(BuscaAEstrela.Checked) {
                relatorio += "\n Tipo de Busca: Busca A*";
                PuzzleA pa = new PuzzleA(puzzle);
                DateTime tempoInicial = DateTime.Now;
                pa.resolvePuzzle();
                DateTime tempoFinal = DateTime.Now;
                relatorio += "Tempo de execução: " + (tempoFinal - tempoInicial);
                //System.out.print("\nHeurísitca A*: Nodos Gerados - " + nodosGerados + " | Nodos Visitados: " + nodosVisitados + " | Tempo de execução: " + (tempoFinal - tempoInicial) + "ms\n");
                //System.out.print("\n Caminho da resolução:");
                //foreach(Puzzle passo in caminho) {
                //    System.out.print("\n" + passo.getAcao());
                //    inicial11.setText("" + passo.getPuzzle()[0][0]);
                //    inicial12.setText("" + passo.getPuzzle()[0][1]);
                //    inicial13.setText("" + passo.getPuzzle()[0][2]);
                //    inicial21.setText("" + passo.getPuzzle()[1][0]);
                //    inicial22.setText("" + passo.getPuzzle()[1][1]);
                //    inicial23.setText("" + passo.getPuzzle()[1][2]);
                //    inicial31.setText("" + passo.getPuzzle()[2][0]);
                //    inicial32.setText("" + passo.getPuzzle()[2][1]);
                //    inicial33.setText("" + passo.getPuzzle()[2][2]);
                //}
            } else {
                MessageBox.Show("Selecione um tipo de busca!");
            }

            CampoRelatorioResultante.Text = relatorio;
        }
    }
}
