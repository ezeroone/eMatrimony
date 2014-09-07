using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eMatrimony.DAL;

namespace eMatrimony.Model
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
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
        public string ResidingState { get; set; }
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

    }
}