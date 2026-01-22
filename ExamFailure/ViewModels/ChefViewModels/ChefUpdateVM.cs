namespace ExamFailure.ViewModels.ChefViewModels
{
    public class ChefUpdateVM
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int PositionID { get; set; }

        public IFormFile? Image { get; set; } 
    }
}
