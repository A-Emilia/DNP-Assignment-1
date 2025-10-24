using System;

namespace DTOs;

public class CreatePostDTO {
    public required int AuthorId { get; set; }
    public required String Title { get; set; }
    public required String Body { get; set; }
}
