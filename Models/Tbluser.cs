using System;
using System.Collections.Generic;

namespace MVC_Core_SocialMediaProject.Models;

public partial class Tbluser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Gender { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string? City { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? UserPhoto { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<TblcontentUserComment> TblcontentUserComments { get; set; } = new List<TblcontentUserComment>();

    public virtual ICollection<TblcontentVideoLike> TblcontentVideoLikes { get; set; } = new List<TblcontentVideoLike>();

    public virtual ICollection<TblcontentVideoVisit> TblcontentVideoVisits { get; set; } = new List<TblcontentVideoVisit>();
}
