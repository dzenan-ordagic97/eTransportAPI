using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.Model;
using eTransport.Model.Requests;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoReservationController : BaseCRUDController<Model.CargoReservation, Model.Requests.CargoReservationSearchRequest, Model.Requests.CargoReservationInsertRequest, Model.Requests.CargoReservationInsertRequest>
    {
        public CargoReservationController(ICRUDService<CargoReservation, CargoReservationSearchRequest, CargoReservationInsertRequest, CargoReservationInsertRequest> service) : base(service)
        {
        }
    }
}