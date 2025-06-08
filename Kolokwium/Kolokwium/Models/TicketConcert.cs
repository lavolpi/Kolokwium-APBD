using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models;

[Table("TicketConcert")]
public class TicketConcert
{
    [Key]
    public int TicketConcertId { get; set; }
    
    [Required]
    public int TicketId { get; set; }
    
    [ForeignKey("TicketId")]
    public Ticket Ticket { get; set; }
    
    [Required]
    public int ConcertId { get; set; }
    
    [ForeignKey("ConcertId")]
    public Concert Concert { get; set; }
    
    [Required, Precision(10, 2)]
    public decimal Price { get; set; }
    
    [Required]
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
}