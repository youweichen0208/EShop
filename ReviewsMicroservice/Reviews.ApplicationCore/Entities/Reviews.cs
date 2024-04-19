namespace Reviews.ApplicationCore.Entities;

public class Reviews
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Comment { get; set; }
    public DateTime Time { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
}