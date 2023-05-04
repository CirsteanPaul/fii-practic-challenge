using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Constants;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;

namespace hackatonBackend.ProjectServices.Services.Common.ToDoList
{
    public class ToDoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration config;
        public ToDoService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.config = config;
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
