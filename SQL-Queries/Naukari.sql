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

alter table PersonalInfo add Status varchar(50)
alter table PersonalInfo add UserID varchar(100)
alter table PersonalInfo add Gender varchar(20)

alter table EmployerInfo add UserID varchar(100) 

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

create table EmployerInfo (
	EmpID int identity(1,1) primary key,
	FullName varchar(100) not null,
	MobileNo varchar(50) not null,
	Email varchar(50) not null,
	Role varchar(200) not null,
	CompanyName varchar(200) not null,
	Description varchar(300) not null,
	CompanyHeadquarters varchar(200) not null,
	NumberOfBranches int not null,
	LogoPath varchar(300) not null,
);

select * from PersonalInfo
select * from EducationInfo
select * from ProfessionalInfo

drop table ProfessionalInfo
drop table EducationInfo
drop table PersonalInfo
