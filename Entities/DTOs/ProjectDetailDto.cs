using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class ProjectDetailDto : IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> ProjectImagePath { get; set; }
    }
}
