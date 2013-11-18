using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EmpaquetadoSolExacta
{
    class Program
    {
        static void Main(string[] args)
        {
            string tipoSolucion;
            List<Elemento> datos = new List<Elemento>();

            if (args.Length > 0)
            {
                presentacion();
                try
                {
                    tipoSolucion = args[0];
                    StreamReader archivo = new StreamReader(args[1]);

                    leerArchivo(archivo, out datos);

                    if (datos.Count == 0)
                    {
                        Console.WriteLine("Error en el formato del archivo.");
                    }
                    else
                    {
                        System.Console.Write(System.Environment.NewLine);

                        //ACA SE LLAMA AL BACKTRACKING
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


        private static void leerArchivo(StreamReader reader, out List<Elemento> datos)
        {
            int i = 1;
            string line = reader.ReadLine();
            datos = new List<Elemento>();

            while (line != null)
            {
                if (i != 1 && !String.IsNullOrEmpty(line))
                {
                    if ((float)Convert.ToSingle(line) > 0 && (float)Convert.ToSingle(line) <= 1)
                    {
                        Elemento newElem = new Elemento((float)Convert.ToSingle(line));

                        datos.Add(newElem);
                    }
                }

                i++;
                line = reader.ReadLine();
            }
        }
    }
}
