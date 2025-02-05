using System;
using System.Data.SqlTypes;
using System.IO;

namespace StreamReadWriteApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //GenerateHtmlFile();

            ReadHtmlfile();
        }
        private static void GenerateHtmlFile(){
            var myhtmlbody = $"<html>" +
                    $"<body>" +
                    $"<h1>Welcome to html Page..</h1>" +
                    $"</body>" +
                    $"</html>";
            FileStream fs = new FileStream("C:\\Users\\admin\\AppData\\Local\\Temp\\welcome.html", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(myhtmlbody);
            sw.Close();
            fs.Close();
            System.Console.WriteLine("End of Stream");
        }
        private static void ReadHtmlfile()
        { 
            var fs=new FileStream("C:\\Users\\admin\\AppData\\Local\\Temp\\welcome.html", FileMode.Open);
            var sr = new StreamReader(fs);
            //System.Console.WriteLine(sr.ReadToEnd());   
            while (true) {
                var line = sr.ReadLine();              
                if(line == null) break;
                Console.WriteLine(line);
            }
        }
        }
}