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
        public readonly IServices1 _Services1;

        public APIscontoller(IServices1 services1)
        {
            _Services1 = services1;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Apis>> GetAll()
        {
            //Services serv1 = new Services();
            Console.WriteLine("event get is encountered");
            return await _Services1.GetAll();
        }

        [HttpGet]
        [Route("GetByDate")]
        public async Task<List<Apis>> GetByDate(string date)
        {
            return await _Services1.GetByDate(date);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<bool> Post(string date, string events)
        {

            bool x = await _Services1.Post(date, events);
            return x == true;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<bool> Update(string curDate, string curEvents, string newDate, string newEvents)
        {
            return await _Services1.Update(curDate, curEvents, newDate, newEvents);
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task<bool> Remove(string curDate, string curEvents)
        {
            Console.WriteLine(curDate + " " + curEvents);
            return await _Services1.Remove(curDate, curEvents);
        }

    }
}