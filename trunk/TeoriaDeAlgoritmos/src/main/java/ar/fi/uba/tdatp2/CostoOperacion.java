package ar.fi.uba.tdatp2;


public class CostoOperacion {

	public enum TipoOperacion{
		
		COPIAR(1) {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
				
				palabraResultante.setCharAt(j, palabraInicio.charAt(i));
				System.out.println("Copiar " + palabraInicio.charAt(i));
				
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
		REEMPLAZAR(1) {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin,
					StringBuilder palabraResultante, int i, int j) {
				
				palabraResultante.setCharAt(j, palabraFin.charAt(j));
				
				System.out.println("Reemplazar " + palabraInicio.charAt(i) + " " + palabraFin.charAt(j));
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
		BORRAR(1) {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin, StringBuilder palabraResultante, int i, int j) {
				
				System.out.println("Borrar " + palabraInicio.charAt(i));
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
		INSERTAR(1) {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin, StringBuilder palabraResultante, int i, int j) {
				
				palabraResultante.setCharAt(j, palabraFin.charAt(j));
				
				System.out.println("Insertar " + palabraFin.charAt(j));
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
		TERMINAR(1) {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin, StringBuilder palabraResultante, int i, int j) {
				
				System.out.println("Terminar");
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
		INTERCAMBIAR(1) {
			@Override
			public void ejecutar(String palabraInicio, String palabraFin, StringBuilder palabraResultante, int i, int j) {
				
				palabraResultante.setCharAt(j, palabraInicio.charAt(i + 1));
				palabraResultante.setCharAt(j + 1, palabraInicio.charAt(i));
				
				System.out.println("Intercambiar " + palabraInicio.charAt(i) + " " + palabraInicio.charAt(i + 1));
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

		private Integer costo;

		private TipoOperacion(int costo) {
			this.costo = costo;
		}
		public abstract void ejecutar(String palabraInicio, String palabraFin, StringBuilder palabraResultante, int i, int j);

		public abstract int nuevoI(int i);
		
		public abstract int nuevoJ(int j);

		public void setCosto(Integer costo) {
			this.costo = costo;
		}
		
		public int getCosto() {
			return this.costo;
		}
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
