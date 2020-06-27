using System;

namespace OwnedTypeDetached.Entities
{
    public class Extension
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool? IsDelete { get; set; }

        public int? EntityState { get; set; }
    }
}