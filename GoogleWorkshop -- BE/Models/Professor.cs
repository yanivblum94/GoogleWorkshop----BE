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
        public int[] CoursesReviewsCounts { get; set; }
        public int[] CoursesDifficultiesSum { get; set; }
        public int[] CoursesMaterialsTrues { get; set; }
        public int[] CoursesRecordsTrues { get; set; }
        public int[] CoursesTakeAgainTrues { get; set; }

        public List<Review> Reviews { get; set; }

        public Professor() { }

        public Professor(string name, string faculty, double totalRating, int[] coursesReviewsCounts, int[] coursesDifficultiesSum, int[] coursesMaterialsTrues,
            int[] coursesRecordsTrues, int[] coursesTakeAgainTrues, double diffRating, double treatRating, double materialsUpdateOdds, double recordsUpdateOdds,
            double takeAgainOdds, string emailAddr, string websiteAddr, string linkedinProfile, string twitterProfile)
        {
            Name = name;
            Faculty = faculty;
            TotalRating = totalRating; DiffRating = diffRating;
            TreatRating = treatRating;
            MaterialsUpdateOdds = materialsUpdateOdds;
            RecordsUpdateOdds = recordsUpdateOdds;
            TakeAgainOdds = takeAgainOdds;
            EmailAddr = emailAddr;
            WebsiteAddr = websiteAddr;
            LinkedinProfile = linkedinProfile;
            TwitterProfile = twitterProfile;
            CoursesReviewsCounts = coursesReviewsCounts;
            CoursesDifficultiesSum = coursesDifficultiesSum;
            CoursesMaterialsTrues = coursesMaterialsTrues;
            CoursesRecordsTrues = coursesRecordsTrues;
            CoursesTakeAgainTrues = coursesTakeAgainTrues;
    }

        public Professor(ObjectId id, string name, string faculty, double totalRating, double diffRating, double treatRating, double materialsUpdateOdds, double recordsUpdateOdds, double takeAgainOdds, string emailAddr, string websiteAddr, string linkedinProfile, string twitterProfile, List<string> courses, List<Review> reviews)
        {
            Id = id;
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
            Courses = courses;
            Reviews = reviews;
        }

        public override bool Equals(object obj)
        {
            return obj is Professor professor &&
                   Array.Equals(CoursesReviewsCounts, professor.CoursesReviewsCounts) &&
                   Array.Equals(CoursesDifficultiesSum, professor.CoursesDifficultiesSum) &&
                   Array.Equals(CoursesMaterialsTrues, professor.CoursesMaterialsTrues) &&
                   Array.Equals(CoursesRecordsTrues, professor.CoursesRecordsTrues) &&
                   Array.Equals(CoursesTakeAgainTrues, professor.CoursesTakeAgainTrues) &&
                   string.Equals(Name, professor.Name) &&
                   string.Equals(Faculty, professor.Faculty) &&
                   TotalRating == professor.TotalRating &&
                   string.Equals(EmailAddr, professor.EmailAddr) &&
                   string.Equals(WebsiteAddr, professor.WebsiteAddr) &&
                   string.Equals(TwitterProfile, professor.TwitterProfile) &&
                   string.Equals(LinkedinProfile, professor.LinkedinProfile) &&
                   Enumerable.SequenceEqual(Courses.OrderBy(e => e), professor.Courses.OrderBy(e => e)) &&
                   Enumerable.SequenceEqual(Reviews.OrderBy(e => e), professor.Reviews.OrderBy(e => e));
        }

        public void UpdateReview(Review rev)
        {
            const int maxNumCourses = 10;

            if (this.Reviews == null)
                this.Reviews = new List<Review>();
            if (this.Courses == null)
                this.Courses = new List<string>();
            if (this.CoursesReviewsCounts == null)
                this.CoursesReviewsCounts = new int[maxNumCourses];
            if (this.CoursesDifficultiesSum == null)
                this.CoursesDifficultiesSum = new int[maxNumCourses];
            if (this.CoursesMaterialsTrues == null)
                this.CoursesMaterialsTrues = new int[maxNumCourses];
            if (this.CoursesRecordsTrues == null)
                this.CoursesRecordsTrues = new int[maxNumCourses];
            if (this.CoursesTakeAgainTrues == null)
                this.CoursesTakeAgainTrues = new int[maxNumCourses];
            this.Reviews.Add(rev);
            if (!this.Courses.Contains(rev.Course))
                this.Courses.Add(rev.Course);
            CalcRating();
        }


        public void CalcRating()
        {
            const int maxNumCourses = 10;

            int ratingSum = 0, diffSum = 0, treatSum = 0, materialsTrues = 0, recordsTrues = 0, takeAgainnTrues = 0;
            int[] courseReviewCount = new int[maxNumCourses] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int[] courseDiffSum = new int[maxNumCourses] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] courseMaterialTrues = new int[maxNumCourses] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] courseRecordsTrues = new int[maxNumCourses] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] courseTakeAgainTrues = new int[maxNumCourses] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (Review rev in this.Reviews)
            {
                for (int i = 0; i < this.Courses.Count; i++)
                {
                    if (this.Courses[i] == rev.Course)
                    {
                        courseReviewCount[i]++;
                        courseDiffSum[i] += rev.DiffRating;
                        if (rev.MaterialsUpdate)
                        {
                            courseMaterialTrues[i]++;
                        }
                        if (rev.RecordsUpdate)
                        {
                            courseRecordsTrues[i]++;
                        }
                        if (rev.TakeAgain)
                        {
                            courseTakeAgainTrues[i]++;
                        }
                    }
                }
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
            this.CoursesReviewsCounts = courseReviewCount;
            this.CoursesDifficultiesSum = courseDiffSum;
            this.CoursesMaterialsTrues = courseMaterialTrues;
            this.CoursesRecordsTrues = courseRecordsTrues;
            this.CoursesTakeAgainTrues = courseTakeAgainTrues;
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
