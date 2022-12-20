using SISGEP.Application.Entities;

namespace SISGEP.Application.DTOs
{
    public class EditPersonDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public string Cpf { get; set; } = string.Empty;

        public PersonType PersonType { get; set; } = PersonType.Benefited;

        public AddressDTO Address { get; set; } = new AddressDTO();
    }
}
