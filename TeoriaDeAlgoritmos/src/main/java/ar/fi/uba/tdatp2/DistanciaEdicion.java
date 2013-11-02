package ar.fi.uba.tdatp2;

public class DistanciaEdicion {

	private int[][] distance;
	private String palabraInicio;
	private String palabraFin;
	private int copyCost;
	private int replaceCost;
	private int insertCost;
	private int switchCost;
	private int endCost;
	private int eraseCost;
	
	

	public DistanciaEdicion(String palabraInicio, String palabraFin,
			int copyCost, int replaceCost, int insertCost, int switchCost,
			int endCost, int eraseCost) {
		this.distance = new int[palabraInicio.length() + 1][palabraFin.length() + 1];
		this.palabraInicio = palabraInicio;
		this.palabraFin = palabraFin;
		this.copyCost = copyCost;
		this.replaceCost = replaceCost;
		this.insertCost = insertCost;
		this.switchCost = switchCost;
		this.endCost = endCost;
		this.eraseCost=eraseCost;
	}

	public int getCopyCost() {
		return copyCost;
	}

	public void setCopyCost(int copyCost) {
		this.copyCost = copyCost;
	}

	public int getReplaceCost() {
		return replaceCost;
	}

	public void setReplaceCost(int replaceCost) {
		this.replaceCost = replaceCost;
	}

	public int getInsertCost() {
		return insertCost;
	}

	public void setInsertCost(int insertCost) {
		this.insertCost = insertCost;
	}

	public int getSwitchCost() {
		return switchCost;
	}

	public void setSwitchCost(int switchCost) {
		this.switchCost = switchCost;
	}

	public int getEndCost() {
		return endCost;
	}

	public void setEndCost(int endCost) {
		this.endCost = endCost;
	}
	
	public int getEraseCost() {
		return eraseCost;
	}

	public void setEraseCost(int eraseCost) {
		this.eraseCost = eraseCost;
	}

	public int[][] getDistance() {
		return distance;
	}

	public void setDistance(int[][] distance) {
		this.distance = distance;
	}

	public String getPalabraInicio() {
		return palabraInicio;
	}

	public void setPalabraInicio(String palabraInicio) {
		this.palabraInicio = palabraInicio;
	}

	public String getPalabraFin() {
		return palabraFin;
	}

	public void setPalabraFin(String palabraFin) {
		this.palabraFin = palabraFin;
	}
	

	public int calcularDistanciaEdicion() {
		for (int i = 0; i <= palabraInicio.length(); i++)
			distance[i][0] = i * getEraseCost(); //Todo el costo de borrar la palabra de Inicio
		for (int j = 0; j <= palabraFin.length(); j++)
			distance[0][j] = j * getInsertCost();  //Todo el costo de insertar la palabra la palabra de Fin
		
		for (int i = 1; i <= palabraInicio.length(); i++) {
			for (int j = 1; j <= palabraFin.length(); j++) {
				distance[i][j] = min(distance[i - 1][j] + getEraseCost(), 
									 distance[i][j - 1] + getInsertCost(),
									 distance[i - 1][j - 1]
											 + ((palabraInicio.charAt(i - 1) == palabraFin.charAt(j - 1)) ? getCopyCost()
										: getSwitchCost())); //El menor costo entre intercambiar o copiar
			}
		}
		return distance[palabraInicio.length()][palabraFin.length()];

	}

	private int min(int a, int b, int c) {
		if (a <= b && a <= c)
			return a;
		if (b <= a && b <= c)
			return b;
		return c;
	}

}
