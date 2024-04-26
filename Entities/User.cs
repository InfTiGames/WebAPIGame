namespace WebAPI.Entities
{
    public class User
    {

        public int Id { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        // 1:M || if use M:N add List <User> Users to Character
        public List<Character> Characters { get; set; } = default!;

        // 1:1 public Character Character { get; set; } = default!;
    }
}