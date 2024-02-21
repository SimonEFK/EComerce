namespace HardwareStore.App.Services.Models
{
    public class SpecificationInfoDTO
    {

        public int? CategoryId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Filter { get; set; }

        public string InfoLevel { get; set; }

        public ICollection<SpecificationValueInfoDTO> Values { get; set; } = new List<SpecificationValueInfoDTO>();
    }
}