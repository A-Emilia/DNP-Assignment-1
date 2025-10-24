using System;

namespace DTOs;

public class CreateCommentDTO {
    public required String Body { get; set; }
    public required int AuthorId { get; set; }
    public required int PostId { get; set; }
}
