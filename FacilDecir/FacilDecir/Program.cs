using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FacilDecir
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreArchivo = "facil.txt";
            string linea;
            string patronVocales = $"[{"a"}]|[{"e"}]|[{"i"}]|[{"o"}]|[{"u"}]";
            string patronVocSegPermitidas = $"[{"e"}]|[{"o"}]";

            TextReader leerArch = new StreamReader(nombreArchivo);
            linea = leerArch.ReadLine();

            Console.WriteLine("***Generador de passwords***");
            while (linea != "end")
            {
                int contVocales = 1, contConsonante = 1;
                Regex miRegex = new Regex(patronVocales);
                MatchCollection elMatch = miRegex.Matches(linea);
                if (elMatch.Count > 0)
                {
                    for (int i = 1; i< linea.Length; i++)
                    {
                        if (linea.Length == 1 && elMatch.Count > 0) Console.WriteLine($"<{linea}> is acceptable");
                        else {                            
                            if (linea.Length > 1 && (linea.ElementAt<char>(i - 1) != linea.ElementAt<char>(i)))
                            {
                                char letra = linea.ElementAt<char>(i - 1);
                                char letra2 = linea.ElementAt<char>(i);
                                Regex miRegex2 = new Regex(patronVocales);
                                MatchCollection elMatch2 = miRegex.Matches(letra.ToString());
                                Regex miRegex3 = new Regex(patronVocales);
                                MatchCollection elMatch3 = miRegex.Matches(letra2.ToString());
                                if (elMatch2.Count > 0 && elMatch3.Count > 0) contVocales++;                                
                                if (elMatch2.Count == 0 && elMatch3.Count == 0) contConsonante++;                                
                                if((elMatch2.Count == 0 && elMatch3.Count > 0) || (elMatch2.Count > 0 && elMatch3.Count == 0))
                                {
                                    if (contVocales < 3 && contConsonante < 3)  contConsonante = contVocales = 1; 
                                }
                                                               
                            } else
                            {
                                if (linea.Length>1 && (linea.ElementAt<char>(i - 1) == linea.ElementAt<char>(i)))
                                {
                                    char letra3 = linea.ElementAt<char>(i);
                                    Regex miRegex4 = new Regex(patronVocSegPermitidas);
                                    MatchCollection elMatch4 = miRegex4.Matches(letra3.ToString());
                                    if (elMatch4.Count == 0) {
                                        i = linea.Length - 1;
                                        contConsonante = contVocales = 3;
                                    }
                                    else { contVocales++; }                                                                
                                }                                
                            }
                        }                       
                    }
                    if (contVocales < 3 && contConsonante < 3) Console.WriteLine($"<{linea}> is acceptable");                    
                    else Console.WriteLine($"<{linea}> is not acceptable");                    
                }
                else Console.WriteLine($"<{linea}> is not acceptable");
                linea = leerArch.ReadLine();
            }
            leerArch.Close();
            Console.ReadLine();
        }
    }
}
