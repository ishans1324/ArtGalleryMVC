using System;
using System.Collections.Generic;

#nullable disable

namespace ArtGallery.Models
{
    public partial class ManasPort
    {
        public ManasPort()
        {
            ManasFerryDestinationNavigations = new HashSet<ManasFerry>();
            ManasFerryOriginNavigations = new HashSet<ManasFerry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ManasFerry> ManasFerryDestinationNavigations { get; set; }
        public virtual ICollection<ManasFerry> ManasFerryOriginNavigations { get; set; }
    }
}
