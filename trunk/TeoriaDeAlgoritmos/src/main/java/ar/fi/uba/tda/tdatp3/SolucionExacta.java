package ar.fi.uba.tda.tdatp3;

class SolucionExacta {

	private double[] itemSize;
	private double[] bagFreeSpace;
	private boolean[][] doesBagContainItem;

	public SolucionExacta(double[] itemSize) {
		this.itemSize = itemSize;
		this.bagFreeSpace = new double[itemSize.length];

		for (int i = 1; i < itemSize.length; i++) {
			this.bagFreeSpace[i] = 1;
		}

		this.doesBagContainItem = new boolean[this.bagFreeSpace.length][this.itemSize.length];
	}

	public boolean pack(int item) {
		// output the solution if we're done
		if (item == itemSize.length) {
			for (int i = 0; i < bagFreeSpace.length; i++) {
				System.out.println("bag" + i);
				for (int j = 0; j < itemSize.length; j++)
					if (doesBagContainItem[i][j])
						System.out.println("item" + j + "(" + itemSize[j]
								+ ") ");
			}
			return true;
		}

		// otherwise, keep traversing the state tree
		for (int i = 0; i < bagFreeSpace.length; i++) {
			if (bagFreeSpace[i] >= itemSize[item]) {
				doesBagContainItem[i][item] = true; // put item into bag
				bagFreeSpace[i] -= itemSize[item];
				if (pack(item + 1)) // explore subtree
					return true;
				bagFreeSpace[i] += itemSize[item]; // take item out of the bag
				doesBagContainItem[i][item] = false;
			}
		}

		return false;
	}

}
