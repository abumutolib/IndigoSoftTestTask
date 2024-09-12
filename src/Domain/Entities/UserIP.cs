namespace IndigoSoftTestTask.Domain.Entities;

public class UserIP
{
    public int Id { get; set; }
    public string IPAddress { get; set; }
    public DateTimeOffset ConnectedAt { get; set; }
    public long UserId { get; set; }
    public virtual User User { get; set; }
}
