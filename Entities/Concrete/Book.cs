using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int CategoryId { get; set; }

        public string? ISBN { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? PublishDate { get; set; }
        public string? CoverImageUrl { get; set; }

        //true: added and verified from open library api, false: added from user
        public bool IsVerified { get; set; } = false;

        //if the book is added by user, this field will be filled with the user id
        public Guid? CreatedByUserId { get; set; }
        public virtual User? CreatedByUser { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}

