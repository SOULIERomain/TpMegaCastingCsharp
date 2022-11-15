using System;
using System.Collections.Generic;

namespace MegaCasting2022.DBLib.Class
{
    public partial class ContractType
    {
        public ContractType()
        {
            Offers = new HashSet<Offer>();
        }

        public long Identifier { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
