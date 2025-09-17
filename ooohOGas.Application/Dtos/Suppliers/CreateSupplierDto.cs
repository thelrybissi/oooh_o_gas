namespace ooohOGas.Application.Dtos.SuppliersDto
{
    public class CreateSupplierDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        //Dados Supplier
        public string CorporateName { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
