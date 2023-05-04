using hackatonBackend.ProjectServices.Services.Common.ToDo;
using hackatonBackend.ProjectServices.Services.Common.ToDoList;
using hackatonBackend.WebApi.Models.ToDoList;

namespace hackatonBackend.WebApi.Mappers
{
    public static class CreateMapper
    {
        public static CreateDto ToDto(this CreateRequest model)
        {
            if (model is null)
            {
                return null;
            }

            return new CreateDto
            {
                Title = model.Title,
                Description = model.Description,
                Importance = (Importance)model.Importance,
            };
        }
    } 
}
