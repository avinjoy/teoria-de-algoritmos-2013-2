using System;
using System.Collections.Generic;
using System.Text;

namespace TDATP2
{
    public class Distancia
    {
        private char[] _cadenaX;
        private char[] _cadenaY;
        private char[] _cadenaZ;
        private int _costoCopiar;
        private int _costoReemplazar;
        private int _costoBorrar;
        private int _costoInsertar;
        private int _costoIntercambiar;
        private int _costoTerminar;
        private int _distanciaCalculada;

        public Distancia(char[] cadenaX, char[] cadenaY, char[] cadenaZ, int costoCopiar, int costoReemplazar, int costoBorrar,
            int costoInsertar, int costoIntercambiar, int costoTerminar)
        {
            _cadenaX = cadenaX;
            _cadenaY = cadenaY;
            _cadenaZ = cadenaZ;
            _costoCopiar = costoCopiar;
            _costoReemplazar = costoReemplazar;
            _costoBorrar = costoBorrar;
            _costoInsertar = costoInsertar;
            _costoIntercambiar = costoIntercambiar;
            _costoTerminar = costoTerminar;
        }

        public int DistanciaCalculada
        {
            get { return _distanciaCalculada; }
            set { _distanciaCalculada = value; }
        }

        public int ObtenerDistancia()
        {
            int i;
            int j = 0;
            for (i = 0; i < _cadenaY.Length; )
            {
                if (j == _cadenaY.Length)
                {
                    Terminar(ref i);
                    return DistanciaCalculada;
                }
                try
                {
                    if (_cadenaX[i] == _cadenaY[i])
                    {
                        int minimo = ObtenerCostoMinimo(_costoCopiar, _costoInsertar);
                        switch (minimo)
                        {
                            case 0:
                                Copiar(ref i, ref j);
                                break;
                            case 1:
                                Insertar(ref i, ref j);
                                break;
                        }
                    }
                    else
                    {
                        try
                        {
                            if (_cadenaX[i + 1] == _cadenaY[i])
                            {
                                if (_cadenaX[i] == _cadenaY[i + 1])
                                    Intercambiar(ref i, ref j);
                                else
                                {


                                    int minimo = ObtenerCostoMinimo(_costoReemplazar, _costoBorrar + _costoCopiar);
                                    switch (minimo)
                                    {
                                        case 0:
                                            Reemplazar(ref i, ref j);
                                            break;
                                        case 1:
                                            Borrar(ref i, ref j);
                                            Copiar(ref i, ref j);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Reemplazar(ref i, ref j);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Reemplazar(ref i, ref j);
                        }


                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Insertar(ref i,ref j);
                }
            }

            return DistanciaCalculada;
        }

        private int ObtenerCostoMinimo(int costoUno, int costoDos)
        {
            if (costoUno <= costoDos)
                return 0;
            return 1;

        }
        /// <summary>
        /// Copiar: copia un carácter de x a z . Esto es: z[ j ]=x [i ] e incrementa los índices i y j
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Copiar(ref int i, ref int j)
        {
            _cadenaZ[j] = _cadenaX[i];
            i++;
            j++;
            DistanciaCalculada += _costoCopiar;
        }

        /// <summary>
        /// Reemplazar: reemplaza un carácter de x por otro carácter c . Esto es: z[ j ]=c e 
        /// incrementa los índices i y j
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Reemplazar(ref int i, ref int j)
        {
            _cadenaZ[j] = _cadenaY[j];
            i++;
            j++;
            DistanciaCalculada += _costoReemplazar;
        }

        /// <summary>
        /// Borrar: borra un carácter de x incrementando i y sin mover j
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Borrar(ref int i, ref int j)
        {
            i++;
            DistanciaCalculada += _costoBorrar;
        }

        /// <summary>
        /// Insertar: inserta un carácter c en z . Esto es: z[ j ]=c e incrementa j sin mover i
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Insertar(ref int i, ref int j)
        {
            _cadenaZ[j] = _cadenaY[j];
            j++;
            DistanciaCalculada += _costoInsertar;
        }

        /// <summary>
        /// Intercambiar: intercambia los próximos dos caracteres copiándolos de x a z pero en
        ///orden inverso. Esto es: z[ j ]=x [i+1] y z[ j +1]=x [i] e incrementa los índices de la 
        ///siguiente manera: i=i+2 y j= j+2
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Intercambiar(ref int i, ref int j)
        {
            _cadenaZ[j] = _cadenaX[i + 1];
            _cadenaZ[j + 1] = _cadenaX[i];
            i += 2;
            j += 2;
            DistanciaCalculada += _costoIntercambiar;
        }

        /// <summary>
        /// Terminar: elimina los caracteres restantes de x haciendo i=m+1 . Esta operación 
        ///descarta todos los caracteres de x que todavía no se analizaron. Es la última operación 
        ///se aplica si hace falta.
        /// </summary>
        /// <param name="i"></param>
        public void Terminar(ref int i)
        {
            i = _cadenaX.Length + 1;
            DistanciaCalculada += _costoTerminar;
        }

    }
}
