namespace OnboardPro.Models
{
    public class SkillMaster
    {
    }

    public class SkillGroupDto
    {
        public int SkillGroupId { get; set; }
        public string SkillGroupName { get; set; }
        public string Description { get; set; }
    }

    public class SkillSubGroupDto
    {
        public int SkillSubGroupId { get; set; }
        public int SkillGroupId { get; set; }
        public string SkillSubGroupName { get; set; }
        public string Description { get; set; }
        public string SkillGroupName { get; set; }
    }

    public class SkillCategoryDto
    {
        public int SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public string Description { get; set; }
    }

    public class SkillMasterResponse
    {
        public IEnumerable<SkillGroupDto> SkillGroups { get; set; }
        public IEnumerable<SkillSubGroupDto> SkillSubGroups { get; set; }
        public IEnumerable<SkillCategoryDto> SkillCategories { get; set; }
    }

    public class SkillDto
    {
        public int SkillId { get; set; } = 0; 
        public string SkillName { get; set; }
        public string Description { get; set; }
        public int SkillGroupId { get; set; }
        public int SkillSubGroupId { get; set; }
        public int SkillCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class SkillResponseDto: SkillDto
    {
        public string SkillGroup { get; set; } 
        public string SkillSubGroup { get; set; } 
        public string SkillCategory { get; set; } 

    }

}
