//Autori: Diego Albertin, Francesco Di Lena, Alessio Donini, Alex Niccolò Ferrari
//Classe: 3F
//Data di realizzazione: dicembre 2020 - gennaio/febbraio 2021
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
                string autousateinvendita = "0:::::::::::::"; //inizializza la stringa che conterrà tutti i dati del file delle auto usate in vendita
                string autonuovevendute = "0:::::::::::::"; //inizializza la stringa che conterrà tutti i dati del file delle auto nuove vendute
                string autousatevendute = "0::::::::::::::";//inizializza la stringa che conterrà tutti i dati del file delle auto usate vendute
                string istruzioni = ""; //inizializza la stringa che conterrà le istruzioni del programma
                Console.Clear(); //pulisce il contenuto della console 
                //alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n                                        Concessionaria Automotors S.N.C., Via A. De Gasperi, 21, Rovigo (RO), 45100                                                 ");
                Console.ResetColor(); //i colori vengono riportati a quelli standard (nero e grigio)
                Console.WriteLine("\n                Benvenuto nel programma. Puoi eseguire una ricerca delle auto presenti nel parco auto aziendale, aggiungerne di nuove al database," +
                                    "\n               spostarle da vendute a in vendita e viceversa, oppure eliminarle. Nel caso in cui avessi bisogno di aiuto inserisci la parola Aiuto. ");
                //alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                string datadioggi = DateTime.Now.ToString("dd/MM/yyyy");//viene acquisita la data odierna
                Console.WriteLine("\n                                                                    Oggi è il: {0}                                                                           ", datadioggi);
                Console.ResetColor(); //i colori vengono riportati a quelli standard (nero e grigio)
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
                string[,] Autousateinvendita = new string[righeusateinvendita, 11]; // si inizializza l'array multidimensionale per contenere le auto usate in vendita
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
                    for (int j = 0; j < 11; j++)
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
                string[] elementiautousateinvenditavisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "numero di proprietari (nel formato N proprietari in lettere)", "chilometri percorsi ( nel formato XX.XXX km )", "targa (nel formato maiuscolo)", "prezzo (nel formato XX.XXX euro)" };
                string[] elementiautonuovevendutevisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "targa (nel formato maiuscolo)", "acquirente", "data di acquisto", "prezzo di vendita iniziale (nel formato XX.XXX euro)", "prezzo di vendita finale (nel formato XX.XXX euro)" };
                string[] elementiautousatevendutevisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "numero di proprietari (nel formato N proprietari in lettere)", "chilometri percorsi ( nel formato XX.XXX km )", "targa (nel formato maiuscolo)", "acquirente", "data di acquisto (nel formato GG/MM/AAAA)", "prezzo di vendita iniziale (nel formato XX.XXX euro)", "prezzo di vendita finale (nel formato XX.XXX euro)" };

                //qui viene eseguito un ciclo preventivo per individuare eventuali errori di inserimento
                while (sceltainiziale != "ricerca" & sceltainiziale != "Ricerca" & sceltainiziale != "inserisci" & sceltainiziale != "Inserisci" &
                       sceltainiziale != "sposta" & sceltainiziale != "Sposta" & sceltainiziale != "elimina" & sceltainiziale != "Elimina" &
                       sceltainiziale != "aiuto" & sceltainiziale != "Aiuto" & sceltainiziale != "help" & sceltainiziale != "Help" & sceltainiziale != "?" &
                       sceltainiziale != "tutte" & sceltainiziale != "Tutte")
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
                            secondascelta != "usate" & secondascelta != "Usate" & secondascelta != "nuove" & secondascelta != "Nuove" &
                            secondascelta != "Tutte" & secondascelta != "tutte")
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
                                for (int j = 0; j < 11; j++)
                                {
                                    Console.Write(Autousateinvendita[i, j]);
                                }
                            }


                        }
                        //se l'utente vuole visualizzare tutte le auto vendute, allora vengono eseguite queste operazioni
                        else if (primascelta == "Venduta" || primascelta == "venduta" || primascelta == "vendute" || primascelta == "Vendute")
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
                                        elementiautousatevendutevisualizati, righenuoveinvendita, righeusateinvendita, righenuovevendute, righeusatevendute, carattereDivisore, risposta);
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
                                 elementiautousatevendutevisualizati, righenuoveinvendita, righeusateinvendita, righenuovevendute, righeusatevendute, carattereDivisore, risposta);
                }
                //se l'utente chiede di visualizzare le istruzioni del programma, esegue le seguenti operazioni **da completare
                else if (sceltainiziale == "aiuto" || sceltainiziale == "Aiuto" || sceltainiziale == "help" || sceltainiziale == "Help" || sceltainiziale == "?")
                {
                    try //il programma prova ad eseguire le seguenti operazioni
                    {
                        //acquisice dal file presente sul disco le istruzioni del programma
                        istruzioni = File.ReadAllText(@"C:\Programma gestionale concessionaria\aiuto.txt");
                        Console.WriteLine("\n\n" + istruzioni);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene le istruzioni del programma non è stato trovato. " +
                                          "\n\nProva a riavviare il programma inserendo sì alla prossima richiesta e, se il problema persiste, vai a questa pagina web:" +
                                          "\n\nhttps://www.gruppo-1-informatica-albertin-di lena-donini-ferrari.iisviolamarchesini.edu.it/" +
                                          "\n\nOppure invia un e-mail a:" +
                                          "\n\ngruppoinformatica1@iisviolamarchesini.edu.it" +
                                          "\n\nPer uscire dal programma inserisci no alla prossima richiesta.");
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("\n\nERRORE: si è verificato un errore durante la lettura delle istruzioni." +
                                          "\n\nProva a riavviare il programma inserendo sì alla prossima richiesta e, se il problema persiste, vai a questa pagina web:" +
                                          "\n\nhttps://www.gruppo-1-informatica-albertin-di lena-donini-ferrari.iisviolamarchesini.edu.it/" +
                                          "\n\nOppure invia un e-mail a:" +
                                          "\n\ngruppoinformatica1@iisviolamarchesini.edu.it" +
                                          "\n\nPer uscire dal programma inserisci no alla prossima richiesta.");
                    }
                }
                //una volta eseguite tutte le operazioni necessarie, il programma fa riferimento a questa funzione
                fineprogramma(risposta);
            } while (risposta == "sì" || risposta == "Sì" || risposta == "si" || risposta == "Si");
        }
        //funzione che sceglie gli array, le stringhe e i numeri interi giusti in base al tipo di richiesta dell'utente
        public static void sceltamatrici(int n, int righe, string[,] autofunzione, string indicazionecaratteristicheauto,
                                         string[] elementivisualizzati, string primascelta, string secondascelta, string sceltainiziale, string[,] Autonuoveinvendita,
                                         string[,] Autousateinvendita, string[,] Autonuovevendute, string[,] Autousatevendute, string[] elementiautonuoveinvenditavisualizati,
                                         string[] elementiautousateinvenditavisualizati, string[] elementiautonuovevendutevisualizati, string[] elementiautousatevendutevisualizati,
                                         int righenuoveinvendita, int righeusateinvendita, int righenuovevendute, int righeusatevendute, char carattereDivisore, string risposta)
        {
            //tutte le funzioni seguenti inseriscono le informazioni di ogni auto in un array generale, che viene usato in ogni funzione del programma
            //primo caso: le scelte sono vendita e nuova
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
            //secondo caso: le scelte sono vendita e usata
            else if ((primascelta == "Vendita" || primascelta == "vendita") & (secondascelta == "Usata" || secondascelta == "usata"))
            {
                n = 11;
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
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore, numero dei proprietari, chilometri percorsi, targa e prezzo. ";
            }
            //terzo caso: le scelte sono venduta e nuova
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
            //quarto caso: le scelte sono venduta e usata
            else if ((primascelta == "Venduta" || primascelta == "venduta") & (secondascelta == "usata" || secondascelta == "Usata"))
            {
                n = 14;
                elementivisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementivisualizzati[i] = elementiautousatevendutevisualizati[i];
                }
                righe = righeusatevendute;
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
            int[] posizioniauto = new int[righe]; //viene inizializzato l'array necessario per contenere la riga del 
            int risultati = 0;
            //da qui in poi prosegue facendo riferimento alla funzione indicata dall'utente
            if (sceltainiziale == "Ricerca" || sceltainiziale == "ricerca" || sceltainiziale == "Elimina" || sceltainiziale == "elimina")
            {
                //si rivolge alla funzione per eseguire la ricerca vera e propria oppure l'eliminazione 
                ricercafile(n, righe, elementivisualizzati, autofunzione, indicazionecaratteristicheauto, sceltainiziale, primascelta, secondascelta, posizioniauto, risultati, carattereDivisore, risposta);
            }
            else if (sceltainiziale == "Inserisci" || sceltainiziale == "inserisci")
            {
                string salvataggio = "";
                string[] nuovautomobile = new string[n];
                for (int i = 0; i < n; i++) //chiede le caratteristiche delle auto da inseire
                {
                    Console.WriteLine("\nInserisci {0} dell'auto che vuoi inserire:", elementivisualizzati[i]);
                    nuovautomobile[i] = Convert.ToString(Console.ReadLine());
                    while (nuovautomobile[i] == "") //esegue un controllo preventivo per evitare che i campi vengano lasciati vuoti
                    {
                        Console.WriteLine("\nNon puoi lasciare vuoto un campo di inserimento. Inserisci {0} dell'auto che vuoi inserire:", elementivisualizzati[i]);
                        nuovautomobile[i] = Convert.ToString(Console.ReadLine());
                    }
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
                    Console.BackgroundColor = ConsoleColor.DarkBlue; //rende lo sfondo della riga blu, in modo che l'utente possa leggerlo meglio
                    Console.ForegroundColor = ConsoleColor.White; //rende i caratteri bianchi, in modo che l'utente possa leggerli meglio
                    Console.Write(nuovautomobile[i]); //visualizza l'auto da inserire
                    Console.ResetColor(); //riporta i colori alle condizioni standard (nero e grigio)
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
                //se la scelta è no, allora ritorna al main, il quale si rivolge alla funzione fineprogramma
            }
            else if (sceltainiziale == "Sposta" || sceltainiziale == "sposta")
            {
                spostafile();
            }
        }
        //funzione che permette la ricerca all'interno degli array
        public static void ricercafile(int n, int righe, string[] elementivisualizzati, string[,] autofunzione, string indicazionecaratteristicheauto, string sceltainiziale,
                                        string primascelta, string secondascelta, int[] posizioniauto, int risultati, char carattereDivisore, string risposta)
        {
            string[] parametri = new string[14]; //inizializza l'array che conterrà i parametri indicati dall'utente
            int n1 = 0; //inizializzata variabile necessaria per l'algoritmo di ricerca
            if (righe != 0) //esegue il codice seguente se il file presente non è vuoto, cioè senza auto
            {
                for (int i = 0; i < n; i++) //ciclo per l'inserimento dei parametri
                {
                    if (sceltainiziale == "ricerca" || sceltainiziale == "Ricerca")
                    {
                        Console.WriteLine("\nInserisci {0} dell'auto che vuoi cercare:", elementivisualizzati[i]);
                    }
                    else if (sceltainiziale == "elimina" || sceltainiziale == "Elimina")
                    {
                        Console.WriteLine("\nInserisci {0} dell'auto che vuoi eliminare:", elementivisualizzati[i]);
                    }
                    string parametro = Convert.ToString(Console.ReadLine());
                    if (parametro == "///") //si ferma all'inserimento del parametro "///"
                    {
                        if (i == 0)
                        {
                            n1 = n;
                        }
                        break;
                    }
                    else if (parametro == "esci" || parametro == "Esci")
                    {
                        fineprogramma(risposta);
                    }
                    parametri[i] = parametro;
                    if (parametro != "") //se non si salta un filtro, allora conta l'inserimento del parametro
                    {
                        n1++;
                    }

                }
                string[,] autoricercate = new string[righe, n + 1]; //inizializzazione array che conterrà le auto corrispondenti alla ricerca effettuata dall'utente
                risultati = 0; //necessario per la visualizzazione del numero di risultati trovati
                int n2 = 1;
                for (int i = 0; i < righe; i++) //ciclo che svolge l'algoritmo di ricerca
                {
                    int n3 = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (parametri[j] != "") //se l'utente non ha saltato delle richieste, allora esegue le operazioni seguenti
                        {
                            CompareInfo confrontostringhe = CultureInfo.InvariantCulture.CompareInfo; //inizializza la variabile per il confronto delle stringhe, dandone le impostazioni iniziali
                            if (confrontostringhe.Compare(autofunzione[i, j], parametri[j], CompareOptions.IgnoreSymbols) == 0) //esegue il confronto fra le varie caratteristiche per individuare l'auto giusta in base ai filtri di ricerca
                            {
                                n3++;
                                if (n3 == n1)
                                {
                                    risultati++;
                                    posizioniauto[n2 - 1] = i;
                                    for (int k = 0; k < n; k++)
                                    {
                                        if (k == 0)
                                        {
                                            autoricercate[i, 0] = "\n" + n2 + ".";
                                            n2++;
                                        }
                                        autoricercate[i, k + 1] = autofunzione[i, k];
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
                        //alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\nLa ricerca ha prodotto un risultato.                                                                                                                                 \n");
                        Console.ResetColor();//i colori vengono riportati a quelli standard (nero e grigio)
                        Console.WriteLine(indicazionecaratteristicheauto + "\n");

                    }
                    if (risultati > 1)
                    {
                        //alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\nLa ricerca ha prodotto {0} risultati.                                                                                                                                 \n", risultati);
                        Console.ResetColor();//i colori vengono riportati a quelli standard (nero e grigio)
                        Console.WriteLine(indicazionecaratteristicheauto + "\n");
                    }
                    for (int i = 0; i < righe; i++)
                    {
                        for (int j = 0; j < n + 1; j++)
                        {
                            if (j == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow; //i numeri diventano color giallo scuro, in modo che l'utente possa distinguerla meglio
                            }
                            Console.Write(autoricercate[i, j]);
                            Console.ResetColor(); //i caratteri vengono riportati al colore standard (grigio)
                        }
                    }

                }

                else if (risultati == 0)
                {
                    //alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nLa ricerca non ha prodotto alcun risultato...                                                                                                                        ");
                    Console.ResetColor();
                    Console.WriteLine("\nProva a ripetere la ricerca con parametri diversi.");
                }
            }
            //nel caso in cui il file sia vuoto, allora visualizza questo messaggio
            else if (righe == 0)
            {
                Console.WriteLine("\nERRORE: se hai recentemente creato uno o più file nuovi, non puoi eseguire le operazioni di ricerca, eliminazione e spostamento" +
                                  "\nper questo tipo di auto, visto che non ci sono dati. Per far uso di queste funzionalità riavvia il programma e inserisci almeno una nuova automobile.");
            }
            if ((sceltainiziale == "elimina" || sceltainiziale == "Elimina") & (righe != 0 & risultati != 0))
            {
                eliminafile(primascelta, secondascelta, n, righe, risultati, autofunzione, posizioniauto, carattereDivisore);
            }

        }
        //funzione per inserire una nuova auto all'interno di un array e poi di un file
        public static void inseriscifile(int n, int righe, string[] elementivisualizzati, string[,] autofunzione, string[] nuovautomobile, char carattereDivisore, string primascelta, string secondascelta)
        {
            Console.WriteLine("\nSalvataggio delle modifiche in corso. Non chiudere il programma...");
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
            salvataggio(primascelta, secondascelta, autodasalvare);
        }
        //funzione per eliminare le auto da un array 
        public static void eliminafile(string primascelta, string secondascelta, int n, int righe, int risultati, string[,] autofunzione, int[] posizioniauto, char carattereDivisore)
        {
            Console.WriteLine("\n\nInserisci il numero dell'auto che vuoi eliminare:");
            bool verificarispostacorretta = false; //viene assegnato alla variabile booleana verificarispostacorretta il valore false
            verificarispostacorretta = int.TryParse(Console.ReadLine(), out int risposta); /* prova ad assegnare alla varibile risposta il valore inserito dall'utente: 
                                                                                            se ci sono errori verificarispostacorretta assume il valore false e richiede 
                                                                                            nuovamente l'inserimento, altrimenti assume il valore true e inserisce il valore
                                                                                            digitato da tastiera all'interno della variabile risposta*/

            while (risposta > risultati || risposta == 0 || verificarispostacorretta == false) /*esegue un controllo per rilevare gli errori dovuti all'inserimento di un numero maggiore
                                                                                                 rispetto a quelli forniti, uguale a zero, oppure nel caso in cui la conversione non sia
                                                                                                 riuscita e verificarispostacorretta assume il valore false*/
            {
                Console.WriteLine("\nIl parametro inserito è maggiore rispetto a quelli forniti o uguale a zero, oppure non hai inserito un numero." +
                                    "\nInserisci di nuovo la tua risposta:");
                verificarispostacorretta = int.TryParse(Console.ReadLine(), out risposta); //prova di nuovo ad eseguire l'inserimento
            }
            risposta--; //risposta viene diminuito di uno per poter identificare nell'array la riga corretta dell'auto che deve essere eliminata
            Console.WriteLine("\nL'auto che hai scelto è la seguente:");
            for (int i = 0; i < n; i++) //viene mostrata di nuovo l'auto scelta dall'utente
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue; //lo sfondo diventa blu, in modo che l'utente possa distinguerla meglio
                Console.ForegroundColor = ConsoleColor.White;//i caratteri diventano bianchi, in modo che l'utente possa distinguerla meglio
                Console.Write(autofunzione[posizioniauto[risposta], i]); //viene scritta sulla console, sulla stessa riga, una caratteristica alla volta
                Console.ResetColor(); //lo sfondo e i caratteri vengono riportati al colore standard (nero e grigio)
            }
            Console.WriteLine("\n\nSei sicuro di voler eliminare quest'auto?");
            string risposta2 = Convert.ToString(Console.ReadLine()); //viene assegnata la variabile che contiene la risposta dell'utente
            //esegue un controllo preventivo per rilevare eventuali errori di inserimento
            while (risposta2 != "Sì" & risposta2 != "sì" & risposta2 != "Si" & risposta2 != "si" & risposta2 != "No" & risposta2 != "no")
            {
                Console.WriteLine("\nNon hai inserito un valore accettabile. Inserisci di nuovo la tua risposta:");
                risposta2 = Convert.ToString(Console.ReadLine());
            }
            //se la risposta è sì, allora inizia il salvataggio delle modifiche
            if (risposta2 == "Sì" || risposta2 == "sì" || risposta2 == "Si" || risposta2 == "si")
            {
                Console.WriteLine("\nSalvataggio delle modifiche in corso. Non chiudere il programma...");
                string autodasalvare = ""; //viene inizializzata la stringa dove vengono inserite le informazioni da scrivere su file
                for (int i = 0; i < righe; i++) //ciclo per inserire le informazioni delle auto in autodasalvare
                {
                    if ((i != posizioniauto[risposta]) || righe - 1 == 0) /*se non si fa riferimento all'auto da eliminare oppure se una volta cancellata un'auto non 
                                                                            ne rimangono altre, esegue le seguenti operazioni*/
                    {
                        if (i == 0) //se i è uguale a 0, allora inserisce subito il numero di righe
                        {
                            autodasalvare = autodasalvare + (righe - 1) + carattereDivisore;
                        }
                        for (int j = 0; j < n; j++) //subito dopo comincia a inserire le varie caratteristiche delle auto, colonna per colonna
                        {
                            if (righe - 1 == 0) //se una volta cancellata un'auto non ne rimangono altre, inserisce solo il carattere divisore
                            {
                                autodasalvare = autodasalvare + carattereDivisore;
                            }
                            else if (i == righe - 1 & j == n - 1) //se ci si trova all'ultima riga e colonna, allora non inserisce alla fine il carattere divisore
                            {
                                autodasalvare = autodasalvare + autofunzione[i, j];
                            }
                            else //in qualsiasi altro caso inserisce l'auto dall'array autofunzione e il carattere divisore
                            {
                                autodasalvare = autodasalvare + autofunzione[i, j] + carattereDivisore;
                            }

                        }
                    }

                }
                salvataggio(primascelta, secondascelta, autodasalvare); // fa riferimento alla funzione salvataggio per passare al salvataggio vero e proprio
            }
            //nel caso in cui la risposta sia no, allora ritorna al main, il quale fa poi riferimento alla funzione fineprogramma
        }
        //funzione per spostare le auto da un array a un altro **da completare
        public static void spostafile()
        {

        }
        //funzione di salvataggio delle modifiche usata dopo le funzioni di inserimento, eliminazione e spostamento
        public static void salvataggio(string primascelta, string secondascelta, string autodasalvare)
        {
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
                catch (IOException) //se si verifica un errore nella scrittura svolge le seguenti operazioni
                {
                    Console.WriteLine("\nERRORE: si è verificato un errore durante la scrittura del file. Nuovo tentativo di scrittura...");
                    n1++;
                    rispostaeccezioni = "si";
                    if (n1 == 3)
                    {
                        Console.WriteLine("\nERRORE: dopo tre tentativi di scrittura si è verificato un errore durante la scrittura del file. " +
                                          "\nProva a riavviare il programma e, se il problema persiste, riavvia il sistema operativo."
                                          + "\nPremi un tasto qualsiasi per uscire dal programma...");
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
        //funzione eseguita al termine di tutte le operazioni e richiamata dal main
        static void fineprogramma(string risposta)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue; //lo sfondo diventa blu, in modo che l'utente possa distinguerla meglio
            Console.ForegroundColor = ConsoleColor.White;//i caratteri diventano bianchi, in modo che l'utente possa distinguerla meglio
            Console.WriteLine("\n\n\nVuoi eseguire ulteriori operazioni all'interno del programma?                                                                                                       ");
            Console.ResetColor(); //riporta i colori alle condizioni standard (nero e grigio)
            risposta = Convert.ToString(Console.ReadLine());
            //questo ciclo while esegue un controllo preventivo nel caso in cui si inseriscano delle parole chiave non accettabili
            while (risposta != "sì" & risposta != "Sì" & risposta != "si" & risposta != "Si" & risposta != "no" & risposta != "No")
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
        //termine del programma 

    }
}