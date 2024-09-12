using System.Text.Json.Serialization;
using IndigoSoftTestTask.Domain.Entities;
using IndigoSoftTestTask.Application.Common.Interfaces;

namespace IndigoSoftTestTask.Application.Users.Commands;

public record class AddUserConnectionCommand : IRequest
{
    [JsonIgnore]
    public long UserId { get; set; }
    public string IpAddress { get; set; }
}

internal class AddUserConnectionCommandHandler : IRequestHandler<AddUserConnectionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly TimeProvider _timeProvider;

    public AddUserConnectionCommandHandler(IApplicationDbContext context, TimeProvider timeProvider)
    {
        _context = context;
        _timeProvider = timeProvider;
    }

    public async Task Handle(AddUserConnectionCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync([request.UserId], cancellationToken);

        if (user == null)
        {
            user = new User { Id = request.UserId };

            _context.Users.Add(user);
        }

        var userIp = new UserIP
        {
            User = user,
            IPAddress = request.IpAddress,
            ConnectedAt = _timeProvider.GetUtcNow()
        };

        _context.UserIPs.Add(userIp);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
