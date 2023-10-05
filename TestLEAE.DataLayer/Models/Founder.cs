using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLEAE.DataLayer;

public class Founder
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("Client")]
    public Guid IdClient { get; set; }
    public int Inn { get; set; }
    public string? Fio { get; set; }
    public DateTime DateToAdd { get; set;}
    public DateTime DateToUpdate { get; set;}
}

