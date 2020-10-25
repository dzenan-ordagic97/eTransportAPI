using AutoMapper;
using eTransport.WebAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public BaseCRUDService(eTransportContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor):base(context,mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual TModel Delete(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Remove(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception err)
            {

                throw err;
            }
            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);
            try
            {
                _context.Set<TDatabase>().Add(entity);
                _context.SaveChanges();
                return _mapper.Map<TModel>(entity);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

    }
}
