using AutoMapper;
using EasyShop.Api.Data;
using EasyShop.Api.Dtos.Product;

namespace EasyShop.Api.AutoMapper
{
	public class MapperProfile : Profile
	{
		public MapperProfile() 
		{	
			CreateMap<Product, GetProductDto>()
				.ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages.Select(pi => pi.ImageUrl).ToList()));

			CreateMap<AddProductDto, Product>()
						   .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src =>
							   src.ProductImages.Select(url => new ProductImages { ImageUrl = url })));

			CreateMap<ProductImages, string>()
				.ConstructUsing(src => src.ImageUrl);

			CreateMap<string, ProductImages>()
				.ConstructUsing(src => new ProductImages { ImageUrl = src });

			CreateMap<Product, Product>()
				.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


		}
	}
}
