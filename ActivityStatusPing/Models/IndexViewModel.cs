namespace ActivityStatusPing.Models
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public User User { get; set; }
        public List<User> Users { get; set; } 
    }
}
