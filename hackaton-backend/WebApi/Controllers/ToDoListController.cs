using hackatonBackend.ProjectServices.Services.Common.ToDoList;
using hackatonBackend.WebApi.Mappers;
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
        public ActionResult CreateToDo([FromBody] CreateRequest createRequest)
        {
            var createDto = createRequest.ToDto();
            toDoService.CreateToDo(createDto);
            return StatusCode(201);
        }
      /*  public IActionResult Index()
        {
            return View();
        }*/
    }
}
