using DbWriter.DbAccess;
using DbWriter.DbAccess.Models;
using DbWriter.src.DTO;
using DbWriter.src.Interfaces;

namespace DbWriter.src.Services
{
    public class Writer : IDbWriter
    {
        private readonly AppDbContext _context;
        private int _res = 0;
        private bool _productSkipped = false;
        public Writer(AppDbContext context) 
        { 
            _context = context;
        }
        public int Write(IEnumerable<XOrder> orders)
        {
            foreach (var order in orders)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var customer = _context.Customers.FirstOrDefault(c => c.Name == order.User.Name && c.Email == order.User.Email);
                        if (customer is null)
                        {
                            _context.Customers.Add(new Customer() { Name = order.User.Name, Email = order.User.Email });
                            _context.SaveChanges();
                        }
                        customer = _context.Customers.FirstOrDefault(c => c.Name == order.User.Name && c.Email == order.User.Email);

                        _context.Orders.Add(new Order() { No = order.No, Customer = customer, Sum = order.Sum, CustomerId = customer.Id, DateTime = order.RegDate });
                        _context.SaveChanges();
                        var newOrder = _context.Orders.Where(no => no.No == order.No).FirstOrDefault();

                        _productSkipped = false;

                        foreach (var prod in order.Products)
                        {
                            var dbProd = _context.Products.FirstOrDefault(p => p.Name == prod.Name);

                            if (dbProd is null)
                            {
                                _productSkipped = true;
                                continue;
                            }
                            if (dbProd.Quantity < prod.Quantity)
                            {
                                _productSkipped = true;
                                continue;
                            }

                            _context.OrderProducts.Add(new OrderProduct() { OrderId = newOrder.Id, ProductId = dbProd.Id, Quantity = prod.Quantity });
                            dbProd.Quantity -= prod.Quantity;
                            _context.SaveChanges();
                        }

                        if (!_productSkipped)
                        {
                            _res++;
                            order.Writed = true;
                        }
                        
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }

            return _res;
        }
    }
}
