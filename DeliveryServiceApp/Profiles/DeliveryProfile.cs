using AutoMapper;
using DeliveryServiceApp.Dto;
using DeliveryServiceApp.Models;

namespace DeliveryServiceApp.Profiles;

public class DeliveryProfile : Profile
{
    public DeliveryProfile()
    {
        CreateMap<Delivery, DeliveryDto>();
        CreateMap<CreateDeliveryRequestDto, Delivery>();
        CreateMap<UpdateDeliveryRequestDto, Delivery>();
    }
}