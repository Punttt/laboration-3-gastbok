/* 
Författare: Pontus Johansson
Uppgift: Laboration 3
Kurs: DT071G
Beskrivning: 
    Simulerar en digital gästbok, där man kan lägga in eller ta bort poster.
    Värden sparas ner i guestbook.json, skapas utifrån JSON format.
*/

using System;

namespace Guests
{
    // Huvudklass som styr program och innehåller meny
    class Program
    {
        // Startpunkt
        static void Main(string[] args)
        {
            // Skapas utanför loopen, konstruktorn läser in sparade inlägg från filen.
            Guestbook guestbook = new Guestbook();
            string? val;

            do
            {
                // Rensar konsolen så den blir ren inför varje val.
                Console.Clear();

                // Anropar utskrift av meny och rubrik.
                SkrivMeny();

                // Skriver ut alla inlägg, i är indexet som användaren använder för att ta bort.
                int i = 0;
                Console.WriteLine("+----------------------------------------------------------+");
                foreach (GuestbookEntry entry in guestbook.GetEntries())
                {
                    Console.WriteLine("[" + i++ + "] " + entry.Owner + " : " + entry.Post);
                }
                Console.WriteLine("+----------------------------------------------------------+\n");
                
                // lägger till ?? så att "" ger en tom sträng istället för null
                val = Console.ReadLine() ?? "";

                switch (val)
                {
                    case "1":
                        // Läser in namn och meddelande från användare
                        Console.Write("Ange namn: ");
                        string? owner = Console.ReadLine();
                        Console.Write("Skriv ditt meddelande: ");
                        string? post = Console.ReadLine();

                        // Felhanterar, inlägget sparas bara om båda fältet är ifyllda
                        if (!String.IsNullOrEmpty(owner) && !String.IsNullOrEmpty(post)) 
                        {
                            guestbook.AddEntry(owner, post);
                        }
                        else
                        {
                            Console.WriteLine("Du måste fylla i Namn + Meddelande \nTryck på någon tangent för att fortsätta.");
                            Console.ReadKey(); // Pausar så ett meddelande hinner skrivas ut.
                        }
                        break;

                    case "2":
                        Console.Write("Ange vilket index att radera: ");
                        string? index = Console.ReadLine();
                        if (!string.IsNullOrEmpty(index))
                            // Try and catch som fångar fel om användaren skriver fel siffra
                            // Eller om indexet inte finns i listan.
                            try
                            {
                                guestbook.DelEntry(Convert.ToInt32(index));
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("Det finns inget index med nummer " + "[" + index + "] \nTryck på någon tangent för att fortsätta.");
                                Console.ReadKey();
                            }
                        break;
                }

            // Loopen körs så länge anv inte skriver x eller X, To upper för att både litet och stort x
            } while (val.ToUpper() != "X");

        }

        // Skriver ut meny och rubriken
        static void SkrivMeny()
        {
            Console.WriteLine("P O N T U S  G U E S T B O O K\n");
            Console.WriteLine("1. Skriv i gästboken");
            Console.WriteLine("2. Ta bort inlägg\n");
            Console.WriteLine("X. Avsluta applikation\n");
        }
    }
}