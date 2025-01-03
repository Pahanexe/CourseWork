namespace MyRestApi.models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навігаційне властивість для зв'язку з CommentModeration та DeleteAccount
        public ICollection<CommentModeration> CommentModerations { get; set; }
        public ICollection<DeleteAccount> DeleteAccounts { get; set; }
    }
}
