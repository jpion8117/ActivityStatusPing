using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityStatusPing.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LastActive { get; set; }

        [NotMapped]
        public bool IsActive 
        {
            get => DateTime.UtcNow < LastActive.AddMinutes(1); 
        }
    }
}
