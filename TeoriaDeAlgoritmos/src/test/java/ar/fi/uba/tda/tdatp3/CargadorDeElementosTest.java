package ar.fi.uba.tda.tdatp3;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;
import static org.mockito.Mockito.*;

import java.io.BufferedReader;
import java.io.IOException;

import org.junit.Test;

public class CargadorDeElementosTest {
	
	@Test
	public void unArchivoCon1EntradaNoTieneElementos() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("", (String)null);
		
		CargadorDeElementos cargador = new CargadorDeElementos(reader);
		
		assertThat("la lista de elementos", cargador.obtenerDatos(), hasSize(0));
		
		verify(reader, times(3)).readLine();
	}
	
	@Test
	public void unArchivoCon2EntradasNoTieneElementos() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("", "", (String)null);
		
		CargadorDeElementos cargador = new CargadorDeElementos(reader);
		
		assertThat("la lista de elementos", cargador.obtenerDatos(), hasSize(0));
		
		verify(reader, times(3)).readLine();
	}

	@Test
	public void unArchivoCon3EntradasTieneUnElemento() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("", "", "0.1", (String)null);
		
		CargadorDeElementos cargador = new CargadorDeElementos(reader);
		
		assertThat("la lista de elementos", cargador.obtenerDatos(), hasSize(1));
		assertThat("el elemento", cargador.obtenerDatos().get(0), is(0.1F));
		
		verify(reader, times(4)).readLine();
	}
	
	@Test
	public void unArchivoCon4EntradasTieneDosElementos() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("", "", "0.1", "0.9", (String)null);
		
		CargadorDeElementos cargador = new CargadorDeElementos(reader);
		
		assertThat("la lista de elementos", cargador.obtenerDatos(), hasSize(2));
		assertThat("el elemento", cargador.obtenerDatos().get(0), is(0.1F));
		assertThat("el elemento", cargador.obtenerDatos().get(1), is(0.9F));
		
		verify(reader, times(5)).readLine();
	}
	

}
