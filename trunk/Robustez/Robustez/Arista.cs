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


        public Arista(Vertice<T> verticeCicloUno, Vertice<T> verticeCicloDos)
        {
            Origen = verticeCicloUno;
            Destino = verticeCicloDos;
        }


    }
}
