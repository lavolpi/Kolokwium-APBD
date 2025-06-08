using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models;
[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    [Required, StringLength(50)]
    public string FirstName { get; set; }
    
    [Required, StringLength(100)]
    public string LastName { get; set; }
    
    [StringLength(100)]
    public String PhoneNumber { get; set; }
    
    [Required]
    public ICollection<PurchasedTicket> PurchasedTickets { get; set; }
}