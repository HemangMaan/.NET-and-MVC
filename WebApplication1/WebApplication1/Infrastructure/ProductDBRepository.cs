using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class ProductDBRepository : IRepository<Product, int>
    {
        public void AddNew(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindAll()
        {
            throw new NotImplementedException();
        }

        public Product FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
