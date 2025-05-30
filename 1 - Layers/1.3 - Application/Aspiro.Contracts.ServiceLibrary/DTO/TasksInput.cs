namespace Aspiro.Contracts.ServiceLibrary.DTO
{
    public class TasksInput
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
        public string AssignedTo { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
        public string TeamAssigned { get; set; }
    }
}
