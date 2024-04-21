using AutoMapper;

namespace ToDoList.Models.DTOs.Mappings;

public class ToDoMapping : Profile
{
    public ToDoMapping()
    {
        CreateMap<ToDoItem, ToDoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueTime, opt => opt.MapFrom(src => src.DueTime))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
        
        CreateMap<CreateToDoDto, ToDoItem>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueTime, opt => opt.MapFrom(src => src.DueTime))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
        
        CreateMap<CreateToDoDto, ToDoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueTime, opt => opt.MapFrom(src => src.DueTime))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
        
        CreateMap<UpdateToDoDto, ToDoItem>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueTime, opt => opt.MapFrom(src => src.DueTime))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
        
        CreateMap<UpdateToDoDto, ToDoDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueTime, opt => opt.MapFrom(src => src.DueTime))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority));
    }
}