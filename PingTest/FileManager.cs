using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections;


namespace PingTest
{
    public class FileManager
    {

        public List<string> readFile(string ruta)
        {
            // Levanto un List de String para meter todas las lineas y obviamente el fileLine es cada linea.
            List<string> linesOfFile = new List<string>();

            string fileLine;

            try
            {
                // Levanto el archivo
                StreamReader streamReader = new StreamReader(ruta);

                // Leo la primer linea y si no esta vacia entra en el bucle.
                fileLine = streamReader.ReadLine();

                // Si entra en el Bucle, me guarda la linea que lei y guarda las siguientes hasta que no haya mas.
                while (fileLine != null)
                {
                    linesOfFile.Add(fileLine);

                    fileLine = streamReader.ReadLine();
                }

                // Cierro el archivo. (Estoy es mucho muy importante)
                streamReader.Close();

            }
            catch (Exception e)
            {

            }

            return linesOfFile;

        }

        public bool saveFile(List<String> lines, string ruta)
        {
            bool ok = false;

            try
            {
                StreamWriter streamWriter = new StreamWriter(ruta);

                // escribo las lineas
                foreach (string line in lines)
                {
                    streamWriter.WriteLine(line);
                }

                streamWriter.Close();

                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ok = false;
            }

            return ok;
        }
        
        public bool insertAndSaveFile(string ruta, string line)
        {
            bool ok = false;

            List<string> linesOfFile = readFile(ruta);

            linesOfFile.Add(line);

            ok = saveFile(linesOfFile, ruta);

            return ok;
        }

    }
}