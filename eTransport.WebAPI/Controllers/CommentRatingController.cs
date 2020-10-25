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
    public class CommentRatingController : BaseCRUDController<Model.CommentRating, Model.Requests.CommentRatingSearchRequest, Model.CommentRating, Model.CommentRating>
    {
        public CommentRatingController(ICRUDService<CommentRating, CommentRatingSearchRequest, CommentRating, CommentRating> service) : base(service)
        {
        }
    }
}