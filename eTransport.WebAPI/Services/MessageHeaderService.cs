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
    public class MessageHeaderService : BaseCRUDService<Model.MessageHeader, Model.Requests.MessageHeaderSearchRequest, Database.MessageHeader, Model.Requests.MessageHeaderInsertRequest, Model.Requests.MessageHeaderInsertRequest>
    {
        private readonly ICRUDService<Model.Message, Model.Message, Model.Message, Model.Message> _messageService;
        private readonly IAuthService _authService;

        public MessageHeaderService(ICRUDService<Model.Message, Model.Message, Model.Message, Model.Message> messageService, eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _messageService = messageService;
            _authService = service;
        }

        public override List<Model.MessageHeader> Get(MessageHeaderSearchRequest search)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            var query = _context.MessageHeader.Include(x=> x.From).OrderByDescending(x=>x.Sent).Where(x=>x.Sent != null && x.ToID == authUser.UserID).AsQueryable();

            if (!String.IsNullOrWhiteSpace(search.UserName))
            {
                query = query.Where(x => x.From.UserName.Equals(search.UserName));
            }

            var response = query.Select(x => new Model.MessageHeader
            {
                Sent = x.Sent,
                MessageHeaderID = x.MessageHeaderID,
                FromID = x.FromID,
                ToID = x.ToID,
                Username = x.From.Email,
                Active = x.From.Active
            }).ToList();

            return response;
        }

        public override Model.MessageHeader Insert(MessageHeaderInsertRequest request)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
            var header = _context.MessageHeader.Where(x => x.ToID == authUser.UserID && x.FromID == request.To).FirstOrDefault();
            if (header != null)
            {
                return new Model.MessageHeader()
                {
                    MessageHeaderID = header.MessageHeaderID
                };
            }
            Database.MessageHeader messageHeader = new Database.MessageHeader()
            {
                FromID = authUser.UserID,
                ToID = request.To
            };
            Database.MessageHeader messageHeader2 = new Database.MessageHeader()
            {
                FromID = request.To,
                ToID = authUser.UserID
            };
            _context.MessageHeader.Add(messageHeader);
            _context.MessageHeader.Add(messageHeader2);
            _context.SaveChanges();
            return new Model.MessageHeader()
            {
                MessageHeaderID = messageHeader2.MessageHeaderID
            };

        }

        public override Model.MessageHeader GetById(int id)
        {
            var header = _context.MessageHeader.Include(x=>x.From).Where(x => x.MessageHeaderID == id).Select(x => new Model.MessageHeader()
            {
                From = new Model.User() { Token = x.From.SignalRToken }
            }).FirstOrDefault();
            return header;
        }

        public override Model.MessageHeader Update(int id, MessageHeaderInsertRequest request)
        {

            var header = _context.MessageHeader.Where(x => x.MessageHeaderID == id).FirstOrDefault();
            header.Sent = DateTime.Now;
            _messageService.Insert(new Model.Message() { Content = request.Message, MessageHeaderID = header.MessageHeaderID });
            _context.SaveChanges();

            return new Model.MessageHeader()
            {
                MessageHeaderID = header.MessageHeaderID
            };
        }
    }
}
