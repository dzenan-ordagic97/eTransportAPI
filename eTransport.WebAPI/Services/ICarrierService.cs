using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public interface ICarrierService:ICRUDService<Model.Carrier,Model.Requests.CarrierSearchRequest,Model.Carrier,Model.Requests.CarrierInsertRequest>
    {
        List<Model.Carrier> Recommend();
    }
}
