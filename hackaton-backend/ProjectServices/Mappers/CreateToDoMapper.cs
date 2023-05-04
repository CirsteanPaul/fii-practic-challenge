using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Common.ToDoList;

namespace hackatonBackend.ProjectServices.Mappers
{
    public static class CreateToDoMapper
    {
        public static ToDo ToEntity(this CreateDto ToDoDto ) {
            return new ToDo 
            {
                Title = ToDoDto.Title,
                Description = ToDoDto.Description,
                Importance = ToDoDto.Importance,
            };
        }
    }
}
