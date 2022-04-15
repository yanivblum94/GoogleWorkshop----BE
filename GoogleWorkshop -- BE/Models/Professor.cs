using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GoogleWorkshop____BE.Models
{
    public class Professor
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public double TotalRating { get; set; }
        public double DiffRating { get; set; }
        public string EmailAddr { get; set; }
        public string WebsiteAddr { get; set; }
        public List<Review> Reviews { get; set; }

        public Professor() { }

        public Professor(string name, string faculty, double totalRating, double diffRating, string emailAddr, string websiteAddr)
        {
            Name = name;
            Faculty = faculty;
            TotalRating = totalRating;
            DiffRating = diffRating;
            EmailAddr = emailAddr;
            WebsiteAddr = websiteAddr;
        }

        public override bool Equals(object obj)
        {
            return obj is Professor professor &&
                   string.Equals(Name, professor.Name) &&
                   string.Equals(Faculty, professor.Faculty) &&
                   TotalRating == professor.TotalRating &&
                   DiffRating == professor.DiffRating &&
                   string.Equals(EmailAddr, professor.EmailAddr) &&
                   string.Equals(WebsiteAddr, professor.WebsiteAddr) &&
                   Enumerable.SequenceEqual(Reviews.OrderBy(e=>e), professor.Reviews.OrderBy(e => e));
        }

        public void UpdateReview(Review rev)
        {
            if (this.Reviews == null)
                this.Reviews = new List<Review>();
            this.Reviews.Add(rev);
            CalcRating();
        }


        public void CalcRating()
        {
            int sum1 = 0, sum2=0;
            foreach (Review rev in this.Reviews)
            {
                sum1 += rev.TotalRating;
                sum2 += rev.DiffRating;
            }

            this.TotalRating = (double)(sum1 / this.Reviews.Count);
            this.DiffRating = (double)(sum2 / this.Reviews.Count);
        }
    }
}
