using ExamFailure.Models.Common;

namespace ExamFailure.Models
{
    public class Position: BaseEntity
    {
        public string Title { get; set; }

        public ICollection <Chef> Chefs { get; set; }
    }
}
