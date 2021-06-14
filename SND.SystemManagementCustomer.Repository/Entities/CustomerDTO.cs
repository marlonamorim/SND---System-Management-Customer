namespace SND.SystemManagementCustomer.Repository.Entities
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CNPJ { get; set; }
        public string City { get; set; }
        public string StatePrefix { get; set; }
        public int OrderQuantity { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}