using System.Collections.Generic;

namespace puzzle_8 {
	public class Operacoes {
		private static List<List<List<int[]>>> operacoes = null;
		private Operacoes() { }
		public static List<List<List<int[]>>> getInstance() {
			if(operacoes == null) {
				operacoes = new List<List<List<int[]>>>();
				buildOperacoes();
			}
			return operacoes;
		}
		private static void buildOperacoes() {
			buildOperacoesTop();
			buildOperacoesMid();
			buildOperacoesBottom();
		}
		private static void buildOperacoesTop() {
			List<List<int[]>> ops = new List<List<int[]>>();
			ops.Add(AddOperacoes1x1());
			ops.Add(AddOperacoes1x2());
			ops.Add(AddOperacoes1x3());
			operacoes.Add(ops);
		}
		private static List<int[]> AddOperacoes1x1() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.ESQ;
			operacao[2] = EPuzzle.MOVE_CIMA;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.TOP;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_ESQ;
			ops.Add(operacao);

			return ops;
		}
		private static List<int[]> AddOperacoes1x2() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.TOP;
			operacao[1] = EPuzzle.ESQ;
			operacao[2] = EPuzzle.MOVE_DIR;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_CIMA;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.TOP;
			operacao[1] = EPuzzle.DIR;
			operacao[2] = EPuzzle.MOVE_ESQ;
			ops.Add(operacao);

			return ops;
		}
		private static List<int[]> AddOperacoes1x3() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.TOP;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_DIR;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.DIR;
			operacao[2] = EPuzzle.MOVE_CIMA;
			ops.Add(operacao);

			return ops;
		}
		private static void buildOperacoesMid() {
			List<List<int[]>> ops = new List<List<int[]>>();
			ops.Add(AddOperacoes2x1());
			ops.Add(AddOperacoes2x2());
			ops.Add(AddOperacoes2x3());
			operacoes.Add(ops);
		}
		private static List<int[]> AddOperacoes2x1() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.TOP;
			operacao[1] = EPuzzle.ESQ;
			operacao[2] = EPuzzle.MOVE_BAIXO;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_ESQ;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.BOTTOM;
			operacao[1] = EPuzzle.ESQ;
			operacao[2] = EPuzzle.MOVE_CIMA;
			ops.Add(operacao);

			return ops;
		}
		private static List<int[]> AddOperacoes2x2() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.TOP;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_BAIXO;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.ESQ;
			operacao[2] = EPuzzle.MOVE_DIR;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.BOTTOM;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_CIMA;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.DIR;
			operacao[2] = EPuzzle.MOVE_ESQ;
			ops.Add(operacao);

			return ops;
		}
		private static List<int[]> AddOperacoes2x3() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.TOP;
			operacao[1] = EPuzzle.DIR;
			operacao[2] = EPuzzle.MOVE_BAIXO;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_DIR;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.BOTTOM;
			operacao[1] = EPuzzle.DIR;
			operacao[2] = EPuzzle.MOVE_CIMA;
			ops.Add(operacao);

			return ops;
		}
		private static void buildOperacoesBottom() {
			List<List<int[]>> ops = new List<List<int[]>>();
			ops.Add(AddOperacoes3x1());
			ops.Add(AddOperacoes3x2());
			ops.Add(AddOperacoes3x3());
			operacoes.Add(ops);
		}
		private static List<int[]> AddOperacoes3x1() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.ESQ;
			operacao[2] = EPuzzle.MOVE_BAIXO;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.BOTTOM;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_ESQ;
			ops.Add(operacao);

			return ops;
		}
		private static List<int[]> AddOperacoes3x2() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao = new int[3];
			operacao[0] = EPuzzle.BOTTOM;
			operacao[1] = EPuzzle.ESQ;
			operacao[2] = EPuzzle.MOVE_DIR;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_BAIXO;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.BOTTOM;
			operacao[1] = EPuzzle.DIR;
			operacao[2] = EPuzzle.MOVE_ESQ;
			ops.Add(operacao);

			return ops;
		}
		private static List<int[]> AddOperacoes3x3() {
			List<int[]> ops = new List<int[]>();

			int[] operacao = new int[3];
			operacao[0] = EPuzzle.MID;
			operacao[1] = EPuzzle.DIR;
			operacao[2] = EPuzzle.MOVE_BAIXO;
			ops.Add(operacao);

			operacao = new int[3];
			operacao[0] = EPuzzle.BOTTOM;
			operacao[1] = EPuzzle.MID;
			operacao[2] = EPuzzle.MOVE_DIR;
			ops.Add(operacao);

			return ops;
		}
	}
}