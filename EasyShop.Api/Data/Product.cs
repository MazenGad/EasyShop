namespace EasyShop.Api.Data
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

		public ICollection<ProductImages>? ProductImages { get; set; }
	}
}
