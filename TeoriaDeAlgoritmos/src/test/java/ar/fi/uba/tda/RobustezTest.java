package ar.fi.uba.tda;

import static org.mockito.Matchers.anyString;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.never;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.PrintStream;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tda.colecciones.Arista;
import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.ListaEnlazada;
import ar.fi.uba.tda.colecciones.Vertice;
import ar.fi.uba.tda.util.AumentadorDeRobustez;
import ar.fi.uba.tda.util.CargadorDeGrafos;

public class RobustezTest {
	
	private PrintStream err;

	@Before
	public void setup() {
	
		err = mock(PrintStream.class);
		System.setErr(err);
	}
	
	@Test
	public void elProgramaTomaComoEntradaLaRobustezYElNombreDeArchivo() throws IOException {
		
		Robustez.main(new String[]{"3", "src/test/resources/grafo.txt"});
		
		verify(err, never()).println(anyString());
	}
	
	@Test
	public void elProgramaTomaComoEntradaLaRobustezYTomaUnNombreDeArchivoDefault() throws IOException {
		
		Robustez.main(new String[]{"3"});
		
		verify(err, never()).println(anyString());
	}
	
	@Test
	public void siNoSeProveenDatosInformaDelError() throws IOException {
		
		Robustez.main(new String[]{});
		
		verify(err).println("Se debe ingresar el grado de robustez y el nombre de archivo");
		verify(err).println("O solo el grado de robustez");
		verify(err).println("i.e.: java -jar Robustez.jar 3");
	}
	
	@Test
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public void elProgramaCargaElGrafoBuscaCiclosYAumentaLaRobustez() throws IOException {
		
		Grafo grafo = mock(Grafo.class);
		CargadorDeGrafos cargador = mock(CargadorDeGrafos.class);
		AumentadorDeRobustez aumentador = mock(AumentadorDeRobustez.class);
		BufferedReader reader = mock(BufferedReader.class);
		ListaEnlazada<Vertice<String>> listaVertices = mock(ListaEnlazada.class);
		Vertice<String> vertice = mock(Vertice.class);
		
		ListaEnlazada<ListaEnlazada<Vertice>> listaCiclos = mock(ListaEnlazada.class);
		
		when(grafo.getVertices()).thenReturn(listaVertices);
		when(listaVertices.primero()).thenReturn(vertice);
		when(grafo.getCiclosGrafo()).thenReturn(listaCiclos);
		when(aumentador.getAristasAgregadas()).thenReturn(new ListaEnlazada<Arista>());
		
		Robustez robustez = new Robustez(grafo, cargador, aumentador);
		
		robustez.ejecutar(3, reader);
		
		verify(cargador).cargar(reader);
		verify(grafo).encontrarCiclos(listaVertices);
		verify(grafo).getCiclosGrafo();
		verify(aumentador).aumentar(listaCiclos, 3);
	}
	
	@Test
	public void grafoQueNoSePuedeAumentarYPidoRobustez3() throws IOException {
		
		Robustez.main(new String[]{"3", "src/test/resources/grafoImposibleDeAumentar.txt"});
		verify(err, never()).println(anyString());
	}
	
	@Test
	public void grafoGrandeRobustez3() throws IOException {
		
		Robustez.main(new String[]{"3", "src/test/resources/grafoGrande.txt"});
		verify(err, never()).println(anyString());
	}

}
