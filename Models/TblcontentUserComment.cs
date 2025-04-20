using System;
using System.Collections.Generic;

namespace MVC_Core_SocialMediaProject.Models;

public partial class TblcontentUserComment
{
    public int CommentId { get; set; }

    public int? ContentId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CommentDate { get; set; }

    public string? Comment { get; set; }

    public virtual TbltopicContent? Content { get; set; }

    public virtual Tbluser? User { get; set; }
}
