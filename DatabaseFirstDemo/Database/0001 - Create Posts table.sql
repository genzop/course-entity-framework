/*
   martes, 19 de diciembre de 201702:27:10 p.m.
   User: 
   Server: (local)
   Database: DatabaseFirstDemo
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Posts
	(
	PostID int NOT NULL,
	DatePublished smalldatetime NOT NULL,
	Title varchar(500) NULL,
	Body varchar(8000) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Posts ADD CONSTRAINT
	Posts PRIMARY KEY CLUSTERED 
	(
	PostID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Posts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
