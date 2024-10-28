using AutoMapper;
using OrderServiceApp.Dtos;
using OrderServiceApp.Models;

namespace OrderServiceApp;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
        CreateMap<CreateBookRequestDto, Book>();
        CreateMap<UpdateBookRequestDto, Book>();
    }
}