package ar.fi.uba.tda.tdatp3;

import java.util.ArrayList;
import java.util.List;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;
import org.junit.Test;

import ar.fi.uba.tdatp3.SolucionAlternativa;

public class SolucionAlternativaTest {

	@Test
	public void laSolucionAlternativaSeConstruyeConUnaListaDeElementos() {
		
		List<Float> elementos = new ArrayList<Float>();
		
		SolucionAlternativa sa = new SolucionAlternativa(elementos);
		
		assertThat("los elementos de la solución alternativa", sa.getElementos(), is(elementos));
	}
	
	@Test
	public void conUnElementoOcupamosUnEnvase() {
		
		List<Float> elementos = new ArrayList<Float>();
		elementos.add(0.8F);
		
		SolucionAlternativa sa = new SolucionAlternativa(elementos);
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(1));
	}
	
	@Test
	public void conDosElementosChicosOcupamosUnEnvase() {
		
		List<Float> elementos = new ArrayList<Float>();
		elementos.add(0.8F);
		elementos.add(0.2F);
		
		SolucionAlternativa sa = new SolucionAlternativa(elementos);
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(1));
	}
	
	@Test
	public void conDosElementosGrandesOcupamosDosEnvases() {
		
		List<Float> elementos = new ArrayList<Float>();
		elementos.add(0.8F);
		elementos.add(0.8F);
		
		SolucionAlternativa sa = new SolucionAlternativa(elementos);
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(2));
	}
	
	@Test
	public void conDosElementosGrandesYUnoChicoOcupamosDosEnvases() {
		
		List<Float> elementos = new ArrayList<Float>();
		elementos.add(0.8F);
		elementos.add(0.8F);
		elementos.add(0.2F);
		
		SolucionAlternativa sa = new SolucionAlternativa(elementos);
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(2));
	}
	
	@Test
	public void casoDelEnunciado() {
		
//		T={0,4; 0,8; 0,5; 0,1; 0,7; 0,6; 0,1; 0,4; 0,2; 0,2}
		List<Float> elementos = new ArrayList<Float>();
		elementos.add(0.4F);
		elementos.add(0.8F);
		elementos.add(0.5F);
		elementos.add(0.1F);
		elementos.add(0.7F);
		elementos.add(0.6F);
		elementos.add(0.1F);
		elementos.add(0.4F);
		elementos.add(0.2F);
		elementos.add(0.2F);
		
		SolucionAlternativa sa = new SolucionAlternativa(elementos);
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(6));
	}
}
