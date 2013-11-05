using System;
using System.Collections.Generic;
using System.Text;

namespace TDATP2
{
    public class DistanciaEdicion
    {

        private readonly int[,] _distancia;
        private readonly String _palabraInicio;
        private readonly String _palabraFin;
        private readonly char[] _resultado;
        private Operacion _copiar;
        private Operacion _reemplazar;
        private Operacion _insertar;
        private Operacion _intercambiar;
        private Operacion _terminar;
        private Operacion _eliminar;
        private int _i;
        private int _j;

        public DistanciaEdicion(string palabraInicio, string palabraFin,
                int costoCopiar, int costoReemplazar, int costoIntercambiar, int costoEliminar, int costoInsertar,
                int costoTerminar)
        {
            _distancia = new int[palabraInicio.Length + 1, palabraFin.Length + 1];
            _palabraInicio = palabraInicio;
            _palabraFin = palabraFin;
            _copiar = new Operacion(costoCopiar, "1");
            _reemplazar = new Operacion(costoReemplazar, "2");
            _intercambiar = new Operacion(costoIntercambiar, "3");
            _eliminar = new Operacion(costoEliminar, "4");
            _insertar = new Operacion(costoInsertar, "5");
            _terminar = new Operacion(costoTerminar, "6");
            _i = 0;
            _j = 0;

            _resultado = new char[(palabraInicio.Length < palabraFin.Length) ? palabraFin
                    .Length : palabraInicio.Length];
        }


        public int CalcularDistanciaEdicion()
        {

            for (int i = 0; i <= _palabraInicio.Length; i++)
                _distancia[i, 0] = i * _eliminar.Costo;
            for (int j = 0; j <= _palabraFin.Length; j++)
                _distancia[0, j] = j * _insertar.Costo;
            for (int i = 1; i < _palabraInicio.Length; i++)
            {
                int j;
                for (j = 1; j < _palabraFin.Length; j++)
                {
                    Operacion opAuxEliminar = new Operacion(_distancia[i - 1, j] + _eliminar.Costo, _eliminar.Id);
                    Operacion opAuxInsertar = new Operacion(_distancia[i, j - 1] + _insertar.Costo, _insertar.Id);
                    Operacion opAuxRestoDePosiblesOp = new Operacion(_distancia[i - 1, j - 1] + GetCostoOperacionesPosibles(i, j).Costo, GetCostoOperacionesPosibles(i, j).Id);
                    Operacion opElegida = Min(opAuxEliminar, opAuxInsertar, opAuxRestoDePosiblesOp);

                    switch (opElegida.Id)
                    {
                        case "1":
                            Copiar();
                            break;
                        case "2":
                            Reemplazar();
                            break;
                        case "3":
                            Intercambiar();
                            break;
                        case "4":
                            Eliminar();
                            break;
                        case "5":
                            Insertar();
                            break;
                        case "6":
                            Terminar();
                            break;
                    }
                    _distancia[i, j] = opElegida.Costo;

                }
                //_distancia[i, j - 1] += _terminar.Costo;
            }

            return _distancia[_palabraInicio.Length - 1, _palabraFin.Length - 1];
        }


        private Operacion GetCostoOperacionesPosibles(int i, int j)
        {
            try
            {
                if (_palabraInicio[_i] == _palabraFin[_j])
                {
                    return (_copiar.Costo <= _reemplazar.Costo) ? _copiar : _reemplazar;
                }
                else
                {
                    if (EsIntercambiable(_i, _j))
                    {
                        return _intercambiar;
                    }
                    return (_insertar.Costo <= _reemplazar.Costo)
                               ? _insertar
                               : _reemplazar;
                }
            }
            catch (Exception)
            {
                if (_i >= _palabraInicio.Length)
                {
                    return _eliminar;

                }
                return _terminar;
            }
        }


        private void Intercambiar()
        {
            if (_i < _palabraInicio.Length && _j < _palabraFin.Length)
            {
                _resultado[_j] = _palabraInicio[_i + 1];
                _resultado[_j + 1] = _palabraInicio[_i];
                Console.WriteLine("Intercambiando " + _resultado[_j] + " con " + _resultado[_j + 1]);
                Console.WriteLine("Costo Intercambiar " + _intercambiar.Costo);
                _i += 2;
                _j += 2;
            }

        }

        private void Reemplazar()
        {
            if (_i < _palabraInicio.Length && _j < _palabraFin.Length)
            {
            _resultado[_j] = _palabraFin[_j];
            Console.WriteLine("Reemplazando " + _palabraFin[_j] + " en el resultado");
            Console.WriteLine("Costo Reemplazar " + _reemplazar.Costo);
            _i++;
            _j++;
        }
    }

        private void Copiar()
        {
            if (_i < _palabraInicio.Length && _j < _palabraFin.Length)
            {
                _resultado[_j] = _palabraInicio[_i];
                Console.WriteLine("Copiando " + _palabraInicio[_i] + " al resultado");
                Console.WriteLine("Costo Copiar " + _copiar.Costo);
                _i++;
                _j++;
            }
        }

        private void Insertar()
        {
            if (_j < _palabraFin.Length)
            {
                _resultado[_j] = _palabraFin[_j];
                Console.WriteLine("Insertando al " + _palabraFin[_j] + " al resultado ");
                Console.WriteLine("Costo Insertar " + _insertar.Costo);
                _j++;
            }
        }

        private void Eliminar()
        {
            if (_i < _palabraInicio.Length && _j < _palabraFin.Length)
            {
                Console.WriteLine("Eliminando de la palabra de inicio: " + _palabraInicio[_i]);
                Console.WriteLine("Costo Eliminar " + _eliminar.Costo);
                _i++;
            }
        }

        private void Terminar()
        {
            Console.WriteLine("Costo Terminar " + _terminar.Costo);

            _i = _palabraInicio.Length + 1;

        }

        private bool EsIntercambiable(int i, int j)
        {
            return (i + 1) < _palabraInicio.Length
                    && (j + 1) < _palabraFin.Length
                    && _palabraInicio[i + 1] == _palabraFin[j]
                    && _palabraInicio[i] == _palabraFin[j + 1];
        }

        private static Operacion Min(Operacion a, Operacion b, Operacion c)
        {
            if (a.Costo <= b.Costo && a.Costo <= c.Costo)
                return a;
            if (b.Costo <= a.Costo && b.Costo <= c.Costo)
                return b;
            return c;
        }

        public class Operacion
        {
            private int _costo;
            private string _id;

            public Operacion()
            {
                _costo = 0;
                _id = "";
            }

            public Operacion(int costo, string id)
            {
                _costo = costo;
                _id = id;
            }

            public int Costo
            {
                get { return _costo; }
                set { _costo = value; }
            }

            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
        }

    }
}
