using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkDesignPattern;

public class CustomerRepository : ICustomerRepository
{
    private ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async void Add(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }
}