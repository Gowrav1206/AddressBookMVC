using AutoMapper;
using AddressBook.Models;
using AddressBook.ViewModels;

namespace AddressBook.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactView>()
            .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.ContactId))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.ContactMail, opt => opt.MapFrom(src => src.ContactMail))
            .ForMember(dest => dest.ContactMobile, opt => opt.MapFrom(src => src.ContactMobile))
            .ForMember(dest => dest.ContactLandline, opt => opt.MapFrom(src => src.ContactLandline))
            .ForMember(dest => dest.ContactWebsite, opt => opt.MapFrom(src => src.ContactWebsite))
            .ForMember(dest => dest.ContactDoorNumber, opt => opt.MapFrom(src => src.ContactAddress.Split()[0].Trim()))
            .ForMember(dest => dest.ContactStreet, opt => opt.MapFrom(src => src.ContactAddress.Split()[1].Trim()))
            .ForMember(dest => dest.ContactCity, opt => opt.MapFrom(src => src.ContactAddress.Split()[2].Trim()));

            CreateMap<ContactView, Contact>()
            .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.ContactId))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.ContactMail, opt => opt.MapFrom(src => src.ContactMail))
            .ForMember(dest => dest.ContactMobile, opt => opt.MapFrom(src => src.ContactMobile))
            .ForMember(dest => dest.ContactLandline, opt => opt.MapFrom(src => src.ContactLandline))
            .ForMember(dest => dest.ContactWebsite, opt => opt.MapFrom(src => src.ContactWebsite))
            .ForMember(dest => dest.ContactAddress, opt => opt.MapFrom(src => $"{src.ContactDoorNumber} {src.ContactStreet} {src.ContactCity}"));
        }
    }
}
