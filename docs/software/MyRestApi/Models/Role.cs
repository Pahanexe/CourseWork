namespace MyRestApi.models
{
    public class Role
    {
        public int Id { get; set; }
        public string Rolecol { get; set; }
        public string Permission { get; set; }

        // Навігаційне властивість для зв'язку з UserRole
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
