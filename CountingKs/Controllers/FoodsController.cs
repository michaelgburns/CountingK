using CountingKs.Data;
using CountingKs.Data.Entities;
using CountingKs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class FoodsController : BaseApiController
    {
        //ICountingKsRepository _repo;
        //ModelFactory _modelFactory;

        //public FoodsController(ICountingKsRepository repo)
        //{
        //    _repo = repo;
        //    _modelFactory = new ModelFactory();
        //}

        public FoodsController(ICountingKsRepository repo) : base(repo)
        {
        }

        public IEnumerable<FoodModel> Get()
        {
            var results = TheRepository.GetAllFoodsWithMeasures()
                              .OrderBy(f => f.Description)
                              .Take(25)
                              .ToList()
                              .Select(f => TheModelFactory.Create(f));

            return results;
        }

        public FoodModel Get(int foodid)
        {
            return TheModelFactory.Create(TheRepository.GetFood(foodid));
        }
    }
}
