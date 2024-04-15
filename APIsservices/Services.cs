using Common.Common;
using System.Data;
using APIsRepo;

namespace APIsservices
{
    public class Services : IServices1
    {
        private readonly IRepo1 _repo;
        public Services(IRepo1 repo)
        {
            _repo = repo;
        }

        public async Task<List<Apis>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<List<Apis>> GetByDate(string date)
        {

            List<Apis> temp = await _repo.GetByDate(date);

            return temp;
        }

        public async Task<bool> Post(string date, string events)
        {
            bool x = await _repo.Post(date, events);
            return x == true;
        }

        public async Task<bool> Update(string curDate, string curEvents, string newDate, string newEvents)
        {
            bool temp = await _repo.Update(curDate, curEvents, newDate, newEvents);
            return temp;
        }

        public async Task<bool> Remove(string curDate, string curEvents)
        {
            bool temp = await _repo.Remove(curDate, curEvents);
            return temp;
        }
    }
}