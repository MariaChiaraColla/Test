using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task
{
    public class TaskFileManagement
    {
        //Classe per gestire l'accesso ai dati sul file, per dividere le funzionalità e rendere il codice più pulito

        //Lettura da file
        public static Task[] LeggiTaskDaFile()
        {
            //conto le righe totali del file e le assegno come grandezza dell'Array dei TaskLettiDaFile
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Task.txt");
            int righeFile = File.ReadLines(path).Count();
            Task[] TaskLettiDaFile = new Task[righeFile-1];
            //singola riga del file
            string riga;

            using(StreamReader reader = File.OpenText(path))
            {
                string rigaHeader = reader.ReadLine();
                Console.WriteLine(rigaHeader);

                for (int i = 0; i < TaskLettiDaFile.Length; i++)
                {
                    riga = reader.ReadLine();
                    string[] righe = riga.Split(",");
                    Task nuovoTask = new Task
                    {
                        Descrizione = righe[0],
                        DataScadenza = Convert.ToDateTime(righe[1]),
                        LivelloImportanza = righe[2]
                    };
                    TaskLettiDaFile[i] = nuovoTask;
                }
            }
            //Console.WriteLine("Tutti i task letti dal file");
            return TaskLettiDaFile;
        }

        //inserisci task nel file
        public static void InserisciTaskNelFile(Task taskDaInserire)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Task.txt");
            using(StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(taskDaInserire.Descrizione + "," + taskDaInserire.DataScadenza + "," + taskDaInserire.LivelloImportanza);
            }
            //Console.WriteLine("Task inserito nel file correttamente");
        }

        //Eliminare un task dal file
        public static void EliminaTaskNelFile(Task taskDaEliminare)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Task.txt");
            Task[] tuttiITask = LeggiTaskDaFile();
            Task[] tuttiITaskDopoLaCancellazione = new Task[tuttiITask.Length-1];
            int j = 0;

            using (StreamWriter writer = File.CreateText(path))
            {
                for(int i = 0; i < tuttiITask.Length; i++)
                {
                    if(tuttiITask[i].Descrizione != taskDaEliminare.Descrizione)
                    {
                        tuttiITaskDopoLaCancellazione[j] = tuttiITask[i];
                        writer.WriteLine(tuttiITaskDopoLaCancellazione[j].Descrizione + "," + tuttiITaskDopoLaCancellazione[j].DataScadenza + "," + tuttiITaskDopoLaCancellazione[j].LivelloImportanza);
                        j++;
                    }
                }
            }
            Console.WriteLine("Task eliminato nel file correttamente");
        }
    }
}
