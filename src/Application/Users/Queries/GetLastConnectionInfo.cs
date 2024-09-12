using IndigoSoftTestTask.Application.Common.Interfaces;

namespace IndigoSoftTestTask.Application.Users.Queries;

public record GetLastConnectionInfoQuery(long UserId) : IRequest<UserIPVm>;

internal class GetLastConnectionInfoQueryHandler : IRequestHandler<GetLastConnectionInfoQuery, UserIPVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLastConnectionInfoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserIPVm> Handle(GetLastConnectionInfoQuery request, CancellationToken cancellationToken)
    {
        var userIp = await _context.UserIPs.Where(x => x.UserId == request.UserId)
            .OrderByDescending(x => x.ConnectedAt)
            .FirstOrDefaultAsync(cancellationToken);


        if (userIp == null)
        {
            throw new NotFoundException(request.UserId.ToString(), nameof(userIp));
        }

         return _mapper.Map<UserIPVm>(userIp);
    }
}
