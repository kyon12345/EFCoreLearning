namespace Models
{
    public class Post
    {
        public int Id { get; set; }
        //约定的外键
        // public int BlogId{ get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Blog Blog { get; set; }
    }
}