package ar.fi.uba.tda.tdatp3;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;
import org.junit.Test;

import ar.fi.uba.tdatp3.SelectorDeSolucion;
import ar.fi.uba.tdatp3.SolucionAlternativa;
import ar.fi.uba.tdatp3.SolucionExacta;

public class SelectorDeSolucionTest {

	@Test
	public void siElParametroEsAElSelectorEsDeSolucionAlternativa() {
		
		SelectorDeSolucion selector = SelectorDeSolucion.obtenerSelector("A");
		
		assertThat("el selector", selector, is(SelectorDeSolucion.SOLUCION_ALTERNATIVA));
	}
	
	@Test
	public void siElParametroEsALaSolucionEsAlternativa() {
		
		SelectorDeSolucion selector = SelectorDeSolucion.obtenerSelector("A");
		
		assertThat("el selector", selector.obtenerSolucion(null), is(instanceOf(SolucionAlternativa.class)));
	}
	
	@Test
	public void siElParametroEsEElSelectorEsDeSolucionExacta() {
		
		SelectorDeSolucion selector = SelectorDeSolucion.obtenerSelector("E");
		
		assertThat("el selector", selector, is(SelectorDeSolucion.SOLUCION_EXACTA));
	}
	
	@Test
	public void siElParametroEsELaSolucionEsExacta() {
		
		SelectorDeSolucion selector = SelectorDeSolucion.obtenerSelector("E");
		
		assertThat("el selector", selector.obtenerSolucion(null), is(instanceOf(SolucionExacta.class)));
	}
}
