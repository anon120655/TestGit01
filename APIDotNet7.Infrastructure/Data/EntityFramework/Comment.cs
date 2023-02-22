using System;
using System.Collections.Generic;

namespace APIDotNet7.Infrastructure.Data.EntityFramework;

public partial class Comment
{
    public Guid CommentId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public Guid CreateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public Guid? UpdateUserId { get; set; }

    public Guid TopicId { get; set; }

    public string? Comment1 { get; set; }

    public virtual User CreateUser { get; set; } = null!;

    public virtual Topic Topic { get; set; } = null!;

    public virtual User? UpdateUser { get; set; }
}
