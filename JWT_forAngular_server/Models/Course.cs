using System;

namespace JWT_forAngular_server.Models
{
    public class Course
    {
        public int courseId { get; set; }
        public string title { get; set; }
        public string discription { get; set; }
        public string courseStartDate { get; set; }
        public string courseEndDate { get; set; }
        public int userId { get; set; }
        public string catagory { get; set; }
        public string level { get; set; }
    }
}
