namespace Domain.Common
{
    public class CommonPerson : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public byte[] Image { get; set; }
    }
}
