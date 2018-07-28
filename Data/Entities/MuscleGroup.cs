using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitHub.Data.Entities
{
    public class MuscleGroup
    {
        [Key]
        public int MgId { get; set; }
        public string MgName { get; set; }

    }
}
