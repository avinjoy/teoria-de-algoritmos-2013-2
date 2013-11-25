package ar.fi.uba.tda.tdatp3;

import static org.mockito.Mockito.*;

import java.io.PrintStream;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp3.CargadorDeElementos;
import ar.fi.uba.tdatp3.Empaquetamiento;
import ar.fi.uba.tdatp3.GeneradorDeCasosRandom;
import ar.fi.uba.tdatp3.SelectorDeSolucion;

public class EmpaquetamientoTest {

	private PrintStream err;
	private PrintStream out;
	private Empaquetamiento instancia;

	@Before
	public void setup() {
	
		err = mock(PrintStream.class);
		System.setErr(err);
		
		out = mock(PrintStream.class);
		System.setOut(out);
		
		instancia = spy(new Empaquetamiento());
		Empaquetamiento.setInstancia(instancia);
	}
	
	@Test
	public void siSeInvocaConAYUnArchivoEjecutaLaSolucionAproximada() {
		
		Empaquetamiento.main(new String[]{"A", "datos.txt"});
		
		verify(err, never()).println();
		
		verify(instancia).ejecutar(eq(SelectorDeSolucion.SOLUCION_ALTERNATIVA), isA(CargadorDeElementos.class), eq(1));
		
		verify(out).println("Solución Aproximada: 1");
		
	}
	
	@Test
	public void siSeInvocaConAYGuionPEjecutaLaSolucionAproximadaConDatosRandom() {
		
		Empaquetamiento.main(new String[]{"A", "-P1"});
		
		verify(err, never()).println();
		
		verify(instancia).ejecutar(eq(SelectorDeSolucion.SOLUCION_ALTERNATIVA), isA(GeneradorDeCasosRandom.class), eq(1));
		
		verify(out).println("Solución Aproximada: 1");
		
	}
	
	@Test
	public void siSeInvocaConEYUnArchivoEjecutaLaSolucionExacta() {
		
		Empaquetamiento.main(new String[]{"E", "datos.txt"});
		
		verify(err, never()).println();
		
		verify(instancia).ejecutar(eq(SelectorDeSolucion.SOLUCION_EXACTA), isA(CargadorDeElementos.class), eq(1));
		
		verify(out).println("Solución Exacta: 0");
		
	}
//	
	@Test
	public void siSeInvocaConEYGuionPEjecutaLaSolucionExactaConDatosRandom() {
		
		Empaquetamiento.main(new String[]{"E", "-P1"});
		
		verify(err, never()).println();
		
		verify(instancia).ejecutar(eq(SelectorDeSolucion.SOLUCION_EXACTA), isA(GeneradorDeCasosRandom.class), eq(1));
		
		verify(out).println("Solución Exacta: 0");
		
	}
	
	@Test
	public void siSeInvocaConAGuionPYConGuionVEjecutaLaSolucionExactaConDatosRandomNVeces() {
		
		Empaquetamiento.main(new String[]{"E", "-P1", "-V2"});
		
		verify(err, never()).println();
		
		verify(instancia).ejecutar(eq(SelectorDeSolucion.SOLUCION_EXACTA), isA(GeneradorDeCasosRandom.class), eq(2));
		
		verify(out).println("Solución Exacta: 0");
		
	}
}
