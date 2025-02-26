using AutoMapper;
using EasyShop.Api.Data;
using EasyShop.Api.Dtos.Product;
using EasyShop.Api.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Api.Repository.Implementation
{
	public class ProductService : IProductService
	{
		private readonly ShopContext _context;
		private readonly IMapper _mapper;

		public ProductService(ShopContext context , IMapper mapper )
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<IEnumerable<GetProductDto>> GetAllProductsAsync()
		{
			var products = await _context.Products
				   .Include(p => p.ProductImages)
				   .ToListAsync();

			return _mapper.Map<IEnumerable<GetProductDto>>(products);


		}

		public async Task<GetProductDto> GetProductByIdAsync(int id)
		{
			var product =  await _context.Products
				.Include(p => p.ProductImages)
				.FirstOrDefaultAsync(p => p.Id == id);

			return _mapper.Map<GetProductDto>(product);
		}

		public async Task<GetProductDto> AddProductAsync(AddProductDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);

			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return _mapper.Map<GetProductDto>(product);
		}

		public async Task<GetProductDto> UpdateProductAsync(int id , AddProductDto productDto)
		{
			var product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return null;

            _mapper.Map(productDto, product);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetProductDto>(product);
		}

		public async Task<bool> DeleteProductAsync(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null) return false;

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return true;
		}
	}

}
