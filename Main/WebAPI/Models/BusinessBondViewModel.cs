using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Models
{
    public class BusinessBondViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }

        public BusinessBond ConvertToBusinessBond()
        {
            return new BusinessBond(StartDate, EndDate, CompanyName, Role);
        }
    }

    public static class BusinessBondExtension
    {
        public static List<BusinessBond> ToBusinessBond(this ICollection<BusinessBondViewModel> businessBondList)
        {
            var list = new List<BusinessBond>();
            businessBondList.ToList().ForEach(b => list.Add(b.ConvertToBusinessBond()));
            return list;
        }

        public static BusinessBondViewModel ConvertToBusinessBondViewModel(this BusinessBond businessBond)
        {
            return new BusinessBondViewModel
            {
                CompanyName = businessBond.CompanyName,
                EndDate = businessBond.EndDate,
                StartDate = businessBond.StartDate,
                Role = businessBond.Role
            };
        }

        public static List<BusinessBondViewModel> ToBusinessBondViewModel(this ICollection<BusinessBond> businessbond)
        {
            var list = new List<BusinessBondViewModel>();
            businessbond.ToList().ForEach(b => list.Add(b.ConvertToBusinessBondViewModel()));
            return list;
        }
    }
}
