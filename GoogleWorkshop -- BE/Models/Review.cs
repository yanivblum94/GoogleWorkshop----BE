﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GoogleWorkshop____BE.Models
{
    public class Review
    { 
        public string ProfId { get; set; }
        public int TotalRating { get; set; }
        public int DiffRating { get; set; }
        public int TreatRating { get; set; }
        public bool MaterialsUpdate { get; set; }
        public bool RecordsUpdate { get; set; }
        public bool TakeAgain { get; set; }
        public string Comment { get; set; }
        public string Course { get; set; }
        public string User { get; set; }

        public Review() { }

        public Review(int totalRating, int diffRating, int treatRating, bool materialsUpdate, bool recordsUpdate, bool takeAgain, string comment, string course, string user)
        {
            TotalRating = totalRating;
            DiffRating = diffRating;
            TreatRating = treatRating;
            MaterialsUpdate = materialsUpdate;
            RecordsUpdate = recordsUpdate;
            TakeAgain = takeAgain;
            Comment = comment;
            Course = course;
            User = user;
        }

        public override bool Equals(object obj)
        {
            return obj is Review review &&
                   TotalRating == review.TotalRating &&
                   DiffRating == review.DiffRating &&
                   TreatRating == review.TreatRating &&
                   MaterialsUpdate == review.MaterialsUpdate &&
                   RecordsUpdate == review.RecordsUpdate &&
                   TakeAgain == review.TakeAgain &&
                   string.Equals(Comment, review.Comment) &&
                   string.Equals(Course, review.Course)&&
                   string.Equals(User, review.User); ;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
