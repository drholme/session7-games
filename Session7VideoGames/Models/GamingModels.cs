using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Session7VideoGames.Models
{
    public class Game {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }

        public virtual List<Character> Characters { get; set; }
        public virtual List<Platform> Platforms { get; set; }
        public virtual Developer Developer { get; set; }
    }

    public class Character {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Playable { get; set; }
        public virtual List<Game> Games { get; set; }
    }

    public class Developer {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual List<Game> Games { get; set; }
    }

    public class Platform {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsBest
        {
            get
            {
                if (Name == "Dreamcast")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual List<Game> Games { get; set; }
    }

    public class GamesContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}