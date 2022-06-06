using System;
using MongoDB.Bson;


namespace GoogleWorkshop____BE.Models
{
    public class Course
    {

        public ObjectId Id { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }

        public Course() { }

        public Course(ObjectId id, string courseNumber, string courseName)
        {
            Id = id;
            CourseNumber = courseNumber;
            CourseName = courseName;
        }

        public override bool Equals(object obj)
        {
            return obj is Course course &&
                   Id.Equals(course.Id) &&
                   CourseNumber == course.CourseNumber &&
                   CourseName == course.CourseName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CourseNumber, CourseName);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
