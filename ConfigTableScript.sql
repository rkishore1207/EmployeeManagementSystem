
--Creation of DB Schemas
CREATE SCHEMA config
CREATE SCHEMA data

--Insert data into UserRole Table
INSERT INTO [config].[UserRole] (Id,Name,DisplayName) 
VALUES (1,'Admin','Admin'),
(2,'Manager','Manager'),
(3,'Employee','Employee')

SELECT * FROM config.UserRole

--Insert data into Designation Table
INSERT INTO [config].[Designation] (Id,Name,DisplayName) 
VALUES (1,'TraineeAssociate','Trainee Associate'),
(2,'JuniorAssociate','Junior Associate'),
(3,'Associate','Associate'),
(4,'SeniorAssociate','Senior Associate'),
(5,'Manager','Manager'),
(6,'SeniorManager','Senior Manager'),
(7,'Leadership','Leadership')

SELECT * FROM [config].[Designation]

-- Insert Admin data for User Table
SELECT * FROM [data].[User]

INSERT INTO [data].[User]
VALUES(NEWID(),'3280','Kishore','Ramesh',null,null,null,1,'rkishoreatr1207@gmail.com','Kallakurichi','9789728800','2002-10-15','2023-09-27','Chennai','Full Stack Developer',6,4,3,0,1,0,'Single',21,'Male','O+ve','9578691211','Jayam','CIT','')


-- Insert Data into Allowance Type Table
INSERT INTO [config].[AllowanceType] 
VALUES(1,'Earnings','Earnings'),
(2,'Deductions','Deductions')

SELECT * FROM [config].[AllowanceType]

-- Insert Data into Allowances Table
INSERT INTO [config].[Allowances]
VALUES (1,'Basic','Basic',1),
(2,'HouseRentAllowance','House Rent Allowance',1),
(3,'ConveyanceRentAllowance','Conveyance Rent Allowance',1),
(4,'ChildrenEducationAllowance','Children Education Allowance',1),
(5,'ChildrenHostelAllowance','ChildrenHostelAllowance',1),
(6,'TelephoneAllowance','Telephone Allowance',1),
(7,'LTA','LTA',1),
(8,'OtherAllowance','Other Allowance',1),
(9,'EPFContributions','EPF Contributions',2),
(10,'ProfessionalTax','Professional Tax',2)

SELECT * FROM [config].[Allowances]
