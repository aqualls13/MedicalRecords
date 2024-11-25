using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessors
{
    public class MedicalRecord
    {
        //Most of this is considered is PHI as far as I can tell. 
        //It make no sense to redact it all since there would be no need to produce a file.
        //So I will redact SSN and MRN as those are individually identifiers.
        public string? PatientName { get; set; } //PII/PHI
        public DateTime DateOfBirth { get; set; } //PII/PHI
        public string? SocialSecurityNumber { get; set; } //PII/PHI
        public string? Address { get; set; } //PII/PHI
        public string? PhoneNumber { get; set; } //PII/PHI
        public string? Email { get; set; }///PII/PHI
        public string? MedicalRecordNumber { get; set; } //PHI
        public List<string> OrderDetails { get; set; } = []; //This could contain PHI such as device ids.
    }
}
