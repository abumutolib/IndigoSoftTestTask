using IndigoSoftTestTask.Domain.Entities;

namespace IndigoSoftTestTask.Application.Users.Queries;

public class UserVm
{
    public long Id { get; set; }
    public string Name { get; set; }

    public IReadOnlyCollection<UserIPVm> UserIPs { get; set; } = Array.Empty<UserIPVm>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserVm>();
        }
    }
}
