namespace StoreService.Api.Autor.Models
{
    public class AcademicGrade
    {
        public int AcademicGradeId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? GradeDate { get; set; }
        public int AutorBookId { get; set; }
        public AutorBook AutorBook { get; set; }
        public string AcademicGradeGuid { get; set; }
    }
}
