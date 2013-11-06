package ar.fi.uba.tdatp2;


public class CostoOperacion {

	public enum TipoOperacion{
		
		COPIAR {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
				
				palabraResultante.setCharAt(j, palabraInicio.charAt(i));
				
			}

			@Override
			public int nuevoI(int i) {
				return i + 1;
			}

			@Override
			public int nuevoJ(int j) {
				return j + 1;
			}
		},
		REEMPLAZAR {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
				
				palabraResultante.setCharAt(j, palabraFin.charAt(j));
			}
			
			@Override
			public int nuevoI(int i) {
				return i + 1;
			}

			@Override
			public int nuevoJ(int j) {
				return j + 1;
			}
		},
		BORRAR {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
			}
			
			@Override
			public int nuevoI(int i) {
				return i + 1;
			}

			@Override
			public int nuevoJ(int j) {
				return j;
			}
		},
		INSERTAR {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
				palabraResultante.setCharAt(j, palabraFin.charAt(j));
			}
			
			@Override
			public int nuevoI(int i) {
				return i;
			}

			@Override
			public int nuevoJ(int j) {
				return j + 1;
			}
		},
		TERMINAR {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
			}
			
			@Override
			public int nuevoI(int i) {
				return i + 1; //TODO
			}

			@Override
			public int nuevoJ(int j) {
				return j;
			}
		},
		INTERCAMBIAR {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
				
				palabraResultante.setCharAt(j, palabraInicio.charAt(i + 1));
				palabraResultante.setCharAt(j + 1, palabraInicio.charAt(i));
			}
			
			@Override
			public int nuevoI(int i) {
				return i + 2;
			}

			@Override
			public int nuevoJ(int j) {
				return j + 2;
			}
		};

		public abstract void ejecutar(String palabraInicio, String palabraFin, StringBuilder palabraResultante, int i, int j);

		public abstract int nuevoI(int i);
		
		public abstract int nuevoJ(int j);
	}
	
	private int costo;
	private int filaAnterior;
	private int colAnterior;
	private TipoOperacion op;
	private char letter;
	
	public int getCosto() {
		return costo;
	}
	public void setCosto(int costo) {
		this.costo = costo;
	}
	public int getFilaAnterior() {
		return filaAnterior;
	}
	public void setFilaAnterior(int filaAnterior) {
		this.filaAnterior = filaAnterior;
	}
	public int getColAnterior() {
		return colAnterior;
	}
	public void setColAnterior(int colAnterior) {
		this.colAnterior = colAnterior;
	}
	public TipoOperacion getOp() {
		return op;
	}
	public void setOp(TipoOperacion op) {
		this.op = op;
	}
	
	public char getLetter() {
		return letter;
	}
	public void setLetter(char letter) {
		this.letter = letter;
	}
	
	public CostoOperacion(int filaAnterior, int colAnterior, int costo,
			TipoOperacion op) {
		super();
		this.costo = costo;
		this.filaAnterior = filaAnterior;
		this.colAnterior = colAnterior;
		this.op = op;
	}
	
	public CostoOperacion(int costo, int filaAnterior, int colAnterior,
			TipoOperacion op, char letter) {
		super();
		this.costo = costo;
		this.filaAnterior = filaAnterior;
		this.colAnterior = colAnterior;
		this.letter = letter;
		this.op = op;
	}
	
	@Override
	public String toString() {
		return "CostoOperacion [costo=" + costo + ", filaAnterior="
				+ filaAnterior + ", colAnterior=" + colAnterior + ", op=" + op
				+ ", letter=" + letter+"]";
	}
	
	
	

}
