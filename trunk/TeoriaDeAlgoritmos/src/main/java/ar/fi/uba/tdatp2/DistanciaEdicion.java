package ar.fi.uba.tdatp2;

public class DistanciaEdicion {

	private int[][] matrizDistancia;
	private String str1;
	private String str2;

	public DistanciaEdicion() {
		super();
	}

	public DistanciaEdicion(int long1, int long2) {
		this.matrizDistancia = new int[long1][long2];

	}
	
	public DistanciaEdicion(String str1, String str2) throws StringNoValidoException {
		if (str1 != null && str2 != null && str1.length() > 0 && str2.length() > 0){
			this.str1=str1;
			this.str2=str2;
			this.matrizDistancia = new int[str1.toCharArray().length][str1.toCharArray().length];
		}
			
		else
			throw new StringNoValidoException("Las cadenas ingresadas no son válidas");

	}

	public int[][] getMatrizDistancia() {
		return matrizDistancia;
	}

	public void setMatrizDistancia(int[][] matrizDistancia) {
		this.matrizDistancia = matrizDistancia;
	}

	public int calcularDistancia() {
		return calcularDistanciaAux(str1.toCharArray(), str2.toCharArray());
	}

	private int calcularDistanciaAux(char[] str1, char[] str2) {

		for (int i = 0; i < str1.length; i++) {
			matrizDistancia[i][0] = i;
		}
		for (int j = 0; j < str2.length; j++) {
			matrizDistancia[0][j] = j;
		}
		for (int i = 1; i < str1.length; i++) {
			for (int j = 1; j < str2.length; j++) {
				matrizDistancia[i][j] = minimo(matrizDistancia[i - 1][j] + 1,
						matrizDistancia[i][j - 1] + 1,
						matrizDistancia[i - 1][j - 1]
								+ ((str1[i - 1] == str2[j - 1]) ? 0 : 1));
			}
		}
		return matrizDistancia[str1.length -1][str2.length - 1];

	}

	private int minimo(int a, int b, int c) {
		if (a <= b && a <= c) {
			return a;
		}
		if (b <= a && b <= c) {
			return b;
		}
		return c;
	}

	public String getStr2() {
		return str2;
	}

	public void setStr2(String str2) {
		this.str2 = str2;
	}

	public String getStr1() {
		return str1;
	}

	public void setStr1(String str1) {
		this.str1 = str1;
	}
}
