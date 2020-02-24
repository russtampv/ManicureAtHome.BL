namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Поставщик материалов
    /// </summary>
    public class Supplier
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public Contact Contact { get; set; }
        public bool IsDelivery { get; set; }
    }
}