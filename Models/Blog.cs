using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    //显式的Id
    public class Entity
    {
        public int Id { get; set; }
    }
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Order:Entity
    {
        public StreetAddress StreetAddress { get; set; }
    }

    public class StreetAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
    }


}