namespace SISGEP.Application.DTOs
{
    public class AddressDTO
    {
        public string PostalCode { get; set; } = string.Empty;

        public string Thoroughfare { get; set; } = string.Empty;

        public int Number { get; set; }

        public string Neighborhood { get; set; } = string.Empty;

        public string? Complement { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;
    }
}
