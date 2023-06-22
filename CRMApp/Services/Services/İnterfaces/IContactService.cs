using Services.DTOs.Contact;

namespace Services.Services.İnterfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllAsync();
        Task<ContactDto> GetByIdAsync(int? id);
        Task CreateAsync(ContactCreateDto model);
        Task SoftDeleteAsync(int? id);
    }
}
