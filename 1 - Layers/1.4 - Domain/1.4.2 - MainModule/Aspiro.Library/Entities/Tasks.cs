using Aspiro.Library.Enums;

namespace Aspiro.Library.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? UpdatedBy { get; set; }
        public Priority Priority { get; set; }
        public TasksStatus Status { get; set; }
        public DateTime? DueDate { get; set; }
        public string? AssignedTo { get; set; }
        public DateTime CompletedAt { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
        public TimeSpan? ActualTime { get; set; }
        public string? TeamAssigned { get; set; }
        //public List<Tasks>? SubTasks { get; set; }

        public Tasks()
        {
            CreatedAt = DateTime.UtcNow;
            Status = TasksStatus.ToDo;
            Priority = Priority.undefined;
        }
    }
}
