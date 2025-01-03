namespace MyRestApi.models
{
    public class UserRole
    {
        public int UserId { get; set; }  // Зовнішній ключ для першого користувача
        public int UserId1 { get; set; } // Зовнішній ключ для другого користувача
        public int RoleId { get; set; }  // Зовнішній ключ для ролі

        // Навігаційні властивості для зв'язку з User (перший користувач), User1 (другий користувач) та Role
        public User User { get; set; }
        public User User1 { get; set; }  // Другий користувач
        public Role Role { get; set; }
    }

}
