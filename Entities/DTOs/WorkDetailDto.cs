using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class WorkDetailDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> WorkImagePath { get; set; }
    }
}
