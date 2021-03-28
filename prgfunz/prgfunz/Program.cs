//Autori: Diego Albertin, Francesco Di Lena, Alessio Donini, Alex Niccolò Ferrari
//Classe: 3F
//Data di realizzazione: dicembre 2020 - gennaio/febbraio/marzo 2021
//Progetto collaborativo di informatica e TPSIT per la creazione di un software per la gestione di una concessionaria.
//Per ulteriori informazioni vedere la relazione.

using System;
using System.IO; //Necessario per le operazioni di input e output nei file.
using System.Globalization; //Necessario per eseguire il confronto fra stringhe.
using System.Threading.Tasks; //Necessario per posticipare varie istruzioni.

namespace prgfunz
{
    class Program
    {
        //Inizializzazione delle variabili che conterranno il numero di automobili (quindi le righe delle matrici) in base al tipo (in vendita nuove, in vendita usate, vendute nuove, vendute usate)
        static int righeNuoveInVendita = 0;
        static int righeUsateInVendita = 0;
        static int righeNuoveVendute = 0;
        static int righeUsateVendute = 0;
        //Inizializzazione di tutti i vettori necessari per contenere le auto in base al tipo.
        static string[,] Autonuoveinvendita;
        static string[,] Autousateinvendita;
        static string[,] Autonuovevendute;
        static string[,] Autousatevendute;
        //Inizializzazione e assegnazione degli elementi da visualizzare durante l'esecuzione delle diverse funzioni, sempre in base al tipo di automobile considerata.
        static string[] elementiAutoNuoveInVenditaVisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "prezzo (nel formato XX.XXX euro)" };
        static string[] elementiAutoUsateInVenditaVisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "targa (nel formato maiuscolo)", "numero di proprietari (nel formato N proprietari in lettere)", "chilometri percorsi ( nel formato XX.XXX km )", "prezzo (nel formato XX.XXX euro)" };
        static string[] elementiAutoNuoveVenduteVisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "targa (nel formato maiuscolo)", "acquirente", "data di acquisto (nel formato GG/MM/AAAA)", "prezzo di vendita iniziale (nel formato XX.XXX euro)", "prezzo di vendita finale (nel formato XX.XXX euro)" };
        static string[] elementiAutoUsateVenduteVisualizati = new string[] { "marca", "modello", "alimentazione", "cilindrata (nel formato X.XXX cm3)", "potenza (nel formato XXX CV/XXX kW)", "anno di produzione", "colore", "targa (nel formato maiuscolo)", "numero di proprietari (nel formato N proprietari in lettere)", "chilometri percorsi ( nel formato XX.XXX km )", "acquirente", "data di acquisto (nel formato GG/MM/AAAA)", "prezzo di vendita iniziale (nel formato XX.XXX euro)", "prezzo di vendita finale (nel formato XX.XXX euro)" };
        static string[] elementiVisualizzati = new string[0]; //Verrà usata per contenere gli elementi da mostrare durante l'inserimento delle caratteristiche delle auto.
        static string[,] autoFunzione = new string[0, 0]; /*Verrà usata per contenere le auto in base alle scelte fatte (ad esempio se si indica "auto-in vendita-nuova" 
                                                             inserisce in questo array le auto nuove in vendita).*/
        static string indicazioneCaratteristicheAuto = ""; //Verrà usata per indicare le caratteristiche che verranno visualizzate una volta terminata una funzione.
        static int n = 0; //Indica generalemente il numero di colonne di array bidimensionali che contengono le auto.
        static int righe = 0;//Indica il numero di righe di array bidimensionali che contengono le auto.
        static char carattereDivisore = ':'; //Inizializza la variabile carattere che contiene l'elemento divisore del file.
        //vengono inizializzate tutte le variabili e gli array che servono nella funzione main, insieme alle altre
        static string sceltaIniziale = "";  //Questa è la scelta indicata dall'utente inizialmente, per poter accedere alle varie funzioni del programma.
        static string primaScelta = "";//Questa è la scelta indicata dall'utente fra auto in vendita e vendute.
        static string secondaScelta = "";//Questa è la scelta indicata dall'utente fra auto nuove e usate.
        static string primaScelta2 = ""; //Variabile necessaria nella funzione di spostamento (SpostaFile), che conterrà la "seconda" prima scelta fra auto in vendita e non.
        static string secondaScelta2 = ""; //Variabile necessaria nella funzione di spostamento (SpostaFile), che conterrà la "seconda" seconda scelta fra auto nuove e usate.
        //Inizializzazione di variabili booleane necessarie per effettuare verifiche all'interno del programma.
        static bool verifica = true;
        static bool verifica2 = true;
        static char capo = '\n'; //Inizializza il valore del carattere capo, necessario per andare a capo oppure no.
        //Funzione principale di acquisizione del contenuto del file e richieste iniziali.
        public static void Main(string[] args)
        {
            Console.SetWindowSize(170, 40); //Imposta le dimensioni della finestra del programma.
            string risposta = "SI";//Inizializza e assegna il valore "sì" alla variabile risposta, che servirà quando il programma chiede se continuare con le operazioni oppure no.
            do
            {
                sceltaIniziale = "";
                primaScelta = "";
                secondaScelta = "";
                secondaScelta2 = "";
                string autonuoveinvendita = "0:::::::::"; //Inizializza la stringa che conterrà tutti i dati del file delle auto nuove in vendita.
                string autousateinvendita = "0:::::::::::::"; //Inizializza la stringa che conterrà tutti i dati del file delle auto usate in vendita.
                string autonuovevendute = "0:::::::::::::"; //Inizializza la stringa che conterrà tutti i dati del file delle auto nuove vendute.
                string autousatevendute = "0::::::::::::::";//inizializza la stringa che conterrà tutti i dati del file delle auto usate vendute.
                string istruzioni = ""; //Inizializza la stringa che conterrà le istruzioni del programma.
                Console.Clear(); //Pulisce il contenuto della console. 
                //Alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco.
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n                                        Concessionaria Automotors S.N.C., Via A. De Gasperi, 21, Rovigo (RO), 45100                                                 ");
                Console.ResetColor(); //I colori vengono riportati a quelli standard (nero e grigio).
                Console.WriteLine("\n                Benvenuto nel programma. Puoi eseguire una ricerca delle auto presenti nel parco auto aziendale, aggiungerne di nuove al database," +
                                    "\n               spostarle da vendute a in vendita e viceversa, oppure eliminarle. Nel caso in cui avessi bisogno di aiuto inserisci la parola Aiuto. ");
                //Alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco.
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                string dataDiOggi = DateTime.Now.ToString("dd/MM/yyyy");//Viene acquisita la data odierna.
                Console.WriteLine("\n                                                                    Oggi è il: {0}                                                                           ", dataDiOggi);
                Console.ResetColor(); //I colori vengono riportati a quelli standard (nero e grigio).
                try //Il programma prova ad acquisire il contenuto dei file.
                {
                    try //Il programma prova ad eseguire le seguenti operazioni.
                    {
                        //Acquisisce dal file presente sul disco le auto nuove in vendita.
                        autonuoveinvendita = File.ReadAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt");

                    }
                    catch (FileNotFoundException) //Se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti.
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto nuove in vendita non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine()).ToUpper();
                        if (rispostaeccezioni == "SI" || rispostaeccezioni== "SÌ")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt", autonuoveinvendita); //Crea il nuovo file che conterrà le auto nuove in vendita.
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "NO")
                        {
                            Console.WriteLine("\nChiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //Attende 1,8 secondi per permettere all'utente di accorgersi della chiusura.
                            Environment.Exit(0); //Esce automaticamente dal programma.
                        }
                    }
                    try //Il programma prova ad eseguire le seguenti operazioni.
                    {
                        //Acquisisce dal file presente sul disco le auto usate in vendita.
                        autousateinvendita = File.ReadAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt");
                    }
                    catch (FileNotFoundException)//Se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti.
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto usate in vendita non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine()).ToUpper();
                        if (rispostaeccezioni == "SI" || rispostaeccezioni == "SÌ")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt", autousateinvendita);//Crea il nuovo file che conterrà le auto usate in vendita.
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "NO")
                        {
                            Console.WriteLine("\nChiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //Attende 1,8 secondi per permettere all'utente di accorgersi della chiusura.
                            Environment.Exit(0); //Esce automaticamente dal programma.
                        }
                    }
                    try //Il programma prova ad eseguire le seguenti operazioni.
                    {
                        //Acquisisce dal file presente sul disco le auto nuove già vendute.
                        autonuovevendute = File.ReadAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt");
                    }
                    catch (FileNotFoundException)//Se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti.
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto nuove vendute non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine()).ToUpper();
                        if (rispostaeccezioni == "SI" || rispostaeccezioni == "SÌ")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt", autonuovevendute);//Crea il nuovo file che conterrà le auto nuove vendute.
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "NO")
                        {
                            Console.WriteLine("\nChiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //Attende 1,8 secondi per permettere all'utente di accorgersi della chiusura.
                            Environment.Exit(0);//Esce automaticamente dal programma.
                        }
                    }
                    try //Il programma prova ad eseguire le seguenti operazioni.
                    {
                        //Acquisisce dal file presente sul disco le auto usate già vendute.
                        autousatevendute = File.ReadAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt");
                    }
                    catch (FileNotFoundException)//Se si verifica questo errore, cioè il file non è stato trovato, esegue le operazioni seguenti.
                    {
                        Console.WriteLine("\n\nERRORE: il file che contiene auto usate vendute non è stato trovato. Vuoi crearne uno nuovo?");
                        string rispostaeccezioni = Convert.ToString(Console.ReadLine()).ToUpper();
                        if (rispostaeccezioni == "SI" || rispostaeccezioni == "SÌ")
                        {
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt", autousatevendute);//Crea il nuovo file che conterrà le auto usate vendute.
                            Console.WriteLine("\nIl file è stato creato con successo.");
                        }
                        else if (rispostaeccezioni == "NO")
                        {
                            Console.WriteLine("Chiusura del programma in corso...");
                            Task.Delay(1800).Wait(); //Attende 1,8 secondi per permettere all'utente di accorgersi della chiusura.
                            Environment.Exit(0);//Esce automaticamente dal programma.
                        }
                    }

                }
                catch (DirectoryNotFoundException) //Se si verifica questo errore, cioè la cartella dei file non è stato trovata, esegue le operazioni seguenti.
                {
                    Console.WriteLine("\n\nERRORE: la cartella in cui si dovrebbero trovare tutte le auto non è stata trovata. Vuoi crearla?");
                    string rispostaeccezioni = Convert.ToString(Console.ReadLine()).ToUpper();
                    if (rispostaeccezioni == "SI" || rispostaeccezioni == "SÌ")
                    {

                        Directory.CreateDirectory(@"C:\Programma gestionale concessionaria"); //Crea prima la cartella.
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt", autonuoveinvendita); //Crea il nuovo file che conterrà le auto nuove in vendita.
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt", autousateinvendita);//Crea il nuovo file che conterrà le auto usate in vendita
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt", autonuovevendute);//Crea il nuovo file che conterrà le auto nuove vendute.
                        File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt", autousatevendute);//Crea il nuovo file che conterrà le auto usate vendute.
                        Console.WriteLine("\nLe cartelle e i file sono stati creati con successo. Ora inserisci delle automobili per sfruttare pienamente le funzionalità del programma.");
                    }
                    else if (rispostaeccezioni == "NO")
                    {
                        Console.WriteLine("\nChiusura del programma in corso...");
                        Task.Delay(1800).Wait(); //Attende 1,8 secondi per permettere all'utente di accorgersi della chiusura.
                        Environment.Exit(0);//Esce automaticamente dal programma.
                    }
                }
                catch (IOException)//Se si verifica questo errore, cioè errore di lettura, esegue le operazioni seguenti.
                {
                    Console.WriteLine("\n\nERRORE: si è verificato un errore durante la lettura dei file. Premi un tasto qualsiasi per chiudere il programma e prova ad aprilo di nuovo.");
                    Console.ReadKey();
                    Environment.Exit(0);//Esce automaticamente dal programma una volta che viene premuto un tasto qualsiasi.
                }
                catch (UnauthorizedAccessException)//Se si verifica questo errore, cioè accesso non autorizzato, esegue le operazioni seguenti.
                {
                    Console.WriteLine("\n\nERRORE: non hai i privilegi per accedere ai file che contengono le auto. Premi un tasto qualsiasi per chiudere il programma e " +
                                      "prova ad aprilo di nuovo. Nel caso in cui il problema persista, contatta l'amministratore. ");
                    Console.ReadKey();
                    Environment.Exit(0);//Esce automaticamente dal programma una volta che viene premuto un tasto qualsiasi.
                }
                //Inserisce all'interno di un array monodimensionale tutti gli elementi del file, inserendo nelle celle ogni elemento diviso dai due punti.
                string[] elementinuoveinvendita = autonuoveinvendita.Split(carattereDivisore);
                string[] elementiusateinvendita = autousateinvendita.Split(carattereDivisore);
                string[] elementinuovevendute = autonuovevendute.Split(carattereDivisore);
                string[] elementiusatevendute = autousatevendute.Split(carattereDivisore);
                //Nel file come prima cifra è presente il numero di righe che l'array multidimensionale deve avere, quindi va convertito da stringa a intero.
                righeNuoveInVendita = Convert.ToInt32(elementinuoveinvendita[0]);
                righeUsateInVendita = Convert.ToInt32(elementiusateinvendita[0]);
                righeNuoveVendute = Convert.ToInt32(elementinuovevendute[0]);
                righeUsateVendute = Convert.ToInt32(elementiusatevendute[0]);
                Autonuoveinvendita = new string[righeNuoveInVendita, 8]; // Si inizializza l'array multidimensionale per contenere le auto nuove in vendita.
                Autousateinvendita = new string[righeUsateInVendita, 11]; // Si inizializza l'array multidimensionale per contenere le auto usate in vendita.
                Autonuovevendute = new string[righeNuoveVendute, 12]; // Si inizializza l'array multidimensionale per contenere le auto vendute.
                Autousatevendute = new string[righeUsateVendute, 14]; // Si inizializza l'array multidimensionale per contenere le auto vendute.
                int n1 = 1; //Si inizializza la variabile necessaria per l'estrazione del contenuto dell'array monodimensionale elementi.
                for (int i = 0; i < righeNuoveInVendita; i++) /*Inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementinuoveinvendita, 
                                                            che contiene auto nuove in vendita.*/

                {
                    for (int j = 0; j < 8; j++)
                    {
                        Autonuoveinvendita[i, j] = elementinuoveinvendita[n1];
                        n1++;
                    }
                }
                n1 = 1; //Assegna a n1 di nuovo il valore uno per il nuovo inserimento.
                for (int i = 0; i < righeUsateInVendita; i++) /*Inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementiusateinvendita, 
                                                            che contiene auto usate in vendita.*/
                {
                    for (int j = 0; j < 11; j++)
                    {
                        Autousateinvendita[i, j] = elementiusateinvendita[n1];
                        n1++;
                    }
                }
                n1 = 1; //Assegna a n1 di nuovo il valore uno per il nuovo inserimento.
                for (int i = 0; i < righeNuoveVendute; i++) /*Inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementinuovevendute, 
                                                     che contiene auto nuove vendute.*/
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Autonuovevendute[i, j] = elementinuovevendute[n1];
                        n1++;
                    }

                }
                n1 = 1; //Assegna a n1 di nuovo il valore uno per il nuovo inserimento.
                for (int i = 0; i < righeUsateVendute; i++) /*Inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementiusatevendute, 
                                                     che contiene auto usate vendute.*/
                {
                    for (int j = 0; j < 14; j++)
                    {
                        Autousatevendute[i, j] = elementiusatevendute[n1];
                        n1++;
                    }

                }
                Console.WriteLine("\n\nCosa vuoi fare?");
                sceltaIniziale = Convert.ToString(Console.ReadLine()).ToUpper(); //Acquisisce la scelta inziale.
                //Qui viene eseguito un ciclo preventivo per individuare eventuali errori di inserimento.
                while (sceltaIniziale != "RICERCA" & sceltaIniziale != "INSERISCI" & sceltaIniziale != "SPOSTA" & sceltaIniziale != "ELIMINA" &
                       sceltaIniziale != "AIUTO" & sceltaIniziale != "HELP" & sceltaIniziale != "?")
                {
                    Console.WriteLine("\nNon hai inserito una parola chiave accettabile." +
                                      "\nInserisci di nuovo un'operazione eseguibile oppure inserisci la parola Aiuto per leggere le istruzioni del programma:");
                    sceltaIniziale = Convert.ToString(Console.ReadLine()).ToUpper();
                }
                //Se l'utente sceglie di svolgere una ricerca esegue le operazioni seguenti.
                if (sceltaIniziale == "RICERCA")
                {
                    Console.WriteLine("\nChe tipo di automobile vuoi ricercare, in vendita oppure già venduta?");
                    primaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                    ControlloPrimaScelta(primaScelta);
                    Console.WriteLine("\nVuoi cercare un'auto nuova o usata?");
                    secondaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                    ControlloSecondaScelta(secondaScelta);
                    if (secondaScelta == "TUTTE") //Se l'utente vuole visualizzare tutte le auto, allora vengono eseguite queste operazioni.
                    {
                        //Se l'utente vuole visualizzare tutte le auto in vendita, allora vengono eseguite queste operazioni.
                        if (primaScelta == "VENDITA" || primaScelta == "VENDITE")
                        {
                            Console.WriteLine("\nLa ricerca ha prodotto {0} risultati.", (righeNuoveInVendita + righeUsateInVendita));
                            Console.WriteLine("\nQueste sono tutte le auto nuove in vendita:\n");
                            for (int i = 0; i < righeNuoveInVendita; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    Console.Write(Autonuoveinvendita[i, j]);
                                }
                            }
                            Console.WriteLine("\n\nQueste, invece, sono tutte le auto usate in vendita:\n");
                            for (int i = 0; i < righeUsateInVendita; i++)
                            {
                                for (int j = 0; j < 11; j++)
                                {
                                    Console.Write(Autousateinvendita[i, j]);
                                }
                            }


                        }
                        //Se l'utente vuole visualizzare tutte le auto vendute, allora vengono eseguite queste operazioni.
                        else if (primaScelta == "VENDUTA" || primaScelta == "VENDUTE")
                        {
                            Console.WriteLine("\nLa ricerca ha prodotto {0} risultati.", (righeNuoveVendute + righeUsateVendute));
                            Console.WriteLine("\nQueste sono tutte le auto nuove vendute:\n");
                            for (int i = 0; i < righeNuoveVendute; i++)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    Console.Write(Autonuovevendute[i, j]);
                                }
                            }
                            Console.WriteLine("\n\nQueste, invece, sono tutte le auto usate già vendute:\n");
                            for (int i = 0; i < righeUsateVendute; i++)
                            {
                                for (int j = 0; j < 14; j++)
                                {
                                    Console.Write(Autousatevendute[i, j]);
                                }
                            }
                        }
                    }
                    //Per tutti gli altri casi fa riferimento alla funzione sceltamatrici.
                    else if (secondaScelta == "NUOVA" || secondaScelta == "USATA" || secondaScelta == "NUOVE" || secondaScelta == "USATE"
                            || secondaScelta == "NUOVO" || secondaScelta == "USATO")
                    {
                        SceltaMatrici(primaScelta, secondaScelta);
                    }

                }

                if (sceltaIniziale == "INSERISCI" || sceltaIniziale == "SPOSTA" || sceltaIniziale == "ELIMINA")
                {
                    //Se l'utente sceglie di inserire un'auto esegue le operazioni seguenti.
                    if (sceltaIniziale == "INSERISCI")
                    {
                        Console.WriteLine("\nChe tipo di automobile vuoi inserire, in vendita oppure già venduta?");
                        primaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                        ControlloPrimaScelta(primaScelta);
                        Console.WriteLine("\nVuoi inserire un'auto nuova o usata?");
                        secondaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                        ControlloSecondaScelta(secondaScelta);

                    }
                    //Se l'utente sceglie di spostare un'auto esegue le operazioni seguenti.
                    else if (sceltaIniziale == "SPOSTA")
                    {
                        Console.WriteLine("\nChe tipo di automobile vuoi spostare, in vendita oppure già venduta?");
                        primaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                        ControlloPrimaScelta(primaScelta);
                        Console.WriteLine("\nVuoi spostare un'auto nuova o usata?");
                        secondaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                        ControlloSecondaScelta(secondaScelta);
                    }
                    //Se l'utente sceglie di eliminare un'auto esegue le operazioni seguenti.
                    else if (sceltaIniziale == "ELIMINA")
                    {
                        Console.WriteLine("\nChe tipo di automobile vuoi eliminare, in vendita oppure già venduta?");
                        primaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                        ControlloPrimaScelta(primaScelta);
                        Console.WriteLine("\nVuoi eliminare un'auto nuova o usata?");
                        secondaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
                        ControlloSecondaScelta(secondaScelta);
                    }
                    //Fa riferimento alla funzione sceltamatrici per svolgere le altre operazioni.
                    SceltaMatrici(primaScelta, secondaScelta);
                }
                //Se l'utente chiede di visualizzare le istruzioni del programma, esegue le seguenti operazioni.
                else if (sceltaIniziale == "AIUTO" || sceltaIniziale == "HELP" || sceltaIniziale == "?")
                {
                    try //Il programma prova ad eseguire le seguenti operazioni.
                    {
                        //Acquisice dal file presente sul disco le istruzioni del programma.
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
                //Una volta eseguite tutte le operazioni necessarie, il programma fa riferimento a questa funzione.
                FineProgramma();
            } while (risposta == "SÌ" || risposta == "SI");
        }
        //Funzione che viene richiamata per eseguire controlli preventivi sulla prima scelta, per individuare eventuali errori di inserimento.
        public static void ControlloPrimaScelta(string primaScelta)
        {
            while (primaScelta != "VENDITA" & primaScelta != "VENDITE" & primaScelta != "VENDUTA" & primaScelta != "VENDUTE")
            {
                Console.WriteLine("\nNon hai inserito una parola chiave accettabile. Inserisci di nuovo la tua risposta:");
                primaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
            }
        }
        //Funzione che viene richiamata per eseguire controlli preventivi sulla seconda scelta, per individuare eventuali errori di inserimento.
        static void ControlloSecondaScelta(string secondaScelta)
        {
            while (secondaScelta != "USATO" & secondaScelta != "USATA" & secondaScelta != "NUOVO" & secondaScelta != "NUOVA" &
                    secondaScelta != "USATE" & secondaScelta != "NUOVE" & secondaScelta != "TUTTE")
            {
                Console.WriteLine("\nNon hai inserito una parola chiave accettabile. Inserisci di nuovo la tua risposta:");
                secondaScelta = Convert.ToString(Console.ReadLine()).ToUpper();
            }
        }
        //Funzione che sceglie gli array, le stringhe e i numeri interi giusti in base al tipo di richiesta dell'utente.
        public static void SceltaMatrici(string primaScelta, string secondaScelta)
        {
            //tutte le funzioni seguenti inseriscono le informazioni di ogni auto in un array generale, che viene usato in ogni funzione del programma
            //primo caso: le scelte sono vendita e nuova
            if (primaScelta == "VENDITA" & secondaScelta == "NUOVA")
            {
                n = 8;
                elementiVisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementiVisualizzati[i] = elementiAutoNuoveInVenditaVisualizati[i];
                }
                righe = righeNuoveInVendita;
                if (verifica == true)
                {
                    autoFunzione = new string[righe, n];
                    for (int i = 0; i < righe; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            autoFunzione[i, j] = Autonuoveinvendita[i, j];
                        }
                    }
                }
                indicazioneCaratteristicheAuto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore e prezzo. ";
            }
            //secondo caso: le scelte sono vendita e usata
            else if (primaScelta == "VENDITA" & secondaScelta == "USATA")
            {
                n = 11;
                elementiVisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementiVisualizzati[i] = elementiAutoUsateInVenditaVisualizati[i];
                }
                righe = righeUsateInVendita;
                if (verifica == true)
                {
                    autoFunzione = new string[righe, n];
                    for (int i = 0; i < righe; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            autoFunzione[i, j] = Autousateinvendita[i, j];
                        }
                    }
                }
                indicazioneCaratteristicheAuto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore, targa, numero dei proprietari, chilometri percorsi e prezzo. ";
            }
            //terzo caso: le scelte sono venduta e nuova
            else if (primaScelta == "VENDUTA" & secondaScelta == "NUOVA")
            {
                n = 12;
                elementiVisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementiVisualizzati[i] = elementiAutoNuoveVenduteVisualizati[i];
                }
                righe = righeNuoveVendute;
                if (verifica == true)
                {
                    autoFunzione = new string[righe, n];
                    for (int i = 0; i < righe; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            autoFunzione[i, j] = Autonuovevendute[i, j];
                        }
                    }
                }
                indicazioneCaratteristicheAuto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore, targa, acquirente, data di acquisto,  " +
                                               "\nprezzo di vendita iniziale e prezzo di vendita finale. ";
            }
            //quarto caso: le scelte sono venduta e usata
            else if (primaScelta == "VENDUTA" & secondaScelta == "USATA") 
            {
                n = 14;
                elementiVisualizzati = new string[n];
                for (int i = 0; i < n; i++)
                {
                    elementiVisualizzati[i] = elementiAutoUsateVenduteVisualizati[i];
                }
                righe = righeUsateVendute;
                if (verifica == true)
                {
                    autoFunzione = new string[righe, n];
                    for (int i = 0; i < righe; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            autoFunzione[i, j] = Autousatevendute[i, j];
                        }
                    }
                }
                indicazioneCaratteristicheAuto = "Verranno mostrate di seguito, separate da spazi, le caratteristiche di ogni auto: marca, modello," +
                                               "\nalimentazione, cilindrata, potenza, anno di produzione, colore, targa, numero dei proprietari,   " +
                                               "\nchilometri percorsi, acquirente, data di acquisto, prezzo di vendita iniziale e prezzo di vendita finale. ";
            }
            int[] posizioniauto = new int[righe]; //viene inizializzato l'array necessario per contenere la riga del 
            int risultati = 0;
            if (verifica == true && verifica2 == true) 
            {
                //da qui in poi prosegue facendo riferimento alla funzione indicata dall'utente
                if (sceltaIniziale == "RICERCA" || sceltaIniziale == "ELIMINA" || sceltaIniziale == "SPOSTA" ) 
                {
                    //si rivolge alla funzione per eseguire la ricerca vera e propria oppure l'eliminazione 
                    RicercaFile(sceltaIniziale, posizioniauto, risultati);
                }
                else if (sceltaIniziale == "INSERISCI") 
                {
                    string salvataggio = "";
                    string [] nuovAutomobile = new string[n];
                    for (int i = 0; i < n; i++) //chiede le caratteristiche delle auto da inseire
                    {
                        Console.WriteLine("\nInserisci {0} dell'auto che vuoi inserire:", elementiVisualizzati[i]);
                        nuovAutomobile[i] = Convert.ToString(Console.ReadLine());
                        while (nuovAutomobile[i] == "") //esegue un controllo preventivo per evitare che i campi vengano lasciati vuoti
                        {
                            Console.WriteLine("\nNon puoi lasciare vuoto un campo di inserimento. Inserisci {0} dell'auto che vuoi inserire:", elementiVisualizzati[i]);
                            nuovAutomobile[i] = Convert.ToString(Console.ReadLine()).ToUpper();
                        }
                        if (i == 0)
                        {
                            nuovAutomobile[i] = "\n" + nuovAutomobile[i];
                        }
                        else
                        {
                            nuovAutomobile[i] = " " + nuovAutomobile[i] + " ";
                        }
                    }
                    Console.WriteLine("\nHai inserito tutte le caratteristiche. Ricontrolla se sono giuste:");
                    for (int i = 0; i < n; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue; //rende lo sfondo della riga blu, in modo che l'utente possa leggerlo meglio
                        Console.ForegroundColor = ConsoleColor.White; //rende i caratteri bianchi, in modo che l'utente possa leggerli meglio
                        Console.Write(nuovAutomobile[i]); //visualizza l'auto da inserire
                        Console.ResetColor(); //riporta i colori alle condizioni standard (nero e grigio)
                    }
                    Console.WriteLine("\n\nVuoi salvare le modifiche, oppure vuoi reinserire l'auto?");
                    salvataggio = Convert.ToString(Console.ReadLine()).ToUpper();
                    while (salvataggio != "SI" & salvataggio != "SÌ" & salvataggio != "NO") 
                    {
                        Console.WriteLine("\nNon hai inserito la parola chiave giusta. Inserisci di nuovo la tua risposta:");
                        salvataggio = Convert.ToString(Console.ReadLine()).ToUpper();
                    }
                    if (salvataggio == "SI" || salvataggio == "SÌ") 
                    {
                        //si rivolge alla funzione per eseguire l'inserimento vero e proprio
                        InserisciFile(primaScelta, secondaScelta, nuovAutomobile);
                    }
                    //se la scelta è no, allora ritorna al main, il quale si rivolge alla funzione fineprogramma
                }
            }
        }
        //Funzione che permette la ricerca all'interno degli array.
        public static void RicercaFile( string sceltaIniziale, int [] posizioniauto, int risultati)
        {
            string[] parametri = new string[14]; //inizializza l'array che conterrà i parametri indicati dall'utente
            int n1 = 0; //inizializzata variabile necessaria per l'algoritmo di ricerca
            if (righe != 0) //esegue il codice seguente se il file presente non è vuoto, cioè senza auto
            {
                for (int i = 0; i < n; i++) //ciclo per l'inserimento dei parametri
                {
                    if (sceltaIniziale == "RICERCA")
                    {
                        Console.WriteLine("\nInserisci {0} dell'auto che vuoi cercare:", elementiVisualizzati[i]);
                    }
                    else if (sceltaIniziale == "ELIMINA") 
                    {
                        Console.WriteLine("\nInserisci {0} dell'auto che vuoi eliminare:", elementiVisualizzati[i]);
                    }
                    else if(sceltaIniziale == "SPOSTA" )
                    {
                        Console.WriteLine("\nInserisci {0} dell'auto che vuoi spostare:", elementiVisualizzati[i]);
                    }
                    string parametro = Convert.ToString(Console.ReadLine()).ToUpper();
                    if (parametro == "///") //si ferma all'inserimento del parametro "///"
                    {
                        if (i == 0)
                        {
                            n1 = n;
                        }
                        break;
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
                            if (confrontostringhe.Compare(autoFunzione[i, j], parametri[j], CompareOptions.IgnoreSymbols) == 0) //esegue il confronto fra le varie caratteristiche per individuare l'auto giusta in base ai filtri di ricerca
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
                                            autoFunzione[i, 0] = autoFunzione[i, 0].TrimStart('\r');
                                            autoFunzione[i, 0] = autoFunzione[i, 0].TrimStart('\n');
                                            autoricercate[i, 0] = "\n" + n2 + ".";
                                            n2++;
                                        }
                                        autoricercate[i, k + 1] = autoFunzione[i, k];
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
                        Console.WriteLine(indicazioneCaratteristicheAuto + "\n");
                        
                    }
                    if (risultati > 1)
                    {
                        //alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\nLa ricerca ha prodotto {0} risultati.                                                                                                                                \n", risultati);
                        Console.ResetColor();//i colori vengono riportati a quelli standard (nero e grigio)
                        Console.WriteLine(indicazioneCaratteristicheAuto + "\n");
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
            if ((sceltaIniziale == "ELIMINA" || sceltaIniziale == "SPOSTA") & (righe != 0 & risultati != 0))  
            {
                EliminaFile(sceltaIniziale, risultati, posizioniauto);
            }
        }
        //Funzione per inserire una nuova auto all'interno di un array e poi di un file.
        public static void InserisciFile(string primaScelta, string secondaScelta, string[] nuovAutomobile)
        {
            Console.WriteLine("\nSalvataggio delle modifiche dell'inserimento in corso. Non chiudere il programma...");
            righe++; //incrementa il numero di righe di uno
            string[] autodainserire = new string[righe]; //inizializza l'array unidimensionale che conterrà le auto che devono essere inserite nel file: è unidimensionale per effettuare un ordinamento più veloce
            CompareInfo confrontostringhe = CultureInfo.InvariantCulture.CompareInfo; //inizializza la variabile per il confronto delle stringhe, dandone le impostazioni iniziali
            for (int i = 0; i < righe; i++) //questo ciclo inserisce le auto già presenti all'interno dell'array coinvolto dall'utente e aggiunge alla fine l'auto nuova appena inserita 
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == righe - 1)
                    {
                        if (j == 0)
                        {
                            if (sceltaIniziale == "SPOSTA")
                            {
                                autodainserire[i] = autodainserire[i] + capo;
                            }
                            autodainserire[i] = autodainserire[i] + nuovAutomobile[j] + carattereDivisore;
                        }
                        else
                        {
                            autodainserire[i] = autodainserire[i] + nuovAutomobile[j] + carattereDivisore;
                        }
                    }
                    else if (righe - 1 != 0)
                    {
                        autodainserire[i] = autodainserire[i] + autoFunzione[i, j] + carattereDivisore;
                    }
                }
            }
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
            Salvataggio(primaScelta, secondaScelta, autodasalvare);

        }
        //Funzione per eliminare le auto da un array.
        public static void EliminaFile(string sceltaIniziale, int risultati, int[] posizioniauto)
        {
            string[] nuovAutomobile = new string[0];
            //alla prima riga viene dato allo sfondo il colore blu e il colore dei caratteri bianco
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            if (sceltaIniziale == "ELIMINA" )
            {
                Console.WriteLine("\n\n\nInserisci il numero dell'auto che vuoi eliminare:                                                                                                                  ");
            }
            else if (sceltaIniziale == "SPOSTA" )
            {
                Console.WriteLine("\n\n\nInserisci il numero dell'auto che vuoi spostare:                                                                                                                  ");
            }
            Console.ResetColor(); //lo sfondo e i caratteri vengono riportati al colore standard (nero e grigio)
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
                Console.Write(autoFunzione[posizioniauto[risposta], i]); //viene scritta sulla console, sulla stessa riga, una caratteristica alla volta
                Console.ResetColor(); //lo sfondo e i caratteri vengono riportati al colore standard (nero e grigio)
            }
            if (sceltaIniziale == "ELIMINA")
            {
                Console.WriteLine("\n\nSei sicuro di voler eliminare quest'auto?");
            }
            else if (sceltaIniziale == "SPOSTA") 
            {
                Console.WriteLine("\n\nSei sicuro di voler spostare quest'auto?");
            }
            string risposta2 = Convert.ToString(Console.ReadLine()).ToUpper(); //viene assegnata la variabile che contiene la risposta dell'utente
            //esegue un controllo preventivo per rilevare eventuali errori di inserimento
            while (risposta2 != "SI" & risposta2 != "SÌ" & risposta2 != "NO") 
            {
                Console.WriteLine("\nNon hai inserito un valore accettabile. Inserisci di nuovo la tua risposta:");
                risposta2 = Convert.ToString(Console.ReadLine()).ToUpper();
            }
            if ((risposta2 == "SI" || risposta2 == "SÌ") & sceltaIniziale == "SPOSTA" )
            {
                SpostaFile(posizioniauto, risposta, risposta2, nuovAutomobile);
            }
            //se la risposta è sì, allora inizia il salvataggio delle modifiche
            if ((risposta2 == "SÌ" || risposta2 == "SI") && verifica2 == true) 
            {
                if (sceltaIniziale == "SPOSTA")
                {
                    verifica2 = false;
                    verifica = true;
                    SceltaMatrici(primaScelta, secondaScelta);
                }
                Console.WriteLine("\nSalvataggio delle modifiche dell'eliminazione in corso. Non chiudere il programma...");
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
                                if (j == 0 & autoFunzione[i, 0].Contains(autoFunzione[posizioniauto[risposta], 0]) & sceltaIniziale == "ELIMINA") 
                                {
                                    autodasalvare = autodasalvare + capo;
                                }
                                autodasalvare = autodasalvare + carattereDivisore;
                            }
                            else if (i == righe - 1 & j == n - 1) //se ci si trova all'ultima riga e colonna, allora non inserisce alla fine il carattere divisore
                            {
                                if (j == 0 & autoFunzione[i, 0].Contains(autoFunzione[posizioniauto[risposta], 0]) & sceltaIniziale == "ELIMINA") 
                                {
                                    autodasalvare = autodasalvare + capo;
                                }
                                autodasalvare = autodasalvare + autoFunzione[i, j];
                            }
                            else //in qualsiasi altro caso inserisce l'auto dall'array autoFunzione e il carattere divisore
                            {
                                if (j == 0 & autoFunzione[i, 0].Contains(autoFunzione[posizioniauto[risposta], 0]) & sceltaIniziale == "ELIMINA")  
                                {
                                    autodasalvare = autodasalvare + capo;
                                }
                                autodasalvare = autodasalvare + autoFunzione[i, j] + carattereDivisore;
                            }

                        }
                    }

                }
                Salvataggio(primaScelta, secondaScelta, autodasalvare); // fa riferimento alla funzione salvataggio per passare al salvataggio vero e proprio
            }
            //nel caso in cui la risposta sia no, allora ritorna al main, il quale fa poi riferimento alla funzione fineprogramma
        }
        //Funzione per spostare le auto da un array a un altro.
        public static void SpostaFile(int[] posizioniauto, int risposta, string risposta2, string[] nuovAutomobile)
        {
            verifica = true;
            do
            {
                Console.WriteLine("\nDove vuoi spostare quest'auto, in vendita oppure già venduta?");
                primaScelta2 = Convert.ToString(Console.ReadLine()).ToUpper();
                Console.WriteLine("\nL'auto deve essere spostata tra quelle nuove, oppure tra quelle usate?");
                secondaScelta2 = Convert.ToString(Console.ReadLine()).ToUpper();
                if (primaScelta2 != "VENDITA" && primaScelta2 != "VENDUTA" && secondaScelta2 != "NUOVA" && secondaScelta2 != "USATA")
                {
                    Console.WriteLine("\nNon sono stati inseriti parametri corretti. Reinserire dei nuovi parametri:");
                    verifica = false;
                }
            }
            while (verifica == false);
            verifica = false;
            SceltaMatrici(primaScelta2, secondaScelta2); //Viene fatto riferimento alla funzione SceltaMatrici per scegliere i nuovi parametri in base alle scelte fatte dall'utente.
            nuovAutomobile = new string[n]; //Crea un nuovo array che conterrà le informazioni esistenti dell'auto più quelle nuove.
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n                                                                                                                                                                   ");
            Console.ResetColor();
            int k = 0;//Variabile necessaria per individuare gli elementi che devono essere mantenuti partendo dalla cella 0 dell'array che contiene l'auto con le informazioni attuali (autoFunzione).
            int j = 0;//Variabile che indica quante celle devono essere saltate perché includono elementi che non possono essere inseriti nel nuovo array (nuovAutomobile).
            int l = 0; /*Variabile che non è sempre necessaria, ma che indica il numero di quante celle bisogna tornare indietro, oltre a j, nell'array autoFunzione per ottenere i dati 
                        che ci sono dopo che è stata effettuata la richiesta dal programma di aggiungere informazioni quando verifica è uguale a true.*/
            //Blocca subito lo spostamento se l'utente inserisce lo stesso gruppo di origine.
            if (((primaScelta == "VENDITA" & primaScelta2 == "VENDITA") || (primaScelta == "VENDUTA" & primaScelta2 == "VENDUTA"))
                && ((secondaScelta == "NUOVA" & secondaScelta2 == "NUOVA") || (secondaScelta == "USATA" & secondaScelta2 == "USATA")))
            {
                Console.WriteLine("\nLo spostamento non può avvenire nello stesso gruppo di origine.");
                verifica2 = false;
            }
            //Primo caso: in questa parte di passa da un array più grande a uno più piccolo.
            else if ((primaScelta == "VENDITA" & primaScelta2 == "VENDITA" & secondaScelta == "USATA" & secondaScelta2 == "NUOVA")
                || (primaScelta == "VENDUTA" & primaScelta2 == "VENDUTA" & secondaScelta == "USATA" & secondaScelta2 == "NUOVA"))
            {
                Console.WriteLine("\nSe hai scelto di spostare un'auto da usata a nuova, sappi che perderai delle informazioni.");
                if (primaScelta == "VENDITA" & primaScelta2 == "VENDITA")
                {
                    k = 7;
                    j = 2;
                }
                else if (primaScelta == "VENDUTA" & primaScelta2 == "VENDUTA")
                {
                    k = 8;
                    j = 1;
                }
            }
            else if (primaScelta == "VENDUTA" & primaScelta2 == "VENDITA")
            {
                if (secondaScelta == "NUOVA" & secondaScelta2 == "NUOVA")
                {
                    Console.WriteLine("\nSe hai scelto di spostare un'auto da venduta nuova a in vendita nuova, sappi che perderai delle informazioni.");
                    k = 7;
                    j = 2;
                }
                else if (secondaScelta == "NUOVA" & secondaScelta2 == "USATA") //In questo particolare caso si rende necessario l'inserimento di nuove informazioni.
                {
                    Console.WriteLine("\nPer spostare l'auto da venduta nuova a vendita usata è neccessario aggiungere le seguenti informazioni, mentre altre verranno perse:");
                    k = 8;
                    j = 1;
                    l = -1;
                    verifica = true;
                }
                else if (secondaScelta == "USATA" & secondaScelta2 == "NUOVA")
                { 
                    Console.WriteLine("\nSe hai scelto di spostare un'auto da venduta usata a in vendita nuova, sappi che perderai delle informazioni.");
                    k = 7;
                    j = 4;
                }
                else if (secondaScelta == "USATA" & secondaScelta2 == "USATA")
                {
                    Console.WriteLine("\nSe hai scelto di spostare un'auto da venduta usata a in vendita usata, sappi che perderai delle informazioni.");
                    k = 10;
                    j = 1;
                }
            }
            //Secondo caso: in questa parte si passa da un array piccolo a uno più grande.
            else
            {
                verifica = true;
                if ((primaScelta == "VENDITA" & primaScelta2 == "VENDUTA") & (secondaScelta == "NUOVA" & secondaScelta2 == "NUOVA"))
                {
                    Console.WriteLine("\nPer spostare l'auto da vendita nuova a venduta nuova è neccessario aggiungere le seguenti informazioni:");
                    k = 7;
                    j = 4;
                }
                else if (((primaScelta == "VENDITA" & primaScelta2 == "VENDITA") || (primaScelta == "VENDUTA" & primaScelta2 == "VENDUTA"))
                         & secondaScelta == "NUOVA" & secondaScelta2 == "USATA")
                {
                    Console.WriteLine("\nPer spostare l'auto da nuova a usata è neccessario aggiungere le seguenti informazioni:");
                    if (primaScelta2 == "VENDITA")
                    {
                        k = 7;
                        j = 2;
                        l = 1;
                        
                    }
                    else
                    {
                        k = 8;
                        j = 1;
                        l = 1;
                    }
                }

                else if (primaScelta == "VENDITA" & primaScelta2 == "VENDUTA" & secondaScelta == "NUOVA" & secondaScelta2 == "USATA")
                {
                    Console.WriteLine("\nPer spostare l'auto da vendita nuova a venduta usata è neccessario aggiungere le seguenti informazioni:");
                    k = 7;
                    j = 6;
                }
                else if (primaScelta == "VENDITA" & primaScelta2 == "VENDUTA" & secondaScelta == "USATA" & secondaScelta2 == "NUOVA")
                {
                    Console.WriteLine("\nPer spostare l'auto da vendita usata a venduta nuova è neccessario aggiungere le seguenti informazioni:");
                    k = 8;
                    j = 3;
                    l = 3;
                }
                else if (primaScelta == "VENDITA" & primaScelta2 == "VENDUTA" & secondaScelta == "USATA" & secondaScelta2 == "USATA")
                {
                    Console.WriteLine("\nPer spostare l'auto da vendita usata a venduta usata è neccessario aggiungere le seguenti informazioni:");
                    k = 10;
                    j = 3;

                }
            }
            if (verifica2 == true)
            {
                //Parte di inserimento dei dati nel nuovo array nel primo caso: da array grande a piccolo, , dove non si rende necessaria l'aggiunta di nuovi dati.
                if (verifica == false)
                {
                    for (int i = 0; i < n + j + 1; i++)
                    {
                        if (i < k)
                        {
                            nuovAutomobile[i] = autoFunzione[posizioniauto[risposta], i];
                        }
                        else if (i > (k + j))
                        {
                            nuovAutomobile[i - j - 1] = autoFunzione[posizioniauto[risposta], i];
                        }

                    }
                }
                //Parte di inserimento dei dati nel nuovo array nel secondo caso: da array piccolo a grande, dove si rende necessaria l'aggiunta di nuovi dati.
                else if (verifica == true)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (i < k)
                        {
                            nuovAutomobile[i] = autoFunzione[posizioniauto[risposta], i];
                        }
                        else if (i > (k + j)) 
                        {
                            nuovAutomobile[i] = autoFunzione[posizioniauto[risposta], i - j - l];
                        }
                        else if (i >= k && i <= (k + j))
                        {
                            Console.WriteLine("\nInserisci {0} dell'auto:", elementiVisualizzati[i]);
                            nuovAutomobile[i] = Convert.ToString(" " + Console.ReadLine() + " ");
                        }
                    }
                }
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nL'auto che vuoi spostare, con le nuove informazioni, è questa:                                                                                                     \n");
                Console.ResetColor();
                Console.WriteLine(indicazioneCaratteristicheAuto + "\n");
                for (int i = 0; i < n; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue; //lo sfondo diventa blu, in modo che l'utente possa distinguerla meglio
                    Console.ForegroundColor = ConsoleColor.White;//i caratteri diventano bianchi, in modo che l'utente possa distinguerla meglio
                    Console.Write(nuovAutomobile[i]);
                    Console.ResetColor();
                }
                Console.WriteLine("\n\nSei sicuro di voler inserire questa nuova auto? Ricordati che verrà inserita nel nuovo elenco, poi verrà eliminata dal precedente.");
                risposta2 = Convert.ToString(Console.ReadLine()).ToUpper();
                //Esegue un controllo preventivo per rilevare eventuali errori di inserimento.
                while (risposta2 != "SI" & risposta2 != "SÌ" & risposta2 != "NO")
                {
                    Console.WriteLine("\nNon hai inserito un valore accettabile. Inserisci di nuovo la tua risposta:");
                    risposta2 = Convert.ToString(Console.ReadLine()).ToUpper();
                }
                verifica = true; //Viene posta uguale a true per poter accedere, in SceltaMatrici, alla selezione dei dati da inserire all'interno dell'array autoFunzione.
                verifica2 = false; //Viene posto uguale a false per non ripetere il riferimento alla funzione di ricerca, alla funzione di eliminazione e spostamento.
                SceltaMatrici(primaScelta2, secondaScelta2); //Si fa riferimento di nuovo a SceltaMatrici per disporre dell'array autoFunzione che conti
                InserisciFile(primaScelta2, secondaScelta2, nuovAutomobile); //Si fa riferimento alla funzione InserisciFile per fare l'inserimento nel file vero e proprio.
                verifica2 = true;//Per poter effettuare l'eliminazione è necessario che verifica2 sia true.
                //Ritorna alla funzione EliminaFile.
            }
        }
        //Funzione di salvataggio delle modifiche usata dopo le funzioni di inserimento, eliminazione e spostamento.
        public static void Salvataggio(string primaScelta, string secondaScelta, string autodasalvare)
        {
            string rispostaeccezioni = ""; //inizializza la variabile necessaria per la risposta dell'utente in caso di eccezioni
            int n1 = 0;  //inizializza la variabile necessaria per i tentativi in caso di errore durante la scrittura
            do //inizia il ciclo di controllo
            {
                try //prova ad eseguire le operazioni seguenti
                {
                    if (primaScelta == "VENDITA" || primaScelta == "VENDITE")
                    {
                        if (secondaScelta == "NUOVA" || secondaScelta == "NUOVE")
                        {
                            //crea oppure sovrascrive il file che contiene le auto nuove in vendita
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovoinvendita.txt", autodasalvare);
                        }
                        else if (secondaScelta == "USATA" || secondaScelta == "USATE")
                        {
                            //crea oppure sovrascrive il file che contiene le auto usate in vendita
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatoinvendita.txt", autodasalvare);
                        }
                    }
                    else if (primaScelta == "VENDUTA" || primaScelta == "VENDUTE")
                    {
                        if (secondaScelta == "NUOVA" || secondaScelta == "NUOVE")
                        {
                            //crea oppure sovrascrive il file che contiene le auto nuove vendute
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arraynuovovenduto.txt", autodasalvare);
                        }
                        else if (secondaScelta == "USATA" || secondaScelta == "USATE")
                        {
                            //crea oppure sovrascrive il file che contiene le auto usate vendute
                            File.WriteAllText(@"C:\Programma gestionale concessionaria\arrayusatovenduto.txt", autodasalvare);
                        }
                    }
                }
                catch (DirectoryNotFoundException) //se non trova la cartella svolge le seguenti operazioni
                {
                    Console.WriteLine("\nERRORE: la cartella che dovrebbe contenere i file di salvataggio non è stata trovata. Vuoi crearne una nuova?");
                    rispostaeccezioni = Convert.ToString(Console.ReadLine()).ToUpper();
                    if (rispostaeccezioni == "SI" || rispostaeccezioni == "SÌ")
                    {
                        Directory.CreateDirectory(@"C:\Programma gestionale concessionaria"); //crea la cartella
                        Console.WriteLine("\nCartella creata con successo.");
                    }
                    else if (rispostaeccezioni == "NO")
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
            while (rispostaeccezioni == "SI" || rispostaeccezioni == "SÌ");
            Task.Delay(1500).Wait(); //attende 1,5 secondi
            Console.WriteLine("\nSalvataggio completato con successo.");
            Task.Delay(1000).Wait(); //attende un secondo
        }
        //Funzione eseguita al termine di tutte le operazioni e richiamata dal main.
        static void FineProgramma() 
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue; //lo sfondo diventa blu, in modo che l'utente possa distinguerla meglio
            Console.ForegroundColor = ConsoleColor.White;//i caratteri diventano bianchi, in modo che l'utente possa distinguerla meglio
            Console.WriteLine("\n\n\nVuoi eseguire ulteriori operazioni all'interno del programma?                                                                                                       ");
            Console.ResetColor(); //riporta i colori alle condizioni standard (nero e grigio)
            string risposta = Convert.ToString(Console.ReadLine()).ToUpper();
            //questo ciclo while esegue un controllo preventivo nel caso in cui si inseriscano delle parole chiave non accettabili
            while (risposta != "SI" & risposta != "SÌ" & risposta != "NO") 
            {
                Console.WriteLine("\n\nNon hai inserito una parola chiave accettabile. Inserisci di nuovo la tua risposta:");
                risposta = Convert.ToString(Console.ReadLine()).ToUpper();
            }
            if (risposta == "SÌ" || risposta == "SI" ) //se l'utente risponde sì, allora fa ritornare il programma allo stato iniziale
            {
                Console.WriteLine("\nRiavvio del programma per eseguire ulteriori operazioni in corso...");
                Task.Delay(1800).Wait();//attende 1,8 secondi per permettere all'utente di accorgersi del riavvio
            }
            else if (risposta == "NO") //se l'utente dice di no, allora chiude il programma
            {
                Console.WriteLine("\nChiusura del programma in corso...");
                Task.Delay(1800).Wait(); //attende 1,8 secondi per permettere all'utente di accorgersi della chiusura
                Environment.Exit(0); //esce automaticamente dal programma
            }

        }
            
    }
}
