using System;
using System.Collections.Generic;

namespace MVC_Core_SocialMediaProject.Models;

public partial class Tbltopic
{
    public int TopicId { get; set; }

    public string TopicName { get; set; } = null!;

    public virtual ICollection<TbltopicContent> TbltopicContents { get; set; } = new List<TbltopicContent>();
}
