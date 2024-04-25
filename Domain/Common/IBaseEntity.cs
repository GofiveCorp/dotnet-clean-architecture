namespace Domain.Common
{
    public interface IBaseEntity {
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}