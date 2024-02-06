namespace UnitOfWorkDesignPattern;

public class UnitOfWork : IDisposable
{
    private readonly ApplicationDbContext _context;
    private CustomerRepository _customerRepository;

    public UnitOfWork()
    {
        _context = new ApplicationDbContext();
    }
    
    public CustomerRepository CustomerRepository
    {
        get
        {
            if (_customerRepository == null)
            {
                _customerRepository = new CustomerRepository(_context);
            }
            return _customerRepository;
        }
    }
    
    public void Save()
    {
        try
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        catch (Exception e)
        {
            // TODO: Hata işleme alanı
        }
    }

    private bool disposed = false;
    

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}