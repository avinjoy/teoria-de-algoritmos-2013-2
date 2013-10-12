package ar.fi.uba.tda;

import java.io.PrintStream;

import org.junit.Before;
import org.junit.Test;

import static org.mockito.Mockito.*;

public class RobustezTest {
	
	private PrintStream err;

	@Before
	public void setup() {
	
		err = mock(PrintStream.class);
		System.setErr(err);
	}
	
	@Test
	public void elProgramaTomaComoEntradaLaRobustezYElNombreDeArchivo() {
		
		Robustez.main(new String[]{"3", "grafo.txt"});
		
		verify(err, never()).println(anyString());
	}
	
	@Test
	public void elProgramaTomaComoEntradaLaRobustezYTomaUnNombreDeArchivoDefault() {
		
		Robustez.main(new String[]{"3"});
		
		verify(err, never()).println(anyString());
	}
	
	@Test
	public void siNoSeProveenDatosInformaDelError() {
		
		Robustez.main(new String[]{});
		
		verify(err).println("Se debe ingresar el grado de robustez y el nombre de archivo");
		verify(err).println("O solo el grado de robustez");
		verify(err).println("i.e.: java -jar Robustez.jar 3");
	}

}
