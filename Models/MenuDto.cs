namespace OnboardPro.Models
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public int? ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string Route { get; set; }
        public string ActionUrl { get; set; }
        public string Icon { get; set; }
        public int MenuOrder { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
