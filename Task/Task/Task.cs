using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class Task
    {
        //Classe task: oggetto che ha una descrizione, una data di scadenza e un livello di importanza(Basso, Medio o Alto)

        //Campi
        private string descrizione = "Null";
        private DateTime dataScadenza;
        private string livelloImportanza = "Basso";

        //Proprietà
        public string Descrizione
        {
            get { return descrizione; }
            set { descrizione = value; }
        }
        public DateTime DataScadenza
        {
            get { return dataScadenza; }
            set { dataScadenza = value; }
        }
        public string LivelloImportanza
        {
            get { return livelloImportanza; }
            set { livelloImportanza = value; }
        }

        //Metodi
        //Vedere i task inseriti: richiamo la funzione che legge i task dal file, nella classe TaskFileManagement
        public static void StampaITask()
        {
            Task[] tuttiITask = TaskFileManagement.LeggiTaskDaFile();
            foreach (Task task in tuttiITask)
            {
                Console.WriteLine(task.Descrizione + " - " + task.DataScadenza + " - " + task.LivelloImportanza);
            }
        }

        //inserisci task: richiamo la funzione che aggiorna il file dei task nella classe TaskFileManagement
        public static void InserisciTask()
        {
            Task taskDaInserire = new Task();
            Console.WriteLine("Inserisci un nuovo task:");

            Console.WriteLine("Scrivi la descrizione del file:");
            string descrizione = Console.ReadLine();
            taskDaInserire.Descrizione = Convert.ToString(descrizione);

            Console.WriteLine("Scrivi la data di scadenza:");
            DateTime data =Convert.ToDateTime(Console.ReadLine());
            DateTime dataDiInseriemtno = DateTime.Now;
            bool giusto = false;

            while (giusto == false)
            {
                if (dataDiInseriemtno > data)
                    giusto = true;
                else
                {
                    Console.WriteLine("Valore non ammesso, riprova");
                    data = Convert.ToDateTime(Console.ReadLine());
                    giusto = false;
                }
            }
            taskDaInserire.DataScadenza = data;

            Console.WriteLine("Scrivi il livello di importanza (Valori ammessi: Alto, Medio, Basso):");
            string livello = Console.ReadLine();
            bool giusto2 = false;

            while (giusto2 == false)
            {
                if (livello == "Alto" || livello == "Basso" || livello == "Medio")
                    giusto2 = true;
                else
                {
                    Console.WriteLine("Valore non ammesso, riprova");
                    livello = Console.ReadLine();
                    giusto2 = false;
                }

            }
            taskDaInserire.LivelloImportanza = Convert.ToString(livello);

            TaskFileManagement.InserisciTaskNelFile(taskDaInserire);
            Console.WriteLine("Task inserito correttamente!");
        }

        //Elimina task: richiamo la funzione che elimina il task dal file nella classe TaskFileManagement,
        //Controllo solo la descrizione del task perchè do per scontato che sia univoca
        public static void EliminaTask()
        {
            Task[] tuttiiTask = TaskFileManagement.LeggiTaskDaFile();
            //Task taskDaEliminare = new Task();
            Console.WriteLine("Elimina un task:");
            Console.WriteLine("Scrivi la descrizione del task che vuoi eliminare:");
            string descrizione = Convert.ToString(Console.ReadLine());
            bool controllaCheEsiste = false;
            for(int i=0; i<tuttiiTask.Length; i++)
            {
                if(tuttiiTask[i].Descrizione == descrizione)
                {
                    TaskFileManagement.EliminaTaskNelFile(tuttiiTask[i]);
                    controllaCheEsiste = true;
                }
            }
            if (controllaCheEsiste == false)
                Console.WriteLine("Task non esistente, riperete l'operazione!");
            else
                Console.WriteLine("Task cancellato correttamente");

        }

        //filtra i task per importanza
        public static void FiltraPerImportanza()
        {
            Console.WriteLine("Per quale livello di importanza filtrare? ");
            string livello = Console.ReadLine();
            bool giusto = false;

            while (giusto == false)
            {
                if (livello == "Alto" || livello == "Basso" || livello == "Medio")
                    giusto = true;
                else
                {
                    Console.WriteLine("Valore non ammesso, riprova");
                    livello = Console.ReadLine();
                    giusto = false;
                }

            }
            Task[] tuttiITask = TaskFileManagement.LeggiTaskDaFile();
            for(int i = 0; i<tuttiITask.Length; i++)
            {
                if(tuttiITask[i].livelloImportanza == livello)
                {
                    Console.WriteLine(tuttiITask[i].Descrizione + " - " + tuttiITask[i].DataScadenza + " - " + tuttiITask[i].livelloImportanza);
                }
            }
        }

    }
}
