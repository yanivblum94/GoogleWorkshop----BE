using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleWorkshop____BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace GoogleWorkshop____BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly ILogger<ProfessorController> _logger;
        private readonly IConfiguration _configuration;
        public ProfessorController(ILogger<ProfessorController> logger, IConfiguration configurations)
        {
            _logger = logger;
            _configuration = configurations;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));
            var dbList = dbClient.GetDatabase("TauRate").GetCollection<Professor>("Professors").AsQueryable();
            return new JsonResult(dbList);
        }
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));
            var dbList = dbClient.GetDatabase("TauRate").GetCollection<Professor>("Professors").AsQueryable();
            var toRet = dbList.Where(prof => string.Equals(prof.Name, name));
            return new JsonResult(dbList);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateReview(Professor prof, Review rev)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));

            prof.UpdateReview(rev);

            var filter = Builders<Professor>.Filter.Eq("Id", prof.Id);

            await dbClient.GetDatabase("testdb").GetCollection<Professor>("Department").ReplaceOneAsync(filter, prof);

            return new JsonResult("Review added Successfully");
        }

    }
}
