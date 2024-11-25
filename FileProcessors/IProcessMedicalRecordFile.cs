namespace FileProcessors
{
    public interface IProcessMedicalRecordFile
    {
        MedicalRecord Process(string path);
    }
}
