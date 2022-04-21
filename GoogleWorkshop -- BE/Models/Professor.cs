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
        public double TreatRating { get; set; }
        public double MaterialsUpdateOdds { get; set; }
        public double RecordsUpdateOdds { get; set; }
        public double TakeAgainOdds { get; set; }
        public string EmailAddr { get; set; }
        public string WebsiteAddr { get; set; }
        public string LinkedinProfile { get; set; }
        public string TwitterProfile { get; set; }
        public List<string> Courses { get; set; }
        public List<Review> Reviews { get; set; }

        public Professor() { }

        public Professor(string name, string faculty, double totalRating, double diffRating, double treatRating, double materialsUpdateOdds, double recordsUpdateOdds, 
            double takeAgainOdds, string emailAddr, string websiteAddr, string linkedinProfile, string twitterProfile)
        {
            Name = name;
            Faculty = faculty;
            TotalRating = totalRating;
            DiffRating = diffRating;
            TreatRating = treatRating;
            MaterialsUpdateOdds = materialsUpdateOdds;
            RecordsUpdateOdds = recordsUpdateOdds;
            TakeAgainOdds = takeAgainOdds;
            EmailAddr = emailAddr;
            WebsiteAddr = websiteAddr;
            LinkedinProfile = linkedinProfile;
            TwitterProfile = twitterProfile;
        }

        public override bool Equals(object obj)
        {
            return obj is Professor professor &&
                   string.Equals(Name, professor.Name) &&
                   string.Equals(Faculty, professor.Faculty) &&
                   TotalRating == professor.TotalRating &&
                   DiffRating == professor.DiffRating &&
                   MaterialsUpdateOdds == professor.MaterialsUpdateOdds &&
                   RecordsUpdateOdds == professor.RecordsUpdateOdds &&
                   TakeAgainOdds == professor.TakeAgainOdds &&
                   string.Equals(EmailAddr, professor.EmailAddr) &&
                   string.Equals(WebsiteAddr, professor.WebsiteAddr) &&
                   string.Equals(TwitterProfile, professor.TwitterProfile) &&
                   string.Equals(LinkedinProfile, professor.LinkedinProfile) &&
                   Enumerable.SequenceEqual(Courses.OrderBy(e => e), professor.Courses.OrderBy(e => e)) &&
                   Enumerable.SequenceEqual(Reviews.OrderBy(e=>e), professor.Reviews.OrderBy(e => e));
        }

        public void UpdateReview(Review rev)
        {
            if (this.Reviews == null)
                this.Reviews = new List<Review>();
            if (this.Courses == null)
                this.Courses = new List<string>();
            this.Reviews.Add(rev);
            if (!this.Courses.Contains(rev.Course))
                this.Courses.Add(rev.Course);
            CalcRating();
        }


        public void CalcRating()
        {
            int ratingSum = 0, diffSum = 0, treatSum = 0, materialsTrues = 0, recordsTrues = 0, takeAgainnTrues = 0;
            foreach (Review rev in this.Reviews)
            {
                ratingSum += rev.TotalRating;
                diffSum += rev.DiffRating;
                treatSum += rev.TreatRating;
                if (rev.MaterialsUpdate)
                    materialsTrues++;
                if (rev.RecordsUpdate)
                    recordsTrues++;
                if (rev.TakeAgain)
                    takeAgainnTrues++;
            }
            var count = (double)this.Reviews.Count;
            this.TotalRating = (double)(ratingSum / count);
            this.DiffRating = (double)(diffSum / count);
            this.TreatRating = (double)(treatSum / count);
            this.MaterialsUpdateOdds = (double)(materialsTrues / count);
            this.RecordsUpdateOdds = (double)(recordsTrues / count);
            this.TakeAgainOdds = (double)(takeAgainnTrues / count);
        }
    }
}
