using IndigoSoftTestTask.Domain.Entities;

namespace IndigoSoftTestTask.Application.Users.Queries;

public class UserIPVm
{
    public int Id { get; set; }
    public string IPAddress { get; set; }
    public string ConnectedAt { get; set; }
    public long UserId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserIP, UserIPVm>();
                //.ForMember(d => d.ConnectedAt, opt => opt.MapFrom(s => s.ConnectedAt.Offset.ToString()));
        }
    }
}
