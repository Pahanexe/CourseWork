namespace MyRestApi.models
{
    public class CommentModeration
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ModeratorId { get; set; }
        public string ModerationReason { get; set; }
        public DateTime? ModerationDate { get; set; }
        public string ModerationStatus { get; set; }

        // Зовнішні ключі
        public User User { get; set; }
        public Admin Moderator { get; set; }
    }
}
