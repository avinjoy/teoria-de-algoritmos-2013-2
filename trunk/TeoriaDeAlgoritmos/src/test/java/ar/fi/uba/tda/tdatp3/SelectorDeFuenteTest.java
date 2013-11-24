package ar.fi.uba.tda.tdatp3;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;

import org.junit.Test;

import ar.fi.uba.tdatp3.CargadorDeElementos;
import ar.fi.uba.tdatp3.FuenteDeDatos;
import ar.fi.uba.tdatp3.GeneradorDeCasosRandom;
import ar.fi.uba.tdatp3.SelectorDeFuente;

public class SelectorDeFuenteTest {
	
	@Test
	public void siElParametroTerminaEnTXTLaFuenteEsElArchivo() {
		
		FuenteDeDatos fuente = SelectorDeFuente.obtenerFuente("datos.txt");
		
		assertThat("la fuente", fuente, is(instanceOf(CargadorDeElementos.class)));
	}
	
	@Test
	public void siElParametroEmpiezaConGuionPLaFuenteEsRandom() {
		
		FuenteDeDatos fuente = SelectorDeFuente.obtenerFuente("-P1000");
		
		assertThat("la fuente", fuente, is(instanceOf(GeneradorDeCasosRandom.class)));
	}
	
	@Test
	public void siLaFuenteEsRandomElParametroIndicaLaCantidadDeElementosAObtener() {
		
		FuenteDeDatos fuente = SelectorDeFuente.obtenerFuente("-P1000");
		
		assertThat("la fuente", fuente.obtenerDatos(), hasSize(1000));
		
	}

}
