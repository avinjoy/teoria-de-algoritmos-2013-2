using System;
using System.IO;
using System.Diagnostics;

namespace tdatp3
{
    class Program
    {
        static void Main(string[] args)
        {
         
            if (args.Length > 0)
            {
                Presentacion();
                try
                {
                    string tipoSolucion = args[0];
                    StreamReader archivo = new StreamReader(args[1]);

                    decimal[] datos;
                    LeerArchivo(archivo, out datos);
                  

                    if (datos.Length == 0)
                    {
                        Console.WriteLine("Error en el formato del archivo.");
                    }
                    else
                    {
                        if(tipoSolucion == "E")
                            EncontrarSolucionExacta(datos);
                        else
                        {
                            EncontrarSolucionAproximada(datos);
                        }
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

        private static void EncontrarSolucionAproximada(decimal[] datos)
        {
            Console.Write(Environment.NewLine);


            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();
            
            SolucionAproximada solucionAproximada = new SolucionAproximada(datos);
            solucionAproximada.EncontrarSolucion();
            
            // Stop timing
            stopwatch.Stop();

            double tiempoEjecucionMilisegundos = stopwatch.Elapsed.TotalMilliseconds;


            Console.WriteLine();
            Console.WriteLine("Solucion exacta: " + solucionAproximada.Envases + " envases");

            Console.Write(Environment.NewLine);
            Console.Write("Total = " + tiempoEjecucionMilisegundos + " mseg.");
        }

        private static void EncontrarSolucionExacta(decimal[] datos)
        {
            Console.Write(Environment.NewLine);

            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            int solucion = 0;
            //O(N)
            for (int i = 1; i <= datos.Length; i++)
            {
                SolucionE solE = new SolucionE(datos, i);
                if (solE.pack(0))
                {
                    solucion = solE.NumberBags;
                    break;
                }
            }

            // Stop timing
            stopwatch.Stop();

            double tiempoEjecucionMilisegundos = stopwatch.Elapsed.TotalMilliseconds;


            Console.WriteLine();
            Console.WriteLine("Solucion exacta: " + solucion + " envases");

            Console.Write(Environment.NewLine);
            Console.Write("Total = " + tiempoEjecucionMilisegundos + " mseg.");

        }

        private static void Presentacion()
        {

            Console.Write(" " + Environment.NewLine);
            Console.Write("************************************************************************" + Environment.NewLine);
            Console.Write("*********************** TRABAJO PRACTICO NRO.3 *************************" + Environment.NewLine);
            Console.Write("************************************************************************" + Environment.NewLine);
            Console.Write("*                                                                      *" + Environment.NewLine);
            Console.Write("* INTEGRANTES:                                                         *" + Environment.NewLine);
            Console.Write("*              SERGIO NICOLAS ORSIANI          85855                   *" + Environment.NewLine);
            Console.Write("*              JULIAN ANDRES D’AMBROSIO        90252                   *" + Environment.NewLine);
            Console.Write("*                                                                      *" + Environment.NewLine);
            Console.Write("************************************************************************" + Environment.NewLine);
            Console.Write("************************************************************************" + Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

        }


        private static void LeerArchivo(StreamReader reader, out decimal[] datos)
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

     
    }
}
