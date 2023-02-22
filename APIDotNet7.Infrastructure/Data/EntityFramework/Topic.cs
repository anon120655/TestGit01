using System;
using System.Collections.Generic;

namespace APIDotNet7.Infrastructure.Data.EntityFramework;

public partial class Topic
{
    public Guid TopicId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public Guid CreateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public Guid? UpdateUserId { get; set; }

    public string? Topic1 { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual User CreateUser { get; set; } = null!;

    public virtual User? UpdateUser { get; set; }
}
