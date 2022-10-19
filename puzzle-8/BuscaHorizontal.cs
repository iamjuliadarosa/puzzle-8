using System.Collections.Generic;
namespace puzzle_8 {
	public class BuscaHorizontal {
		private List<string> visitados = new List<string>();
		private Queue<Puzzle> visitar = new Queue<Puzzle>();
		private string estadoDesejado = "1;2;3;4;5;6;7;8;0";
		public void Resolver() {
			Puzzle puzzle = visitar.Dequeue();
			if(puzzle.getResultadoPuzzle().Equals(this.estadoDesejado)) {
				Form_Puzzle_8.CaminhoPercorrido.Add(puzzle);
			} else {
				BuscaGulosa(puzzle);
			}
		}
		private bool BuscaGulosa(Puzzle puzzle) {
            string resultadoPuzzle = puzzle.getResultadoPuzzle();
			visitados.Add(resultadoPuzzle);
			int[] posicaoLivre = puzzle.getPosicaoLivre();
			foreach(int[] operacoes in Operacoes.getInstance()[posicaoLivre[0]][posicaoLivre[1]]) {
				Puzzle novoPuzzle = new Puzzle(resultadoPuzzle,operacoes[2],operacoes[0],operacoes[1]);
				string novoResultado = novoPuzzle.getResultadoPuzzle();
				Form_Puzzle_8.NodosGerados++;
				Form_Puzzle_8.NodosVisitados++;
				if(!visitados.Contains(novoResultado)) {
					novoPuzzle.setPai(puzzle);
                    puzzle.setFilho(novoPuzzle);
                    if(novoResultado.Equals(estadoDesejado)) {
						Form_Puzzle_8.CaminhoPercorrido.Add(novoPuzzle);
						return true;
					} else {
						visitados.Add(novoResultado);
						visitar.Enqueue(novoPuzzle);
					}
				}				
			}
			Puzzle Item = visitar.Dequeue();
            return BuscaGulosa(Item);
		}
		public BuscaHorizontal(Puzzle puzzleInicial) {
			visitar.Enqueue(puzzleInicial);
		}
		public BuscaHorizontal(Puzzle puzzleInicial,string estadoDesejado) {
			visitar.Enqueue(puzzleInicial);
			this.estadoDesejado = estadoDesejado;
		}
	}
}