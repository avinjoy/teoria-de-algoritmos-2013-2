namespace Robustez
{
    public class Arista<T>
    {

        private Vertice<T> _origen;
        private Vertice<T> _destino;

        public Vertice<T> Origen
        {
            get { return _origen; }
            set { _origen = value; }
        }

        public Vertice<T> Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }

        /// <summary>
        /// Crea una nueva arista apartir de dos vertices.
        /// </summary>
        /// <param name="verticeCicloUno"></param>
        /// <param name="verticeCicloDos"></param>
        public Arista(Vertice<T> verticeCicloUno, Vertice<T> verticeCicloDos)
        {
            Origen = verticeCicloUno;
            Destino = verticeCicloDos;
        }

        public override string ToString()
        {
            return _origen.Contenido + ", " + _destino.Contenido;
        }
        public override bool Equals(object obj)
        {
            Arista<T> arista = (Arista<T>)obj;
            return Origen.Equals(arista.Origen) && Destino.Equals(arista.Destino);
        }
    }
}
