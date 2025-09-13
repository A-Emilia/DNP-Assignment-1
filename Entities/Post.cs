public class Post {
    public required int Id { get; set; }
    public required User Author { get; set; }
    public required String Title { get; set; }
    public required String Body { get; set; }
}