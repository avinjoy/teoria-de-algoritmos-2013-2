using System;
using System.Collections.Generic;
using System.Text;

namespace tdatp3
{
    public class SolucionAproximada
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

        public SolucionAproximada(List<Objeto> objetos)
        {
            _objetos = objetos;
            _envases = new Dictionary<int, double>();
        }

        /// <summary>
        ///Se abre el primer envase y se empaqueta el primer objeto,
        ///luego por cada uno de los objetos restantes se prueba si cabe en el envase actual que está
        ///abierto, si es así se lo empaqueta en el mismo envase y se continúa con el siguiente objeto,
        ///si no cabe se cierra el envase actual y se abre uno nuevo que pasa a ser el envase actual y
        ///se empaqueta el objeto y continúa con el próximo hasta lograr empaquetar todos los objetos.
        /// </summary>
        public void EncontrarSolucion()
        {
            if (_objetos.Count == 0)
                return;

            int nroEnvase = 1;
            _envases.Add(nroEnvase, 0);

            //O(N), N = Cantidad de Objetos.
            foreach (Objeto objeto in _objetos)
            {

                double tamanioEnvase = _envases[nroEnvase];

                if (tamanioEnvase + objeto.Tamanio <= 1)
                {
                    _envases[nroEnvase] = tamanioEnvase + objeto.Tamanio;
                }
                else
                {
                    nroEnvase++;
                    _envases.Add(nroEnvase, objeto.Tamanio);
                }
            }
        }
    }
}
