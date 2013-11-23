using System;
using System.Collections.Generic;
using System.Text;

namespace tdatp3
{
    public class Objeto
    {

        private double _tamanio;

        public double Tamanio
        {
            get { return _tamanio; }
            set { _tamanio = value; }
        }


        public Objeto()
        {
            _tamanio = 0;
        }

        public Objeto(double tamanio)
        {
            _tamanio = tamanio;
        }
    }

}
