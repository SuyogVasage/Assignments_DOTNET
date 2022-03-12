create database Clinic;

use Clinic;

Create Table Patient (
  PatientID int Primary Key,
  PatientName varchar(200) not null,
  MobileNo varchar(100) not null,
  Age int not null ,
  )


Create Table MedicalInfo (
  InfoID int IDENTITY(1,1) Primary Key,
  PatientId int not null References Patient(PatientID),
  Patientname varchar (200) not null,
  Weight int not null ,
  BP float ,
  Cholestrol_HDL float,
  Cholestrol_LDL float,
  Sugar_Fast float,
  Sugar_PostFast float,
  Medicine varchar (300),
  AppointmentDate date,
  )

Create table DailyReport (
	 ReportID int IDENTITY(1,1) Primary Key,
	 PatientId int not null References Patient(PatientID),
	 Date date,
	 Fees float,
	 )




select * from MedicalInfo;

select * from Patient;

select * from DailyReport;







Drop table Patient;
Drop table MedicalInfo;
Drop table DailyReport;
