using System;
using System.Collections.Generic;
using System.Text;

namespace EmpaquetadoSolExacta
{
    class BackTracking
    {
        private Elemento[] almacen;

        private List<Elemento> tmpEnvase;
        private List<Elemento> Envase;

        private List<List<Elemento>> Solucion;
        float valorMaximo;

        public BackTracking()
        {
            this.tmpEnvase = new List<Elemento>();
            this.Envase = new List<Elemento>();
        }

        // Solución por backtracking
        public void resolverProblemaBT(int posicion)
        {
            float valorEnvase = getValor(tmpEnvase);     // valor de la solucion temporal

            if (posicion >= almacen.GetLength(1))        // si ya se tuvieron en cuenta todos los elementos
            {   
                
                if (valorEnvase > valorMaximo)           // si el valor es mayor que el máximo anterior
                {  
                    valorMaximo = valorEnvase;           // se actualiza el valor mayor
                    Envase.Clear();
                    Envase.AddRange(tmpEnvase);
                }
                return;
            }

            Elemento e = almacen[posicion];
            // Si el elemento se puede agregar, se envía a la mochila temporal
            if (valorEnvase + e.Valor <= valorMaximo)
            {
                tmpEnvase.Add(e);                       // Se agrega a la mochila temporal
                resolverProblemaBT(posicion + 1);       // se revisa para el siguiente elemento
                tmpEnvase.Remove(e);                    // Se retira el elemento
            }
            // Si no se pudo agregar, o ya se agregó y se retiró, se revisa para el siguiente
            resolverProblemaBT(posicion + 1);
        }


        float getValor(List<Elemento> tmp) {
            float respuesta=0;
            foreach(Elemento e in tmp) respuesta+=e.Valor;
                return respuesta;
        }

    }

    public class Elemento
    {
        private float _valor;
        private float p;

        public Elemento(){}

        public Elemento(float valor)
        {
            this._valor = valor;
        }

        public float Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
    }
}
