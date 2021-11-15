using AutoMapper;
using PhoneBook.Reports.Host.Entities;
using PhoneBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Reports.Host.Utilities.Mapping
{
    public class PhoneBookReportProfile:Profile
    {
        public PhoneBookReportProfile()
        {
            CreateMap<ReportDto, Report>().ReverseMap();
        }
    }
}
