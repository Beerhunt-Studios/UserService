using System.Security.Claims;
using System.Threading.Tasks;
using BaseChord.Api.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Queries.HasUserQuery;

namespace UserService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    public UserController(ISender sender) : base(sender)
    {
    }

    [Route("HasUser")]
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<bool>> HasUser()
    {
        HasUserQuery query = new HasUserQuery() { ExternalIdentifier = (HttpContext.User.Identity as ClaimsIdentity).FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value };

        return await Sender.Send(query);
    }
}
