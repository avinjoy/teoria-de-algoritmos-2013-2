namespace tdatp3
{
    public class SolucionExacta
    {
        private readonly decimal[] _itemSize;
        private readonly decimal[] _bagFreeSpace;
        private readonly bool[,] _doesBagContainItem;

        private int _numberBags;

        public int NumberBags
        {
            get { return _numberBags; }
            set { _numberBags = value; }
        }

        public SolucionExacta(decimal[] itemSize, int bags)
        {
            _itemSize = itemSize;
            _bagFreeSpace = new decimal[bags];
            _numberBags = 0;

            for (int i = 0; i < _bagFreeSpace.Length; i++)
            {
                _bagFreeSpace[i] = 1;
            }

            _doesBagContainItem = new bool[_bagFreeSpace.Length, this._itemSize.Length];
        }

        //O(N!)
        public bool pack(int item)
        {
            // Si llegamos a la solucion, guardo la cantidad de envases
            if (item == _itemSize.Length)
            {
                for (int i = 0; i < _bagFreeSpace.Length; i++)
                {
                    for (int j = 0; j < _itemSize.Length; j++)
                        if (_doesBagContainItem[i, j])
                        {
                            _numberBags++;
                            break;
                        }
                }
                return true;
            }

            // de lo contrario, sigo recorriendo el arbol de elementos
            for (int i = 0; i < _bagFreeSpace.Length; i++)
            {
                if (_bagFreeSpace[i] >= _itemSize[item])
                {
                    _doesBagContainItem[i, item] = true; // pongo el elemento en el envase
                    _bagFreeSpace[i] -= _itemSize[item];
                    if (pack(item + 1))                 // exploro siguiente rama
                        return true;
                    _bagFreeSpace[i] += _itemSize[item];  // quito el elemento del envase
                    _doesBagContainItem[i, item] = false;
                }
            }

            return false;
        }
    }
}
