using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using FilmApp.WebServiceCore.Entities;


namespace FilmApp.WebServiceCore.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

              
    }
}
