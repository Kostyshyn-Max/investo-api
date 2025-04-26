namespace Investo.DataAccess.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("investments")]
public class Investment : AbstractEntity<int>
{
    [Column("owner_id")]
    [ForeignKey(nameof(Owner))]
    public Guid OwnerId { get; set; }
    
    public User Owner { get; set; } = null!;
    
    [Column("proposal_id")]
    [ForeignKey(nameof(Proposal))]
    public int ProposalId { get; set; }
    
    public RealEstate Proposal { get; set; } = null!;
    
    [Column("invested_sum")]
    public int InvestedSum { get; set; }
    
    [Column("added_at")]
    public DateTime AddedAt { get; set; }
}