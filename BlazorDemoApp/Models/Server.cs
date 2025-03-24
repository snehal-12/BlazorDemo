using System.ComponentModel.DataAnnotations;

namespace BlazorDemoApp.Models
{
    public class Server
    {
        public Server() 
        {
            Random random = new();
            int randomNum = random.Next(0, 2);
            IsActive = randomNum == 0? false : true;
        }
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        public bool IsActive { get; set; }
    }
}
