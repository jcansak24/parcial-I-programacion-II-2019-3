using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Realizado por Jimer Sayago CIV- 24611409*/

namespace Misiones
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCasos, cont = 0;
            string nombreArchivo = "misiones.txt";
            string linea;

            TextReader leerArch = new StreamReader(nombreArchivo);
            numCasos = int.Parse(leerArch.ReadLine());
            linea = leerArch.ReadLine();
            int[] navesxCasos = new int[numCasos];
            if (numCasos < 1 || numCasos > 50)
            {
                Console.WriteLine("El numero de casos excede el maximo permitido. Intente evaluar hasta 50 casos");
                linea = null;
            }
            while (linea != null)
            {
                string[] num = linea.Split();
                int naves = int.Parse(num[0]);
                int dist = int.Parse(num[1]);
                linea = leerArch.ReadLine();
                if ((naves < 1 || naves > 100) || (dist < 1 || dist > 999999)) {
                    Console.WriteLine("El numero de naves o distancia ha excedido el maximo permitido");
                    linea = null; break;
                }
                int contNaves = 0;                
                for (int i = 0; i < naves; i++)
                {
                    string[] caso = linea.Split();
                    float veloc = float.Parse(caso[0]);
                    float peso = float.Parse(caso[1]);
                    float consumo = float.Parse(caso[2]);
                    if ((veloc < 1 || veloc > 1000) || (peso < 1 || peso > 1000) || (consumo < 1 || consumo > 1000)){
                        Console.WriteLine("La cantidad solicitada excede los limites maximos permitidos."); break;
                    }
                    float cantHorasDestino = dist / veloc;
                    float consTot = cantHorasDestino * consumo;
                    if (consTot <= peso) contNaves++; 
                    linea = leerArch.ReadLine();
                }
                navesxCasos[cont++] = contNaves;   
            }
            leerArch.Close();
            Console.WriteLine("***Naves que llegaron al sitio de expedicion***");
            foreach (int navesMision in navesxCasos) Console.WriteLine($"\t{navesMision}");
            Console.ReadLine();
        }
    }
}
