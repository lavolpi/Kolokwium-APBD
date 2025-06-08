using System.ComponentModel.DataAnnotations;
using Kolokwium.Models;

namespace Kolokwium.DTO;

public class ClientPurchaseDTO
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    public List<PurchasedTicketDTO> PurchasedTickets { get; set; }
}

public class PurchasedTicketDTO
{
    [Required]
    public DateTime PurchaseDate { get; set; }
    
    [Required]
    public TicketConcertDTO TicketConcert { get; set; }
}

public class TicketConcertDTO
{
    public decimal Price { get; set; }
    
    public TicketDTO Ticket { get; set; }
}

public class TicketDTO
{
    public string SerialNumber { get; set; }
    
    public int SeatNumber { get; set; }
}