using System;
namespace hackatonBackend.ProjectData.Entities
{
	public sealed class Job
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public string Name { get; set; }
		public string NumberOfVacancies { get; set; }
		public string Description { get; set; }
		public string MinimumRequirementDescription { get; set; }
        public double? MinimumRequirementPsychology { get; set; }
		public double? MinimumRequirementCoding { get; set; }
		public bool IsPsychologyRequirementMet { get; set; }
		public bool IsCodingRequirementMet { get; set; }
		public int NumberOfApplicants { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? Deadline { get; set; }

		public Company Company { get; set; }
	}
}

