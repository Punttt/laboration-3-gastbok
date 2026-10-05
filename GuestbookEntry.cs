namespace Guests
{
    // Ett enkelt inlägg i gästboken
    public class GuestbookEntry
    {
        // Namnet på den som skriver inlägg
        public string? Owner {
            get; set;
        }

        // Själva texten i inlägget
        public string? Post {
            get; set;
        }

        // Sätter ägare och text direkt när inläget skapas.
        public GuestbookEntry(string owner, string post)
        {
            Owner = owner;
            Post = post;
        }
    }

}