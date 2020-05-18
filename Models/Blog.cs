using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public Driver Driver { get; set; }
    }

    public class Driver
    {
        public int Id { get; set; }
        //约定的外键
        public int CarId { get; set; }
        public string Name { get; set; }
        public Car Car { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }
    }


    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }

    }

    //在EF中可以不需要中间表，但是EFCore尚未支持
    public class CourseStudent
    {
        //也可以不配置联合主键直接使用自增的主键，这样就不用写配置了（逃
        // public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}