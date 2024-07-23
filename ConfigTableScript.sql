
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

