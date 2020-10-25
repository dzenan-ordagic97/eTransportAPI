using eTransport.Model.Requests;
using eTransport.Model.SignalR;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.SignalR
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub
    {
        private readonly eTransportContext _db;
        private readonly ICRUDService<Model.Message, Model.Message, Model.Message, Model.Message> _messageService;
        private readonly ICRUDService<Model.MessageHeader, MessageHeaderSearchRequest, MessageHeaderInsertRequest, MessageHeaderInsertRequest> _messageHeaderService;

        public ChatHub(eTransportContext db, ICRUDService<Model.Message, Model.Message, Model.Message, Model.Message> messageService,
                       ICRUDService<Model.MessageHeader, Model.Requests.MessageHeaderSearchRequest, Model.Requests.MessageHeaderInsertRequest, Model.Requests.MessageHeaderInsertRequest> messageHeaderService)
        {
            _db = db;

            _messageService = messageService;
            _messageHeaderService = messageHeaderService;
        }
        public override Task OnConnectedAsync()
        {

            var x = this.Context.ConnectionId;
            var y = this.Context.UserIdentifier;
            var user = _db.User.Find(int.Parse(y));
            user.SignalRToken = x;
            _db.SaveChanges();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(SignalMessage message)
        {
            var authUserID = int.Parse(this.Context.UserIdentifier);
            var user = _db.User.Where(x => x.Id == authUserID).FirstOrDefault();
            int header;
            Model.User toUser;
            if (message.HeaderId == null)
            {
                try
                {
                    header = _messageHeaderService.Insert(new MessageHeaderInsertRequest() { To = (int)message.To }).MessageHeaderID;

                }
                catch (Exception err)
                {

                    throw;
                }
            }
            else
            {
                header = (int)message.HeaderId;
            }
            toUser = _messageHeaderService.GetById(header).From;

            _messageHeaderService.Update(header, new MessageHeaderInsertRequest() { Message = message.Message });
            if (toUser.Token != null)
            {
                await this.Clients.Client(toUser.Token).SendAsync("onSendMessage", new SignalMessage() { Message = message.Message, Sent = message.Sent, HeaderId = header, From = authUserID });
            }
        }
    }
}
