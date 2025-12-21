using System.Security.Claims;
using System.Threading.Tasks;
using BaseChord.Api.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands.CreateUserCommand;
using UserService.Application.Commands.UpdateUserCommand;
using UserService.Application.Queries.HasUserQuery;

namespace UserService.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ProfileController : BaseController
{
    public ProfileController(ISender sender) : base(sender)
    {
    }

    [Route("HasProfile")]
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<bool>> HasUser()
    {
        HasUserQuery query = new HasUserQuery() { ExternalIdentifier = GetExternalIdentifier() };

        return await Sender.Send(query);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<bool>> CreateUser([FromBody] CreateUserCommand command)
    {
        command.ExternalIdentifier = GetExternalIdentifier();

        return await Sender.Send(command);
    }

    [HttpPatch]
    [Authorize]
    public async Task<ActionResult<bool>> UpdateUser([FromBody] UpdateUserCommand command)
    {
        command.ExternalIdentifier = GetExternalIdentifier();

        return await Sender.Send(command);
    }
}
