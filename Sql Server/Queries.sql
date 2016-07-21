SELECT * FROM [BlogDB].[dbo].[Posts];

SELECT * FROM [BlogDB].[dbo].[Users];

SELECT Title, Body FROM [BlogDB].[dbo].[Posts];

SELECT Username, FullName FROM [BlogDB].[dbo].[Users] 
ORDER BY Username ASC;

SELECT Username, FullName FROM [BlogDB].[dbo].[Users] 
ORDER BY FullName DESC, Username DESC;

SELECT * FROM [BlogDB].[dbo].[Users]
WHERE Id in (SELECT AuthorID FROM [BlogDB].[dbo].[Posts]);

SELECT Users.Username, Posts.Title
FROM [BlogDB].[dbo].[Users] JOIN  [BlogDB].[dbo].[Posts] ON Users.id = Posts.AuthorID;

SELECT Username, FullName FROM [BlogDB].[dbo].[Users]
WHERE Id in (SELECT AuthorID FROM [BlogDB].[dbo].[Posts] WHERE Id = 4);

INSERT INTO [BlogDB].[dbo].[Posts] (AuthorId, Title,Body, Date)
VALUES (2, 'Random Title', 'Random Content', CAST('2016-07-06' AS DateTime));

UPDATE [BlogDB].[dbo].[Posts] SET Title = 'Too random to be true' WHERE Id = 1;

DELETE FROM [BlogDB].[dbo].[Posts] WHERE Id = 2;

SELECT COUNT(*) as Posts_Count from [BlogDB].[dbo].[Posts];

SELECT MIN(AuthorId) as Min_Value from [BlogDB].[dbo].[Posts];

SELECT MAX(AuthorId) as Max_Value from [BlogDB].[dbo].[Posts];

SELECT SUM(Id) as Sum_Ids from [BlogDB].[dbo].[Tags];


SELECT COUNT(*) as Users_Count from [BlogDB].[dbo].[Users] Join [BlogDB].[dbo].[Posts] on Users.id = Posts.AuthorID
WHERE Posts.Date like '2016-06-14%';

SELECT * FROM [BlogDB].[dbo].[Posts]
WHERE Date like '2016-06-14%'
ORDER BY AuthorID ASC;

SELECT TOP 1 Posts.Id, AuthorID, Title, Body, [Date]
FROM [BlogDB].[dbo].[Posts], [BlogDB].[dbo].[Users]
WHERE Users.Id=2 and Users.Id = Posts.Id
Order BY [Date];

SELECT *
FROM [BlogDB].[dbo].[Comments]
ORDER BY AuthorID ASC, Id DESC