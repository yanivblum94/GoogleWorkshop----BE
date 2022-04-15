using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GoogleWorkshop____BE.Models
{
    public class Review
    { 

        public ObjectId ID { get; set; }
        public int TotalRating { get; set; }
        public int DiffRating { get; set; }
        public string Comment { get; set; }
        public string Course { get; set; }

        public Review() { }

        public Review(int totalRating, int diffRating, string comment, string course)
        {
            TotalRating = totalRating;
            DiffRating = diffRating;
            Comment = comment;
            Course = course;
        }

        public override bool Equals(object obj)
        {
            return obj is Review review &&
                   TotalRating == review.TotalRating &&
                   DiffRating == review.DiffRating &&
                   string.Equals(Comment, review.Comment) &&
                   string.Equals(Course, review.Course);
        }
    }
}
