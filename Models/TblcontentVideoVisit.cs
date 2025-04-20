using System;
using System.Collections.Generic;

namespace MVC_Core_SocialMediaProject.Models;

public partial class TblcontentVideoVisit
{
    public int VisitId { get; set; }

    public int? ContentId { get; set; }

    public int? UserId { get; set; }

    public DateTime? VisitDate { get; set; }

    public virtual TbltopicContent? Content { get; set; }

    public virtual Tbluser? User { get; set; }
}
