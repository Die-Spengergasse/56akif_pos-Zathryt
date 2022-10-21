namespace Spg.Zathura.Domain.Model
{
    public enum Gender { m, w, d }
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty ;
        public string Email { get; set; } = string.Empty;
        public int Birth_Date { get; set; }
        public Gender Genders { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
    
    }
}