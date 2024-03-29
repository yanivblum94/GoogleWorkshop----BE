﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleWorkshop____BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson;

namespace GoogleWorkshop____BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            // GetByPupik();
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));
            var dbList = dbClient.GetDatabase("TauRate").GetCollection<Professor>("Lecturers").AsQueryable();
            return new JsonResult(dbList);
        }
        // [Route("ByPupik")]
        // [HttpGet]
        // public void GetByPupik()
        // {
        //     MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));
        //     var TauDB = dbClient.GetDatabase("TauRate");
        //     var courseCollection = TauDB.GetCollection<Course>("Courses");
        //     var lectCollection = TauDB.GetCollection<Professor>("Lecturers");
        //     var lectList = lectCollection.AsQueryable<Professor>().ToList<Professor>();
        //     foreach (var lect in lectList)
        //     {
        //         Console.WriteLine(lect.Name);
        //         foreach (var courseId in lect.Courses)
        //         {
        //             var pupik = courseCollection.AsQueryable<Course>().Where(course => course.Id.ToString().Equals(courseId));
        //             foreach (var blabla in pupik)
        //                 Console.WriteLine(blabla.Name);
        //         }
        //     }
        // }
        [Route("ByName")]
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));
            var collection = dbClient.GetDatabase("TauRate").GetCollection<Professor>("Lecturers");
            var toRet = collection.AsQueryable<Professor>().Where(prof => prof.Name.Contains(name));
            return new JsonResult(toRet);
        }

        [Route("ById")]
        [HttpGet]
        public JsonResult GetById(string id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));
            var dbList = dbClient.GetDatabase("TauRate").GetCollection<Professor>("Lecturers").AsQueryable<Professor>();
            var objProfId = ObjectId.Parse(id);
            var prof = dbList.FirstOrDefault(professor => professor.Id.Equals(objProfId));
            return new JsonResult(prof);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateReview([FromBody]Review rev)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("GoogleWorkshopCon"));
            var dbList = dbClient.GetDatabase("TauRate").GetCollection<Professor>("Lecturers").AsQueryable<Professor>();
            var objProfId =  ObjectId.Parse(rev.ProfId);
            var prof = dbList.FirstOrDefault(professor => professor.Id.Equals(objProfId));
            if(prof == null)
                return new JsonResult("Update did not work, profId does not exist in the DB");
            prof.UpdateReview(rev);

            var filter = Builders<Professor>.Filter.Eq(p => p.Id, objProfId);

            var res = await dbClient.GetDatabase("TauRate").GetCollection<Professor>("Lecturers").ReplaceOneAsync(filter, prof);

            return new JsonResult("Review added Successfully");
        }

    }
}
