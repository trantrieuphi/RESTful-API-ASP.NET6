using AutoMapper;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<BookModel, Book>();
        }   
    }
}
