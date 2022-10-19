using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle_8 {
    public partial class Form_Puzzle_8:Form {
        public Form_Puzzle_8() {
            InitializeComponent();
        }
        private void Form1_Load(object sender,EventArgs e) {

        }
        public static List<Puzzle> CaminhoPercorrido = new List<Puzzle>();
        public static Puzzle PassoCaminhoExibicao = null;
        public static int NodosVisitados = 0;
        public static int NodosGerados = 0;
        private void Btn_Resolver_Click(object sender,EventArgs e) {
            bool valido = true;
            string EstadoFinal = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",EF1.Text,EF2.Text,EF3.Text,EF4.Text,EF5.Text,EF6.Text,EF7.Text,EF8.Text,EF9.Text);
            string[] PuzzleValidateFinal = EstadoFinal.Split(';');
            if(PuzzleValidateFinal.Contains("")) {
                MessageBox.Show("Puzzle Final inválido!");
                valido = false;
            }
            try {
                int[] PuzzleFinal = new int[] { int.Parse(EF1.Text),int.Parse(EF2.Text),int.Parse(EF3.Text),int.Parse(EF4.Text),int.Parse(EF5.Text),int.Parse(EF6.Text),int.Parse(EF7.Text),int.Parse(EF8.Text),int.Parse(EF9.Text) };
                if(PuzzleFinal.Sum() != 36 || (PuzzleFinal.Length - PuzzleFinal.Distinct().Count() != 0)) {
                    MessageBox.Show("Puzzle Final inválido!");
                    valido = false;
                }
            } catch {
                MessageBox.Show("Puzzle Final inválido!");
                valido = false;
            }
            string EstadoInicial = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",ES1.Text,ES2.Text,ES3.Text,ES4.Text,ES5.Text,ES6.Text,ES7.Text,ES8.Text,ES9.Text);
            string[] PuzzleValidateInicial = EstadoInicial.Split(';');
            if(PuzzleValidateInicial.Contains("")) {
                MessageBox.Show("Puzzle Inicial inválido!");
                valido = false;
            }
            try {
                int[] PuzzleInicial = new int[] { int.Parse(ES1.Text),int.Parse(ES2.Text),int.Parse(ES3.Text),int.Parse(ES4.Text),int.Parse(ES5.Text),int.Parse(ES6.Text),int.Parse(ES7.Text),int.Parse(ES8.Text),int.Parse(ES9.Text) };
                if(PuzzleInicial.Sum() != 36 || (PuzzleInicial.Length - PuzzleInicial.Distinct().Count() != 0)) {
                    MessageBox.Show("Puzzle Inicial inválido!");
                    valido = false;
                }
            } catch {
                MessageBox.Show("Puzzle Inicial inválido!");
                valido = false;
            }            

            string relatorio = null;//string.Format("Puzzle inicial: {0}\nPuzzle Final: {1}",EstadoInicial,EstadoFinal);
            if(valido) {
                Puzzle puzzle = new Puzzle(EstadoInicial);
                if(BuscaHorizontal.Checked) {
                    try {
                        relatorio += "\nTipo de Busca: Busca Horizontal";
                        BuscaHorizontal BuscaHorizontal = new BuscaHorizontal(puzzle,EstadoFinal);
                        DateTime tempoInicial = DateTime.Now;
                        BuscaHorizontal.Resolver();
                        DateTime tempoFinal = DateTime.Now;
                        TimeSpan TempoDecorrido = tempoFinal.Subtract(tempoInicial);
                        relatorio += "\nBusca Horizontal:\nNodos Gerados: " + NodosGerados + " \nNodos Visitados: " + NodosVisitados + " \nTempo de execução: " + TempoDecorrido.TotalMilliseconds + "ms\n";
                        relatorio += "\nCaminho da resolução:";
                        Puzzle nodoFinal = CaminhoPercorrido.Last();
                        List<Puzzle> queue = new List<Puzzle>();
                        do {
                            queue.Add(nodoFinal);
                            nodoFinal = nodoFinal.getPai();
                        } while(nodoFinal != null);
                        queue.Reverse();
                        foreach(Puzzle passo in queue) {
                            relatorio += "\n" + passo.getAcao();
                        }
                        PassoCaminhoExibicao = queue.First();
                        LoadPassoCaminho();
                    } catch(Exception err) {
                        MessageBox.Show(err.Message);
                    }
                } else if(BuscaAEstrela.Checked) {
                    try {
                        relatorio += "\nTipo de Busca: Busca A*";
                        BuscaA BuscaA = new BuscaA(puzzle,EstadoFinal);
                        DateTime tempoInicial = DateTime.Now;
                        BuscaA.Resolver();
                        DateTime tempoFinal = DateTime.Now;
                        TimeSpan TempoDecorrido = tempoFinal.Subtract(tempoInicial);
                        relatorio += "\nHeurísitca A*:\nNodos Gerados:" + NodosGerados + " \nNodos Visitados: " + NodosVisitados + " \nTempo de execução: " + TempoDecorrido.TotalMilliseconds + "ms\n";
                        relatorio += "\nCaminho da resolução:";
                        foreach(Puzzle passo in CaminhoPercorrido) {
                            relatorio += "\n" + passo.getAcao();
                        }
                        PassoCaminhoExibicao = CaminhoPercorrido.First();
                        LoadPassoCaminho();
                    } catch(Exception err) {
                        MessageBox.Show(err.Message);
                    }
                } else {
                    MessageBox.Show("Selecione um tipo de busca!");
                }
                CaminhoPercorrido.Clear();
                NodosGerados = 0;
                NodosVisitados = 0;
                CampoRelatorioResultante.Text = relatorio;
            }
        }
        private void LoadPassoCaminho() {
            if(PassoCaminhoExibicao != null) {
                Btn_Ante.Enabled = false;
                Btn_Prox.Enabled = false;
                if(PassoCaminhoExibicao.getPai() != null) {
                    Btn_Ante.Enabled = true;
                }
                if(PassoCaminhoExibicao.getFilho() != null) {
                    Btn_Prox.Enabled = true;
                }
                ES1.Text = PassoCaminhoExibicao.getPuzzle()[0][0].ToString();
                ES2.Text = PassoCaminhoExibicao.getPuzzle()[0][1].ToString();
                ES3.Text = PassoCaminhoExibicao.getPuzzle()[0][2].ToString();
                ES4.Text = PassoCaminhoExibicao.getPuzzle()[1][0].ToString();
                ES5.Text = PassoCaminhoExibicao.getPuzzle()[1][1].ToString();
                ES6.Text = PassoCaminhoExibicao.getPuzzle()[1][2].ToString();
                ES7.Text = PassoCaminhoExibicao.getPuzzle()[2][0].ToString();
                ES8.Text = PassoCaminhoExibicao.getPuzzle()[2][1].ToString();
                ES9.Text = PassoCaminhoExibicao.getPuzzle()[2][2].ToString();
                LabelEstado.Text = PassoCaminhoExibicao.getAcao();
                if(string.IsNullOrEmpty(LabelEstado.Text)) {
                    LabelEstado.Text = "Estado Inicial";
                }
            }
        }
        private void BtnLimpar_Click(object sender,EventArgs e) {
            CampoRelatorioResultante.Text = "Informe o puzzle inicial.";
            PassoCaminhoExibicao = null;
            Btn_Ante.Enabled = false;
            Btn_Prox.Enabled = false;
            ES1.Text = "";
            ES2.Text = "";
            ES3.Text = "";
            ES4.Text = "";
            ES5.Text = "";
            ES6.Text = "";
            ES7.Text = "";
            ES8.Text = "";
            ES9.Text = "";
        }
        private void Btn_Shuffle_Click(object sender,EventArgs e) {
            Random rnd = new Random();
            List<int> list1 = new List<int>() { 1,2,3,4,5,6,7,8,0 };
            List<int> randomized = list1.OrderBy(item => rnd.Next()).ToList();
            ES1.Text = randomized[0].ToString();
            ES2.Text = randomized[1].ToString();
            ES3.Text = randomized[2].ToString();
            ES4.Text = randomized[3].ToString();
            ES5.Text = randomized[4].ToString();
            ES6.Text = randomized[5].ToString();
            ES7.Text = randomized[6].ToString();
            ES8.Text = randomized[7].ToString();
            ES9.Text = randomized[8].ToString();
        }
        private void Btn_Ante_Click(object sender,EventArgs e) {
            if(PassoCaminhoExibicao != null) {
                Puzzle newCaminho = null;
                newCaminho = PassoCaminhoExibicao.getPai();
                if(newCaminho != null) {
                    PassoCaminhoExibicao = newCaminho;
                } else {
                    Btn_Ante.Enabled = false;
                }
            }
            LoadPassoCaminho();
        }
        private void Btn_Prox_Click(object sender,EventArgs e) {
            if(PassoCaminhoExibicao != null) {
                Puzzle newCaminho = null;
                newCaminho = PassoCaminhoExibicao.getFilho();
                if(newCaminho != null) {
                    PassoCaminhoExibicao = newCaminho;
                } else {
                    Btn_Prox.Enabled = false;
                }

            }
            LoadPassoCaminho();
        }
    }
}
