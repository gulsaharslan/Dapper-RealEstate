using DapperRealEstate.Dtos.TestimonialDtos;

namespace DapperRealEstate.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task DeleteTestimonialAsync(int id);
        
    }
}
