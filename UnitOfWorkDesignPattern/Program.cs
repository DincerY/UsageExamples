using UnitOfWorkDesignPattern;

using (var unitOfWork = new UnitOfWork())
{
    var orders = new List<Order>()
    {
        new Order() { CustomerId = 1 },
        new Order() { CustomerId = 1 },
        new Order() { CustomerId = 1 },
        new Order() { CustomerId = 1 },
    };
    var customer = new Customer() { Name = "Dincer", Surname = "Yigit" };

    var repository = unitOfWork.CustomerRepository;
    repository.Add(customer);
    unitOfWork.Save();
}


Console.WriteLine("Hello, World!");