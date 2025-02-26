using EasyShop.Api.Data;
using EasyShop.Api.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Api.Repository.Implementation
{
	public class ProductImageService : IProductImageService
	{
		private readonly ShopContext _context;

		public ProductImageService(ShopContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ProductImages>> GetImagesByProductIdAsync(int productId)
		{
			return await _context.ProductImages
			.Where(pi => pi.ProductId == productId)
			.ToListAsync();
		}

		public async Task<ProductImages> AddImageAsync(ProductImages image)
		{
			_context.ProductImages.Add(image);
			await _context.SaveChangesAsync();
			return image;
		}

		public async Task<bool> DeleteImageAsync(int id)
		{
			var image = await _context.ProductImages.FindAsync(id);
			if (image == null) return false;

			_context.ProductImages.Remove(image);
			await _context.SaveChangesAsync();
			return true;
		}
	}

}
