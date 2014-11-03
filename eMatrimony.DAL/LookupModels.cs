using System.ComponentModel.DataAnnotations;

namespace eMatrimony.DAL
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
    }

    public class Religion
    {
        [Key]
        public int ReligionId { get; set; }

        public string Name { get; set; }
    }

    public class EducationLevel
    {
        [Key]
        public int EducationId { get; set; }
        public string Description { get; set; }
    }

    public class Tongue
    {
        [Key]
        public int TongueId { get; set; }
        public string Description { get; set; }
    }
}
