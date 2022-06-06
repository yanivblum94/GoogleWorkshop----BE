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
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string CourseID { get; set; }

        public Course() { }

        public Course(string name, string faculty, string courseID)
        {
            Name = name;
            Faculty = faculty;
            CourseID = courseID;
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
