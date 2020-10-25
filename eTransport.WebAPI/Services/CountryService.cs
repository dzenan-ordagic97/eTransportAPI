using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class CountryService : BaseCRUDService<Model.Country,Model.Country, Database.Country, Model.Requests.CountryInsertRequest, Model.Requests.CountryInsertRequest>
    {
        public CountryService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
        //public override List<Model.Country> Get(CitySearchRequest search)
        //{
        //    var query = _context.Set<Database.Country>().AsQueryable();

        //    var list = query.Select(x => new Model.Country
        //    {
        //        Name = x.Name,
        //        Acronym=x.Acronym,
        //        CountryID=x.CountryID
        //    }).ToList();
        //    return list;
        //}
        public override Model.Country Insert(CountryInsertRequest request)
        {
            Database.Country country = new Database.Country()
            {
                Acronym = request.Acronym,
                Name = request.Name
            };
            _context.Country.Add(country);
            _context.SaveChanges();
            return _mapper.Map<Model.Country>(country);
        }
        public override Model.Country Update(int id, CountryInsertRequest request)
        {
            var old = _context.Country.Where(x => x.CountryID == id).FirstOrDefault();
            old.Acronym = request.Acronym;
            old.Name = request.Name;
            _context.SaveChanges();
            return _mapper.Map<Model.Country>(old);
        }
    }
}
