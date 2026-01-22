namespace ExamFailure.ViewModels.ChefViewModels
{
    public class ChefGetVM
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int PositionID { get; set; }

        public string ImagePath { get; set; } = null!;
    }
}
