using System;
 
namespace JWT_forAngular_server.Models
{
    public class User
    {
        public int userId { get; set; }
        public string? userName { get; set; }
        public string? password{ get; set; }
        public string? email{get; set; }
        public string? mobile_no{get; set; }
        public string? role{get; set; }
        public string? profileImage{get; set; }
    }
}