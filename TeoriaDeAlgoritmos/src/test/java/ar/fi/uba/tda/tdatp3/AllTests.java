package ar.fi.uba.tda.tdatp3;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.junit.runners.Suite.SuiteClasses;

@RunWith(Suite.class)
@SuiteClasses({ CargadorDeElementosTest.class, EmpaquetamientoTest.class,
		GeneradorDeCasosRandomTest.class, SelectorDeFuenteTest.class,
		SelectorDeSolucionTest.class, SolucionAlternativaTest.class,
		SolucionExactaTest.class, SolucionTest.class })
public class AllTests {

}
