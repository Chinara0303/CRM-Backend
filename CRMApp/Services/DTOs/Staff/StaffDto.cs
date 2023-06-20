using Services.DTOs.Common;
namespace Services.DTOs.Staff
{
    public class StaffDto:ActionDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
        //public List<int>   { get; set; }
    }
}
