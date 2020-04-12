using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acongrebility.Models
{
    public class Bills
    {
        public int Id { get; set; }
        [Display(Name = "Legal Name")]
        public string LegalName { get; set; }
        [Display(Name = "Common Name")]
        public string StreetName { get; set; }
        [Display(Name = "Bill Proposed By")]
        public string ProposedBy { get; set; }
        [Display(Name = "Passed House")]
        public bool PassedHouse { get; set; }
        [Display(Name = "Passed Senate")]
        public bool PassedSenate { get; set; }
        [Display(Name = "Date Proposed")]

        [DataType(DataType.Date)]
        public DateTime DateProposed { get; set; }
        [Display(Name = "Date Passed/Failed")]
        public DateTime DatePassedFailed { get; set; }
        [Display(Name = "Republican support")]
        public int RepSupport { get; set; }
        [Display(Name = "Democratic support")]
        public int DemSupport { get; set; }
        [Display(Name = "Independent support")]
        public int IndSupport { get; set; }
    }
}
