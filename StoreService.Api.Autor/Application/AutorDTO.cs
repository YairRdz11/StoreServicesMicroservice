namespace StoreService.Api.Autor.Application
{
    public class AutorDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string AutorBookGuid { get; set; }
    }
}
