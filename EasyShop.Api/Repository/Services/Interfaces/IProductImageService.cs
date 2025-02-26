using EasyShop.Api.Data;

namespace EasyShop.Api.Repository.Services.Interfaces
{
	public interface IProductImageService
	{
		Task<IEnumerable<ProductImages>> GetImagesByProductIdAsync(int productId);
		Task<ProductImages> AddImageAsync(ProductImages image);
		Task<bool> DeleteImageAsync(int id);
	}
}
