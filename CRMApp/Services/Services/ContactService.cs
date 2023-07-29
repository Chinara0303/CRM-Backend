using AutoMapper;
using Domain.Common.Constants;
using Domain.Common.Exceptions;
using Domain.Entities;
using Repository.Repositories.İnterfaces;
using Services.DTOs.Contact;
using Services.DTOs.Subscribe;
using Services.Services.İnterfaces;

namespace Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IEducationRepository  _eduRepo;
        private readonly IMapper _mapper;
        public ContactService(IContactRepository repo,
                               IMapper mapper,
                               IEducationRepository eduRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _eduRepo = eduRepo;

        }
        public async Task CreateAsync(ContactCreateDto model)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            if (!await _repo.CheckByEmail(model.Email))
            {
                throw new InvalidException(ExceptionResponseMessages.ExistMessage);
            }


            var edu = await _eduRepo.GetByIdAsync(model.EducationId)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _repo.CreateAsync(_mapper.Map<Contact>(model));
        }

        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            var existContacts = await _repo.GetAllAsync();
            var mappedDatas = _mapper.Map<IEnumerable<ContactDto>>(existContacts);
            foreach (var item in mappedDatas)
            {
                Contact contact = existContacts.FirstOrDefault(x => x.Id == item.Id)
                    ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

                Education education = await _eduRepo.GetByIdAsync(contact.EducationId);
                item.EducationName = education.Name;
            }
            return mappedDatas;

        }

        public async Task<ContactDto> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);
            return _mapper.Map<ContactDto>(await _repo.GetByIdAsync(id));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(id, ExceptionResponseMessages.ParametrNotFoundMessage);

            Contact existContact = await _repo.GetByIdAsync(id)
                ?? throw new InvalidException(ExceptionResponseMessages.NotFoundMessage);

            await _repo.SoftDeleteAsync(existContact);
        }

    }
}
