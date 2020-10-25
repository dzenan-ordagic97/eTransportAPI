using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class CityService : BaseCRUDService<Model.City, Model.Requests.CitySearchRequest, Database.City, Model.Requests.CityInsertRequest, Model.Requests.CityInsertRequest>
    {
        public CityService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
        public override List<Model.City> Get(CitySearchRequest search)
        {
            var query = _context.Set<Database.City>().AsQueryable();

            var list = query.Include(x => x.Country).Where(x=>x.CountryID==search.CountryID).Select(x => new Model.City
            {
                Name=x.Name,
                PostalNumber=x.PostalNumber,
                CityID=x.CityID
            }).ToList();

            return list;
        }
        public override Model.City Insert(CityInsertRequest request)
        {
            Database.City city = new Database.City()
            {
                CountryID=request.CountryID,
                Name=request.Name,
                PostalNumber=request.PostalNumber
            };
            _context.City.Add(city);
            _context.SaveChanges();
            return _mapper.Map<Model.City>(city);
        }
        public override Model.City Update(int id, CityInsertRequest request)
        {
            var old = _context.City.Include(x=>x.Country).Where(x => x.CityID == id).FirstOrDefault();
            old.CountryID = request.CountryID;
            old.Name = request.Name;
            old.PostalNumber = request.PostalNumber;
            _context.SaveChanges();
            return _mapper.Map<Model.City>(old);
        }
    }
}
