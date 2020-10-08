using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ASP_ComplexEx.Models
{

    //List<string> levels = new List<string>() { "Easier Than Easy", "Easy", "Normal", "Hard", "Harder Than Hard" };
    public enum Level
    {
        [Display(Name = "Easier Than Easy")]
        EasierThanEasy,
        [Display(Name = "Easy")]
        Easy,
        [Display(Name = "Normal")]
        Normal,
        [Display(Name = "Hard")]
        Hard,
        [Display(Name = "Harder Than Hard")]
        HarderThanHard
    }
    public class Room : IEntity
    {

        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public int Duration { get; set; } // время прохождения (минуты)
        [DataType(DataType.Currency)]
        public int MinPlayers { get; set; }
        [DataType(DataType.Currency)]
        public int MaxPlayers { get; set; }
        [DataType(DataType.Text)]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        public int Rating { get; set; }
        public Level FearLevel { get; set; } // уровень страха (1-5)
        public Level DifficultyLevel { get; set; } // уровень сложности (1-5)
        public virtual ICollection<ImageForRoom> Images { get; set; }

        public Room()
        {
            Images = new HashSet<ImageForRoom>();
        }
    }
}