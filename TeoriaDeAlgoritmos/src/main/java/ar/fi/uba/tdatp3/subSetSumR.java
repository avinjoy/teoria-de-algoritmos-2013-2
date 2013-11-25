package ar.fi.uba.tdatp3;

import java.util.Set;
import java.util.TreeSet;
import java.util.Vector;

public class subSetSumR {
	// Solving Subset sum recursion
	// Programmed by Olac Fuentes
	// Last modified November 17, 2011
	// Subset sum consists of finding a subset of mySet whose elements add up to
	// goal
	// It is a well-know NP-complete problem
	static double[] mySet = { 0.4, 0.8, 0.5, 0.1, 0.7, 0.6, 0.1, 0.4, 0.2, 0.2 };
	static Vector<Double> respuesta;
	static Vector<Vector<Double>> totalResp;
	static Set <String> resultados = new TreeSet<String>();
	static String resultTotal="";
	
	

	public static boolean subSetSumRecur(double[] mySet, int n, double goal) {
		if (goal == 0)
			return true;
		if ((goal < 0) | (n < 0))
			return false;
		if (subSetSumRecur(mySet, n - 1, goal - mySet[n])) {
			System.out.print(mySet[n] + " ");
			return true;
		}
		return (subSetSumRecur(mySet, n - 1, goal));
	}

	public static void main(String[] args) {

		double[] mySet = { 0.4, 0.8, 0.5, 0.1, 0.7, 0.6, 0.1, 0.4, 0.2, 0.2 };

		// Try multiple values of goal, print subset if it exists
		System.out.println("The Goal is : " + 1.0);
		//System.out.println(subSetSumRecur(mySet, mySet.length - 1, 1.0));
		findNumbers(mySet, 0, 0, 1, "");
		System.out.println("FIN");
	}
	
	static void findNumbers(double[] list, int index, double current, double goal, String result)
	{ 
		
	  if (list.length < index || current>goal)
	          return;
	   for (int i = index; i < list.length; i++) {
	      if (current + list[i] == goal)   {
	        System.out.println(result + " " + (list[i]));
	         resultTotal = result + " " + (list[i]);
	        resultados.add(resultTotal);
	        resultTotal="";
	       }
	       else if (current + list[i] < goal) {
	           findNumbers(list, i + 1, current + list[i], goal, result + " " + list[i]);
	        }
	  }
	}
}
