using System;
using System.Collections.Generic;

#nullable disable

namespace ArtGallery.Models
{
    public partial class ManasFerry
    {
        public ManasFerry()
        {
            ManasTickets = new HashSet<ManasTicket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomsLeft { get; set; }
        public double Charge { get; set; }
        public int Origin { get; set; }
        public int Destination { get; set; }
        public DateTime Departure { get; set; }

        public virtual ManasPort DestinationNavigation { get; set; }
        public virtual ManasPort OriginNavigation { get; set; }
        public virtual ICollection<ManasTicket> ManasTickets { get; set; }
    }
}
