using AutoMapper;
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
    public class MessageService : BaseCRUDService<Model.Message, Model.Message, Database.Message, Model.Message, Model.Message>
    {
        private IAuthService _authService;

        public MessageService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }

        public class Ids
        {

            public int id1 { get; set; }
             public int id2 { get; set; }

        }
        public override List<Model.Message> Get(Model.Message search)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
            Ids ids = _context.MessageHeader.Where(x => x.MessageHeaderID == search.MessageHeaderID).Select(x => new Ids
            {
                id1 = x.ToID,
                id2 = x.FromID
            }).FirstOrDefault();

            var header2 = _context.MessageHeader.Where(x => x.ToID == ids.id2 && x.FromID == ids.id1).FirstOrDefault();


            var response0 = _context.Message.OrderByDescending(x => x.SendAt).Include(x => x.MessageHeader).Where(x => x.MessageHeaderID == search.MessageHeaderID || x.MessageHeaderID == header2.MessageHeaderID).ToList();


            var response = _context.Message.OrderByDescending(x=>x.SendAt).Include(x=>x.MessageHeader).Where(x => x.MessageHeaderID == search.MessageHeaderID || x.MessageHeaderID == header2.MessageHeaderID).Select(x=> new Model.Message {
                SendAt = x.SendAt,
                Content = x.Content,
                IsMyMessage = x.MessageHeader.ToID == authUser.UserID
            }).ToList();

            return response;

        }

        public override Model.Message Insert(Model.Message request)
        {
            var message = new Database.Message
            {
                Content = request.Content,
                MessageHeaderID = request.MessageHeaderID,
                SendAt = DateTime.Now
            };

            var header = _context.MessageHeader.Where(x => x.MessageHeaderID == request.MessageHeaderID).FirstOrDefault();

            header.Sent = message.SendAt;

            _context.SaveChanges();

            _context.Message.Add(message);
            _context.SaveChanges();

            return new Model.Message
            {
                Content = message.Content
            };


        }
    }
}
