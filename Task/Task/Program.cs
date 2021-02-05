using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel programma di gestione dei task!");
            Console.WriteLine("Scrivi il numero dell' operazione che vuoi eseguire o premi 'q' per uscire:");
            Console.WriteLine("1- Stampa i Task esistenti,");
            Console.WriteLine("2- Inserisci un nuovo Task,");
            Console.WriteLine("3- Elimina un Task esistente,");
            Console.WriteLine("4- Filtra i Task per livello di importanza,");
            Console.WriteLine("5- Premi q per uscire dal programma.");
            char key = Convert.ToChar(Console.ReadLine());
            while(key != 'q')
            {
                switch (key)
                {
                    case '1':
                        Task.StampaITask();
                        Console.WriteLine("Esegui una nuova operazione:");
                        key = Convert.ToChar(Console.ReadLine());
                        break;
                    case '2':
                        Task.InserisciTask();
                        Console.WriteLine("Esegui una nuova operazione:");
                        key = Convert.ToChar(Console.ReadLine());
                        break;
                    case '3':
                        Task.EliminaTask();
                        Console.WriteLine("Esegui una nuova operazione:");
                        key = Convert.ToChar(Console.ReadLine());
                        break;
                    case '4':
                        Task.FiltraPerImportanza();
                        Console.WriteLine("Esegui una nuova operazione:");
                        key = Convert.ToChar(Console.ReadLine());
                        break;
                }
            }
        }
    }
}
