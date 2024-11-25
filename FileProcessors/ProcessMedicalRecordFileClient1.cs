using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileProcessors
{
    public class ProcessMedicalRecordFileClient1 : IProcessMedicalRecordFile
    {
        //Client specific regular expressions to process the file.
        //Using regular expression so that order in the file is not important.
        private readonly string _patientName = @"Patient Name:\s+([a-zA-Z0-9\s]+)\r";
        private readonly string _dateOfBirth = @"Date of Birth:\s+(\d\d/\d\d\/\d\d\d\d)\r";
        private readonly string _socialSecurityNumber = @"Social Security Number:\s+([0-9]{3}-[0-9]{2}-[0-9]{4})\r";
        private readonly string _socialSecurityNumberMask = @"[0-9]{3}-[0-9]{2}";
        private readonly string _address = @"Address:\s+([0-9a-zA-Z ,]+)\r";
        private readonly string _phoneNumber = @"Phone Number:\s+([0-9\(\)\- ]+)\r";
        private readonly string _email = @"Email:\s+([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})\r";
        private readonly string _medicalRecordNumber = @"Medical Record Number:\s+(MRN-[0-9]+)\r";
        private readonly string _medicalRecordNumberMask = @".+";
        private readonly string _orderDetail = @"-\s+(.+)+\r*";

    //Read the medial record from the supplied path.
    public MedicalRecord Process(string path)
        {
            MedicalRecord medicalRecord = new MedicalRecord();
            StringBuilder builder = new StringBuilder();
            List<Exception> fileProcessingExceptions = new List<Exception>();
            //Read the file fromt he path
            try
            {
                //Check if the file exists
                if (!File.Exists(path))
                    throw new Exception("The file does not exist on the path: " + path);

                //Open and read the file.
                using (StreamReader reader = File.OpenText(path))
                {
                    var result = new char[reader.BaseStream.Length];
                    reader.Read(result, 0, (int)reader.BaseStream.Length);

                    foreach (char c in result)
                    {
                        builder.Append(c);
                    }
                }

                string medicalrecordFile = builder.ToString();

                //Extract the data from the file
                var match = Regex.Match(medicalrecordFile, _patientName, RegexOptions.Multiline);
                if (match.Success && match.Groups.Count > 1)
                    medicalRecord.PatientName = match.Groups[1].Value;
                else
                    fileProcessingExceptions.Add(new Exception("Unable to file Patient Name."));

                match = Regex.Match(medicalrecordFile, _dateOfBirth, RegexOptions.Multiline);
                if (match.Success && match.Groups.Count > 1)
                    medicalRecord.DateOfBirth = DateTime.Parse(match.Groups[1].Value);
                else
                    fileProcessingExceptions.Add(new Exception("Unable to fined Date of Birth."));

                match = Regex.Match(medicalrecordFile, _socialSecurityNumber, RegexOptions.Multiline);
                if (match.Success && match.Groups.Count > 1) {
                    var ssn = match.Groups[1].Value;
                    //Mask the Social Security Number.
                    var maskedSsn = Regex.Replace(ssn, _socialSecurityNumberMask, "XXX-XX");
                    medicalRecord.SocialSecurityNumber = maskedSsn;
                }
                else
                    fileProcessingExceptions.Add(new Exception("Unable to find Social Security Number"));

                match = Regex.Match(medicalrecordFile, _address, RegexOptions.Multiline);
                if (match.Success && match.Groups.Count > 1)
                    medicalRecord.Address = match.Groups[1].Value;
                else
                    fileProcessingExceptions.Add(new Exception("Unable to find Address"));

                match = Regex.Match(medicalrecordFile, _phoneNumber, RegexOptions.Multiline);
                if (match.Success && match.Groups.Count > 1)
                    medicalRecord.PhoneNumber = match.Groups[1].Value;
                else
                    fileProcessingExceptions.Add(new Exception("Unable to find Phone Number"));

                match = Regex.Match(medicalrecordFile, _email, RegexOptions.Multiline);
                if (match.Success && match.Groups.Count > 1)
                    medicalRecord.Email = match.Groups[1].Value;
                else
                    fileProcessingExceptions.Add(new Exception("Unable to find Email"));

                //Could just assign [REDACTED] here but this validates the file contains the medical record number.
                match = Regex.Match(medicalrecordFile, _medicalRecordNumber, RegexOptions.Multiline);
                if (match.Success && match.Groups.Count > 1) {
                    var mrn = match.Groups[1].Value;
                    //Mask the Medical Record Number
                    var maskedMrn = Regex.Replace(mrn, _medicalRecordNumberMask, "[REDACTED]");
                    medicalRecord.MedicalRecordNumber = maskedMrn;
                }
                else
                    fileProcessingExceptions.Add(new Exception("Unable to find Medical Record Number"));

                //Matching each order detail line.
                var matches = Regex.Matches(medicalrecordFile, _orderDetail, RegexOptions.Multiline);
                if (matches.Count() > 0)
                    foreach (Match m in matches)
                        if (m.Success && m.Groups.Count > 1)
                            medicalRecord.OrderDetails.Add(m.Groups[1].Value);
                        else
                            fileProcessingExceptions.Add(new Exception("Unable to find Order Details"));
                else
                    fileProcessingExceptions.Add(new Exception("Unable to find Order Details"));
                //Throw data processing exceptions all at once.
                if (fileProcessingExceptions.Count > 0)
                    throw new AggregateException("Aggregate Exception Message", fileProcessingExceptions);
            }
            catch (Exception)
            {
                throw;
            }

            return medicalRecord;
        }
    }
}
