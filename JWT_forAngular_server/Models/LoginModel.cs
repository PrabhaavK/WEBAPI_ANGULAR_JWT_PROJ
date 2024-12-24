using System.ComponentModel.DataAnnotations;

namespace JWT_forAngular_server.Models{
    public class LoginModel{

        public string? Email {get;set;}
        [MinLength(8)]
        public string? Password {get;set;}
    }
}