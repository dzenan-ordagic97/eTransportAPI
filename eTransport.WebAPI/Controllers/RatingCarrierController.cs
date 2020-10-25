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
    public class RatingCarrierController : BaseCRUDController<Model.RatingCarrier, Model.RatingCarrier, Model.Requests.RatingCarrierInsertRequest, Model.RatingCarrier>
    {
        public RatingCarrierController(ICRUDService<RatingCarrier, RatingCarrier, RatingCarrierInsertRequest, RatingCarrier> service) : base(service)
        {
        }
    }
}
