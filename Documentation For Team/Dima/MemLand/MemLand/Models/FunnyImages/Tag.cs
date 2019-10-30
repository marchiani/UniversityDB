using System.Collections.Generic;

namespace MemLand.Models.FunnyImages
{
    public class Tag
    {
        public virtual int Id
        { get; set; }

        public virtual string Name
        { get; set; }

        public virtual string UrlSlug
        { get; set; }

        public virtual string Description
        { get; set; }

        public virtual IList<Mem> Posts
        { get; set; }
    }
}