namespace Aspiro.Library.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Tasks(string name, string description)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
