using hackatonBackend.ProjectServices.Services.Common.ToDo;
using System.ComponentModel.DataAnnotations;

namespace hackatonBackend.WebApi.Models.ToDoList
{
    public class CreateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required] 
        public string Description { get; set; }
        public short Importance { get; set;}
    }
}
