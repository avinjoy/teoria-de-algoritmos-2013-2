using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TDATP2
{
    public class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                presentacion();
                char[] palabraInicio = null;
                char[] palabraFin = null;
                int costoCopiar, costoReemplazar, costoIntercambiar, costoBorrar, costoInsertar, costoTerminar;

                try
                {
                    palabraInicio = args[0].ToCharArray();
                    palabraFin = args[1].ToCharArray();
                    StreamReader archivo = new StreamReader(args[2]);

                    leerArchivo(archivo, out costoCopiar, out costoReemplazar, out costoIntercambiar, out costoBorrar, out costoInsertar, out costoTerminar);
                    
                    System.Console.Write("Palabra inicial: " + args[0] + System.Environment.NewLine);
                    System.Console.Write("Palabra final: " + args[1] + System.Environment.NewLine);
                    System.Console.Write(System.Environment.NewLine);

                    DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, costoCopiar, costoReemplazar, costoIntercambiar, costoBorrar, costoInsertar, costoTerminar);
                    Console.WriteLine(distanciaEdicion.ObtenerDistanciaEdicion());

                }
                catch (Exception) {

                    Console.WriteLine("No es posible leer el archivo asegurese que esta en el directorio actual" + System.Environment.NewLine); 
                }
       
                Console.ReadKey();
            }
            else
            {
                System.Console.Write("Se debe ingresar la palabra inicial, la final y el nombre del archivo de Costos" + System.Environment.NewLine);
                Console.ReadKey();
            }

        }

        private static void presentacion()
        {

            System.Console.Write(" " + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("*********************** TRABAJO PRACTICO NRO.2 *************************" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("*                                                                      *" + System.Environment.NewLine);
            System.Console.Write("* INTEGRANTES:                                                         *" + System.Environment.NewLine);
            System.Console.Write("*              SERGIO NICOLAS ORSIANI          85855                   *" + System.Environment.NewLine);
            System.Console.Write("*              JULIAN ANDRES D�AMBROSIO        90252                   *" + System.Environment.NewLine);
            System.Console.Write("*                                                                      *" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write(System.Environment.NewLine);
            System.Console.Write(System.Environment.NewLine);

        }


        private static void leerArchivo(StreamReader reader, out int costoCopiar, out int costoReemplazar, out int costoIntercambiar, out int costoEliminar, out int costoInsertar,
                out int costoTerminar)
        {

            string line = reader.ReadLine();
            char[] delimiterstring = { ':' };

            costoCopiar = 1000;
            costoEliminar = 1000;
            costoInsertar = 1000;
            costoIntercambiar = 1000;
            costoReemplazar = 1000;
            costoTerminar = 1000;

            while (line != null)
            {

                string[] datos = line.Split(delimiterstring, StringSplitOptions.RemoveEmptyEntries);

                string operacion = datos[0].Trim();

                if (operacion == "Copiar") costoCopiar = Convert.ToInt32(datos[1]);
                if (operacion == "Reemplazar") costoReemplazar = Convert.ToInt32(datos[1]);
                if (operacion == "Intercambiar") costoIntercambiar = Convert.ToInt32(datos[1]);
                if (operacion == "Borrar") costoEliminar = Convert.ToInt32(datos[1]);
                if (operacion == "Insertar") costoInsertar = Convert.ToInt32(datos[1]);
                if (operacion == "Terminar") costoTerminar = Convert.ToInt32(datos[1]);

                line = reader.ReadLine();
            }
        }

    }

}
