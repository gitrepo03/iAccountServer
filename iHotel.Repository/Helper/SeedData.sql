USE [iHotel]
GO

INSERT INTO [dbo].[AspNetRoles]
           ([Id]
		   ,[Name]
           ,[NormalizedName])
     VALUES(1,
			'SuperAdminDeveloper'
			,'SUPERADMINDEVELOPER');

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
		   ,[UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
		   ,[EmailConfirmed]
           ,[PasswordHash]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[FullName])
     VALUES
           ('56g6d5fgd5fg4df54g'
		   ,'SuperAdminDeveloper'
           ,'SUPERADMINDEVELOPER'
           ,'ramji.gautam24@gmail.com'
           ,'RAMJI.GAUTAM24@GMAIL.COM'
		   ,1
           ,'AQAAAAEAACcQAAAAEPrSl48tiF1RX0Sra8G1QzWLKY5oFHzsxRNi0nb48obkKHUVdzYKVC6OMsH/enN8Kg=='--Pass123!@#
           ,'9805829770'
           ,1
           ,0
           ,1
           ,0
           ,'Ramji Gautam');

DECLARE @userId varchar(50);
DECLARE @roleId INT;

select @userId = (select TOP 1 id from AspNetUsers where Email = 'ramji.gautam24@gmail.com');
select @roleId = (select TOP 1 id from AspNetRoles where Name = 'SuperAdminDeveloper');

INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
     VALUES
           (@userId
           ,@roleId);


INSERT INTO [dbo].[Organizations]
           ([IsActive]
           ,[OrgName]
           ,[PanNo]
           ,[Address]
           ,[ContactNo]
           ,[Email]
           ,[Website]
           ,[OrgCode])
     VALUES
           (1
           ,'Our Software Company'
           ,'516354621'
           ,'Fulbari-12, Pokhara, Kaski, Nepal'
           ,'061535700'
           ,'ramji.gautam24@gmail.com'
           ,'ramjigautam.com.np'
           ,'Default');

--declare @userId varchar(50);
declare @orgId varchar(50);

select @userId = (select TOP 1 id from AspNetUsers where Email = 'ramji.gautam24@gmail.com');
select @orgId = (select TOP 1 id from Organizations where Email = 'ramji.gautam24@gmail.com');

INSERT INTO [dbo].[UsersOrgs]
           ([IsActive]
           ,[AudId]
           ,[Organization]
           ,[User])
     VALUES
           (1
           ,'5312152'
           ,@orgId
           ,@userId);


SELECT * FROM AspNetRoles
SELECT * FROM AspNetUsers
SELECT * FROM AspNetUserRoles
SELECT * FROM Organizations
SELECT * FROM UsersOrgs

GO






