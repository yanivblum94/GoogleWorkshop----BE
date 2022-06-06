using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace GoogleWorkshop____BE.Models
{
    public class Course
    {

        public ObjectId Id { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }

        public Course() { }

        public Course(string courseNumber, string courseName)
        {
            CourseNumber = courseNumber;
            CourseName = courseName;
        }

        public override bool Equals(object obj)
        {
            return obj is Course course &&
                   Id.Equals(course.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
