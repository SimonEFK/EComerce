namespace HardwareStore.App.Services.Data.Category
{
    public class CategoryInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string FilePath { get; set; }

        public ICollection<SpecificationInfoDTO> Specifications { get; set; } = new List<SpecificationInfoDTO>();
    }
}
