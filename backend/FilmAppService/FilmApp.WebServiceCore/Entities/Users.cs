using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmApp.WebServiceCore.Helpers;


namespace FilmApp.WebServiceCore.Entities
{
    public class Users : BaseEntity
    {
        [StringLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public void SetPassword(string password, object bCryptNet) {
            Password = MD5Helper.MD5Hash(password);
        }
        // public bool VerifyPassword(string password) {

        //     return BCryptNet.Verify(password, Password);
        // }
    }
}
