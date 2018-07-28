using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitHub.Data.Entities
{
    public class Workout
    {
        [Key]
        public int WoId { get; set; }

        // WoUserID references AspNetUsers table, Id column.
        public string WoUserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime WoDate { get; set; }

        // Setup FK constraint to map AspNetUsers.Id to WoUserID.
        // Note that class type is IdentityUser since this implements AspNetUsers table.
        [ForeignKey("WoUserID")]
        [Column("Id")]
        public IdentityUser User { get; set; }

        public int WoExID { get; set; }

        [ForeignKey("WoExID")]
        [Column("ExId")]
        public Exercise Exercise { get; set; }

        public int WoSetCount { get; set; }
        public int WoRepCount { get; set; }
        public int WoWeightUsed { get; set; }


    }
}
