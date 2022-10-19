using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzle_8 {
	public class BuscaA {
		private Puzzle puzzle = null;
		private string estadoDesejado = "1;2;3;4;5;6;7;8;0";
		private Puzzle puzzleEstadoDesejado = null;
		public string Resolver() {
            Form_Puzzle_8.CaminhoPercorrido.Add(puzzle);
            return BuscaHeuristicaA(this.puzzle);
		}
		private string BuscaHeuristicaA(Puzzle puzzle) {
			if(puzzle.getResultadoPuzzle().Equals(estadoDesejado)) {
				return puzzle.getAcao();
			}
			if(puzzle.getFilho() == null) {
				puzzle.setFilho(getFilhoHeuristicaPuzzle(puzzle));
			}
			Form_Puzzle_8.CaminhoPercorrido.Add(puzzle.getFilho());
            Form_Puzzle_8.NodosVisitados++;
			return puzzle.getAcao() + "\n" + BuscaHeuristicaA(puzzle.getFilho());
		}
		private Puzzle getFilhoHeuristicaPuzzle(Puzzle puzzle) {
			Dictionary<int,List<Puzzle>> filhos = getDescendentesPorHeuristica(puzzle);
			List<int> keys = filhos.Keys.ToList();
			keys = keys.OrderBy(k => k).ToList();
			if(filhos.TryGetValue(keys.First(),out List<Puzzle> Result)) {
				return getMenorFilhoHeuristica(Result);
			} else {
				throw new System.Exception("getFilhoHeuristicaPuzzle");
			}
		}
		private Puzzle getMenorFilhoHeuristica(List<Puzzle> empate) {
			if(empate.Count() == 1) {
				return empate.First();
			}
			Dictionary<int,Puzzle> filhosEmpate = new Dictionary<int,Puzzle>();
			Dictionary<int,List<Puzzle>> melhoresFilhos = new Dictionary<int,List<Puzzle>>();
			foreach(Puzzle filho in empate) {
				Dictionary<int,List<Puzzle>> filhos = getDescendentesPorHeuristica(filho);
				List<int> chaves = filhos.Keys.ToList();
				chaves = chaves.OrderBy(k => k).ToList();
				filhosEmpate[chaves.First()] = filho;
				melhoresFilhos[chaves.First()] = filhos[chaves.First()];
			}
			List<int> keys = filhosEmpate.Keys.ToList();
			keys = keys.OrderBy(k => k).ToList();
			filhosEmpate[keys.First()].setFilho(getMenorFilhoHeuristica(melhoresFilhos[keys.First()]));
			return filhosEmpate[keys.First()];
		}
		private Dictionary<int,List<Puzzle>> getDescendentesPorHeuristica(Puzzle puzzle) {
			Dictionary<int,List<Puzzle>> filhos = new Dictionary<int,List<Puzzle>>();
			int[] posicaoLivre = puzzle.getPosicaoLivre();
			foreach(int[] operacoes in Operacoes.getInstance()[posicaoLivre[0]][posicaoLivre[1]]) {
				Puzzle novoPuzzle = new Puzzle(puzzle.getResultadoPuzzle(),operacoes[2],operacoes[0],operacoes[1]);
				novoPuzzle.setPai(puzzle);
                Form_Puzzle_8.NodosGerados++;
				int heuristica = getHeuristica(novoPuzzle);
				if(novoPuzzle.getPai().getPai() != null) {
					if(novoPuzzle.getResultadoPuzzle().Equals(novoPuzzle.getPai().getPai().getResultadoPuzzle())) {
						continue;
					}
				}
				if(filhos.ContainsKey(heuristica)) {
					filhos[heuristica].Add(novoPuzzle);
				} else {
					List<Puzzle> novo = new List<Puzzle>();
					novo.Add(novoPuzzle);
					filhos[heuristica] = novo;
				}

			}
			return filhos;
		}
		private int getHeuristica(Puzzle puzzle) {
			return getPecasForaDoLugar(puzzle) + getDistanciaPecas(puzzle);
		}
		public int getPecasForaDoLugar(Puzzle puzzle) {
			int fora = 0;
			char[] pecasEstadoDesejado = estadoDesejado.ToCharArray();
			char[] pecas = puzzle.getResultadoPuzzle().ToCharArray();
			for(int x = 0; x < pecasEstadoDesejado.Length; x++) {
				if(pecas[x] != '0' && pecas[x] != pecasEstadoDesejado[x])
					fora++;
			}
			return fora;
		}
		public int getDistanciaPecas(Puzzle puzzle) {
			int distancia = 0;
			foreach(string peca in puzzle.getResultadoPuzzle().Split(';')) {
				if(!peca.Equals("0")) {
					distancia += getDistanciaPecaEstadoDesejado(puzzle,int.Parse(peca));
				}
			}
			return distancia;
		}
		public int getDistanciaPecaEstadoDesejado(Puzzle puzzle,int peca) {
			int[] locPeca = puzzle.getLocalizacaoPeca(peca);
			int[] locPecaDesejado = puzzleEstadoDesejado.getLocalizacaoPeca(peca);
			return Math.Abs(locPeca[0] - locPecaDesejado[0]) + Math.Abs(locPeca[1] - locPecaDesejado[1]);
		}
		public BuscaA(Puzzle puzzle) {
			setPuzzle(puzzle);
			puzzleEstadoDesejado = new Puzzle(estadoDesejado);
		}
		public BuscaA(Puzzle puzzle,string estadoDesejado) {
			setPuzzle(puzzle);
			puzzleEstadoDesejado = new Puzzle(estadoDesejado);
			this.estadoDesejado = estadoDesejado;
		}
		public Puzzle getPuzzle() {
			return puzzle;
		}
		public void setPuzzle(Puzzle puzzle) {
			this.puzzle = puzzle;
		}
	}
}