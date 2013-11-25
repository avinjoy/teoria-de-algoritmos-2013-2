package ar.fi.uba.tdatp3;

import java.math.BigDecimal;

public class SolucionExacta extends Solucion {

	private double[] itemSize;
	private double[] bagFreeSpace;
	private boolean[][] doesBagContainItem;

	public SolucionExacta(double[] itemSize) {
		super(null);
		this.itemSize = itemSize;
		this.bagFreeSpace = new double[itemSize.length];

		for (int i = 0; i < itemSize.length; i++) {
			this.bagFreeSpace[i] = 1.0F;
		}

		this.doesBagContainItem = new boolean[this.bagFreeSpace.length][this.itemSize.length];
	}

	public SolucionExacta(FuenteDeDatos fuente) {
		// TODO Auto-generated constructor stub
		super(fuente);
	}

	@Override
	public Integer getEnvases() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public void aplicarAlgoritmo() {
		// TODO Auto-generated method stub
		
	}
	
	public boolean pack(int item) {
		// output the solution if we're done
		if (item == itemSize.length) {
			for (int i = 0; i < bagFreeSpace.length; i++) {
				System.out.println("bag" + i);
				for (int j = 0; j < itemSize.length; j++)
					if (doesBagContainItem[i][j] == true)
						System.out.println("item" + j + "(" + itemSize[j]
								+ ") ");
			}
			return true;
		}

		// otherwise, keep traversing the state tree
		for (int i = 0; i < bagFreeSpace.length; i++) {
			if (round(bagFreeSpace[i],2) >= round(itemSize[item],2)) {
				doesBagContainItem[i][item] = true; // put item into bag
				bagFreeSpace[i]=round(bagFreeSpace[i] -= itemSize[item],2);
				if (pack(item+1))
					return true;
				bagFreeSpace[i]=round(bagFreeSpace[i] += itemSize[item],2); // take item out of the bag
				doesBagContainItem[i][item] = false;
			}
				
		
		}

		return false;
	}
	
	public static double round(double value, int places) {
	    if (places < 0) throw new IllegalArgumentException();

	    BigDecimal bd = new BigDecimal(value);
	    bd = bd.setScale(places, BigDecimal.ROUND_HALF_UP);
	    return bd.doubleValue();
	}

}
