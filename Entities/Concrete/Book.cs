using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Isbn { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? PublishDate { get; set; }
        public string? CoverImageUrl { get; set; }

        //true: from open library api, false: from user
        public bool IsVerified { get; set; } = false;

        //if the book is added by user, this field will be filled with the user id
        public Guid? CreatedByUserId { get; set; }
        public virtual User? CreatedByUser { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}

