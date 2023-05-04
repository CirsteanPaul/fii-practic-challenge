using hackatonBackend.ProjectServices.Services.Common.ToDoList;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models.Common;
using hackatonBackend.WebApi.Models.ToDoList;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
    [Route("api/tasks")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoService toDoService;
        
        public ToDoListController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult CreateToDo(CreateRequest createRequest)
        {
            var createDto = createRequest.ToDto();
            toDoService.CreateToDo(createDto);
            return Ok();
        }
      /*  public IActionResult Index()
        {
            return View();
        }*/
    }
}
