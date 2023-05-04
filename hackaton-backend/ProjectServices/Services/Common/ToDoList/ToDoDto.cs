using hackatonBackend.ProjectData.Entities;

namespace hackatonBackend.ProjectServices.Services.Common.ToDo
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance Importance { get; set; }
        public int AuthorId { get; set; }
        public User User { get; set; }
    }
}
