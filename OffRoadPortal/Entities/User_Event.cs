namespace OffRoadPortal.Entities;

public class User_Event
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }

    public long EventId { get; set; }
    public Event Event { get; set; }
}
