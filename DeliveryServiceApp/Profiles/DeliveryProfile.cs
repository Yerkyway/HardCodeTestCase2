using AutoMapper;
using DeliveryServiceApp.Dto;
using DeliveryServiceApp.Models;
using OrderServiceApp.Dtos;
using OrderServiceApp.Models;

namespace DeliveryServiceApp.Profiles;

public class DeliveryProfile : Profile
{
    public DeliveryProfile()
    {
        CreateMap<Delivery, DeliveryDto>();
        CreateMap<CreateDeliveryRequestDto, Delivery>();
        CreateMap<UpdateDeliveryRequestDto, Delivery>();
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
        CreateMap<CreateBookRequestDto, Book>();
        CreateMap<UpdateBookRequestDto, Book>();
    }
}