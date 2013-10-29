package ar.fi.uba.tdatp2;

public class DistanciaEdicion {

	private char[] strX;
	private char[] strY;
	private char[] strZ;
	private int costoCopiar;
	private int costoReemplazar;
	private int costoBorrar;
	private int costoInsertar;
	private int costoIntercambiar;
	private int costoTerminar;
	private int distanciaCalculada;
	private int i = 0;
	private int j = 0;

	public DistanciaEdicion() {
		super();
	}

	public DistanciaEdicion(String strX, String strY, int costoCopiar,
			int costoReemplazar, int costoBorrar, int costoInsertar,
			int costoIntercambiar, int costoTerminar) {
		super();
		this.strX = strX.toCharArray();
		this.strY = strY.toCharArray();
		this.strZ = new char[1000];
		this.costoCopiar = costoCopiar;
		this.costoReemplazar = costoReemplazar;
		this.costoBorrar = costoBorrar;
		this.costoInsertar = costoInsertar;
		this.costoIntercambiar = costoIntercambiar;
		this.costoTerminar = costoTerminar;
	}

	public char[] getStrX() {
		return strX;
	}

	public void setStrX(char[] strX) {
		this.strX = strX;
	}

	public char[] getStrY() {
		return strY;
	}

	public void setStrY(char[] strY) {
		this.strY = strY;
	}

	public char[] getStrZ() {
		return strZ;
	}

	public void setStrZ(char[] strZ) {
		this.strZ = strZ;
	}

	public int getCostoCopiar() {
		return costoCopiar;
	}

	public void setCostoCopiar(int costoCopiar) {
		this.costoCopiar = costoCopiar;
	}

	public int getCostoReemplazar() {
		return costoReemplazar;
	}

	public void setCostoReemplazar(int costoReemplazar) {
		this.costoReemplazar = costoReemplazar;
	}

	public int getCostoBorrar() {
		return costoBorrar;
	}

	public void setCostoBorrar(int costoBorrar) {
		this.costoBorrar = costoBorrar;
	}

	public int getCostoInsertar() {
		return costoInsertar;
	}

	public void setCostoInsertar(int costoInsertar) {
		this.costoInsertar = costoInsertar;
	}

	public int getCostoIntercambiar() {
		return costoIntercambiar;
	}

	public void setCostoIntercambiar(int costoIntercambiar) {
		this.costoIntercambiar = costoIntercambiar;
	}

	public int getCostoTerminar() {
		return costoTerminar;
	}

	public void setCostoTerminar(int costoTerminar) {
		this.costoTerminar = costoTerminar;
	}

	public int getDistanciaCalculada() {
		return distanciaCalculada;
	}

	public void setDistanciaCalculada(int distanciaCalculada) {
		this.distanciaCalculada = distanciaCalculada;
	}

	public int calcularDistancia() {
		calcularDistanciaAux();
		return getDistanciaCalculada();
	}

	private void calcularDistanciaAux() {

		for (i = 0; i < strY.length;) {
			// Si ya se acabo el string, s�lo resta finalizar.
			if (j == strY.length) {
				endString(i);
				continue;
			}

			// Si las dos cadenas son iguales, debo ver si conviene copiar o
			// insertar.
			try {
				if (strX[i] == strY[i]) {

					if (getCostoCopiar() <= getCostoInsertar()) {
						copy(i, j);
					} else {
						insert(i, j);
					}
				} else {

					try {

						if (strX[i + 1] == strY[i]) {
							if (strX[i] == strY[i + 1]) { // Si difieren en la
															// posicion de debo
															// intercambiarlos
								change(i, j);

							} else { // Sino tengo que ver que es lo que menos
										// me cuesta
								if (getCostoReemplazar() <= (getCostoBorrar() + getCostoCopiar())) {
									replace(i, j);

								} else {
									erase(i, j);
									copy(i, j);

								}
							}
						} else {
							replace(i, j);

						}
					} catch (ArrayIndexOutOfBoundsException e) {
						replace(i, j);

					}
				}
			} catch (ArrayIndexOutOfBoundsException e) {
				copy(i, j);

			}
		}

	}

	/**
	 * * Copia un car�cter de x a z . Esto es: z[ j ]=x [i ].
	 * 
	 * @param i
	 * @param j
	 */

	public void copy(int i, int j) {
		strZ[j] = strX[i];
		this.i++;
		this.j++;
		this.distanciaCalculada += this.costoCopiar;
	}

	/**
	 * Reemplazar: reemplaza un car�cter de x por otro car�cter c . Esto es: z[
	 * j ]=c
	 * 
	 * @param i
	 * @param j
	 */
	public void replace(int i, int j) {
		strZ[j] = strY[j];
		this.i++;
		this.j++;
		this.distanciaCalculada += this.costoReemplazar;
	}

	/**
	 * Borrar: borra un car�cter de x
	 * 
	 * @param i
	 * @param j
	 */
	public void erase(int i, int j) {
		this.i++;
		this.distanciaCalculada += this.costoBorrar;
	}

	/**
	 * Insertar: inserta un car�cter c en z . Esto es: z[ j ]=c
	 * 
	 * @param i
	 * @param j
	 */
	public void insert(int i, int j) {
		strZ[j] = strY[j];
		this.j++;
		this.distanciaCalculada += this.costoInsertar;
	}

	/**
	 * Intercambiar: intercambia los pr�ximos dos caracteres copi�ndolos de x a
	 * z pero en orden inverso. Esto es: z[ j ]=x [i+1] y z[ j +1]=x [i].
	 * 
	 * @param i
	 * @param j
	 */
	public void change(int i, int j) {
		strZ[j] = strX[i + 1];
		strZ[j + 1] = strX[i];
		this.i += 2;
		this.j += 2;
		this.distanciaCalculada += this.costoIntercambiar;
	}

	/**
	 * Terminar: elimina los caracteres restantes de x haciendo i=m+1 . Esta
	 * operaci�n descarta todos los caracteres de x que todav�a no se
	 * analizaron. Es la �ltima operaci�n se aplica si hace falta.
	 * 
	 * @param i
	 * @return
	 */
	public void endString(int i) {
		this.distanciaCalculada += this.costoTerminar;
		this.i = strX.length + 1;
	}

}
