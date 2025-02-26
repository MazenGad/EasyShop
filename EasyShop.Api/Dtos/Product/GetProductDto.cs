namespace EasyShop.Api.Dtos.Product
{
	public class GetProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public ICollection<string> ProductImages { get; set; }
	}
}
