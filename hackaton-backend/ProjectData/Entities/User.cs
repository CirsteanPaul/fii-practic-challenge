namespace hackatonBackend.ProjectData.Entities
{
    public sealed class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public short? Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public short? PositionRole { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}
