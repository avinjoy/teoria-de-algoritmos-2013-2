using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tdatp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string tipoSolucion;
            //decimal[] datos = null;
            List<Objeto> objetos;

            if (args.Length > 0)
            {
                presentacion();
                try
                {
                    tipoSolucion = args[0];
                    StreamReader archivo = new StreamReader(args[1]);

                    //leerArchivo(archivo, out datos);
                    cargarDatos(out objetos);

                    if (objetos.Count == 0)
                    {
                        Console.WriteLine("Error en el formato del archivo.");
                    }
                    else
                    {
                        System.Console.Write(System.Environment.NewLine);
                        DateTime horaInicio = DateTime.Now;

                        /*
                        BackTracking binPack = new BackTracking(datos);
                        if (!binPack.pack(0))
                            Console.WriteLine("No existe solucion");
                        */

                        SolucionExacta solucionExacta = new SolucionExacta(objetos);
                        solucionExacta.EncontrarSolucion();

                        DateTime horaFin = DateTime.Now;

                        System.Console.Write(System.Environment.NewLine);
                        System.Console.Write("Total = " + (horaFin - horaInicio).TotalMilliseconds + " mseg.");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("No es posible leer el archivo asegurese que esta en el directorio actual" + System.Environment.NewLine);
                }

                Console.ReadKey();
            }
            else
            {
                System.Console.Write("Se debe ingresar el tipo de ejecucion y el nombre del archivo de datos" + System.Environment.NewLine);
                Console.ReadKey();
            }

        }

        private static void presentacion()
        {

            System.Console.Write(" " + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("*********************** TRABAJO PRACTICO NRO.3 *************************" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("*                                                                      *" + System.Environment.NewLine);
            System.Console.Write("* INTEGRANTES:                                                         *" + System.Environment.NewLine);
            System.Console.Write("*              SERGIO NICOLAS ORSIANI          85855                   *" + System.Environment.NewLine);
            System.Console.Write("*              JULIAN ANDRES D’AMBROSIO        90252                   *" + System.Environment.NewLine);
            System.Console.Write("*                                                                      *" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write(System.Environment.NewLine);
            System.Console.Write(System.Environment.NewLine);

        }


        private static void leerArchivo(StreamReader reader, out decimal[] datos)
        {
            int i = 1;
            int idx = 0;
            string line = reader.ReadLine();
            datos = null;

            while (line != null)
            {
                if (i != 1 && !String.IsNullOrEmpty(line))
                {
                    if ((decimal)Convert.ToSingle(line) > 0 && (decimal)Convert.ToSingle(line) <= 1)
                    {
                        datos[idx] = ((decimal)Convert.ToSingle(line));

                        idx++;
                    }
                }
                else
                    datos = new decimal[Convert.ToInt32(line)];

                i++;
                line = reader.ReadLine();
            }
        }

        private static void cargarDatos(out decimal[] datos)
        {
            datos = new decimal[1400];
            Random random = new Random();

            for (int idx = 0; idx < 1400; idx++)
            {
                datos[idx] = Math.Round((decimal)random.NextDouble(), 1);

                while (datos[idx] == 0) 
                    datos[idx] = Math.Round((decimal)random.NextDouble(), 1);
            }
        }

        private static void cargarDatos(out List<Objeto> objetos)
        {
            objetos = new List<Objeto>();

            Random random = new Random();

            for (int idx = 0; idx < 50000; idx++)
            {
                double tamanio = Math.Round(random.NextDouble(), 1);
                while (tamanio == 0)
                    tamanio = Math.Round(random.NextDouble(), 1);

                objetos.Add(new Objeto(tamanio));
            }
        }
    }
}
