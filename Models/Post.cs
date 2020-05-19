namespace Models
{
public class Post:Entity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public Blog Blog { get; set; }
    }
}