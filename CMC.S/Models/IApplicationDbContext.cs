
namespace CMCS.Models
{
    public interface IApplicationDbContext
    {
        ISet<Claim> Claims { get; set; }
        ISet<Lecturer> Lecturers { get; set; }
    }
}