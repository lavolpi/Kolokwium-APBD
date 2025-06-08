using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models;

[Table("Ticket")]
public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    
    [Required, StringLength(50)]
    public string SerialNumber { get; set; }
    
    [Required]
    public int SeatNumber { get; set; }
    
    [Required]
    public ICollection<TicketConcert> TicketConcerts { get; set; }
}