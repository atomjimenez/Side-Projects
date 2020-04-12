using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acongrebility.Models
{
    public class CongressmemberPartyViewModel
    {
        public List<Congressmembers> Congressmembers { get; set; }
        public SelectList Parties { get; set; }
        public string Party { get; set; }
        public string SearchString { get; set; }
    }
    public class Congressmembers
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTookOffice { get; set; }
        public string Role { get; set; }
        public string Pic { get; set; }
        public string Party { get; set; }
        public string VotingHistory { get; set; }

    }
}
