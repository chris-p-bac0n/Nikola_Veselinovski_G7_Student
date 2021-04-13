using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person jimmy = new Person(123, "Jimmy", "Jimson", 25, Genre.Rock);
            Song sweetHomeAlabama = new Song("Sweet Home Alabama", 3, Genre.Rock);
            Song pushIt = new Song("Pushit", 5, Genre.Rock);
            Song mockingbird = new Song("Mockingbird", 4, Genre.Hip_Hop);
            jimmy.FavoriteSongs.Add(sweetHomeAlabama);
            jimmy.FavoriteSongs.Add(pushIt);
            jimmy.FavoriteSongs.Add(mockingbird);
            jimmy.GetFavSongs();
        }
    }
}
