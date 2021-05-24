using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineJobPortal.Models
{
    public partial class TblJob
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int? Experience { get; set; }
        public int? TypeOfContract { get; set; }
        public string QualificationRequired { get; set; }
        public string SkillsRequired { get; set; }
        public DateTime? JobPostingDate { get; set; }
        public DateTime? JobJoiningDate { get; set; }
        public int? Salary { get; set; }
        public int CompanyId { get; set; }
        public int? JobStatus { get; set; }
        public string Department { get; set; }
    }
}
