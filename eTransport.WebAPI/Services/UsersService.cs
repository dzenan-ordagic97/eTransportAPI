using AutoMapper;
using eTransport.Model;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class UsersService : IUsersService
    {
        protected eTransportContext _context;
        protected IMapper _mapper;
        public UsersService(eTransportContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IList<Model.User> GetAll(UserSearchRequest request)
        {

            var query = _context.User.Include(c => c.Carrier).Include(x => x.Client).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Username))
            {
                query = query.Where(x => x.UserName.StartsWith(request.Username));
            }
            var entities = query.ToList();

            return _mapper.Map<List<Model.User>>(entities);
        }
        public Model.User GetById(int id)
        {
            var entity = _context.User.Find(id);

            return _mapper.Map<Model.User>(entity);
        }
        public Model.User Insert(UserInsertRequest request)
        {
            var entity = _mapper.Map<Database.User>(request);

            if (request.Password != request.PasswordConfirmation)
            {
                throw new UsersExceptions("Passwords don't match");
            }
            _context.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.User>(entity);
        }
    }
}
