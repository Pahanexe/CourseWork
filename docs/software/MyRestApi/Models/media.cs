namespace MyRestApi.models
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Зовнішній ключ до таблиці User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
