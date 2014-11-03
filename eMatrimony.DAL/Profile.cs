using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eMatrimony.DAL
{

    public enum Gender : int
    {
        Male = 0,
        Female = 1
    }

    public enum MaritalStatus : int
    {
        Unmarried = 0,
        WidowWidower = 1,
        Divorced = 2,
        Separated = 3
    }

    public enum PhysicalStatus : int
    {
        Normal =  0,
        PhysicallyChallenged = 1 
    }


    public class User : IdentityUser
    {
    }

    public class Profile
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public decimal Height { get; set; }
        public PhysicalStatus PhysicalStatus { get; set; }
        public string Religion { get; set; }
        public string Branch { get; set; }
        public string EducationLevel { get; set; }
        public string OccupationLevel { get; set; }
        public decimal AnnualIncome { get; set; }
        public string PlaceOfBirthday { get; set; }
        public string CountryOfliving { get; set; }
        public string Citizenship { get; set; }
        public string ResidingState{ get; set; }
        public string ResidingCityDistrict { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string MotherTongue { get; set; }
        public string FamilyValue { get; set; }
        public string FamilyType { get; set; }
        public string FamilyStatus { get; set; }
        public string Ethnicity { get; set; }
        public string AboutMe { get; set; }
        public string AboutMyParent { get; set; }
        public string ProfileFilePath { get; set; }
        public string ProfileFileContentType { get; set; }
        public string HoroscopeFilePath { get; set; }
        public string HoroscopeFileContentType { get; set; }
    }
}
