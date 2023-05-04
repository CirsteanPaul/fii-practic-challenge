using hackatonBackend.ProjectServices.Services.Common.ToDo;

namespace hackatonBackend.ProjectServices.Services.Common.ToDoList
{
    public sealed class CreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance Importance { get; set; }
    }
}
