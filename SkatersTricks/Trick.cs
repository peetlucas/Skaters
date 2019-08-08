namespace SkatersTricks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trick
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        public string description { get; set; }

        [StringLength(50)]
        public string location { get; set; }

        public string videourl { get; set; }
    }
}
