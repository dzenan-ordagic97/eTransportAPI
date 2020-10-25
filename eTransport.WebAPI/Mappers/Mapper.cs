using AutoMapper;
using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Database.User, Model.User>().ReverseMap();
            CreateMap<Model.Requests.ApplicationUserCreateRequest, Model.User>().ReverseMap();
            CreateMap<ApplicationUserCreateRequest, Database.User>().ReverseMap();
            CreateMap<Database.VehicleType, Model.VehicleType>().ReverseMap();
            CreateMap<Database.VehicleModel, Model.VehicleModel>().ReverseMap();
            CreateMap<Database.VehicleDetails, Model.VehicleDetails>().ReverseMap();
            CreateMap<Database.Vehicle, Model.Vehicle>().ForMember(dest=>dest.VehicleModel,
                                                                   opts=>opts.MapFrom(src=>src.VehicleModel.Name))
                                                        .ForMember(dest => dest.VehicleType,
                                                                   opts => opts.MapFrom(src => src.VehicleType.Name)).ReverseMap();
            CreateMap<Database.ExtraServices, Model.ExtraServices>().ReverseMap();
            CreateMap<Database.Carrier, Model.Carrier>().ReverseMap();
            CreateMap<Database.Country, Model.Country>().ReverseMap();
            CreateMap<Database.City, Model.City>().ReverseMap();
            CreateMap<Database.CargoReservation, Model.CargoReservation>().ForMember(dest => dest.Client,
                                                                   opts => opts.MapFrom(src => src.Client.FirstName + " " + src.Client.LastName)).ReverseMap();
            CreateMap<Database.Cargo, Model.Cargo>().ReverseMap();
            CreateMap<Database.Freight, Model.Freight>().ReverseMap();
            CreateMap<Database.CommentRating, Model.CommentRating>().ForMember(dest => dest.Client,
                                                                   opts => opts.MapFrom(src => src.Client.FirstName + " " + src.Client.LastName)).ReverseMap();
            CreateMap<Database.Client, Model.Client>().ReverseMap();
            CreateMap<Database.RatingCarrier, Model.RatingCarrier>().ReverseMap();







        }
    }
}
