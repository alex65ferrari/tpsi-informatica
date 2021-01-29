//Autori: Diego Albertin, Francesco Di Lena, Alessio Donini, Alex Niccolò Ferrari
//Classe: 3F
//Progetto collaborativo di informatica per la creazione di un software per la gestione di una concessionaria.
//Per ulteriori informazioni vedere la relazione.
using System;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;

namespace prgfunz
{
    class Program
    {
        //funzione principale di acquisizione del contenuto del file e richieste iniziali
        public static void Main(string[] args)
        {
            Console.SetWindowSize(170, 50); //imposta le dimensioni della finestra del programma
            string risposta = "sì";//inizializza e assegna il valore "sì" alla variabile risposta, che servirà quando il programma chiede se continuare con le operazioni oppure no
            do
            {
                string autonuoveinvendita = "0:::::::::"; //inizializza la stringa che conterrà tutti i dati del file delle auto nuove in vendita
                string autousateinvendita = "0::::::::::::"; //inizializza la stringa che conterrà tutti i dati del file delle auto usate in vendita
                string autonuovevendute = "0:::::::::::::"; //inizializza la stringa che conterrà tutti i dati del file delle auto nuove vendute
                string autousatevendute = "0::::::::::::::";//inizializza la stringa che conterrà tutti i dati del file delle auto usate vendute
                string istruzioni = ""; //inizializza la stringa che conterrà le istruzioni del programma
                Console.Clear(); //pulisce il contenuto della console 
                Console.WriteLine("\n -------------------------------- Concessionaria Automotors S.N.C., Via A. De Gasperi, 21, Rovigo (RO), 45100 ------------------------------------- ");
                Console.WriteLine("\n          Benvenuto nel programma. Puoi eseguire una ricerca delle auto presenti nel parco auto aziendale, aggiungerne di nuove al database," +
                                    "\n      spostarle da vendute a in vendita e viceversa, oppure eliminarle. Nel caso in cui avessi bisogno di aiuto inserisci la parola Aiuto. ");

                try //il programma prova ad acquisire il contenuto dei file
                {
                    try //il programma prova ad eseguire le seguenti operazioni
                    {
                        //acquisisce dal file presente sul disco le auto nuove in vendita
                        autonuoveinvendita = File.ReadAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt");

                    }
                    catch (FileNotFoundException) //se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto nuove in vendita non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine());
                        if (rispostaeccezioni == "si")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt", autonuoveinvendita); //crea il nuovo file che conterrà le auto nuove in vendita
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "no")
                        {
                            Console.WriteLine("\nChiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                            Environment.Exit(0); //esce automaticamente dal programma
                        }
                    }
                    try //il programma prova ad eseguire le seguenti operazioni
                    {
                        //acquisisce dal file presente sul disco le auto usate in vendita
                        autousateinvendita = File.ReadAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt");
                    }
                    catch (FileNotFoundException)//se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto usate in vendita non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine());
                        if (rispostaeccezioni == "si")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt", autousateinvendita);//crea il nuovo file che conterrà le auto usate in vendita
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "no")
                        {
                            Console.WriteLine("\nChiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                            Environment.Exit(0); //esce automaticamente dal programma
                        }
                    }
                    try //il programma prova ad eseguire le seguenti operazioni
                    {
                        //acquisisce dal file presente sul disco le auto nuove già vednute
                        autonuovevendute = File.ReadAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt");
                    }
                    catch (FileNotFoundException)//se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto nuove vendute non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine());
                        if (rispostaeccezioni == "si")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt", autonuovevendute);//crea il nuovo file che conterrà le auto nuove vendute
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "no")
                        {
                            Console.WriteLine("\nChiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                            Environment.Exit(0);//esce automaticamente dal programma
                        }
                    }
                    try //il programma prova ad eseguire le seguenti operazioni
                    {
                        //acquisisce dal file presente sul disco le auto usate già vednute
                        autousatevendute = File.ReadAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt");
                    }
                    catch (FileNotFoundException)//se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto usate vendute non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine());
                        if (rispostaeccezioni == "si")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt", autousatevendute);//crea il nuovo file che conterrà le auto usate vendute
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "no")
                        {
                            Console.WriteLine("Chiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                            Environment.Exit(0);//esce automaticamente dal programma
                        }
                    }

                }
                catch (DirectoryNotFoundException) //se si verifica questo errore, cioè la cartella dei file non è stato trovata, esegue le operazioni seguenti
                {
                    Console.WriteLine("\n\nERRORE: la cartella in cui si dovrebbero trovare tutte le auto non è stata trovata. Vuoi crearla?");
                    string rispostaeccezioni = Convert.ToString(Console.ReadLine());
                    if (rispostaeccezioni == "si")
                    {

                        Directory.CreateDirectory(@"C:\Programma gestionale concessionaria"); //crea prima la cartella
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt", autonuoveinvendita); //crea il nuovo file che conterrà le auto nuove in vendita
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt", autousateinvendita);//crea il nuovo file che conterrà le auto usate in vendita
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt", autonuovevendute);//crea il nuovo file che conterrà le auto nuove vendute
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt", autousatevendute);//crea il nuovo file che conterrà le auto usate vendute
                        Console.WriteLine("\nLe cartelle e i file sono stati creati con successo. Ora inserisci delle automobili per sfruttare pienamente le funzionalità del programma.");
                    }
                    else if (rispostaeccezioni == "no")
                    {
                        Console.WriteLine("\nChiusura del programma in corso...");
                        Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                        Environment.Exit(0);//esce automaticamente dal programma
                    }
                }
                catch (IOException)//se si verifica questo errore, cioè errore di lettura, esegue le operazioni seguenti
                {
                    Console.WriteLine("\n\nERRORE: si è verificato un errore durante la lettura dei file. Premi un tasto qualsiasi per chiudere il programma e prova ad aprilo di nuovo.");
                    Console.ReadKey();
                    Environment.Exit(0);//esce automaticamente dal programma una volta che viene premuto un tasto qualsiasi
                }
                catch (UnauthorizedAccessException)//se si verifica questo errore, cioè accesso non autorizzato, esegue le operazioni seguenti
                {
                    Console.WriteLine("\n\nERRORE: non hai i privilegi per accedere ai file che contengono le auto. Premi un tasto qualsiasi per chiudere il programma e " +
                                      "prova ad aprilo di nuovo. Nel caso in cui il problema persista, contatta l'amministratore. ");
                    Console.ReadKey();
                    Environment.Exit(0);//esce automaticamente dal programma una volta che viene premuto un tasto qualsiasi
                }
                //inizializza la variabile che contiene l'elemento divisore del file
                char carattereDivisore = ':';
                //inserisce all'interno di un array monodimensionale tutti gli elementi del file, inserendo nelle celle ogni elemento diviso dai due punti
                string[] elementinuoveinvendita = autonuoveinvendita.Split(carattereDivisore);
                string[] elementiusateinvendita = autousateinvendita.Split(carattereDivisore);
                string[] elementinuovevendute = autonuovevendute.Split(carattereDivisore);
                string[] elementiusatevendute = autousatevendute.Split(carattereDivisore);
                //nel file come prima cifra è presente il numero di righe che l'array multidimensionale deve avere, quindi va convertito da stringa a intero
                int righenuoveinvendita = Convert.ToInt32(elementinuoveinvendita[0]);
                int righeusateinvendita = Convert.ToInt32(elementiusateinvendita[0]);
                int righenuovevendute = Convert.ToInt32(elementinuovevendute[0]);
                int righeusatevendute = Convert.ToInt32(elementiusatevendute[0]);
                string[,] Autonuoveinvendita = new string[righenuoveinvendita, 8]; // si inizializza l'array multidimensionale per contenere le auto nuove in vendita
                string[,] Autousateinvendita = new string[righeusateinvendita, 10]; // si inizializza l'array multidimensionale per contenere le auto usate in vendita
                string[,] Autonuovevendute = new string[righenuovevendute, 12]; // si inizializza l'array multidimensionale per contenere le auto vendute
                string[,] Autousatevendute = new string[righeusatevendute, 14]; // si inizializza l'array multidimensionale per contenere le auto vendute
                int n1 = 1; //si inizializza la variabile necessaria per l'estrazione del contenuto dell'array monodimensionale elementi
                for (int i = 0; i < righenuoveinvendita; i++) /*inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementinuoveinvendita, 
                                                            che contiene auto nuove in vendita*/

                {
                    for (int j = 0; j < 8; j++)
                    {
                        Autonuoveinvendita[i, j] = elementinuoveinvendita[n1];
                        n1++;
                    }
                }
                n1 = 1; //assegna a n1 di nuovo il valore uno per il nuovo inserimento
                for (int i = 0; i < righeusateinvendita; i++) /*inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementiusateinvendita, 
                                                            che contiene auto usate in vendita*/
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Autousateinvendita[i, j] = elementiusateinvendita[n1];
                        n1++;
                    }
                }
                n1 = 1; //assegna a n1 di nuovo il valore uno per il nuovo inserimento
                for (int i = 0; i < righenuovevendute; i++) /*inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementinuovevendute, 
                                                     che contiene auto nuove vendute*/
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Autonuovevendute[i, j] = elementinuovevendute[n1];
                        n1++;
                    }

                }
                n1 = 1; //assegna a n1 di nuovo il valore uno per il nuovo inserimento
                for (int i = 0; i < righeusatevendute; i++) /*inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementiusatevendute, 
                                                     che contiene auto usate vendute*/
                {
                    for (int j = 0; j < 14; j++)
                    {
                        Autousatevendute[i, j] = elementiusatevendute[n1];
                        n1++;
                    }

                }
                Console.WriteLine("\n\nCosa vuoi fare?");
                //vengono inizializzate tutte le variabili e gli array che servono nella funzione main, insieme alle altre
                string sceltainiziale = "";  //è la scelta indicata dall'utente inizialmente, per poter accedere alle varie funzioni del programma
                sceltainiziale = Convert.ToString(Console.ReadLine()); //acquisisce la scelta inziale
                string primascelta = "";//è la scelta indicata dall'utente fra auto in vendita e vendute
                string secondascelta = "";//è la scelta indicata dall'utente fra auto nuove e usate
                string[] elementivisualizzati = new string[0]; //verrà usata per contenere gli elementi da mostrare durante l'inserimento delle caratteristiche delle auto
                string[,] autofunzione = new string[0, 0]; /*verrà usata per contenere le auto in base alle scelte fatte (ad esempio se si indica "auto-in vendita-nuova" 
                                                             inserisce in questo array le auto nuove in vendita*/
                string indicazionecaratteristicheauto = ""; //verrà usata per indicare le caratteristiche che verranno visualizzate una volta terminata una funzione
                int n = 0; //indica generalemente il numero di colonne di un array bidimensionale
                int righe = 0;//indica il numero di righe di un array bidimensionale

                // inizializzazione e assegnazione degli elementi da visualizzare durante l'esecuzione delle diverse funzioni
                string[] elementiautonuoveinvenditavisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "prezzo (nel formato XX.XXX euro)" };
                string[] elementiautousateinvenditavisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "numero di proprietari (nel formato N proprietari in lettere)", "chilometri percorsi ( nel formato XX.XXX km )", "prezzo (nel formato XX.XXX euro)" };
                string[] elementiautonuovevendutevisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "targa (nel formato maiuscolo)", "acquirente", "data di acquisto", "prezzo di vendita iniziale (nel formato XX.XXX euro)", "prezzo di vendita finale (nel formato XX.XXX euro)" };
                string[] elementiautousatevendutevisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "numero di proprietari (nel formato N proprietari in lettere)", "chilometri percorsi ( nel formato XX.XXX km )", "targa (nel formato maiuscolo)", "acquirente", "data di acquisto (nel formato GG/MM/AAAA)", "prezzo di vendita iniziale (nel formato XX.XXX euro)", "prezzo di vendita finale (nel formato XX.XXX euro)" };

                //qui viene eseguito un ciclo preventivo per individuare eventuali errori di inserimento
                while (sceltainiziale != "ricerca" & sceltainiziale != "Ricerca" & sceltainiziale != "inserisci" & sceltainiziale != "Inserisci" &
                       sceltainiziale != "sposta" & sceltainiziale != "Sposta" & sceltainiziale != "elimina" & sceltainiziale != "Elimina" &
                       sceltainiziale != "aiuto" & sceltainiziale != "Aiuto" & sceltainiziale != "help" & sceltainiziale != "Help" & sceltainiziale != "?")
                {
                    Console.WriteLine("\nNon hai inserito una parola chiave accettabile." +
                                      "\nInserisci di nuovo un'operazione eseguibile oppure inserisci la parola aiuto per leggere le istruzioni del programma:");
                    sceltainiziale = Convert.ToString(Console.ReadLine());
                }
                //se l'utente sceglie di svolgere una ricerca esegue le operazioni seguenti
                if (sceltainiziale == "ricerca" || sceltainiziale == "Ricerca")
                {
                    Console.WriteLine("\nChe tipo di automobile vuoi ricercare, in vendita oppure già venduta?");
                    primascelta = Convert.ToString(Console.ReadLine());
                    //qui viene eseguito un ciclo preventivo per individuare eventuali errori di inserimento
                    while (primascelta != "vendita" & primascelta != "Vendita" & primascelta != "vendite" & primascelta != "Vendite" &
                            primascelta != "venduta" & primascelta != "Venduta" & primascelta != "vendute" & primascelta != "Vendute") 
                    {
                        Console.WriteLine("\nNon hai inserito una parola chiave accettabile. Inserisci di nuovo la tua risposta:");
                        primascelta = Convert.ToString(Console.ReadLine());
                    }
                    Console.WriteLine("\nVuoi cercare un'auto nuova o usata?");
                    secondascelta = Convert.ToString(Console.ReadLine());
                    //qui viene eseguito un ciclo preventivo per individuare eventuali errori di inserimento
                    while (secondascelta != "usato" & secondascelta != "Usato " & secondascelta != "usata" & secondascelta != "Usata" &
                            secondascelta != "nuovo" & secondascelta != "Nuovo" & secondascelta != "nuova" & secondascelta != "Nuova" &
                            secondascelta != "usate" & secondascelta != "Usate" & secondascelta != "nuove" & secondascelta != "Nuove"
                            & secondascelta != "tutte" & secondascelta != "Tutte")  
                    {
                        Console.WriteLine("\nNon hai inserito una parola chiave accettabile. Inserisci di nuovo la tua risposta:");
                        secondascelta = Convert.ToString(Console.ReadLine());
                    }
                    if (secondascelta == "Tutte" || secondascelta == "tutte") //se l'utente vuole visualizzare tutte le auto, allora vengono eseguite queste operazioni
                    {
                        //se l'utente vuole visualizzare tutte le auto in vendita, allora vengono eseguite queste operazioni
                        if (primascelta == "Vendita" || primascelta == "vendita" || primascelta == "vendite" || primascelta == "Vendite") 
                        {
                            Console.WriteLine("\nLa ricerca ha prodotto {0} risultati.", (righenuoveinvendita + righeusateinvendita));
                            Console.WriteLine("\nQueste sono tutte le auto nuove in vendita:\n");
                            for (int i = 0; i < righenuoveinvendita; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    Console.Write(Autonuoveinvendita[i, j]);
                                }
                            }
                            Console.WriteLine("\n\nQueste, invece, sono tutte le auto usate in vendita:\n");
                            for (int i = 0; i < righeusateinvendita; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    Console.Write(Autousateinvendita[i, j]);
                                }
                            }


                        }
                        //se l'utente vuole visualizzare tutte le auto vendute, allora vengono eseguite queste operazioni
                        else if (primascelta == "Venduta" || primascelta == "venduta" || primascelta == "vendute" || primascelta == "Vendute" )
                        {
                            Console.WriteLine("\nLa ricerca ha prodotto {0} risultati.", (righenuovevendute + righeusatevendute));
                            Console.WriteLine("\nQueste sono tutte le auto nuove vendute:\n");
                            for (int i = 0; i < righenuovevendute; i++)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    Console.Write(Autonuovevendute[i, j]);
                                }
                            }
                            Console.WriteLine("\n\nQueste, invece, sono tutte le auto usate già vendute:\n");
                            for (int i = 0; i < righeusatevendute; i++)
                            {
                                for (int j = 0; j < 14; j++)
                                {
                                    Console.Write(Autousatevendute[i, j]);
                                }
                            }
                        }
                    }
                    //per tutti gli altri casi fa riferimento alla funzione sceltamatrici
                    else if (secondascelta == "nuova" || secondascelta == "Nuova" || secondascelta == "usata" || secondascelta == "Usata"
                            || secondascelta == "nuove" || secondascelta == "Nuove" || secondascelta == "usate" || secondascelta == "Usate"
                            || secondascelta == "nuovo" || secondascelta == "Nuovo" || secondascelta == "usato" || secondascelta == "Usato")
                    {
                        sceltamatrici(n, righe, autofunzione, indicazionecaratteristicheauto, elementivisualizzati, primascelta, secondascelta, sceltainiziale, Autonuoveinvendita, Autousateinvendita, 
                                        Autonuovevendute, Autousatevendute, elementiautonuoveinvenditavisualizati, elementiautousateinvenditavisualizati, elementiautonuovevendutevisualizati, 
                                        elementiautousatevendutevisualizati, righenuoveinvendita, righeusateinvendita, righenuovevendute, righeusatevendute, carattereDivisore);
                    }

                }

                if (sceltainiziale == "inserisci" || sceltainiziale == "Inserisci" || sceltainiziale == "sposta" || sceltainiziale == "Sposta" || sceltainiziale == "elimina" || sceltainiziale == "Elimina")
                {
                    //se l'utente sceglie di inserire un'auto esegue le operazioni seguenti
                    if (sceltainiziale == "inserisci" || sceltainiziale == "Inserisci")
                    {
                        Console.WriteLine("\nChe tipo di automobile vuoi inserire, in vendita oppure già venduta?");
                        primascelta = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("\nVuoi inserire un'auto nuova o usata?");
                        secondascelta = Convert.ToString(Console.ReadLine());

                    }
                    //se l'utente sceglie di spostare un'auto esegue le operazioni seguenti
                    else if (sceltainiziale == "sposta" || sceltainiziale == "Sposta")
                    {
                        Console.WriteLine("\nChe tipo di automobile vuoi spostare, in vendita oppure già venduta?");
                        primascelta = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("\nVuoi spostare un'auto nuova o usata?");
                        secondascelta = Convert.ToString(Console.ReadLine());
                    }
                    //se l'utente sceglie di eliminare un'auto esegue le operazioni seguenti
                    else if (sceltainiziale == "elimina" || sceltainiziale == "Elimina")
                    {
                        Console.WriteLine("\nChe tipo di automobile vuoi eliminare, in vendita oppure già venduta?");
                        primascelta = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("\nVuoi eliminare un'auto nuova o usata?");
                        secondascelta = Convert.ToString(Console.ReadLine());
                    }
                    //fa riferimento alla funzione sceltamatrici per svolgere le altre operazioni
                    sceltamatrici(n, righe, autofunzione, indicazionecaratteristicheauto, elementivisualizzati, primascelta, secondascelta, sceltainiziale, Autonuoveinvendita, Autousateinvendita, Autonuovevendute, 
                                 Autousatevendute, elementiautonuoveinvenditavisualizati, elementiautousateinvenditavisualizati, elementiautonuovevendutevisualizati, 
                                 elementiautousatevendutevisualizati, righenuoveinvendita, righeusateinvendita, righenuovevendute, righeusatevendute, carattereDivisore);
                }
                //se l'utente chiede di visualizzare le istruzioni del programma, esegue le seguenti operazioni **da completare
                else if (sceltainiziale == "aiuto" || sceltainiziale == "Aiuto" || sceltainiziale == "help" || sceltainiziale == "Help" || sceltainiziale == "?")
                {
                    try //il programma prova ad eseguire le seguenti operazioni
                    {
                        //acquisice dal file presente sul disco le istruzioni del programma
                        istruzioni = File.ReadAllText(@"C:\Programma gestionale concessionaria\aiuto.txt");
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene le istruzioni del programma non è stato trovato.");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("\n\nERRORE: si è verificato un errore durante la lettura delle istruzioni.");
                    }
                    Console.WriteLine("\n\n"+istruzioni);
                }
                //una volta eseguite tutte le operazioni necessarie, il programma fa riferimento a questa funzione
                fineprogramma(risposta);
            } while (risposta == "sì" || risposta == "Sì" || risposta == "si" || risposta == "Si");
        }
        //funzione che sceglie gli array, le stringhe e i numeri interi giusti in base al tipo di richiesta dell'utente
        public static void sceltamatrici(int n, int righe, string [,] autofunzione, string indicazionecaratteristicheauto, 
                                         string [] elementivisualizzati, string primascelta, string secondascelta, string sceltainiziale, string[,] Autonuoveinvendita, 
                                         string[,] Autousateinvendita, string [,] Autonuovevendute, string [,] Autousatevendute, string [] elementiautonuoveinvenditavisualizati, 
                                         string [] elementiautousateinvenditavisualizati, string[] elementiautonuovevendutevisualizati, string[] elementiautousatevendutevisualizati,
                                         int righenuoveinvendita, int righeusateinvendita, int righenuovevendute, int righeusatevendute, char carattereDivisore)
        {
            //tutte le funzioni seguenti inseriscono le informazioni di ogni auto in un array generale, che viene usato in ogni funzione del programma
            if ((primascelta == "Vendita" || primascelta == "vendita") & (secondascelta == "Nuova" || secondascelta == "nuova"))
            {
                n = 8; 
                elementivisualizzati = new string[n];
                for (int i = 0; i < n; i++) 
                {
                    elementivisualizzati[i] = elementiautonuoveinvenditavisualizati[i];
                }
                righe = righenuoveinvendita;
                autofunzione = new string[righe, n];
                for (int i = 0; i < righe; i++) 
                {
                    for (int j = 0; j < n; j++)
                    {
                        autofunzione[i, j] = Autonuoveinvendita[i, j];
                    }
                }
                indicazionecaratteristicheauto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore e prezzo. ";
            }
            else if ((primascelta == "Vendita" || primascelta == "vendita") & (secondascelta == "Usata" || secondascelta == "usata"))
            {
                n = 10;
                elementivisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementivisualizzati[i] = elementiautousateinvenditavisualizati[i];
                }
                righe = righeusateinvendita;
                autofunzione = new string[righe, n];
                for (int i = 0; i < righe; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        autofunzione[i, j] = Autousateinvendita[i, j];
                    }
                }
                indicazionecaratteristicheauto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore, numero dei proprietari, chilometri percorsi e prezzo. ";
            }
            else if ((primascelta == "Venduta" || primascelta == "venduta") & (secondascelta == "nuova" || secondascelta == "Nuova"))
            {
                n = 12;
                elementivisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementivisualizzati[i] = elementiautonuovevendutevisualizati[i];
                }
                righe = righenuovevendute;
                autofunzione = new string[righe, n];
                for (int i = 0; i < righe; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        autofunzione[i, j] = Autonuovevendute[i, j];
                    }
                }
                indicazionecaratteristicheauto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore, targa, acquirente, data di acquisto,  " +
                                               "\nprezzo di vendita iniziale e prezzo di vendita finale. ";
            }
            else if ((primascelta == "Venduta" || primascelta == "venduta") & (secondascelta == "usata" || secondascelta == "Usata"))
            {
                n = 14;
                elementivisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementivisualizzati[i] = elementiautousatevendutevisualizati[i];
                }
                righe = righenuovevendute;
                autofunzione = new string[righe, n];
                for (int i = 0; i < righe; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        autofunzione[i, j] = Autousatevendute[i, j];
                    }
                }
                indicazionecaratteristicheauto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore, numero dei proprietari, chilometri percorsi,  " +
                                               "\ntarga, acquirente, data di acquisto, prezzo di vendita iniziale e prezzo di vendita finale. ";
            }
            //da qui in poi prosegue facendo riferimento alla funzione indicata dall'utente
            if (sceltainiziale == "Ricerca" || sceltainiziale == "ricerca")
            {
                //si rivolge alla funzione per eseguire la ricerca vera e propria
                ricercafile(n, righe, elementivisualizzati, autofunzione, indicazionecaratteristicheauto);
            }
            else if (sceltainiziale == "Inserisci" || sceltainiziale == "inserisci")
            {
                string salvataggio = "";
                string[] nuovautomobile = new string[n];
                for (int i = 0; i < n; i++) //chiede le caratteristiche delle auto da inseire
                {
                    Console.WriteLine("\nInserisci {0} dell'auto che vuoi inserire:", elementivisualizzati[i]);
                    nuovautomobile[i] = Convert.ToString(Console.ReadLine());
                    if (i == 0)
                    {
                        nuovautomobile[i] = "\n" + nuovautomobile[i];
                    }
                    else
                    {
                        nuovautomobile[i] = " " + nuovautomobile[i] + " ";
                    }
                }
                Console.WriteLine("\nHai inserito tutte le caratteristiche. Ricontrolla se sono giuste:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write(nuovautomobile[i]);
                }
                Console.WriteLine("\n\nVuoi salvare le modifiche, oppure vuoi reinserire l'auto?");
                salvataggio = Convert.ToString(Console.ReadLine());
                while (salvataggio != "si" & salvataggio != "sì" & salvataggio != "Si" & salvataggio != "Sì" & salvataggio != "no" & salvataggio != "No")
                {
                    Console.WriteLine("\nNon hai inserito la parola chiave giusta. Inserisci di nuovo la tua risposta:");
                    salvataggio = Convert.ToString(Console.ReadLine());
                }
                if (salvataggio == "si" || salvataggio == "sì" || salvataggio == "Si" || salvataggio == "Sì")
                {
                    //si rivolge alla funzione per eseguire l'inserimento vero e proprio
                    inseriscifile(n, righe, elementivisualizzati, autofunzione, nuovautomobile, carattereDivisore, primascelta, secondascelta);
                }
                else if (salvataggio == "no" || salvataggio == "No") //si rivolge direttamente alla funzione fineprogramma
                {
                    Console.WriteLine("\nSe vuoi inserire un'auto con caratteristiche diverse, inserisci sì alla prossima richiesta."); 
                }
            }
            else if (sceltainiziale == "Elimina" || sceltainiziale == "elimina")
            {
                eliminafile();
            }
            else if (sceltainiziale == "Sposta" || sceltainiziale == "sposta")
            {
                spostafile();
            }
        }
        //funzione che permette la ricerca all'interno degli array
        public static void ricercafile( int n, int righe, string [] elementivisualizzati, string [,] autofunzione, string indicazionecaratteristicheauto)
        {
            string[] parametri = new string[11]; //inizializza l'array che conterrà i parametri indicati dall'utente
            int n1 = 0; //inizializzata variabile necessaria per l'algoritmo di ricerca
            if (righe!=0) //esegue il codice seguente se il file presente non è vuoto, cioè senza auto
            {
                for (int i = 0; i < n; i++) //ciclo per l'inserimento dei parametri
                {
                    Console.WriteLine("\nInserisci {0} dell'auto che vuoi cercare:", elementivisualizzati[i]);
                    string parametro = Convert.ToString(Console.ReadLine());
                    if (parametro == "///") //si ferma all'inserimento del parametro "///"
                    {
                        break;
                    }
                    parametri[i] = parametro;
                    if (parametro != "") //se non si salta un filtro, allora conta l'inserimento del parametro
                    {
                        n1++;
                    }

                }
                string[,] autoricercate = new string[righe, n]; //inizializzazione array che conterrà le auto corrispondenti alla ricerca effettuata dall'utente
                int risultati = 0; //necessario per la visualizzazione del numero di risultati trovati
                for (int i = 0; i < righe; i++) //ciclo che svolge l'algoritmo di ricerca
                {
                    int n2 = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (parametri[j] != "") //se l'utente non ha saltato delle richieste, allora esegue le operazioni seguenti
                        {
                            CompareInfo confrontostringhe = CultureInfo.InvariantCulture.CompareInfo; //inizializza la variabile per il confronto delle stringhe, dandone le impostazioni iniziali
                            if (confrontostringhe.Compare(autofunzione[i, j], parametri[j], CompareOptions.IgnoreSymbols) == 0) //esegue il confronto fra le varie caratteristiche per individuare l'auto giusta in base ai filtri di ricerca
                            {
                                n2++;
                                if (n2 == n1)
                                {
                                    risultati++;
                                    for (int k = 0; k < n; k++)
                                    {
                                        autoricercate[i, k] = autofunzione[i, k];
                                    }
                                }
                            }
                        }
                    }
                }
                //mostra i risultati della ricerca
                if (risultati != 0)
                {
                    if (risultati == 1)
                    {
                        Console.WriteLine("\n\nLa ricerca ha prodotto un risultato.\n");
                        Console.WriteLine(indicazionecaratteristicheauto + "\n");
                    }
                    if (risultati > 1)
                    {
                        Console.WriteLine("\n\nLa ricerca ha prodotto {0} risultati.\n", risultati);
                        Console.WriteLine(indicazionecaratteristicheauto + "\n");
                    }
                    for (int i = 0; i < righe; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(autoricercate[i, j]);
                        }
                    }
                }

                else if (risultati == 0)
                {
                    Console.WriteLine("\n\nLa ricerca non ha prodotto alcun risultato...\nProva a ripetere la ricerca con parametri diversi.");
                }
            }
            //nel caso in cui il file sia vuoto, allora visualizza questo messaggio
            else if (righe==0)
            {
                Console.WriteLine("\nERRORE: se hai recentemente creato uno o più file nuovi, non puoi eseguire la ricerca per questo tipo di auto, visto che non ci sono dati."+
                                   "\n        Per far uso di questa funzionalità riavvia il programma e inserisci almeno una nuova automobile.");
            }
            
        }
        //funzione per inserire una nuova auto all'interno di un array e poi di un file
        public static void inseriscifile(int n, int righe, string[] elementivisualizzati, string[,] autofunzione, string[] nuovautomobile, char carattereDivisore, string primascelta, string secondascelta)
        {
            Console.WriteLine("\nSalvataggio in corso. Non chiudere il programma...");
            righe++; //incrementa il numero di righe di uno
            string[] autodainserire = new string[righe]; //inizializza l'array unidimensionale che conterrà le auto che devono essere inserite nel file: è unidimensionale per effettuare un ordinamento più veloce
            CompareInfo confrontostringhe = CultureInfo.InvariantCulture.CompareInfo; //inizializza la variabile per il confronto delle stringhe, dandone le impostazioni iniziali
            for (int i = 0; i < righe; i++) //questo ciclo inserisce le auto già presenti all'interno dell'array coinvolto dall'utente e aggiunge alla fine l'auto nuova appena inserita 
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == righe - 1)
                    {
                        autodainserire[i] = autodainserire[i] + nuovautomobile[j] + carattereDivisore;
                    }
                    else if (righe - 1 != 0) 
                    {
                        autodainserire[i] = autodainserire[i] + autofunzione[i, j] + carattereDivisore;
                    }
                }

            }
            char capo = '\n'; //inizializza il valore del carattere capo, necessario per andare a capo oppure no 
            if (righe - 1 != 0) //solamente se il file non è vuoto esegue l'ordinamento
            {
                for (int i = righe - 1; i > 0; i--)
                {
                    if (confrontostringhe.Compare(autodainserire[i], autodainserire[i - 1], CompareOptions.IgnoreSymbols) <= 0) //esegue il confronto fra le auto
                    {
                        if (i == 1)
                        {
                            string marcasenzacapo = autodainserire[i].TrimStart(capo); //questa istruzione elimina il carattere capo all'inizio della stringa
                            autodainserire[i] = marcasenzacapo + capo; //aggiunge il carattere capo a quell'auto che non lo ha e ne ha bisogno
                        }
                        //parte di ordinamento
                        string temp = "";
                        temp = autodainserire[i];
                        autodainserire[i] = autodainserire[i - 1];
                        autodainserire[i - 1] = temp;

                    }
                }
            }
            else if (righe - 1 == 0) //se il file è vuoto allora inserisce la macchina appena inserita, che è la prima, direttamente, senza procedere all'ordinamento
            {
                string marcasenzacapo = autodainserire[0].TrimStart(capo);
                autodainserire[0] = marcasenzacapo;
            }
            autodainserire[righe - 1] = autodainserire[righe - 1].TrimEnd(carattereDivisore); //elimina alla fine dall'ultima caratteristica dell'ultima auto dell'elenco il carattere divisore (':'), necessario per dividere le caratteristiche quando si apre il programma
            string autodasalvare = ""; //inizializza la stringa dove inserire le auto da salvare
            autodasalvare = autodasalvare + righe + carattereDivisore; //come prima informazione inserisce nella stringa appena creata il numero di righe, necessarie durante la lettura del file a inizio programma
            for (int i = 0; i < righe; i++) //inserisce successivamente tutte le auto
            {
                autodasalvare = autodasalvare + autodainserire[i];
            }
            string rispostaeccezioni = ""; //inizializza la variabile necessaria per la risposta dell'utente in caso di eccezioni
            int n1 = 0;  //inizializza la variabile necessaria per i tentativi in caso di errore durante la scrittura
            do //inizia il ciclo di controllo
            {
                try //prova ad eseguire le operazioni seguenti
                {
                    if (primascelta == "vendita" || primascelta == "Vendita" || primascelta == "vendite" || primascelta == "Vendite")
                    {
                        if (secondascelta == "nuova" || secondascelta == "Nuova" || secondascelta == "nuove" || secondascelta == "Nuove")
                        {
                            //crea oppure sovrascrive il file che contiene le auto nuove in vendita
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt", autodasalvare);
                        }
                        else if (secondascelta == "usata" || secondascelta == "Usata" || secondascelta == "usate" || secondascelta == "Usate")
                        {
                            //crea oppure sovrascrive il file che contiene le auto usate in vendita
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt", autodasalvare);
                        }
                    }
                    else if (primascelta == "venduta" || primascelta == "Venduta" || primascelta == "vendute" || primascelta == "Vendute")
                    {
                        if (secondascelta == "nuova" || secondascelta == "Nuova" || secondascelta == "nuove" || secondascelta == "Nuove")
                        {
                            //crea oppure sovrascrive il file che contiene le auto nuove vendute
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt", autodasalvare);
                        }
                        else if (secondascelta == "usata" || secondascelta == "Usata" || secondascelta == "usate" || secondascelta == "Usate")
                        {
                            //crea oppure sovrascrive il file che contiene le auto usate vendute
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt", autodasalvare);
                        }
                    }
                }
                catch (DirectoryNotFoundException) //se non trova la cartella svolge le seguenti operazioni
                {
                    Console.WriteLine("\nERRORE: la cartella che dovrebbe contenere i file di salvataggio non è stata trovata. Vuoi crearne una nuova?");
                    rispostaeccezioni = Convert.ToString(Console.ReadLine());
                    if (rispostaeccezioni == "si" || rispostaeccezioni == "Si" || rispostaeccezioni == "sì" || rispostaeccezioni == "Sì")
                    {
                        Directory.CreateDirectory(@"C:\Programma gestionale concessionaria"); //crea la cartella
                        Console.WriteLine("\nCartella creata con successo.");
                    }
                    else if (rispostaeccezioni == "no" || rispostaeccezioni == "No")
                    {
                        Console.WriteLine("Chiusura del programma in corso...");
                        Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                        Environment.Exit(0);//esce automaticamente dal programma
                    }
                }
                catch(IOException) //se si verifica un errore nella scrittura svolge le seguenti operazioni
                {
                    Console.WriteLine("\nERRORE: si è verificato un errore durante la scrittura del file. Nuovo tentativo di scrittura...");
                    n1++;
                    rispostaeccezioni = "si";
                    if (n1 == 3) 
                    {
                        Console.WriteLine("\nERRORE: dopo tre tentativi si è verificato ancora un errore durante la scrittura del file. " +
                                          "\nProva a riavviare il programma e, se il problema persiste, riavvia il sistema operativo."
                                          +"\nPremi un tasto qualsiasi per uscire dal programma...");
                        Console.ReadKey();
                        Environment.Exit(0);//esce automaticamente dal programma
                    }
                }
            }
            //se si risolvono delle eccezioni, allora prova a eseguire di nuovo il salvataggio
            while (rispostaeccezioni == "si" || rispostaeccezioni == "Si" || rispostaeccezioni == "sì" || rispostaeccezioni == "Sì");
            Task.Delay(1500).Wait(); //attende 1,5 secondi
            Console.WriteLine("\nSalvataggio completato con successo.");
            Task.Delay(1000).Wait(); //attende un secondo
        }
        //funzione per eliminare le auto da un array **da completare
        public static void eliminafile()
        {

        }
        //funzione per spostare le auto da un array a un altro **da completare
        public static void spostafile()
        {

        }
        //funzione eseguita al termine di tutte le operazioni e richiamata dal main
        static void fineprogramma(string risposta) 
        {
            Console.WriteLine("\n\nVuoi eseguire ulteriori operazioni all'interno del programma?");
            risposta = Convert.ToString(Console.ReadLine());
            //questo ciclo while esegue un controllo preventivo nel caso in cui si inseriscano delle parole chiave non accettabili
            while(risposta!="sì" & risposta != "Sì" & risposta != "si" & risposta != "Si" & risposta != "no" & risposta != "No" )
            {
                Console.WriteLine("\n\nNon hai inserito una parola chiave accettabile. Inserisci di nuovo la tua risposta:");
                risposta = Convert.ToString(Console.ReadLine());
            }
            if (risposta == "sì" || risposta == "Sì" || risposta == "si" || risposta == "Si") //se l'utente risponde sì, allora fa ritornare il programma allo stato iniziale
            {
                Console.WriteLine("\nRiavvio del programma per eseguire ulteriori operazioni in corso...");
                Task.Delay(1800).Wait();//attende 1,8 secondi per permettere all'utente di accorgersi del riavvio
            }
            else if (risposta == "no" || risposta == "No") //se l'utente dice di no, allora chiude il programma
            {
                Console.WriteLine("\nChiusura del programma in corso...");
                Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                Environment.Exit(0); //esce automaticamente dal programma
            }

        }
            
    }
}
