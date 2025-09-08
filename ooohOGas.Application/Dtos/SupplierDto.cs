namespace ooohOGas.Application.DTOs
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string CorporateName { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
