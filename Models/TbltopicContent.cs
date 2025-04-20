using System;
using System.Collections.Generic;

namespace MVC_Core_SocialMediaProject.Models;

public partial class TbltopicContent
{
    public int ContentId { get; set; }

    public string ContentName { get; set; } = null!;

    public int? TopicId { get; set; }

    public string? VideoUrl { get; set; }

    public string? CoverPhoto { get; set; }

    public virtual ICollection<TblcontentUserComment> TblcontentUserComments { get; set; } = new List<TblcontentUserComment>();

    public virtual ICollection<TblcontentVideoLike> TblcontentVideoLikes { get; set; } = new List<TblcontentVideoLike>();

    public virtual ICollection<TblcontentVideoVisit> TblcontentVideoVisits { get; set; } = new List<TblcontentVideoVisit>();

    public virtual Tbltopic? Topic { get; set; }
}
