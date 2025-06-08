using Kolokwium.Data;
using Kolokwium.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services;

public class PurchasesService : IPurchasesService
{
    private readonly DatabaseContext _context;

    public PurchasesService(DatabaseContext context)
    {
        _context = context;
    }
    //implementacja metody z interfejsu
    //public async Task<Typ> ZrobCosTam

    public async Task<List<ClientPurchaseDTO>> GetPurchases(int id)
    {
        var result = await _context.Customers.Where(c => c.CustomerId == id)
            .Select(c => new ClientPurchaseDTO
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                PurchasedTickets = c.PurchasedTickets
                    .Select(pt => new PurchasedTicketDTO
                    {
                        PurchaseDate = pt.PurchaseDate,
                        TicketConcert = new TicketConcertDTO
                        {
                            Price = pt.TicketConcert.Price,
                            Ticket = new TicketDTO
                            {
                                SerialNumber = pt.TicketConcert.Ticket.SerialNumber,
                                SeatNumber = pt.TicketConcert.Ticket.SeatNumber,
                            }
                        }
                    }).ToList()
            }).ToListAsync();
        
        return result;
    }
    
    
}