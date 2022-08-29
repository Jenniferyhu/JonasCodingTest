using System;


namespace WebApi.Models
{
    public class EmployeeDto :  EmployeeBaseDto

    {
       // public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string OccupationName { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LastModifiedDateTime { get; set; }
    }
    public class EmployeeBaseDto
    {
        public string SiteId { get; set; }
        public string EmployeeCode { get; set; }
    }
}