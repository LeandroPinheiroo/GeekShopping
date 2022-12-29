using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;

namespace GeekShopping.ProductAPI.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public List<ProductVO> FindAll()
        {
            List<Product> products = _productRepository.FindAll().ToList();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public ProductVO FindById(long id)
        {
            Product product = _productRepository.FindById(id);
            return _mapper.Map<ProductVO>(product);
        }
        public ProductVO update(ProductVO vo)
        {
            Product product = _productRepository.Update(_mapper.Map<Product>(vo));
            return _mapper.Map<ProductVO>(product);
        }

        public ProductVO Save(ProductVO vo)
        {
            Product product = _productRepository.Save(_mapper.Map<Product>(vo));
            return _mapper.Map<ProductVO>(product);
        }
    }
}
