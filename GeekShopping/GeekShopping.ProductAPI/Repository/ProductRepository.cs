using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(MySQLContext context) : base(context)
        {
        }

    }
}
