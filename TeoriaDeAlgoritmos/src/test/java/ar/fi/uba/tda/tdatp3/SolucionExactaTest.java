package ar.fi.uba.tda.tdatp3;

import java.util.Arrays;

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
		Arrays.sort(datos);
		SolucionExacta binPack = new SolucionExacta(datos);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos2 = {0.8, 0.5, 0.1, 0.7, 0.6, 0.1, 0.4, 0.2, 0.2, 0.4};
		binPack = new SolucionExacta(datos2);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos3 = {0.5, 0.1, 0.7, 0.6, 0.1, 0.4, 0.2, 0.2, 0.4, 0.8};
		 binPack = new SolucionExacta(datos3);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos4 = {0.1, 0.7, 0.6, 0.1, 0.4, 0.2, 0.2,0.4, 0.8, 0.5};
		binPack = new SolucionExacta(datos4);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos5 = {0.7, 0.6, 0.1, 0.4, 0.2, 0.2, 0.4, 0.8, 0.5, 0.1};
		 binPack = new SolucionExacta(datos5);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos6 = {0.6, 0.1, 0.4, 0.2, 0.2, 0.4, 0.8, 0.5, 0.1, 0.7};
		 binPack = new SolucionExacta(datos6);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos7 = {0.1, 0.4, 0.2, 0.2, 0.4, 0.8, 0.5, 0.1, 0.7, 0.6};
		binPack = new SolucionExacta(datos7);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos8 = {0.4, 0.2, 0.2, 0.4, 0.8, 0.5, 0.1, 0.7, 0.6, 0.1};
		binPack = new SolucionExacta(datos8);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos10 = {0.2, 0.2, 0.4, 0.8, 0.5, 0.1, 0.7, 0.6, 0.1, 0.4};
		binPack = new SolucionExacta(datos10);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		double [] datos9 = {0.2, 0.4, 0.8, 0.5, 0.1, 0.7, 0.6, 0.1, 0.4, 0.2};
		binPack = new SolucionExacta(datos9);
		if (!binPack.pack(0))
			System.out.println("No existe solucion");
		
		
		
//		    int datos[] = {4,8,5,1,7,6,1,4,2,2};
//		    BinPack bp = new BinPack(datos,10,10);
//		    bp.clear();
//		    bp.pack();
//		    System.out.println(bp);
		    
		    
		    
	}

}
