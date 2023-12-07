using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace FilmApp.WebServiceCore.Entities
{
    public class Films : BaseEntity
    {
        [StringLength(255)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [StringLength(50)]
        public string Author { get; set; }
        
        public Category Category { get; set; }

    }
}
