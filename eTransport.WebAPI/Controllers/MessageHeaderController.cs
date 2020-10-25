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
    public class MessageHeaderController : BaseCRUDController<Model.MessageHeader, Model.Requests.MessageHeaderSearchRequest, Model.Requests.MessageHeaderInsertRequest, Model.Requests.MessageHeaderInsertRequest>
    {
        public MessageHeaderController(ICRUDService<MessageHeader, MessageHeaderSearchRequest, MessageHeaderInsertRequest, MessageHeaderInsertRequest> service) : base(service)
        {
        }

    }
}