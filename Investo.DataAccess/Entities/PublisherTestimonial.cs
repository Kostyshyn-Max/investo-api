namespace Investo.DataAccess.Entities;

using System.ComponentModel.DataAnnotations.Schema;

[Table("publisher_testimonials")]
public class PublisherTestimonial : AbstractEntity<int>
{
    [Column("author_id")]
    [ForeignKey(nameof(Author))]
    public Guid AuthorId { get; set; }
    
    public User Author { get; set; } = null!;
    
    [Column("publisher_id")]
    [ForeignKey(nameof(Publisher))]
    public Guid PublisherId { get; set; }
    
    public User Publisher { get; set; } = null!;
    
    [Column("title")]
    public string Title { get; set; } = string.Empty;
    
    [Column("rate")]
    public int Rate { get; set; }
    
    [Column("publish_date")]
    public DateTime PublishDate { get; set; }
}