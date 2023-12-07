using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmApp.WebServiceCore.Entities
{
    public class Comments : BaseEntity
    {

        [ForeignKey("Users")]
        public Users User { get; set; }

        [ForeignKey("Films")]
        public Films Film { get; set; }

        public string Content { get; set; }
        
        public DateTime Timestamp { get; set; }
    }
}
