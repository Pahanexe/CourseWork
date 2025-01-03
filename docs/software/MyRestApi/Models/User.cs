namespace MyRestApi.models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Навігаційне властивість для зв'язку з Media, UserRole та CommentModeration
        public ICollection<Media> Media { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<CommentModeration> CommentModerations { get; set; }
    }
}
