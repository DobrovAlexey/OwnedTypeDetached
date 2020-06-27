using System;

namespace OwnedTypeDetached.Entities
{
    public class TokenEntity
    {
        public TokenEntity()
        {
            //Extension = new Extension();
        }
        public int Id { get; set; }

        public string? Text { get; set; }

        public DateTime? CreateDate { get; set; }

        public Extension Extension { get; set; }
    }
}