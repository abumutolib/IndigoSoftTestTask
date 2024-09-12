using IndigoSoftTestTask.Application.Common.Interfaces;

namespace IndigoSoftTestTask.Application.Users.Queries;

public record GetAllUserIPsQuery(long UserId) : IRequest<IReadOnlyCollection<UserIPVm>>;

internal class GetAllUserIPsQueryHandler : IRequestHandler<GetAllUserIPsQuery, IReadOnlyCollection<UserIPVm>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUserIPsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<UserIPVm>> Handle(GetAllUserIPsQuery request, CancellationToken cancellationToken)
        => await _context.UserIPs.Where(x => x.UserId == request.UserId)
        .ProjectTo<UserIPVm>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
}
