using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models
{
    public class EducationViewModel
    {
        public string InstitutionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Degree { get; set; }

        public Education ConverToEducation()
        {
            return new Education(InstitutionName, StartDate, EndDate, Degree); 
        }
    }
    public static class EducationExtension
    {
        public static List<Education> ToEducation(this ICollection<EducationViewModel> educationList)
        {
            var list = new List<Education>();
            educationList.ToList().ForEach(b => list.Add(b.ConverToEducation()));
            return list;
        }

        public static EducationViewModel ConvertToEducationViewModel(this Education education)
        {
            return new EducationViewModel()
            {
                Degree = education.Degree,
                EndDate = education.EndDate,
                StartDate = education.StartDate,
                InstitutionName = education.InstitutionName
            };
        }

        public static List<EducationViewModel> ToEducationViewModel(this ICollection<Education> educationList)
        {
            var list = new List<EducationViewModel>();
            educationList.ToList().ForEach(b => list.Add(b.ConvertToEducationViewModel()));
            return list;
        }
    }

}
