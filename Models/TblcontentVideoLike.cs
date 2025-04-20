using System;
using System.Collections.Generic;

namespace MVC_Core_SocialMediaProject.Models;

public partial class TblcontentVideoLike
{
    public int LikeId { get; set; }

    public int? ContentId { get; set; }

    public int? UserId { get; set; }

    public int? IsLike { get; set; }

    public DateTime? LikeDate { get; set; }

    public virtual TbltopicContent? Content { get; set; }

    public virtual Tbluser? User { get; set; }
}
