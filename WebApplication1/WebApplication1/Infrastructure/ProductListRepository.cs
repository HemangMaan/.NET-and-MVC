using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class ProductListRepository : IRepository<Product, int>
    {
        private static List<Product> _products;

        public ProductListRepository()
        {
            if (_products == null)
            {
                _products = new List<Product>();
                AddItemsToList();
            }
            void AddItemsToList()
            {
                _products.Add(new Product
                {
                    ProductId = 1,
                    ProductName = "Markers",
                    UnitPrice = 175,
                    UnitInStock = 50,
                    Discontinued = false
                });
                _products.Add(new Product
                {
                    ProductId = 2,
                    ProductName = "Pens",
                    UnitPrice = 10,
                    UnitInStock = 100,
                    Discontinued = false
                });
                _products.Add(new Product
                {
                    ProductId = 3,
                    ProductName = "Geometry Box",
                    UnitPrice = 150,
                    UnitInStock = 70,
                    Discontinued = true
                });
                _products.Add(new Product
                {
                    ProductId = 4,
                    ProductName = "Paper Clips",
                    UnitPrice = 100,
                    UnitInStock = 40,
                    Discontinued = false
                });
                _products.Add(new Product
                {
                    ProductId = 5,
                    ProductName = "Crayons",
                    UnitPrice = 125,
                    UnitInStock = 90,
                    Discontinued = true
                });

            }
        }

        public IEnumerable<Product> FindAll()
        {
            return _products;
        }

        public Product FindById(int id)
        {
            return _products.FirstOrDefault(c=>c.ProductId==id)!;
        }

        public void AddNew(Product entity)
        {
            if (FindById(entity.ProductId) == null)
            {
                //generate the next ProductId
                var id = _products.Max(c=>c.ProductId) + 1;
                _products.Add(entity);
            }
            else
                throw new Exception("Item already exists");
        }

        public void DeleteById(int id)
        {
            var item = FindById(id);
            if (item != null)
            {
                _products.Remove(item);
            }
        }


        public void Update(Product entity)
        {
            var item = FindById(entity.ProductId);
            if(item != null)
            {
                item.ProductName = entity.ProductName;
                item.UnitPrice = entity.UnitPrice;
                item.UnitInStock = entity.UnitInStock;
                item.Discontinued = entity.Discontinued;
            }
        }
    }
}
