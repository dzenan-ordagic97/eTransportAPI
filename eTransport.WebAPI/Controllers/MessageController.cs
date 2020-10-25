using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.Model;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseCRUDController<Model.Message, Model.Message, Model.Message, Model.Message>
    {
        public MessageController(ICRUDService<Message, Message, Message, Message> service) : base(service)
        {
        }
    }
}