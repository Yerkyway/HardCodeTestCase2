using AutoMapper;
using OrderServiceApp.Dtos;
using OrderServiceApp.Models;

namespace OrderServiceApp.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile() 
    {
        CreateMap<Orders, OrderDto>();
        CreateMap<OrderDto, Orders>();
        CreateMap<CreateOrderRequestDto, Orders>();
        CreateMap<UpdateOrderRequestDto, Orders>();
    }
}