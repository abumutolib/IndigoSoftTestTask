namespace IndigoSoftTestTask.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } // Можем добавить, если необходимо
    public virtual ICollection<UserIP> UserIPs { get; set; }

    public User()
    {
        UserIPs = new HashSet<UserIP>();
    }
}
