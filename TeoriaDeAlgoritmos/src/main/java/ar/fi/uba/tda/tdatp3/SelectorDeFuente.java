package ar.fi.uba.tda.tdatp3;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;

import ar.fi.uba.tdatp3.CargadorDeElementos;
import ar.fi.uba.tdatp3.FuenteDeDatos;
import ar.fi.uba.tdatp3.GeneradorDeCasosRandom;

public class SelectorDeFuente {

	public static FuenteDeDatos obtenerFuente(String parametro) {
		
		FuenteDeDatos fuenteDeDatos = null;
		
		if (parametro.endsWith(".txt")) {
			
			fuenteDeDatos = construirCargador(parametro);
			
		} else {
		
			fuenteDeDatos = construirGenerador(parametro);
		}
		
		return fuenteDeDatos;
	}

	public static FuenteDeDatos construirCargador(String parametro) {
		
		FuenteDeDatos fuenteDeDatos = null;
		BufferedReader reader;
		
		try {
			reader = new BufferedReader(new FileReader(parametro));
			fuenteDeDatos = new CargadorDeElementos(reader);
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		return fuenteDeDatos;
	}
	
	public static FuenteDeDatos construirGenerador(String parametro) {
	
		FuenteDeDatos fuenteDeDatos;
		String cantidadElementosStr = parametro.substring(2);
		int cantidadElementos = Integer.valueOf(cantidadElementosStr);
		
		fuenteDeDatos = new GeneradorDeCasosRandom(cantidadElementos);
		return fuenteDeDatos;
	}

}
