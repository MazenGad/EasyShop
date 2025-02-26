using EasyShop.Api.Data;

namespace EasyShop.Api.Dtos.Product
{
	public class AddProductDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public ICollection<string> ProductImages { get; set; }
	}
}
