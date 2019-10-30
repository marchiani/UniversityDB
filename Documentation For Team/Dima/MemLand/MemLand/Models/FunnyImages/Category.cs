using System.Collections.Generic;

namespace MemLand.Models.FunnyImages
{
    public class Category
    {
        public  int Id
        { get; set; }

        public  string Name
        { get; set; }

        public  string UrlSlug
        { get; set; }

        public  string Description
        { get; set; }

        public  IList<Mem> Posts
        { get; set; }
    }
}