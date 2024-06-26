USE [DDD]
GO

INSERT INTO [account].[Account]
           ([Email]
           ,[Password]
           ,[Name]
           ,[Surname]
           ,[Title])
     VALUES
           ('email@email.com'
           ,'password'
           ,'Name'
           ,'surname'
           ,'mr')
GO

SELECT *
  FROM [DDD].[account].[Account]

  UPDATE [DDD].[account].[Account]
  SET Surname = 'edited'
  WHERE UUID = '8032A6A6-18C3-47A0-B8BD-4ED765BB45D3'

  SELECT *
  FROM [DDD].[account].[Account]
