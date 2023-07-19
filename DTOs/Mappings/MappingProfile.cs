using AutoMapper;
using ConstruAppAPI.Models;

namespace ConstruAppAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderDTO>().ReverseMap();
            CreateMap<PurchaseOrderItem, PurchaseOrderItemDTO>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
            CreateMap<UserAdmin, UserAdminDTO>().ReverseMap();
            CreateMap<UserClient, UserClientDTO>().ReverseMap();
            CreateMap<UserSeller, UserSellerDTO>().ReverseMap();
        }
    }
}
