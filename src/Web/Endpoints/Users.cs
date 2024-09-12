using IndigoSoftTestTask.Application.Users.Commands;
using IndigoSoftTestTask.Application.Users.Queries;

namespace IndigoSoftTestTask.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetUserIPs, "{userId}/user-ips")
            .MapGet(FindUsersByIpPart, "users-by-ip")
            .MapGet(GetLastConnection, "{userId}/last-connection")
            .MapPost(AddConnection, "{userId}/connection");
    }

    public async Task<IEnumerable<UserVm>> FindUsersByIpPart(ISender sender, string ipPart)
        => await sender.Send(new FindUsersByIpPartQuery(ipPart));

    public async Task<IEnumerable<UserIPVm>> GetUserIPs(ISender sender, long userId)
        => await sender.Send(new GetAllUserIPsQuery(userId));

    public async Task<UserIPVm> GetLastConnection(ISender sender, long userId)
       => await sender.Send(new GetLastConnectionInfoQuery(userId));

    public async Task<IResult> AddConnection(ISender sender, long userId, AddUserConnectionCommand request)
    {
        request.UserId = userId;

        await sender.Send(request);
        return Results.Ok();
    }
}
