using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Blog:IUpdatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Color Color { get; set; }
        public string Password { get; set; }
        public bool IsMine { get; set; }
    }

    // public enum Color:byte 老版本需要继承自byte
    public enum Color{
        Red,
        Green,
        Blue
    }
}