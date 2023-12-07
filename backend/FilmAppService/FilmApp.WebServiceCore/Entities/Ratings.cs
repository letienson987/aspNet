using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApp.WebServiceCore.Entities
{
    public class Ratings : BaseEntity
    {
        [ForeignKey("Users")]
        public Users User { get; set; }

        [ForeignKey("Films")]
        public Films Film { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        
        public DateTime Timestamp { get; set; }
       
    }
}
