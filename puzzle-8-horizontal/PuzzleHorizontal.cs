using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace puzzle_8_horizontal {
	public class PuzzleHorizontal {

		private List<string> visitados = new List<string>();
		private Queue<Puzzle> visitar = new Queue<Puzzle>();
		private string estadoDesejado = "1;2;3;4;5;6;7;8;0";
		public void resolvePuzzle() {
			Puzzle puzzle = visitar.Dequeue();
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
                    puzzle.setFilho(novoPuzzle);
                    if(novoResultado.Equals(estadoDesejado)) {
						Form_Puzzle_8.caminho.Add(novoPuzzle);
						return true;
					} else {
						visitados.Add(novoResultado);
						visitar.Enqueue(novoPuzzle);
					}
				}
				
			}
			Puzzle Item = visitar.Dequeue();
            return resolve(Item);
		}
		public bool isVisitado(string resultadoPuzzle) {
			return visitados.Contains(resultadoPuzzle);
		}
		public PuzzleHorizontal(Puzzle puzzleInicial) {
			visitar.Enqueue(puzzleInicial);
		}
		public PuzzleHorizontal(Puzzle puzzleInicial,string estadoDesejado) {
			visitar.Enqueue(puzzleInicial);
			this.estadoDesejado = estadoDesejado;
		}
	}
}