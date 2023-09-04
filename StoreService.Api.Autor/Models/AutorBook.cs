namespace StoreService.Api.Autor.Models
{
    public class AutorBook
    {
        public int AutorBookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public ICollection<AcademicGrade> AcademicGradeList { get; set; }
        public string AutorBookGuid { get; set; }
    }
}
