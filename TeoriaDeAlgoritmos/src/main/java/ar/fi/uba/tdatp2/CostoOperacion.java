package ar.fi.uba.tdatp2;


public class CostoOperacion {
	private int costo;
	private int filaAnterior;
	private int colAnterior;
	public enum TipoOperacion{
		COPIAR,REEMPLAZAR,BORRAR,INSERTAR,TERMINAR,INTERCAMBIAR;
	}
	private TipoOperacion op;
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
	
	public CostoOperacion(int filaAnterior, int colAnterior, int costo,
			TipoOperacion op) {
		super();
		this.costo = costo;
		this.filaAnterior = filaAnterior;
		this.colAnterior = colAnterior;
		this.op = op;
	}
	@Override
	public String toString() {
		return "CostoOperacion [costo=" + costo + ", filaAnterior="
				+ filaAnterior + ", colAnterior=" + colAnterior + ", op=" + op
				+ "]";
	}
	
	

}
