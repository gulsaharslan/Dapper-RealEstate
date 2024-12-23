using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.TestimonialDtos;

namespace DapperRealEstate.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly RealEstateContext _context;

        public TestimonialService(RealEstateContext context)
        {
            _context = context;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            string query = "Insert Into Testimonial (TestimonialName,Comment) values (@testimonialName, @comment)";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialName", createTestimonialDto.TestimonialName);
            parameters.Add("@comment", createTestimonialDto.Comment);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            string query = "Delete From Testimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultTestimonialDto>(query);
            return values.ToList();
        }
    }
}
