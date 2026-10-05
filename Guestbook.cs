using System.Text.Json;

namespace Guests
{
    // Hanterar listan med inlägg - sparar och läser dom från JSON-fil
    public class Guestbook
    {
        // Filen där data sparas
        private string filename = @"guestbook.json";

        // Listan som håller alla inlägg medan programmet körs
        private List<GuestbookEntry> guests = new List<GuestbookEntry>();

        // Körs när objekt skapas, om filen finns läses sparad data in
        public Guestbook()
        {
            if (File.Exists(filename) == true)
            {
                string jsonString = File.ReadAllText(filename);
                guests = JsonSerializer.Deserialize<List<GuestbookEntry>>(jsonString)!;
            }
        }

        // Skapar nytt inlägg, lägger in i listan och sparar till fil.
        public GuestbookEntry AddEntry(string owner, string post)
        {
            GuestbookEntry obj = new GuestbookEntry(owner, post);
            guests.Add(obj);
            Marshal();
            return obj;
        }

        // Tar bort inlägg på input (index) sparar till filen.
        public int DelEntry(int index)
        {
            guests.RemoveAt(index);
            Marshal();
            return index;
        }

        // Returnerar listan så att program kan skriva inlägget
        public List<GuestbookEntry> GetEntries()
        {
            return guests;
        }

        // Gör om listan till JSON och skriver den till filen.
        private void Marshal()
        {
            var jsonString = JsonSerializer.Serialize(guests);
            File.WriteAllText(filename, jsonString);
        }
    }
}