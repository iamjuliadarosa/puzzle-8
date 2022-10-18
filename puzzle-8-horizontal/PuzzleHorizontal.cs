using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace puzzle_8_horizontal {
	public class PuzzleHorizontal {

		private List<string> visitados = new List<string>();
		private LinkedList<Puzzle> visitar = new LinkedList<Puzzle>();
		private string estadoDesejado = "123456780";
		public void resolvePuzzle() {
			Puzzle puzzle = visitar.First();
			visitar.RemoveFirst();
			if(puzzle.getResultadoPuzzle().Equals(this.estadoDesejado)) {
				Form_Puzzle_8.caminho.Add(puzzle);
			} else {
				resolve(puzzle);
			}
		}
		private bool resolve(Puzzle puzzle) {
            string resultadoPuzzle = puzzle.getResultadoPuzzle();
			visitados.Add(resultadoPuzzle);
			int[] posicaoLivre = puzzle.getPosicaoLivre();
			foreach(int[] operacoes in Operacoes.getInstance()[posicaoLivre[0]][posicaoLivre[1]]) {
				Puzzle novoPuzzle = new Puzzle(resultadoPuzzle,operacoes[2],operacoes[0],operacoes[1]);
				string novoResultado = novoPuzzle.getResultadoPuzzle();
				Form_Puzzle_8.nodosGerados++;
				Form_Puzzle_8.nodosVisitados++;
				if(!isVisitado(novoResultado)) {
					novoPuzzle.setPai(puzzle);
					if(novoResultado.Equals(estadoDesejado)) {
						Form_Puzzle_8.caminho.Add(novoPuzzle);
						return true;
					} else {
						visitados.Add(novoResultado);
						visitar.AddLast(novoPuzzle);
					}
				}
				
			}
			Puzzle Item = visitar.First();
			visitar.RemoveFirst();
            return resolve(Item);
		}
		public bool isVisitado(string resultadoPuzzle) {
			return visitados.Contains(resultadoPuzzle);
		}
		public PuzzleHorizontal(Puzzle puzzleInicial) {
			visitar.AddLast(puzzleInicial);
		}
		public PuzzleHorizontal(Puzzle puzzleInicial,string estadoDesejado) {
			visitar.AddLast(puzzleInicial);
			this.estadoDesejado = estadoDesejado;
		}
	}
}