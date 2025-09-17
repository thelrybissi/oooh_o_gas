namespace ooohOGas.Domain.Entities
{
    public class Supplier
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }   // FK para Account
        public string CorporateName { get; set; } = string.Empty; // Razão social
        public string TradeName { get; set; } = string.Empty;     // Nome fantasia
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Account Account { get; set; } = null!;
    }
}
