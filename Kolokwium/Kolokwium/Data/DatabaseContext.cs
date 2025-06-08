using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Data;

public class DatabaseContext : DbContext
{
    /*Tu tworzymy obiekty bazy danych
    public DbSet<Klasa> NazwaKlasy {get; set;}    
    */
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    
    protected DatabaseContext(){}
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>().HasData(new List<Concert>()
        {
            new Concert() {ConcertId = 1, Name = "Zorza festival", Date = new DateTime(2025, 8, 7), AvailableTickets = 5000},
            new Concert() {ConcertId = 2, Name = "Roztanczony Narodowy", Date = new DateTime(2027, 4, 3), AvailableTickets = 20000}
        });

        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>()
        {
            new Ticket() {TicketId = 1, SerialNumber = "A123", SeatNumber = 50},
            new Ticket() {TicketId = 2, SerialNumber = "B456", SeatNumber = 100},
            new Ticket() {TicketId = 3, SerialNumber = "C789", SeatNumber = 150},
            new Ticket() {TicketId = 4, SerialNumber = "D247", SeatNumber = 200},
        });
        
        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>()
        {
            new TicketConcert() {TicketConcertId = 1, TicketId = 1, ConcertId = 1, Price = 200},
            new TicketConcert() {TicketConcertId = 2, TicketId = 2, ConcertId = 1, Price = 400},
            new TicketConcert() {TicketConcertId = 3, TicketId = 3, ConcertId = 2, Price = 600},
            new TicketConcert() {TicketConcertId = 4, TicketId = 4, ConcertId = 2, Price = 800}
        });
        
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer() {CustomerId = 1, FirstName = "Damian", LastName = "Lewandowski", PhoneNumber = "123456789"},
            new Customer() {CustomerId = 2, FirstName = "Janek", LastName = "Dobrowolski", PhoneNumber = "324567912"},
            new Customer() {CustomerId = 3, FirstName = "Wojtek", LastName = "Szczesny", PhoneNumber = "754921283"},
            new Customer() {CustomerId = 4, FirstName = "Olaf", LastName = "Piatek", PhoneNumber = "384732193"},
        });
        
        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>()
        {
            new PurchasedTicket() {TicketConcertId = 2, CustomerId = 4, PurchaseDate = new DateTime(2025, 9, 9)},
            new PurchasedTicket() {TicketConcertId = 4, CustomerId = 1, PurchaseDate = new DateTime(2027, 6, 3)},
        });
        
        modelBuilder.Entity<PurchasedTicket>()
            .HasKey(p => new {p.TicketConcertId, p.CustomerId});
    }
}