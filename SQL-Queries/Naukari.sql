create database Naukari

use Naukari

create table PersonalInfo (
	CandidateID int identity(1,1) primary key,
	FullName varchar(100) not null,
	MobileNo varchar(50) not null,
	Email varchar(50) not null,
	Address varchar(200) not null,
	ImgPath varchar(300) not null,
	ResumePath varchar(300) not null
);

create table EducationInfo (
	EduID int identity(1,1) primary key,
	CandidateID int not null References PersonalInfo(CandidateID),
	SSCPassYear int not null,
	SSCPercentage float not null,
	HSCPassYear int,
	HSCPercentage float,
	DiplomaPassYear int,
	DiplomaPercentage float,
	DegreePassYear int not null,
	DegreePercentage float not null,
	DegreeName varchar(50) not null,
	MastersPassYear int,
	MastersPercentage float,
	MastersName varchar(50)
);

create table ProfessionalInfo (
	InfoID int identity(1,1) primary key,
	CandidateID int not null References PersonalInfo(CandidateID),
	ExpInYears float,
	Companies varchar(200),
	Projects varchar(500)
);

select * from PersonalInfo
select * from EducationInfo
select * from ProfessionalInfo

drop table ProfessionalInfo
drop table EducationInfo
drop table PersonalInfo

DELETE FROM PersonalInfo WHERE CandidateID = 2;
DELETE FROM PersonalInfo WHERE CandidateID = 3;
DELETE FROM PersonalInfo WHERE CandidateID = 4;
DELETE FROM PersonalInfo WHERE CandidateID = 5;
DELETE FROM PersonalInfo WHERE CandidateID = 6;
DELETE FROM PersonalInfo WHERE CandidateID = 7;
DELETE FROM PersonalInfo WHERE CandidateID = 8;

DELETE FROM EducationInfo WHERE CandidateID = 2;
DELETE FROM EducationInfo WHERE CandidateID = 3;
DELETE FROM EducationInfo WHERE CandidateID = 4;
DELETE FROM EducationInfo WHERE CandidateID = 5;
DELETE FROM EducationInfo WHERE CandidateID = 6;
DELETE FROM EducationInfo WHERE CandidateID = 7;
DELETE FROM EducationInfo WHERE CandidateID = 8;

DELETE FROM ProfessionalInfo WHERE InfoID = 2;
DELETE FROM ProfessionalInfo WHERE InfoID = 3;
DELETE FROM ProfessionalInfo WHERE InfoID = 4;
DELETE FROM ProfessionalInfo WHERE InfoID = 5;
DELETE FROM ProfessionalInfo WHERE InfoID = 6;
DELETE FROM ProfessionalInfo WHERE InfoID = 1;