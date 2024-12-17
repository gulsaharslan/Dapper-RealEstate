namespace DapperRealEstate.Dtos.PropertyDetailDtos
{
    public class CreatePropertyDetailDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public decimal Price { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public int Year { get; set; }
        public int Area { get; set; }
        public int LocationId { get; set; }
        public int Garage { get; set; }
        public int AgentId { get; set; }
        public int PropertyId { get; set; }
        public int CategoryId { get; set; }
        public bool PropertySlider { get; set; }
        public bool PropertyHome { get; set; }
    }
}
