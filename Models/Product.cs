namespace Models
{
    public class Product : ICloneable
    {
        public string? Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsDamaged { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
