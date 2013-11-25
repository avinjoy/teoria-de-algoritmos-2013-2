using System;
using System.Collections.Generic;
using System.Text;

namespace tdatp3
{
    class SolucionExacta
    {
        private List<Objeto> _objetos;
        private Dictionary<int, double> _envases;

        public List<Objeto> Objetos
        {
            get { return _objetos; }
            set { _objetos = value; }
        }
        
        public Dictionary<int, double> Envases
        {
            get { return _envases; }
            set { _envases = value; }
        }

        public SolucionExacta(List<Objeto> objetos)
        {
            _objetos = objetos;
            _envases = new Dictionary<int, double>();

            _objetos.Sort(Objeto.Comparer);
            _objetos.Reverse();
        }

        /// <summary>
        ///Se ordenan los Objetos en orden decreciente.
        ///
        /// </summary>
        public void EncontrarSolucion()
        {
            if (_objetos.Count == 0)
                return;

            int nroEnvase = 0;
            _envases.Add(nroEnvase, 0);


            //O(N), N = Cantidad de Objetos.
            foreach (Objeto objeto in _objetos)
            {
                int idxExacto = -1;
                int idxEntra = -1;

                for (int i = 0; i < _envases.Count; i++)
                {
                    if (objeto.Tamanio + _envases[i] == 1)
                    {
                        idxExacto = i;
                        break;
                    }

                    if (_envases[i] + objeto.Tamanio <= 1 && idxEntra == -1)
                    {
                        idxEntra = i;
                    }
                }

                if (idxExacto != -1)
                {
                    _envases[idxExacto] = _envases[idxExacto] + objeto.Tamanio;
                }
                else if (idxEntra != -1)
                {
                    _envases[idxEntra] = _envases[idxEntra] + objeto.Tamanio;
                }
                else
                {
                    nroEnvase++;
                    _envases.Add(nroEnvase, objeto.Tamanio);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Solucion exacta: " + _envases.Count + " envases");
        }
    }
}
