package ar.fi.uba.tda.tdatp2;

import static org.mockito.Matchers.anyString;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.never;
import static org.mockito.Mockito.verify;

import java.io.IOException;
import java.io.PrintStream;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp2.Distancia;

public class DistanciaTest {
	
	private PrintStream err;

	@Before
	public void setup() {
	
		err = mock(PrintStream.class);
		System.setErr(err);
	}
	
	@Test
	public void elProgramaTomaComoEntradaLasPalabrasYElArchivoDeCostos() throws IOException {
		
		Distancia.main(new String[]{"Algoritmo", "Altruista", "src/test/resources/costos.txt"});
		
		verify(err, never()).println(anyString());
	}
	
	@Test
	public void elProgramaTomaComoEntradaLasPalabrasYElArchivoDeCostosPorDefault() throws IOException {
		
		Distancia.main(new String[]{"Algoritmo", "Altruista"});
		
		verify(err, never()).println(anyString());
	}
	
	@Test
	public void siNoSeProveenDatosInformaDelError() throws IOException {
		
		Distancia.main(new String[]{});
		
		verify(err).println("Se debe ingresar la palabra inicial, la palabra final y el nombre del archivo de costos");
		verify(err).println("O solo las palabras inciales y finales");
		verify(err).println("i.e.: java -jar Distancia.jar Algoritmo Altruista");
	}

}
