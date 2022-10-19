using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzle_8 {
    public class Puzzle {
        private int[][] puzzle = new int[3][];
        private int[] posicaoLivre = null;
        private string resultado = null;
        private string acao = "";
        private Puzzle pai = null;
        private Puzzle filho = null;
        public Puzzle(string resultadoPuzzle) {
            setNumerosPuzzle(resultadoPuzzle);
        }
        public Puzzle(string resultadoPuzzle,int operacao,int i,int j) {
            setNumerosPuzzle(resultadoPuzzle);
            setAcao(operacao,i,j);
            switch(operacao) {
                case EPuzzle.MOVE_CIMA:
                    moveUp(i,j);
                    break;
                case EPuzzle.MOVE_BAIXO:
                    moveDown(i,j);
                    break;
                case EPuzzle.MOVE_ESQ:
                    moveEsq(i,j);
                    break;
                case EPuzzle.MOVE_DIR:
                    moveDir(i,j);
                    break;
            }
            this.resultado = geraResultado();
        }
        public void setNumerosPuzzle(string resultadoPuzzle) {
            string[] resultado = resultadoPuzzle.Split(';');
            this.puzzle = new int[][]{
                new int[] {int.Parse(resultado[0]), int.Parse(resultado[1]),int.Parse(resultado[2]) },
                new int[] {int.Parse(resultado[3]), int.Parse(resultado[4]),int.Parse(resultado[5])},
                new int[] {int.Parse(resultado[6]),int.Parse(resultado[7]),int.Parse(resultado[8]) }
            };
        }
        public int[] getLocalizacaoPeca(int peca) {
            int[] localizacao = new int[2];
            for(int i = 0; i <= 2; i++) {
                for(int j = 0; j <= 2; j++) {
                    if(puzzle[i][j] == peca) {
                        localizacao[0] = i;
                        localizacao[1] = j;
                        return localizacao;
                    }
                }
            }
            return localizacao;
        }
        public string geraResultado() {
            string[] resultado = new string[0];
            for(int i = 0; i <= 2; i++) {
                for(int j = 0; j <= 2; j++) {
                    string teste = this.puzzle[i][j].ToString();
                    resultado = resultado.Append(teste).ToArray();
                }
            }
            string[] Array = resultado.ToArray();

            if(Array != null) {
                return string.Join(";",Array);
            }


            return Array.ToString();
        }
        public string getResultadoPuzzle() {
            if(this.resultado == null) {
                this.resultado = geraResultado();
            }
            return this.resultado;
        }
        public int[] getPosicaoLivre() {
            if(this.posicaoLivre == null) {
                setPosicaoLivre(achaPosicaoLivre());
            }
            return this.posicaoLivre;
        }
        public void setPosicaoLivre(int[] posicaoLivre) {
            this.posicaoLivre = posicaoLivre;
        }
        public int[] achaPosicaoLivre() {
            int[] posicaoLivre = new int[2];
            int i;
            int j;
            for(i = 0; i <= 2; i++) {
                for(j = 0; j <= 2; j++) {
                    if(this.puzzle[i][j] == 0) {
                        posicaoLivre[0] = i;
                        posicaoLivre[1] = j;
                        return posicaoLivre;
                    }
                }
            }
            return posicaoLivre;
        }
        public void moveUp(int i,int j) {
            int valor = this.puzzle[i][j];
            this.puzzle[i][j] = 0;
            this.puzzle[i - 1][j] = valor;
            int[] posicaoLivre = { i,j };
            setPosicaoLivre(posicaoLivre);
        }
        public void moveDown(int i,int j) {
            int valor = this.puzzle[i][j];
            this.puzzle[i][j] = 0;
            this.puzzle[i + 1][j] = valor;
            int[] posicaoLivre = { i,j };
            setPosicaoLivre(posicaoLivre);
        }
        public void moveEsq(int i,int j) {
            int valor = this.puzzle[i][j];
            this.puzzle[i][j] = 0;
            this.puzzle[i][j - 1] = valor;
            int[] posicaoLivre = { i,j };
            setPosicaoLivre(posicaoLivre);
        }
        public void moveDir(int i,int j) {
            int valor = this.puzzle[i][j];
            this.puzzle[i][j] = 0;
            this.puzzle[i][j + 1] = valor;
            int[] posicaoLivre = { i,j };
            setPosicaoLivre(posicaoLivre);
        }
        public int[][] getPuzzle() {
            return this.puzzle;
        }
        public void setAcao(int operacao,int i,int j) {
            string teste = this.puzzle[i][j].ToString();
            teste += "" + EPuzzle.operacoes[operacao];
            this.acao = teste;
        }
        public string getAcao() {
            return this.acao;
        }
        public Puzzle getPai() {
            return pai;
        }
        public void setPai(Puzzle pai) {
            this.pai = pai;
        }
        public Puzzle getFilho() {
            return filho;
        }
        public void setFilho(Puzzle filho) {
            this.filho = filho;
        }
        public void setPuzzle(int[][] puzzle) {
            this.puzzle = puzzle;
        }
        public void setAcao(string acao) {
            this.acao = acao;
        }
    }
}