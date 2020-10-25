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
    public class ClientController : BaseCRUDController<Model.Client, Model.Requests.ClientSearchRequest, Model.Client, Model.Requests.ClientInsertRequest>
    {
        public ClientController(ICRUDService<Client, ClientSearchRequest, Client, ClientInsertRequest> service) : base(service)
        {
        }
    }
}
