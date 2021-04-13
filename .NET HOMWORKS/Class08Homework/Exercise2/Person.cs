using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Genre FavoriteMusicType { get; set; }

        public List<Song> FavoriteSongs = new List<Song>();

        public Person(int id, string firstName, string lastName, int age, Genre favoriteMusicType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavoriteMusicType = favoriteMusicType;

        }

        public void GetFavSongs()
        {
            if (FavoriteSongs.Count == 0) Console.WriteLine($"{FirstName} hates music");
            else
            {
                foreach (Song song in FavoriteSongs)
                {
                    Console.WriteLine(song.Title);
                }
            }
        }
    }    
}
