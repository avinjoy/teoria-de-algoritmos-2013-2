using System;
using System.Collections.Generic;
using System.Text;

namespace tdatp3
{
    public class BackTracking
    {
        private float[] itemSize;
        private float[] bagFreeSpace;
        private bool[,] doesBagContainItem; 

        public BackTracking(float[] itemSize)
        {
            this.itemSize = itemSize;
            this.bagFreeSpace = new float[itemSize.Length];

            for (int i = 1; i < itemSize.Length; i++)
            {
                this.bagFreeSpace[i] = 1;
            }

            this.doesBagContainItem = new bool[this.bagFreeSpace.Length, this.itemSize.Length];
        }

        public bool pack(int item)
        {
            // output the solution if we're done
            if (item == itemSize.Length)
            {
                for (int i = 0; i < bagFreeSpace.Length; i++)
                {
                    Console.WriteLine("bag" + i);
                    for (int j = 0; j < itemSize.Length; j++)
                        if (doesBagContainItem[i, j])
                            Console.Write("item" + j + "(" + itemSize[j] + ") ");
                    Console.WriteLine();
                }
                return true;
            }

            // otherwise, keep traversing the state tree
            for (int i = 0; i < bagFreeSpace.Length; i++)
            {
                if (bagFreeSpace[i] >= itemSize[item])
                {
                    doesBagContainItem[i, item] = true; // put item into bag
                    bagFreeSpace[i] -= itemSize[item];
                    if (pack(item + 1))                 // explore subtree
                        return true;
                    bagFreeSpace[i] += itemSize[item];  // take item out of the bag
                    doesBagContainItem[i, item] = false;
                }
            }

            return false;
        }

    }

}
