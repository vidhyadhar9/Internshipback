using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Common;

namespace APIsRepo
{
    public interface IRepo1
    {
        public Task<List<Apis>> GetAll();

        public Task<List<Apis>> GetByDate(string date);
        public Task<bool> Post(string date, string events);

        public Task<bool> Update(string curDate, string curEvents, string newDate, string newEvents);

        public Task<bool> Remove(string curDate, string curEvents);


    }
}