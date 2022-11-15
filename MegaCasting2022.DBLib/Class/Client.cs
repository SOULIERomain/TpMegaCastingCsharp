using System;
using System.Collections.Generic;

namespace MegaCasting2022.DBLib.Class
{
    public partial class Client
    {
        public Client()
        {
            Offers = new HashSet<Offer>();
        }

        public long Identifier { get; set; }
        public string Name { get; set; } = null!;
        public string AddressRoad { get; set; } = null!;
        public string AddressCity { get; set; } = null!;
        public string AddressZipCode { get; set; } = null!;
        public string AddressComplement { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
