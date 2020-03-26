using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SimpleEfCore.API.Controllers
{
    [ApiController]
    [Route("api/v1/workbooks")]
    public class WorkbookController : ControllerBase
    {
        public WorkbookController()
        {
        }

        [Route("{workbookId}")]
        [HttpGet]
        public async Task<ActionResult> GetWorkbookByIdAsync(string workbookId)
        {

            return Ok();
        }
    }
}
