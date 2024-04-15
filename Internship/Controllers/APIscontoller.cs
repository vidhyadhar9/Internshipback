using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Common;
using APIsservices;

namespace Internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIscontoller
    {
        public readonly IServices1 Services1;

        public APIscontoller(IServices1 services1)
        {
            Services1 = services1;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Apis>> GetAll()
        {
            //Services serv1 = new Services();
            return await Services1.GetAll();
        }

        [HttpPost]
        [Route("Post")]
        public async Task<bool> Post(string date,string events){

            bool x=await Services1.Post(date,events);
            return x == true;
        }

    }
}
