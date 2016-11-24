using CountingKs.Data;
using CountingKs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class MeasuresController : BaseApiController
    {
        //private ICountingKsRepository _repo;
        //private ModelFactory _modelFactory;
        public MeasuresController(ICountingKsRepository repo) : base(repo)
        {            
        }

        public IEnumerable<MeasureModel> Get(int foodid)
        {
            var results = TheRepository.GetMeasuresForFood(foodid)
                                                  .ToList()
                                                  .Select(m => this.TheModelFactory.Create(m));

            return results;
        }

        public MeasureModel Get(int foodid, int id)
        {
            var results = this.TheRepository.GetMeasure(id);

            if (results.Food.Id == foodid)
            {
                return this.TheModelFactory.Create(results);
            }
            else return null;
        }
    }
}
