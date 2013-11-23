using System;
using System.Collections.Generic;
using System.Text;

namespace tdatp3
{
    public class BackTracking
    {
        private decimal[] itemSize;
        private decimal[] bagFreeSpace;
        private bool[,] doesBagContainItem;

        public BackTracking(decimal[] itemSize)
        {
            this.itemSize = itemSize;
            this.bagFreeSpace = new decimal[itemSize.Length];

            for (int i = 0; i < itemSize.Length; i++)
            {
                this.bagFreeSpace[i] = 1;
            }

            this.doesBagContainItem = new bool[this.bagFreeSpace.Length, this.itemSize.Length];

            Array.Sort(itemSize);
            Array.Reverse(itemSize);
        }

        public void imprimirSolucion() 
        {
            for (int i = 0; i < bagFreeSpace.Length; i++)
            {
                Console.WriteLine("bag" + i);
                for (int j = 0; j < itemSize.Length; j++)
                    if (doesBagContainItem[i, j])
                        Console.Write("item" + j + "(" + itemSize[j] + ") ");
                Console.WriteLine();
            }
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

            int entraJusto = -1;
            int hayLugar = -1;
            // otherwise, keep traversing the state tree
            for (int i = 0; i < bagFreeSpace.Length; i++)
            {
                if (bagFreeSpace[i] - itemSize[item] == 0)
                {
                    entraJusto = i;
                    break;
                }

                if (bagFreeSpace[i] >= itemSize[item] && hayLugar == -1)
                {
                    hayLugar = i;
                }
                /*
                if (bagFreeSpace[i] >= itemSize[item])
                {
                    doesBagContainItem[i, item] = true; // put item into bag
                    bagFreeSpace[i] -= itemSize[item];
                    Math.Round(bagFreeSpace[i], 1);
                    if (pack(item + 1))                 // explore subtree
                        return true;
                    
                    bagFreeSpace[i] += itemSize[item];  // take item out of the bag
                    doesBagContainItem[i, item] = false;
                }
                */
            }

            //SNO
            if (entraJusto != -1)
            {
                doesBagContainItem[entraJusto, item] = true; // put item into bag
                bagFreeSpace[entraJusto] -= itemSize[item];
                bagFreeSpace[entraJusto]= Math.Round(bagFreeSpace[entraJusto], 1);
                if (pack(item + 1))                 // explore subtree
                    return true;

                bagFreeSpace[entraJusto] += itemSize[item];  // take item out of the bag
                doesBagContainItem[entraJusto, item] = false;
            }
            else if (hayLugar != -1)
            {
                doesBagContainItem[hayLugar, item] = true; // put item into bag
                bagFreeSpace[hayLugar] -= itemSize[item];
                Math.Round(bagFreeSpace[hayLugar], 1);
                bagFreeSpace[hayLugar] = Math.Round(bagFreeSpace[hayLugar], 1);
                if (pack(item + 1))                 // explore subtree
                    return true;

                bagFreeSpace[hayLugar] += itemSize[item];  // take item out of the bag
                doesBagContainItem[hayLugar, item] = false;
            }

            return false;
        }

    }

}
