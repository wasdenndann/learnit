using System;
using System.IO;


namespace learnit
{
    class Program
    {
        static void Main(string[] args)
        {

            MoveShots();
            



        }

        static void MoveShots()
        {   
            string verzeichnis_screenshots = new string("C:\\Users\\_username_\\Pictures\\Screenshots");
            // Ursprungsverzeichnis der Screenshots, _username_ muss auf jeden Fall angepasst werden

            string verzeichnis_vitero = new string("C:\\Users\\_username_\\Desktop\\vitero Dateien");
            string datum_ordner = new string("C:\\Users\\_username_\\Desktop\\vitero Dateien\\"); 
            // Für die alte Vitero/Viona-Platform, _username_ auch anpassen, evtl auch Pfad


            int counter = 0;        // Dödelcounter zum evt. limitieren

            if (Directory.Exists(verzeichnis_screenshots))
                {
                Directory.SetCurrentDirectory(verzeichnis_screenshots);

                string[] dateiliste = Directory.GetFiles(verzeichnis_screenshots);

                foreach (string datei in dateiliste)
                {
                    counter += 1;
                    Console.WriteLine(datei.Length+"  "+datei);
                    Console.WriteLine(datei.LastIndexOf("\\"));
                    string screenshot = (datei.Substring(38,21));         // Dateiname vom Screenshot
                    Console.WriteLine(screenshot);
                    //= Console.WriteLine(datei.Substring(datei.LastIndexOf("\\") + 1, 21));

                    //      Datumsstempel aus CreationTime erzeugen
                    DateTime erstellt =  File.GetCreationTime(datei);
                    string erstelldatum = erstellt.ToShortDateString();
                    Console.WriteLine(erstelldatum);
                    Console.WriteLine(erstelldatum.Length);
                    string datumsstempel = erstelldatum.Substring(6, 4) + erstelldatum.Substring(3, 2) + erstelldatum.Substring(0, 2);
                    //Console.WriteLine(erstelldatum.Substring(6,4)+erstelldatum.Substring(3,2)+erstelldatum.Substring(0,2));
                    Console.WriteLine(datumsstempel);

                    //      Zielpfad anhand Datumsstempel
                    string zielverzeichnis = datum_ordner +  datumsstempel;

                    //      Erstellung Verzeichnis, falls nicht existent
                    if  (!(Directory.Exists(zielverzeichnis)))
                        {
                        Directory.CreateDirectory(zielverzeichnis);
                        }
                    

                    if (Directory.Exists(zielverzeichnis))
                    {
                        Console.WriteLine("Yes");

                        //      Zielpfad inklusive Dateiname
                        string dateiimzielverzeichnis = zielverzeichnis +"\\"+ screenshot;
                        Console.WriteLine(dateiimzielverzeichnis);
                        Console.WriteLine(datei);
                        File.Move(datei, dateiimzielverzeichnis);


                    }
                    Console.WriteLine(zielverzeichnis);

                    //      Dödelcounter zum limitieren
                    if (counter==1000)
                    {
                        break;
                    }
                }

                }
            
            Console.WriteLine("done");

        }

        
    }
}
