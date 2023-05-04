using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Constants;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;

namespace hackatonBackend.ProjectServices.Services.Common.ToDoList
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;

        public ToDoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateToDo(CreateDto dto)
        {
            var existingtodo = unitOfWork.ToDos.GetToDoByTitle(dto.Title);

            if(existingtodo is not null)
            {
                throw new BusinessException(ErrorCodes.GenericRegisterError,
                    "Title already in use");
            }
            var todoEntity = dto.ToEntity();
            unitOfWork.ToDos.Add(todoEntity);
            unitOfWork.SaveChanges();
        }
    }
}
