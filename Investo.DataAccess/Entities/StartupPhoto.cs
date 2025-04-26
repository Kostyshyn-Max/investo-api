namespace Investo.DataAccess.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("startup_photos")]
public class StartupPhoto : AbstractEntity<int>
{
    [Column("startup_id")]
    [ForeignKey(nameof(Startup))]
    public int StartupId { get; set; }
    
    public Startup Startup { get; set; } = null!;
    
    [Column("url")]
    public string Url { get; set; } = string.Empty;
}