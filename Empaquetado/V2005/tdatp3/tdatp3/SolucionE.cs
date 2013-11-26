using System;
using System.Collections.Generic;
using System.Text;

namespace tdatp3
{
    class SolucionE
    {
        private decimal[] itemSize;
        private decimal[] bagFreeSpace;
        private bool[,] doesBagContainItem;

        private int numberBags;

        public int NumberBags
        {
            get { return numberBags; }
            set { numberBags = value; }
        }

        public SolucionE(decimal[] itemSize, int bags)
        {
            this.itemSize = itemSize;
            this.bagFreeSpace = new decimal[bags];
            this.numberBags = 0;

            for (int i = 0; i < bagFreeSpace.Length; i++)
            {
                this.bagFreeSpace[i] = 1;
            }

            this.doesBagContainItem = new bool[this.bagFreeSpace.Length, this.itemSize.Length];
        }

        //O(N!)
        public bool pack(int item)
        {
            // Si llegamos a la solucion, guardo la cantidad de envases
            if (item == itemSize.Length)
            {
                for (int i = 0; i < bagFreeSpace.Length; i++)
                {
                    for (int j = 0; j < itemSize.Length; j++)
                        if (doesBagContainItem[i, j])
                        {
                            numberBags++;
                            break;
                        }
                }
                return true;
            }

            // de lo contrario, sigo recorriendo el arbol de elementos
            for (int i = 0; i < bagFreeSpace.Length; i++)
            {
                if (bagFreeSpace[i] >= itemSize[item])
                {
                    doesBagContainItem[i, item] = true; // pongo el elemento en el envase
                    bagFreeSpace[i] -= itemSize[item];
                    if (pack(item + 1))                 // exploro siguiente rama
                        return true;
                    bagFreeSpace[i] += itemSize[item];  // quito el elemento del envase
                    doesBagContainItem[i, item] = false;
                }
            }

            return false;
        }
    }
}
