namespace MyRestApi.models
{
    public class DeleteAccount
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Reason { get; set; }
        public DateTime? Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        // Зовнішній ключ до Admin
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}

