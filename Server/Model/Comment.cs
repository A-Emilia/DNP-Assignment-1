namespace Model;

public class Comment {
    public required int Id { get; set; }
    public required String Body { get; set; }
    public required Post PostParent { get; set; }
    public required User Author { get; set; }
}