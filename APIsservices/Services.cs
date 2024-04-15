using Common.Common;
using System.Data;
using APIsRepo;

namespace APIsservices
{
    public class Services:IServices1
    {
        private readonly IRepo1 _repo;
        public Services(IRepo1 repo)
        {
            _repo=repo;
        }

        public Task<List<Apis>> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<bool> Post(string date,string events)
        {
            bool x = await _repo.Post(date, events);
            return x == true;
        }
    }
}
