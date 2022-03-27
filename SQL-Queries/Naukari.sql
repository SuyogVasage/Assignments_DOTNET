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

DELETE FROM PersonalInfo WHERE CandidateID = 2;