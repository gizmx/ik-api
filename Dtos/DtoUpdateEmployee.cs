namespace InsanKaynaklariAPI.Dtos
{
    public class DtoUpdateEmployee   {

        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstStartDate { get; set; }
        public int? Age { get; set; }
        public string? CompanyID { get; set; }
    }
}
