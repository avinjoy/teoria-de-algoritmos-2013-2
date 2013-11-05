using System;
using System.Collections.Generic;
using System.Text;

namespace TDATP2
{
    public class DistanciaEdicion
    {

        private int[,] distance;
        private String palabraInicio;
        private String palabraFin;
        private char[] resultado;
        private int copyCost;
        private int replaceCost;
        private int insertCost;
        private int switchCost;
        private int endCost;
        private int eraseCost;
        private int i = 0;
        private int j = 0;

        public DistanciaEdicion(String palabraInicio, String palabraFin,
                int copyCost, int replaceCost, int insertCost, int switchCost,
                int endCost, int eraseCost) {
		this.distance = new int[palabraInicio.Length,palabraFin.Length];
		this.palabraInicio = palabraInicio;
		this.palabraFin = palabraFin;
		this.copyCost = copyCost;
		this.replaceCost = replaceCost;
		this.insertCost = insertCost;
		this.switchCost = switchCost;
		this.endCost = endCost;
		this.eraseCost = eraseCost;
		this.resultado = new char[(palabraInicio.Length < palabraFin.Length) ? palabraFin
				.Length : palabraInicio.Length];
	}

        public int getCopyCost()
        {
            return copyCost;
        }

        public void setCopyCost(int copyCost)
        {
            this.copyCost = copyCost;
        }

        public int getReplaceCost()
        {
            return replaceCost;
        }

        public void setReplaceCost(int replaceCost)
        {
            this.replaceCost = replaceCost;
        }

        public int getInsertCost()
        {
            return insertCost;
        }

        public void setInsertCost(int insertCost)
        {
            this.insertCost = insertCost;
        }

        public int getSwitchCost()
        {
            return switchCost;
        }

        public void setSwitchCost(int switchCost)
        {
            this.switchCost = switchCost;
        }

        public int getEndCost()
        {
            return endCost;
        }

        public void setEndCost(int endCost)
        {
            this.endCost = endCost;
        }

        public int getEraseCost()
        {
            return eraseCost;
        }

        public void setEraseCost(int eraseCost)
        {
            this.eraseCost = eraseCost;
        }

        public int[,] getDistance()
        {
            return distance;
        }

        public void setDistance(int[,] distance)
        {
            this.distance = distance;
        }

        public String getPalabraInicio()
        {
            return palabraInicio;
        }

        public void setPalabraInicio(String palabraInicio)
        {
            this.palabraInicio = palabraInicio;
        }

        public String getPalabraFin()
        {
            return palabraFin;
        }

        public void setPalabraFin(String palabraFin)
        {
            this.palabraFin = palabraFin;
        }

        public char[] getResultado()
        {
            return resultado;
        }

        public String getResultadoAsString()
        {
            return new String(resultado);

        }

        public void setResultado(char[] resultado)
        {
            this.resultado = resultado;
        }

        public int calcularDistanciaEdicion()
        {
            // Casos base (si no viene la palabra inicial o la palabra final)
            if (palabraInicio.Length == 0)
            {
                resultado = palabraFin.ToCharArray();
                return palabraFin.Length * insertCost; // Costo total de inserción
                // de cada letra de la
                // palabra final
            }
            if (palabraFin.Length == 0)
            {
                resultado = "".ToCharArray();
                return palabraInicio.Length * eraseCost; // Costo total de
                // borrado de cada
                // letra de la palabra
                // inicial
            }

            // si son distintas hay que ver el min entre reemplazar, borrar y copiar
            // para el primer caracter
            if (palabraInicio[0] != palabraFin[0])
            {
                distance[0,0] = Math.Min(replaceCost, eraseCost + insertCost);
            }

            // Inicializo la columna de la palabra final con todas las minimas
            // distancias posibles
            for (int i = 1; i < palabraInicio.Length; i++)
            {

                int costoBorrar = distance[i - 1,0] + eraseCost;
                int costoInsertar = (i + 1) * eraseCost + insertCost;
                int costoRestoOp = (i * eraseCost)
                        + (palabraInicio[i] == palabraFin[0] ? 0
                                : (copyCost <= replaceCost) ? copyCost
                                        : replaceCost);
                distance[i,0] = min(costoBorrar, costoInsertar, costoRestoOp);
            }

            // Inicializo la fila de la palabra inicial con todas las minimas
            // distancias posibles
            for (int j = 1; j < palabraFin.Length; j++)
            {
                int costoBorrar = distance[0,j - 1] + insertCost;
                int costoInsertar = (j + 1) * insertCost + eraseCost;
                int costoRestoOp = (j * insertCost)
                                + (palabraInicio[0] == palabraFin[j] ? 0
                                : (copyCost <= replaceCost) ? copyCost
                                        : replaceCost);
                distance[0,j] = min(costoBorrar, costoInsertar, costoRestoOp);
            }

            for (int i = 1; i < palabraInicio.Length; i++)
            {
                for (int h = 1; h < palabraFin.Length; h++)
                {
                    int costoBorrar = distance[i - 1,h] + borrar();
                    int costoInsertar = distance[i,h - 1] + insertar();
                    int costoRestoOp = distance[i - 1,h - 1];
                    costoRestoOp += getOperacionesPosibles(i, h, costoRestoOp);
                    distance[i,h] = min(costoBorrar, costoInsertar, costoRestoOp);
                }
                distance[i,j - 1] += terminar();
            }
            return distance[palabraInicio.Length - 1,palabraFin.Length - 1];
        }

        private int getOperacionesPosibles(int i, int j, int costoRestoOp)
        {
            if (palabraInicio[i] == palabraFin[j])
            {
                costoRestoOp += (copyCost <= replaceCost) ? copiar() : reemplazar();
            }
            else
            {
                if (palabraInicio[i] != palabraFin[j])
                {
                    if (esIntercambiable(i, j))
                    {
                        costoRestoOp += intercambiar();
                    }
                    else
                    {
                        costoRestoOp += (copyCost <= replaceCost) ? copiar()
                                : reemplazar();
                    }
                }
            }
            return costoRestoOp;
        }

        private int intercambiar() {
		if (i > palabraInicio.Length || j > palabraFin.Length)
			return 0;
		resultado[j] = palabraInicio[i + 1];
        resultado[j + 1] = palabraInicio[i];
		System.Console.WriteLine("Intercambiando "+ resultado[j]+" con "+resultado[j + 1]);
		i += 2;
		j += 2;
		return switchCost;
	}

        private int reemplazar() {
		if (i >= palabraInicio.Length || j >= palabraFin.Length)
			return 0;
		resultado[j] = palabraFin[i];
        System.Console.WriteLine("Reemplazando " + palabraFin[i] + " en el resultado");
		i++;
		j++;
		return replaceCost;
	}

        private int copiar() {
		if (i >= palabraInicio.Length || j >= palabraFin.Length)
			return 0;
		resultado[j] = palabraInicio[i];
        System.Console.WriteLine("Copiando " + palabraInicio[i] + " al resultado");
		i++;
		j++;
		
		return copyCost;
	}

        private int insertar() {
		if (j >= palabraFin.Length)
			return 0;
		resultado[j] = palabraFin[j];
        System.Console.WriteLine("Insertando al " + palabraFin[j] + " al resultado ");
		j++;
		return 0;
	}

        private int borrar() {
		if (i >= palabraInicio.Length || j >= palabraFin.Length)
			return 0;
        System.Console.WriteLine("Borrando de la palabra de inicio: " + palabraInicio[i]);
		i++;
		return eraseCost;
	}

        private int terminar()
        {
            i = palabraInicio.Length + 1;
            return endCost;
        }

        private bool esIntercambiable(int i, int j)
        {
            return (i + 1) < palabraInicio.Length
                    && (j + 1) < palabraFin.Length
                    && palabraInicio[i + 1] == palabraFin[j]
                    && palabraInicio[i] == palabraFin[j + 1];
        }

        private int min(int a, int b, int c)
        {
            if (a <= b && a <= c)
                return a;
            if (b <= a && b <= c)
                return b;
            return c;
        }

    }
}
