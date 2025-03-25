namespace Aspiro.Contracts.ServiceLibrary.DTO
{
    public class UsersCreate
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
