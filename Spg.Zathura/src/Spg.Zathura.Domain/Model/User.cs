namespace Spg.Zathura.Domain.Model
{
    public enum Gender { m, w, d }
    public class User
    {
        public int Id { get; private set; }
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty ;
        public string Email { get; set; } = string.Empty;
        public DateTime Birth_Date { get; set; }
        public Gender Genders { get; set; }
        public DateTime RegistrationDateTime { get; }
        public List<Character> _characters= new();
        public IReadOnlyList<Character> Characters { get => _characters;}


        protected User() { }
        public User(
            int id,
            string firstName,
            string lastName,
            string eMail,
            DateTime birthDate,
            DateTime registrationDateTime,
            Gender gender) 
        {
            Id = id;
            Genders = gender;
            First_Name= firstName;
            Last_Name= lastName;
            Email = eMail;
            Birth_Date = birthDate;
            RegistrationDateTime= registrationDateTime;
        }   
    }
}