using System;
using MongoDB.Bson;


namespace GoogleWorkshop____BE.Models
{
    public class Course
    {

        public string courseNumber { get; set; }
        public string courseName { get; set; }

        public Course() { }

        public Course(string courseNumber, string courseName)
        {
            this.courseNumber = courseNumber;
            this.courseName = courseName;
        }

        public override bool Equals(object obj)
        {
            return obj is Course course &&
                   courseNumber == course.courseNumber &&
                   courseName == course.courseName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(courseNumber, courseName);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
