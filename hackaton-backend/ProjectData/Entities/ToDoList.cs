namespace hackatonBackend.ProjectData.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        IList<ToDo> tasks;
    }
}
