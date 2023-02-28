using System;
using System.Collections.Generic;

#nullable disable

namespace ArtGallery.Models
{
    public partial class AvaniOrder
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int? PersonId { get; set; }

        public virtual AvaniPerson Person { get; set; }
    }
}
