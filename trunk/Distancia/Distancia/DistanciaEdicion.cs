using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TDATP2
{
    public class DistanciaEdicion
    {

        private readonly Operacion[,] _distancia;
        private readonly char[] _palabraInicio;
        private readonly char[] _palabraFin;
        private readonly char[] _resultado;

        private Operacion _copiar;
        private Operacion _reemplazar;
        private Operacion _insertar;
        private Operacion _intercambiar;
        private Operacion _terminar;
        private Operacion _borrar;
        private int _i;
        private int _j;
        private List<Operacion> _operaciones;

        public List<Operacion> Operaciones
        {
            get { return _operaciones; }
            set { _operaciones = value; }
        }

        public char[] Resultado
        {
            get { return _resultado; }
        }

        public DistanciaEdicion(char[] palabraInicio, char[] palabraFin,
                int costoCopiar, int costoReemplazar, int costoIntercambiar, int costoBorrar, int costoInsertar,
                int costoTerminar)
        {
            _distancia = new Operacion[palabraInicio.Length + 1, palabraFin.Length + 1];
            _palabraInicio = palabraInicio;
            _palabraFin = palabraFin;
            _copiar = new Operacion(costoCopiar, IdOperacion.Copiar);
            _reemplazar = new Operacion(costoReemplazar, IdOperacion.Reemplazar);
            _intercambiar = new Operacion(costoIntercambiar, IdOperacion.Intercambiar);
            _borrar = new Operacion(costoBorrar, IdOperacion.Borrar);
            _insertar = new Operacion(costoInsertar, IdOperacion.Insertar);
            _terminar = new Operacion(costoTerminar, IdOperacion.Terminar);
            _i = 0;
            _j = 0;
            _operaciones = new List<Operacion>();
            _resultado = new char[palabraFin.Length];
        }


        /// <summary>
        /// Devuelve la distancia de edición entre dos palabras teniendo en cuenta los costos de las operaciones.
        /// </summary>
        /// <returns></returns>
        public int ObtenerDistanciaEdicion()
        {

            for (int i = 0; i <= _palabraInicio.Length; i++)
                _distancia[i, 0] = new Operacion(i - 1 > 0 ? i - 1 : 0, 0, i * _borrar.Costo, _borrar.Id);
            for (int j = 0; j <= _palabraFin.Length; j++)
                _distancia[0, j] = new Operacion(0, j - 1 > 0 ? j - 1 : 0, j * _insertar.Costo, _insertar.Id);
            for (int i = 1; i <= _palabraInicio.Length; i++)
            {
                for (int j = 1; j <= _palabraFin.Length; j++)
                {
                    Operacion opAuxBorrar = new Operacion(i - 1, j, _distancia[i - 1, j].Costo + _borrar.Costo, _borrar.Id);
                    Operacion opAuxInsertar = new Operacion(i, j - 1, _distancia[i, j - 1].Costo + _insertar.Costo, _insertar.Id);
                    Operacion opPosibles = GetCostoOperacionesPosibles(i - 1, j - 1);
                    Operacion opQueCorresponde = new Operacion(i - 1, j - 1, _distancia[i - 1, j - 1].Costo + opPosibles.Costo, opPosibles.Id);

                    Operacion opElegida = ObtenerMinimaOperacion(opAuxBorrar, opAuxInsertar, opQueCorresponde);


                    _distancia[i, j] = opElegida;
                    if (opElegida.Id.Equals(IdOperacion.Intercambiar))
                    {
                        _distancia[i, j].Costo -= _distancia[i - 1, j - 1].Costo;
                    }

                }

            }

            
            StreamWriter archivo = new StreamWriter("Costos.csv");
            string linea=null;
            for (int i = 0; i <= _palabraInicio.Length; i++)
            {
                linea = null;
                for (int j = 0; j <= _palabraFin.Length; j++)
                {
                    linea = linea + _distancia[i, j].Costo+",";
                    //Console.WriteLine("{0}-{1}:{2}",i,j,_distancia[i,j].Costo);
                }
                archivo.WriteLine(linea);
                //Console.WriteLine("\n");
            }
            archivo.Close();
             

            Operacion op = TerminarSiEsNecesario();
            RecuperarOperacionesMinimas(op);
            AplicarOperaciones();
            return op.Costo;
        }

        /// <summary>
        /// Termina si es necesario o utiliza borrar en caso de que sea menos costoso.
        /// </summary>
        /// <returns></returns>
        private Operacion TerminarSiEsNecesario()
        {
            int costoMinimo = int.MaxValue;
            int index = 0;
            for (int i = 0; i <= _palabraInicio.Length; i++)
            {
               
                if (_distancia[i, _palabraFin.Length].Costo + _terminar.Costo <
                    _distancia[_palabraInicio.Length, _palabraFin.Length].Costo && _distancia[i, _palabraFin.Length].Costo <= costoMinimo)
                {
                    costoMinimo = _distancia[i, _palabraFin.Length].Costo;
                    index = i;
                }
               
              
            }
            if(index>0)
            {
                _operaciones.Add(new Operacion(_terminar.Costo, IdOperacion.Terminar));

                _distancia[index, _palabraFin.Length].Costo += _terminar.Costo;
                return _distancia[index, _palabraFin.Length];
            }
            return _distancia[_palabraInicio.Length, _palabraFin.Length];


        }

        /// <summary>
        /// Recupera las operaciones a realizar para obtener la palabra fin con el menor costo.
        /// </summary>
        private void RecuperarOperacionesMinimas(Operacion op)
        {
            Operacion opAnterior = op;
            _operaciones.Insert(0, op);

            while (op.FilaAnterior > 0 && op.ColumnaAnterior > 0)
            {
                op = _distancia[op.FilaAnterior, op.ColumnaAnterior];

                if (!opAnterior.Id.Equals(IdOperacion.Intercambiar))
                {
                    _operaciones.Insert(0, op);
                }
                opAnterior = op;

            }


        }

        /// <summary>
        /// Recorre las operaciones y las aplica para transformar la palabra inicio a la palabra fin.
        /// </summary>        
        private void AplicarOperaciones()
        {
            foreach (Operacion op in _operaciones)
            {
                switch (op.Id)
                {
                    case IdOperacion.Copiar: Copiar(); break;
                    case IdOperacion.Reemplazar: Reemplazar(); break;
                    case IdOperacion.Intercambiar: Intercambiar(); break;
                    case IdOperacion.Borrar: Borrar(); break;
                    case IdOperacion.Insertar: Insertar(); break;
                    case IdOperacion.Terminar: Terminar(); break;
                }
            }


        }

        /// <summary>
        /// Devuelve la operacion posible de realizar.
        /// </summary>
        private Operacion GetCostoOperacionesPosibles(int i, int j)
        {
            if (_palabraInicio[i] == _palabraFin[j])
            {
                try
                {
                    if (EsIntercambiable(i, j))
                    {
                        return _copiar.Costo <= _intercambiar.Costo ? _copiar : _intercambiar;
                    }
                    return _copiar;
                }
                catch (IndexOutOfRangeException)
                {
                    return _copiar;
                }

            }
            try
            {
                if (EsIntercambiable(i, j))
                {
                    return _reemplazar.Costo <= _intercambiar.Costo ? _reemplazar : _intercambiar;
                }
                return _reemplazar;
            }
            catch (IndexOutOfRangeException)
            {
                return _reemplazar;
            }
        }

        /// <summary>
        /// Copiar: copia un carácter de x a z . Esto es: z[ j ]=x [i ] e incrementa los índices i y j
        /// </summary>
        private void Copiar()
        {
            if (_i < _palabraInicio.Length && _j < _palabraFin.Length)
            {
                _resultado[_j] = _palabraInicio[_i];
                Console.WriteLine("Copiar " + _palabraInicio[_i]);
                //Console.WriteLine("Costo Copiar " + _copiar.Costo);
                _i++;
                _j++;
            }
        }

        /// <summary>
        /// Reemplazar: reemplaza un carácter de x por otro carácter c . Esto es: z[ j ]=c e 
        ///incrementa los índices i y j
        /// </summary>
        private void Reemplazar()
        {
            if (_i < _palabraInicio.Length && _j < _palabraFin.Length)
            {
                _resultado[_j] = _palabraFin[_j];
                Console.WriteLine("Reemplazar " + _palabraFin[_j]);
                //Console.WriteLine("Costo Reemplazar " + _reemplazar.Costo);
                _i++;
                _j++;
            }
        }


        //Borrar: borra un carácter de x incrementando i y sin mover j
        private void Borrar()
        {
            if (_i < _palabraInicio.Length && _j <= _palabraFin.Length)
            {
                Console.WriteLine("Borrar " + _palabraInicio[_i]);
                //Console.WriteLine("Costo Borrar " + _borrar.Costo);
                _i++;
            }
        }


        /// <summary>
        /// Insertar: inserta un carácter c en z . Esto es: z[ j ]=c e incrementa j sin mover i
        /// </summary>
        private void Insertar()
        {
            if (_j < _palabraFin.Length)
            {
                _resultado[_j] = _palabraFin[_j];
                Console.WriteLine("Insertar " + _palabraFin[_j]);
                // Console.WriteLine("Costo Insertar " + _insertar.Costo);
                _j++;
            }
        }

        /// <summary>
        /// Intercambiar: intercambia los próximos dos caracteres copiándolos de x a z pero en 
        ///orden inverso. Esto es: z[ j ]=x [i+1] y z[ j +1]=x [i] e incrementa los índices de la 
        ///siguiente manera: i=i+2 y j= j+2
        /// </summary>
        private void Intercambiar()
        {
            if (_i < _palabraInicio.Length && _j < _palabraFin.Length)
            {
                _resultado[_j] = _palabraInicio[_i + 1];
                _resultado[_j + 1] = _palabraInicio[_i];
                Console.WriteLine("Intercambiar " + _resultado[_j] + " con " + _resultado[_j + 1]);
                //Console.WriteLine("Costo Intercambiar " + _intercambiar.Costo);
                _i += 2;
                _j += 2;
            }

        }

        /// <summary>
        /// Terminar: elimina los caracteres restantes de x haciendo i=m+1 . Esta operación 
        ///descarta todos los caracteres de x que todavía no se analizaron. Es la última operación 
        ///se aplica si hace falta.
        /// </summary>
        private void Terminar()
        {
            Console.WriteLine("Terminar");
            //Console.WriteLine("Costo Terminar " + _terminar.Costo);
            _i = _palabraInicio.Length + 1;

        }

        /// <summary>
        /// Determina si las letras estan intercambiadas
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool EsIntercambiable(int i, int j)
        {
            return _palabraInicio[i] == _palabraFin[j - 1]
                    && _palabraInicio[i - 1] == _palabraFin[j];
        }

        /// <summary>
        /// Devuelve la operacion de menor costo.
        /// </summary>       
        private Operacion ObtenerMinimaOperacion(Operacion a, Operacion b, Operacion c)
        {
            if (a.Costo <= b.Costo && a.Costo <= c.Costo)
                return a;
            if (b.Costo <= a.Costo && b.Costo <= c.Costo)
                return b;
            return c;
        }


        /// <summary>
        /// Enum auxiliar para identificar las operaciones.
        /// </summary>
        public enum IdOperacion
        {
            NA = 0,
            Copiar = 1,
            Reemplazar = 2,
            Intercambiar = 3,
            Borrar = 4,
            Insertar = 5,
            Terminar = 6
        }

        /// <summary>
        /// Clase para crear objetos de tipo op y guardar la informacion que necesito.
        /// Id, costo, y como llegue a dicha operacion.
        /// </summary>
        public class Operacion
        {
            private int _costo;
            private IdOperacion _id;
            private int _filaAnterior;
            private int _columnaAnterior;


            public Operacion()
            {
                _costo = 0;
                _id = IdOperacion.NA;
                _filaAnterior = 0;
                _columnaAnterior = 0;
            }


            public Operacion(int costo, IdOperacion id)
            {
                _filaAnterior = 0;
                _columnaAnterior = 0;
                _costo = costo;
                _id = id;
            }

            public Operacion(int filaAnterior, int columnaAnterior, int costo, IdOperacion id)
            {
                _filaAnterior = filaAnterior;
                _columnaAnterior = columnaAnterior;
                _costo = costo;
                _id = id;
            }

            public int Costo
            {
                get { return _costo; }
                set { _costo = value; }
            }

            public IdOperacion Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public int FilaAnterior
            {
                get { return _filaAnterior; }
                set { _filaAnterior = value; }
            }


            public int ColumnaAnterior
            {
                get { return _columnaAnterior; }
                set { _columnaAnterior = value; }
            }

        }

    }
}
