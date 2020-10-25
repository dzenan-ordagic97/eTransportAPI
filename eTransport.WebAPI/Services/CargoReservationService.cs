using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class CargoReservationService : BaseCRUDService<Model.CargoReservation, Model.Requests.CargoReservationSearchRequest, Database.CargoReservation, Model.Requests.CargoReservationInsertRequest, Model.Requests.CargoReservationInsertRequest>
    {
        IAuthService _authService;

        public CargoReservationService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override List<Model.CargoReservation> Get(CargoReservationSearchRequest search)
        {
            var query = _context.Set<Database.CargoReservation>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            if (search.CarrierID != 0)
            {
                query = query.Include(x => x.Freight).ThenInclude(x => x.Carrier).Where(x => x.Freight.CarrierID == authUser.UserID);
                var list = query.Include(x => x.Cargo).Include(x => x.ExtraServices).Include(x => x.Client).Include(x => x.Freight).ThenInclude(x => x.Carrier).Select(x => new Model.CargoReservation
                {
                    CargoID = x.CargoID,
                    CargoReservationID = x.CargoReservationID,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    StartDateTransport = x.StartDateTransport,
                    EndDateTransport = x.EndDateTransport,
                    Accepted = x.Accepted,
                    Cargo = new Model.Cargo()
                    {
                        Name = x.Cargo.Name,
                        Description = x.Cargo.Description,
                        Image = x.Cargo.Image,
                        MaxHeight = x.Cargo.MaxHeight,
                        MaxWidth = x.Cargo.MaxWidth,
                        Weight = x.Cargo.Weight
                    },
                    ExtraServicesID = x.ExtraServicesID,
                    ExtraServices = new Model.ExtraServices()
                    {
                        CarrierID = x.ExtraServices.CarrierID,
                        Description = x.ExtraServices.Description,
                        Name = x.ExtraServices.Name,
                        Price = x.ExtraServices.Price
                    },
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        AcceptDate = x.Freight.AcceptDate,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName,
                            Image = x.Freight.Carrier.Image,
                            BusinessNumber = x.Freight.Carrier.BusinessNumber,
                            CarrierBusinessEmail = x.Freight.Carrier.CarrierBusinessEmail,
                            DriverLicenceNumber = x.Freight.Carrier.DriverLicenceNumber,
                            CarrierID = x.Freight.CarrierID
                        },
                        CarrierID = x.Freight.CarrierID,
                        Distance = x.Freight.Distance,

                        Finished = x.Freight.Finished,
                        Price = x.Freight.Price,
                        TransportDate = x.Freight.TransportDate,
                        ClientAccepted = x.Freight.ClientAccepted,
                        isPayed=x.Freight.IsPayed
                    },
                }).ToList();
                return list;
            }
            else if (search.isClient == true && search.isAccepted == false)
            {
                query = query.Include(x => x.ExtraServices).Include(x => x.Cargo).Include(x => x.Client).Include(x => x.Freight).ThenInclude(x => x.Carrier);
                var list = query.Where(x => x.ClientID == search.ClientID && (x.Freight == null || x.Freight.Finished == false || x.Freight.Finished == null)).Select(x => new Model.CargoReservation
                {
                    CargoID = x.CargoID,
                    CargoReservationID = x.CargoReservationID,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    StartDateTransport = x.StartDateTransport,
                    EndDateTransport = x.EndDateTransport,
                    Accepted = x.Accepted,
                    Cargo = new Model.Cargo()
                    {
                        Name = x.Cargo.Name,
                        Description = x.Cargo.Description,
                        Image = x.Cargo.Image,
                        MaxHeight = x.Cargo.MaxHeight,
                        MaxWidth = x.Cargo.MaxWidth,
                        Weight = x.Cargo.Weight
                    },
                    ExtraServicesID = x.ExtraServicesID,
                    ExtraServices = new Model.ExtraServices()
                    {
                        CarrierID = x.ExtraServices.CarrierID,
                        Description = x.ExtraServices.Description,
                        Name = x.ExtraServices.Name,
                        Price = x.ExtraServices.Price
                    },
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        AcceptDate = x.Freight.AcceptDate,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName,
                            Image = x.Freight.Carrier.Image,
                            BusinessNumber = x.Freight.Carrier.BusinessNumber,
                            CarrierBusinessEmail = x.Freight.Carrier.CarrierBusinessEmail,
                            DriverLicenceNumber = x.Freight.Carrier.DriverLicenceNumber,
                            CarrierID = x.Freight.CarrierID
                        },
                        CarrierID = x.Freight.CarrierID,
                        Finished = x.Freight.Finished,
                        Price = x.Freight.Price,
                        Distance = x.Freight.Distance,

                        TransportDate = x.Freight.TransportDate,
                        isPayed = x.Freight.IsPayed,
                        isRated = x.Freight.IsRated,
                        ClientAccepted = x.Freight.ClientAccepted
                    },
                }).ToList();
                return list;
            }
            else if (search.isClient == true && search.isAccepted == true)
            {
                query = query.Include(x => x.ExtraServices).Include(x => x.Cargo).Include(x => x.Client).Include(x => x.Freight).ThenInclude(x => x.Carrier);
                var list = query.Where(x => x.ClientID == search.ClientID && (x.Freight == null || x.Freight.Finished == false || x.Freight.Finished == null) && (x.Freight.ClientAccepted == false || x.Freight.ClientAccepted == null) && x.Accepted).Select(x => new Model.CargoReservation
                {
                    CargoID = x.CargoID,
                    CargoReservationID = x.CargoReservationID,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    StartDateTransport = x.StartDateTransport,
                    EndDateTransport = x.EndDateTransport,
                    Accepted = x.Accepted,
                    Cargo = new Model.Cargo()
                    {
                        Name = x.Cargo.Name,
                        Description = x.Cargo.Description,
                        Image = x.Cargo.Image,
                        MaxHeight = x.Cargo.MaxHeight,
                        MaxWidth = x.Cargo.MaxWidth,
                        Weight = x.Cargo.Weight
                    },
                    ExtraServicesID = x.ExtraServicesID,
                    ExtraServices = new Model.ExtraServices()
                    {
                        CarrierID = x.ExtraServices.CarrierID,
                        Description = x.ExtraServices.Description,
                        Name = x.ExtraServices.Name,
                        Price = x.ExtraServices.Price
                    },
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        AcceptDate = x.Freight.AcceptDate,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName,
                            Image = x.Freight.Carrier.Image,
                            BusinessNumber = x.Freight.Carrier.BusinessNumber,
                            CarrierBusinessEmail = x.Freight.Carrier.CarrierBusinessEmail,
                            DriverLicenceNumber = x.Freight.Carrier.DriverLicenceNumber,
                            CarrierID = x.Freight.CarrierID
                        },
                        CarrierID = x.Freight.CarrierID,
                        Finished = x.Freight.Finished,
                        Price = x.Freight.Price,
                        Distance = x.Freight.Distance,

                        TransportDate = x.Freight.TransportDate,
                        isPayed = x.Freight.IsPayed,
                        isRated = x.Freight.IsRated,
                        ClientAccepted = x.Freight.ClientAccepted
                    },
                }).ToList();
                return list;
            }
            else if (search.isFinished == true && search.Payed == true)
            {
                query = query.Include(x => x.ExtraServices).Include(x => x.Cargo).Include(x => x.Client).Include(x => x.Freight).ThenInclude(x => x.Carrier);
                var list = query.Where(x => x.ClientID == search.ClientID && x.Freight.Finished == true && (x.Freight.IsPayed == false || x.Freight.IsPayed == null)).Select(x => new Model.CargoReservation
                {
                    CargoID = x.CargoID,
                    CargoReservationID = x.CargoReservationID,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    StartDateTransport = x.StartDateTransport,
                    EndDateTransport = x.EndDateTransport,
                    Accepted = x.Accepted,
                    Cargo = new Model.Cargo()
                    {
                        Name = x.Cargo.Name,
                        Description = x.Cargo.Description,
                        Image = x.Cargo.Image,
                        MaxHeight = x.Cargo.MaxHeight,
                        MaxWidth = x.Cargo.MaxWidth,
                        Weight = x.Cargo.Weight
                    },
                    ExtraServicesID = x.ExtraServicesID,
                    ExtraServices = new Model.ExtraServices()
                    {
                        CarrierID = x.ExtraServices.CarrierID,
                        Description = x.ExtraServices.Description,
                        Name = x.ExtraServices.Name,
                        Price = x.ExtraServices.Price
                    },
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        AcceptDate = x.Freight.AcceptDate,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName,
                            Image = x.Freight.Carrier.Image,
                            BusinessNumber = x.Freight.Carrier.BusinessNumber,
                            CarrierBusinessEmail = x.Freight.Carrier.CarrierBusinessEmail,
                            DriverLicenceNumber = x.Freight.Carrier.DriverLicenceNumber,
                            CarrierID = x.Freight.CarrierID
                        },
                        CarrierID = x.Freight.CarrierID,
                        Finished = x.Freight.Finished,
                        Price = x.Freight.Price,
                        Distance = x.Freight.Distance,

                        TransportDate = x.Freight.TransportDate,
                        ClientAccepted = x.Freight.ClientAccepted
                    },
                }).ToList();
                return list;
            }
            else if (search.isFinished == true)
            {
                query = query.Include(x => x.ExtraServices).Include(x => x.Cargo).Include(x => x.Client).Include(x => x.Freight).ThenInclude(x => x.Carrier);
                var list = query.Where(x => x.ClientID == search.ClientID && x.Freight.Finished == true && (x.Freight.IsRated == false || x.Freight.IsRated == null) && x.Freight.IsPayed == true).Select(x => new Model.CargoReservation
                {
                    CargoID = x.CargoID,
                    CargoReservationID = x.CargoReservationID,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    StartDateTransport = x.StartDateTransport,
                    EndDateTransport = x.EndDateTransport,
                    Accepted = x.Accepted,
                    Cargo = new Model.Cargo()
                    {
                        Name = x.Cargo.Name,
                        Description = x.Cargo.Description,
                        Image = x.Cargo.Image,
                        MaxHeight = x.Cargo.MaxHeight,
                        MaxWidth = x.Cargo.MaxWidth,
                        Weight = x.Cargo.Weight
                    },
                    ExtraServicesID = x.ExtraServicesID,
                    ExtraServices = new Model.ExtraServices()
                    {
                        CarrierID = x.ExtraServices.CarrierID,
                        Description = x.ExtraServices.Description,
                        Name = x.ExtraServices.Name,
                        Price = x.ExtraServices.Price
                    },
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        AcceptDate = x.Freight.AcceptDate,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName,
                            Image = x.Freight.Carrier.Image,
                            BusinessNumber = x.Freight.Carrier.BusinessNumber,
                            CarrierBusinessEmail = x.Freight.Carrier.CarrierBusinessEmail,
                            DriverLicenceNumber = x.Freight.Carrier.DriverLicenceNumber,
                            CarrierID = x.Freight.CarrierID
                        },
                        CarrierID = x.Freight.CarrierID,
                        Finished = x.Freight.Finished,
                        Price = x.Freight.Price,
                        Distance = x.Freight.Distance,

                        TransportDate = x.Freight.TransportDate,
                        ClientAccepted = x.Freight.ClientAccepted
                    },
                }).ToList();
                return list;
            }
            else if(search.isExtraServiceDelete == true)
            {
                query = query.Include(x => x.ExtraServices).Include(x => x.Cargo).Include(x => x.Client).Include(x => x.Freight).ThenInclude(x => x.Carrier);
                var list = query.Where(x=> x.ExtraServicesID == search.ExtraServicesID).Select(x => new Model.CargoReservation
                {
                    CargoID = x.CargoID,
                    CargoReservationID = x.CargoReservationID,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    StartDateTransport = x.StartDateTransport,
                    EndDateTransport = x.EndDateTransport,
                    Accepted = x.Accepted,
                    Cargo = new Model.Cargo()
                    {
                        Name = x.Cargo.Name,
                        Description = x.Cargo.Description,
                        Image = x.Cargo.Image,
                        MaxHeight = x.Cargo.MaxHeight,
                        MaxWidth = x.Cargo.MaxWidth,
                        Weight = x.Cargo.Weight
                    },
                    ExtraServicesID = x.ExtraServicesID,
                    ExtraServices = new Model.ExtraServices()
                    {
                        CarrierID = x.ExtraServices.CarrierID,
                        Description = x.ExtraServices.Description,
                        Name = x.ExtraServices.Name,
                        Price = x.ExtraServices.Price
                    },
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        AcceptDate = x.Freight.AcceptDate,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName,
                            Image = x.Freight.Carrier.Image,
                            BusinessNumber = x.Freight.Carrier.BusinessNumber,
                            CarrierBusinessEmail = x.Freight.Carrier.CarrierBusinessEmail,
                            DriverLicenceNumber = x.Freight.Carrier.DriverLicenceNumber,
                            CarrierID = x.Freight.CarrierID
                        },
                        CarrierID = x.Freight.CarrierID,
                        Finished = x.Freight.Finished,
                        Price = x.Freight.Price,
                        Distance = x.Freight.Distance,

                        TransportDate = x.Freight.TransportDate,
                        ClientAccepted = x.Freight.ClientAccepted
                    },
                }).ToList();
                return list;
            }
            else
            {
                var list = query.Include(x => x.ExtraServices).Include(x => x.Cargo).Include(x => x.Client).Include(x => x.Freight).ThenInclude(x => x.Carrier).Select(x => new Model.CargoReservation
                {
                    CargoID = x.CargoID,
                    CargoReservationID = x.CargoReservationID,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    StartDateTransport = x.StartDateTransport,
                    EndDateTransport = x.EndDateTransport,
                    Accepted = x.Accepted,
                    Cargo = new Model.Cargo()
                    {
                        Name = x.Cargo.Name,
                        Description = x.Cargo.Description,
                        Image = x.Cargo.Image,
                        MaxHeight = x.Cargo.MaxHeight,
                        MaxWidth = x.Cargo.MaxWidth,
                        Weight = x.Cargo.Weight
                    },
                    ExtraServicesID = x.ExtraServicesID,
                    ExtraServices = new Model.ExtraServices()
                    {
                        CarrierID = x.ExtraServices.CarrierID,
                        Description = x.ExtraServices.Description,
                        Name = x.ExtraServices.Name,
                        Price = x.ExtraServices.Price
                    },
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        AcceptDate = x.Freight.AcceptDate,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName,
                            Image = x.Freight.Carrier.Image,
                            BusinessNumber = x.Freight.Carrier.BusinessNumber,
                            CarrierBusinessEmail = x.Freight.Carrier.CarrierBusinessEmail,
                            DriverLicenceNumber = x.Freight.Carrier.DriverLicenceNumber,
                            CarrierID = x.Freight.CarrierID
                        },
                        CarrierID = x.Freight.CarrierID,
                        Finished = x.Freight.Finished,
                        Price = x.Freight.Price,
                        Distance = x.Freight.Distance,
                        TransportDate = x.Freight.TransportDate,
                        ClientAccepted = x.Freight.ClientAccepted,
                        isPayed=x.Freight.IsPayed
                    },
                }).ToList();
                return list;
            }
        }
        public override Model.CargoReservation GetById(int id)
        {
            var query = _context.Set<Database.CargoReservation>().AsQueryable();

            var cargoReservation = query.Include(x => x.ExtraServices).Include(x => x.Freight).ThenInclude(x => x.Carrier).Include(x => x.Client).Include(x => x.Cargo).Where(x => x.CargoReservationID == id).FirstOrDefault();
            return _mapper.Map<Model.CargoReservation>(cargoReservation);
        }
        public override Model.CargoReservation Update(int id, CargoReservationInsertRequest request)
        {
            var old = _context.CargoReservation.Include(x => x.Freight).ThenInclude(x => x.Carrier).Where(x => x.CargoReservationID == id).FirstOrDefault();
            if (request.isClient == true)
            {
                old.Accepted = false;
                _context.SaveChanges();
                return _mapper.Map<Model.CargoReservation>(old);
            }
            else if (request.isFreightUpdate)
            {
                //FreightID = request.Freight.FreightID,
                old.Freight.AcceptDate = request.Freight.AcceptDate;
                old.Freight.CarrierID = request.Freight.CarrierID;
                old.Freight.Price = request.Freight.Price;
                old.Freight.Distance = request.Freight.Distance;
                old.Freight.TransportDate = request.Freight.TransportDate;
                old.Freight.VehicleID = request.Freight.VehicleID;
                old.Accepted = request.Accepted;
                old.Freight.Finished = request.Finished;
                _context.SaveChanges();
                return _mapper.Map<Model.CargoReservation>(old);
            }
            else
            {
                old.FreightID = request.FreightID;
                if (request.Freight != null)
                {
                    old.Freight = new Freight()
                    {
                        FreightID = request.Freight.FreightID,
                        Finished = request.Freight.Finished,
                        AcceptDate = request.Freight.AcceptDate,
                        CarrierID = request.Freight.CarrierID,
                        Price = request.Freight.Price,
                        Distance = request.Freight.Distance,
                        TransportDate = request.Freight.TransportDate,
                        VehicleID = request.Freight.VehicleID
                    };
                }
                old.Accepted = request.Accepted;
                old.Freight.Finished = request.Finished;
                old.ExtraServicesID = request.ExtraServicesID;
                _context.SaveChanges();
                return _mapper.Map<Model.CargoReservation>(old);
            }
        }
        public override Model.CargoReservation Insert(CargoReservationInsertRequest request)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            if (request.Freight != null)
            {
                Database.CargoReservation reservation = new Database.CargoReservation()
                {
                    ClientID = authUser.UserID,
                    Accepted = request.Accepted,
                    CargoID = request.CargoID,
                    StartDateTransport = request.StartDateTransport,
                    EndDateTransport = request.EndDateTransport,
                    StartLocation = request.StartLocation,
                    EndLocation = request.EndLocation,
                    FreightID = request.FreightID,
                    ExtraServicesID = request.ExtraServicesID == 0 || request.ExtraServicesID == null ? null : request.ExtraServicesID,
                    Freight = new Freight()
                    {
                        CarrierID = request.Freight.CarrierID
                    }
                };
                _context.CargoReservation.Add(reservation);
                _context.SaveChanges();
                return _mapper.Map<Model.CargoReservation>(reservation);
            }
            else
            {
                Database.CargoReservation reservation = new Database.CargoReservation()
                {
                    ClientID = authUser.UserID,
                    Accepted = request.Accepted,
                    CargoID = request.CargoID,
                    StartDateTransport = request.StartDateTransport,
                    EndDateTransport = request.EndDateTransport,
                    StartLocation = request.StartLocation,
                    EndLocation = request.EndLocation,
                    FreightID = request.FreightID,
                    ExtraServicesID = request.ExtraServicesID == 0 || request.ExtraServicesID == null ? null : request.ExtraServicesID
                };
                _context.CargoReservation.Add(reservation);
                _context.SaveChanges();
                return _mapper.Map<Model.CargoReservation>(reservation);
            }
        }
    }
}
