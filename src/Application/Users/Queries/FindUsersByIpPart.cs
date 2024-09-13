using IndigoSoftTestTask.Application.Common.Interfaces;

namespace IndigoSoftTestTask.Application.Users.Queries;

public record FindUsersByIpPartQuery(string IpPart) : IRequest<IReadOnlyCollection<UserVm>>;

internal class FindUsersByIpPartQueryHandler : IRequestHandler<FindUsersByIpPartQuery, IReadOnlyCollection<UserVm>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public FindUsersByIpPartQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<UserVm>> Handle(FindUsersByIpPartQuery request, CancellationToken cancellationToken)
    {
        var items = _context.Users.Include(x => x.UserIPs).ToList();
        return await _context.UserIPs.Where(uip => uip.IPAddress.Contains(request.IpPart))
        .Select(e => e.User)
        .Distinct()
        .ProjectTo<UserVm>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
    }

    //public async Task<IReadOnlyCollection<UserVm>> Handle(FindUsersByIpPartQuery request, CancellationToken cancellationToken)
    //    => await _context.UserIPs.Where(uip => uip.IPAddress.Contains(request.IpPart))
    //    .Select(e => e.User)
    //    .Distinct()
    //    .ProjectTo<UserVm>(_mapper.ConfigurationProvider)
    //    .ToListAsync(cancellationToken);
}
