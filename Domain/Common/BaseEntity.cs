namespace Domain.Common
{
    public class BaseEntity : IBaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}