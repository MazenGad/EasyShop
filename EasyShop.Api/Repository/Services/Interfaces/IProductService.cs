using EasyShop.Api.Data;
using EasyShop.Api.Dtos.Product;

namespace EasyShop.Api.Repository.Services.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
		Task<GetProductDto> GetProductByIdAsync(int id);
		Task<GetProductDto> AddProductAsync(AddProductDto product);
		Task<GetProductDto> UpdateProductAsync(int id ,AddProductDto product);
		Task<bool> DeleteProductAsync(int id);
	}

}
