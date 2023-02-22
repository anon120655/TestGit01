using System;
using System.Collections.Generic;

namespace APIDotNet7.Infrastructure.Data.EntityFramework;

public partial class User
{
    public Guid UserId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Comment> CommentCreateUsers { get; } = new List<Comment>();

    public virtual ICollection<Comment> CommentUpdateUsers { get; } = new List<Comment>();

    public virtual ICollection<Topic> TopicCreateUsers { get; } = new List<Topic>();

    public virtual ICollection<Topic> TopicUpdateUsers { get; } = new List<Topic>();
}
