package ar.fi.uba.tda.tdatp3;

import static org.junit.Assert.*;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class SolucionExactaTest {

	@Before
	public void setUp() throws Exception {
	}

	@After
	public void tearDown() throws Exception {
	}

	@Test
	public void test() {
		double [] datos = {0.4, 0.8, 0.5, 0.1, 0.7, 0.6, 0.1, 0.4, 0.2, 0.2};
		SolucionExacta binPack = new SolucionExacta(datos);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
	}

}
