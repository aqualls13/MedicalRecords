# MedicalRecords

Assumptions:
* Given the 4 hour window and simple graphical insterace, I chose to write a Windows Forms application in .NET 6 because I thought writing MVC/WebAPI and React would take to long for me to do. I focused on writing a clean application with good validation of the file and exception handling. Do to the way I chose to write the processing, additional fields can be added to the file without breaking the application.
* Give that the file contains information that is almost all PHI and PII I chose to mask SSN and redact the MRN as they explicitely contain identifiers that can be used on their own to identify a person.
* Iam assuming that the file will be used to import information into another system for analysis or reporing.
* 
#Running the application:

Simply run the application in Visual Studio 2022. Make sure that the WinFOrmUi project is set as the Startup Project. Select the file to process and the output directory and click process. 
Errors will be displayed in the multirow textbox and if the processing is successful a messagebox will appear upon completion. 
