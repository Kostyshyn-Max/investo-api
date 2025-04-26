namespace Investo.DataAccess.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("startups")]
public class Startup : AbstractEntity<int>
{
    [Column("publisher_id")]
    [ForeignKey(nameof(Publisher))]
    public Guid PublisherId { get; set; }
    
    public User Publisher { get; set; }
    
    [Column("title")]
    public string Title { get; set; } = string.Empty;
    
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    
    [Column("is_approved")]
    public bool IsApproved { get; set; }
    
    [Column("publish_date")]
    public DateTime PublishDate { get; set; }
    
    [Column("location")]
    public string? Location { get; set; }
    
    [Column("payback_period")]
    public int PaybackPeriod { get; set; }
    
    [Column("payback_success_coef")]
    public int PaybackSuccessCoef { get; set; }
}