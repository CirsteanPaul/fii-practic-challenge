using hackatonBackend.ProjectServices.Services.Common.ToDo;
namespace hackatonBackend.ProjectData.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Importance { get; set; }
        public int AuthorId { get; set; }
        public User User { get; set; }

    }
}
