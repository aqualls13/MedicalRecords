using FileProcessors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUi
{
    public partial class MedicalRecordsProcessor : Form
    {
        private readonly IProcessMedicalRecordFile processor = new ProcessMedicalRecordFileClient1();

        public MedicalRecordsProcessor()
        {
            InitializeComponent();
        }

        private void selectInputFIleButton_Click(object sender, EventArgs e)
        {
            if (openInputFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFIlePath.Text = openInputFileDialog.FileName;
            }
        }

        private void selectOutputFolderPath_Click(object sender, EventArgs e)
        {
            if (outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolderPath.Text = outputFolderBrowserDialog.SelectedPath;
            }
        }

        private void processFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                string outputFileText;
                var fileName = openInputFileDialog.SafeFileName.Split('.')[0] + "_sanitized.txt";
                var filePath = outputFolderPath.Text + "\\" + fileName;
                var medicalRecord = processor.Process(inputFIlePath.Text);

                if (medicalRecord != null)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Patient Name: " + medicalRecord.PatientName);
                    sb.AppendLine("Date of Birth: " + medicalRecord.DateOfBirth.ToShortDateString());
                    sb.AppendLine("Social Security Number: " + medicalRecord.SocialSecurityNumber);
                    sb.AppendLine("Address: " + medicalRecord.Address);
                    sb.AppendLine("Phone Number: " + medicalRecord.PhoneNumber);
                    sb.AppendLine("Email: " + medicalRecord.Email);
                    sb.AppendLine("Medical Record Number: " + medicalRecord.MedicalRecordNumber);
                    sb.AppendLine("Order Details:");
                    foreach (var order in medicalRecord.OrderDetails)
                    {
                        sb.AppendLine("- " + order);
                    }

                    outputFileText = sb.ToString();
                    using (FileStream fs = new(filePath, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter sw = new(fs))
                        {
                            sw.Write(outputFileText);
                        };
                    };
                }
                else
                {
                    throw new Exception("An unknown exception has occured!");
                }
            }
            catch (AggregateException ex)
            {
                var sb = new StringBuilder();
                foreach (var item in ex.InnerExceptions)
                {
                    sb.AppendLine(item.Message);
                    outputLogTextBox.Text = sb.ToString();
                }
            }
            catch(Exception ex) 
            {
                if(ex.InnerException is not null)
                    outputLogTextBox.Text = ex.InnerException.Message;
                else outputLogTextBox.Text = ex.Message;
            } 
        }
    }
}
