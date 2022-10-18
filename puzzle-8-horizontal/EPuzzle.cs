namespace puzzle_8_horizontal {
	public class EPuzzle {
		public const int ESQ = 0;
		public const int MID = 1;
		public const int DIR = 2;
		public const int TOP = 0;
		public const int BOTTOM = 2;

		public const int MOVE_CIMA = 0;
		public const int MOVE_BAIXO = 1;
		public const int MOVE_ESQ = 2;
		public const int MOVE_DIR = 3;

		public static readonly string[] operacoes = {
		"_cima", "_baixo", "_esquerda", "_direita"
	};

		public static readonly string[] linhas = {
			"Primeira Linha", "Segunda Linha", "Terceira Linha"
	};

		public static readonly string[] colunas = {
			"Primeira Coluna", "Segunda Coluna", "Terceira Coluna"
	};
	}
}