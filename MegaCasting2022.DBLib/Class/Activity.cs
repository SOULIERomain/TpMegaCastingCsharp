using System;
using System.Collections.Generic;

namespace MegaCasting2022.DBLib.Class
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityArtists = new HashSet<ActivityArtist>();
        }

        public long Identifier { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ActivityArtist> ActivityArtists { get; set; }
    }
}
