--新建一个数据库：17bang，能指定/查看该数据库存放位置 
CREATE DATABASE [17bang];
--依次备份/删除/恢复该数据库 --
BACKUP DATABASE [17bang] TO DISK='D:\\yz\\17bang.bak';

DROP DATABASE [17bang];

RESTORE DATABASE [17bang] FROM DISK='D:\\yz\\17bang.bak';


-- 观察“一起帮”的：

--    注册和发布求助功能，试着建表User：包含UserName（用户名），Password（密码）
--    内容发布功能：试着建表Keyword：包含Name（名称），Used（使用次数）


CREATE TABLE [User]
(
[UserName] NVARCHAR(10) NOT NULL,
[Password] NVARCHAR(10) NOT NULL
)

CREATE TABLE [Keyword]
(
[Name] NVARCHAR(10) NOT NULL,
[Used] INT NOT NULL
)

--为User表添加一列：邀请人（InvitedBy），类型为INT
--将InvitedBy类型修改为NVARCHAR(10)
--删除列Inv
ALTER TABLE [User] ADD [InvitedBy] INT;

ALTER TABLE [User] 
ALTER COLUMN [InvitedBy] NVARCHAR(10);

ALTER TABLE [User] DROP COLUMN [INvitedBy];

-- 观察“一起帮”的发布求助功能，试着建立表Problem，包含：

--    Id
--    Title（标题）
--    Content（正文）
--    NeedRemoteHelp（需要远程求助）
--    Reward（悬赏）
--    PublishDateTime（发布时间）……

--请为这些列选择合适的数据类型。

CREATE TABLE [Problem]
(
Id INT NOT NULL PRIMARY KEY,
Title TEXT NOT NULL,
Content TEXT ,
NeedRemoteHelp BIT,
Reward INT,
PUblishDateTime DATETIME
)
-- 在User表中插入以下四行数据：
--UserName  --	Password

--17bang      --	1234
 
--Admin       --	NULL

--Admin       -1
	
--SuperAdmin  --	123456

INSERT [User](UserName,[Password]) VALUES (N'17bang',1234); 
INSERT [User](UserName,[Password]) VALUES (N'Admin',NULL);
INSERT [User](UserName,[Password]) VALUES (N'Admin',1);
INSERT [User](UserName,[Password]) VALUES (N'SuperAdmin',123456);
SELECT * FROM [User];


--将Problem表中的Reward全部更新为0
UPDATE Problem SET Reward=0;
SELECT * FROM Problem;
--使用事务，

--    删除User表中的全部数据，
--    回滚事务，撤销之前的删除行为
BEGIN TRANSACTION
DELETE [User]
SELECT * FROM [User]
ROLLBACK

 --在User表中：

 --   查找没有录入密码的用户
 --   删除用户名（UserName）中包含“Admin”或者“17bang”字样的用户
BEGIN TRANSACTION
SELECT * FROM  [User]
WHERE UserName LIKE '%Admin%' 
OR UserName LIKE '%17bang%'
ROLLBACK 
COMMIT

 --在Problem表中：

INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
(1,N'当前',N'我是正文',1,10,'2020/1/1')
INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
(2,N'当前',N'我是正文',1,10,'2020/1/1')
INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
(3,N'当前',N'我是正文',1,21,'2020/1/1')
INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
(4,N'当前',N'我是正文',1,10,'2020/1/1')
INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
(5,N'当前',N'我是正文',1,7,'2020/1/1')
ALTER TABLE Problem 
ALTER COLUMN Title NVARCHAR(10)
DELETE Problem

 --   给所有悬赏（Reward）大于10的求助标题加前缀：【推荐】

BEGIN TRANSACTION
SELECT *FROM Problem
UPDATE Problem SET Title ='['+ N'推荐'+']'+Title
WHERE  Reward >10
ROLLBACK
COMMIT

 --   给所有悬赏大于20且发布时间（Created）在2019年10月10日之后的求助标题加前缀：【加急】
 BEGIN TRANSACTION
 SELECT * FROM Problem
 UPDATE Problem SET Title = '['+N'加急'+']'+Title 
 WHERE Reward>20 AND PUblishDateTime>'2019/10/10'
 ROLLBACK
 COMMIT
 --   删除所有标题以中括号【】开头（无论其中有什么内容）的求助
 BEGIN TRANSACTION
 SELECT *FROM Problem
 DELETE Problem
WHERE Title LIKE '%\[%\]%' ESCAPE '\' 
ROLLBACK
COMMIT
 --   查找Title中第5个起，字符不为“数据库”且包含了百分号（%）的求助
 ALTER TABLE Problem
 ALTER COLUMN Title NVARCHAR(20)
INSERT Problem(Id, Title) VALUES(6,N'我是标题，我什么都不包含');
INSERT Problem(Id,Title) VALUES(7,N'我是标题，我包含数据库');
INSERT Problem(Id,Title) VALUES (8,N'我是标题，我包含数据库和%号');
INSERT Problem(Id,Title) VALUES(9,N'我是标题，我只包含%号')
SELECT * FROM Problem
WHERE Title NOT LIKE N'_____%数据库%' AND Title LIKE N'_____%\%%' ESCAPE '\'

SELECT 1
WHERE EXISTS (SELECT *FROM Problem WHERE Id>10)

 --在Keyword表中：


 ALTER  TABLE Keyword
 ALTER COLUMN Used INT
 INSERT Keyword([Name],[Used]) VALUES(N'C#',50);
 INSERT Keyword([Name],[Used]) VALUES(N'SQL',200);
 INSERT Keyword([Name],[Used]) VALUES(N'JAVA',30);
 INSERT Keyword([Name],[Used]) VALUES(N'CSS',10);
 INSERT Keyword([name],[Used]) VALUES(N'LINQ',0);
 INSERT Keyword([name],[Used]) VALUES(N'F#',NULL);
 INSERT Keyword([Name],[Used]) VALUES(N'JavaScript',-1)
 --   找出所有被使用次数（Used）大于10小于50的关键字名称（Name）
 SELECT Name FROM Keyword
 WHERE Used>10 AND Used <50
 --   如果被使用次数（Used）小于等于0，或者是NULL值，或者大于100的，将其更新为1
  BEGIN TRANSACTION
  --SELECT * FROM Keyword
  UPDATE Keyword SET Used = 1
  WHERE Used<= 0 OR Used IS NULL OR Used>100
  ROLLBACK
  COMMIT

   --   删除所有使用次数为奇数的Keyword
  BEGIN TRANSACTION
  --SELECT * FROM Keyword
  DELETE Keyword 
  WHERE Used%2<>0
  ROLLBACK
  COMMIT

--  在User表上的基础上：
--    添加Id列，让Id成为主键
--    添加约束，让UserName不能重复
DELETE [User]	
ALTER TABLE [User]  NOCHECK CONSTRAINT ALL
ALTER TABLE [User]  CHECK CONSTRAINT ALL
ALTER TABLE [User]

ADD  CONSTRAINT PK PRIMARY KEY(Id)
INSERT [User](Id,UserName,[Password])VALUES(NULL,'',12334)
ALTER TABLE [User]
--ADD Id INT

--UPDATE [User] SET Id=1
--WHERE UserName=N'Admin'
--ALTER COLUMN Id INT NOT NULL
ADD CONSTRAINT PK_Ids PRIMARY KEY(id)


ALTER TABLE [User] NOCHECK CONSTRAINT ALL;
ALTER TABLE [User] CHECK CONSTRAINT ALL;
ALTER TABLE [User]
ADD CONSTRAINT UE_UserName UNIQUE(UserName)
SELECT * FROM [User]


--在Problem表的基础上：

--    为NeedRemoteHelp添加NOT NULL约束，再删除NeedRemoteHelp上NOT NULL的约束
--    添加自定义约束，让Reward不能小于10
ALTER TABLE Problem NOCHECK CONSTRAINT ALL
ALTER TABLE Problem
--DELETE  Problem
--ALTER COLUMN NeedRemoteHelp BIT NOT NULL
ALTER COLUMN NeedRemoteHelp BIT NULL
SELECT * FROM Problem
ALTER TABLE Problem
ADD CONSTRAINT CK_Reward CHECK(Reward>10)
INSERT Problem(Id,Title,Content,Reward,PUblishDateTime,NeedRemoteHelp)
VALUES(1,2,2,12,'1999-10-10',1)

-- 观察一起帮的“关键字”功能，新建Keyword表，要求带一个自增的主键Id，起始值为10，步长为5；并存入若干条数据
--将User表中Id列修改为可存储GUID的类型，并存入若干条包含GUID值的数据
DROP TABLE Keyword

CREATE TABLE Keyword
(
Id INT IDENTITY(10,5) PRIMARY KEY, 
[Name] NVARCHAR(10)
)
INSERT Keyword([Name]) VALUES('C#');
INSERT Keyword([Name]) VALUES('CSS');
INSERT Keyword([Name]) VALUES('sql');
DELETE Keyword
SELECT * FROM Keyword
SET IDENTITY_INSERT Keyword ON
SET IDENTITY_INSERT Keyword OFF
ALTER TABLE Keyword
--DROP COLUMN Id  
--DROP [PK__Keyword__3214EC070A822F73]
ADD  Id CHAR(40) 

INSERT Keyword(Id,[Name]) VALUES(NEWID(),'C#');
INSERT Keyword(Id,[Name])  VALUES(NEWID(),'CSS');
INSERT Keyword(Id,[Name])  VALUES(NEWID(),'SQL');
--Problem表已有Id列，如何给该列加上IDENTITY属性？

--在Problem中插入不同作者（Author）不同悬赏（Reward）的若干条数据，以便能完成以下操作： 
--ADD Author NVARCHAR(10)
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(15,N'C#进阶',N'.....',16,1,N'飞哥')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(16,N'JS语法',N'.....',66,1,N'飞哥')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(17,N'CSS浮动',N'.....',77,1,N'小鱼')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(18,N'C#基础',N'.....',25,1,N'飞哥')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(19,N'JAVA环境搭配',N'.....',101,1,N'飞哥')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(20,N'SQL语法',N'.....',123,1,N'小鱼')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(21,N'JS事件',N'.....',196,1,N'小鱼')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(22,N'JS回调函数',N'.....',67,1,N'小鱼')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(23,N'JS回调函数',N'.....',4,1,N'大鱼')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(24,N'JS回调函数',N'.....',3,1,N'大鱼')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(25,N'JS回调函数',N'.....',9,1,N'大鱼')
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(26,N'JS回调函数',N'.....',NULL,1,NULL)
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(27,N'JS回调函数',N'.....',NULL,1,NULL)
INSERT Problem(Id,Title,Content,Reward,NeedRemoteHelp,Author)
VALUES(28,N'JS回调函数',N'.....',NULL,1,NULL)

-- 查找出Author为“飞哥”的、Reward最多的3条求助

SELECT TOP 3 * FROM Problem
WHERE Author=N'飞哥' 
ORDER BY Reward DESC

--所有求助，先按作者“分组”，然后在“分组”中按悬赏从大到小排序

SELECT  Author, SUM(Reward) AS [Reward] FROM Problem
GROUP BY Author 
ORDER BY SUM(Reward) DESC
--查找并统计出每个作者的：求助数量、悬赏总金额和平均值
SELECT AUthor ,COUNT(*) AS [Count] FROM Problem
GROUP BY Author
SELECT AUthor ,SUM(Reward) AS [Sum] FROM Problem
GROUP BY Author
SELECT AUthor ,AVG(Reward) AS [Avg] FROM Problem
GROUP BY Author

--找出平均悬赏值少于10的作者并按平均值从小到大排序
--ALTER TABLE Problem
--DROP CONSTRAINT CK_Reward
SELECT Author, AVG(Reward) AS [Reward] FROM Problem
GROUP BY Author
--HAvING AVG(Reward)<10
ORDER BY AVG(Reward) ASC

--以Problem中的数据为基础，使用SELECT INTO，
--新建一个Author和Reward都没有NULL值的新表
--NewProblem （把原Problem里Author或Reward为NULL值的数据删掉） 
BEGIN TRANSACTION
SELECT * INTO NewProblem FROM Problem
WHERE NOT Author  IS NULL AND NOT Reward IS NULL
ROLLBACK
COMMIT
SELECT * FROM Problem
SELECT * FROM NewProblem
--使用INSERT SELECT, 将Problem中Reward为NULL的行再次插入到NewProblem中
BEGIN TRANSACTION
INSERT NewProblem
SELECT * FROM Problem
WHERE Author  IS NULL AND  Reward IS NULL
ROLLBACK
COMMIT 

-- 新建表Message(Id, FromUser, ToUser, UrgentLevel, Kind, HasRead, IsDelete, Content)，使用该表和SQL语句，证明：
--    唯一约束依赖于唯一索引
--    主键上可以是非聚集索引
--并利用“执行计划”图演示说明：Scan、Seek和Lookup的使用和区别。

USE [17bang]
CREATE TABLE [Message]
(
Id INT IDENTITY(1,1) PRIMARY KEY,
FromUser NVARCHAR(10),
ToUser NVARCHAR(10),
UrgentLevel INT,
Kind NVARCHAR(10),
HasRead BIT,
isDelete BIT,
Content TEXT
)

INSERT [Message](FromUser,ToUser,UrgentLevel,Kind,HasRead,isDelete,Content)
VALUES(N'飞哥',N'自由飞',1,NULL,1,1,N'......')
INSERT [Message](FromUser,ToUser,UrgentLevel,Kind,HasRead,isDelete,Content)
VALUES(N'大飞哥',N'自由飞',1,NULL,1,1,N'......')
INSERT [Message](FromUser,ToUser,UrgentLevel,Kind,HasRead,isDelete,Content)
VALUES(N'小鱼',N'自由飞',1,NULL,1,1,N'......')

--删除主键约束
ALTER TABLE [Message]
DROP CONSTRAINT [PK__Message__3214EC07AF2B02FF]
--添加唯一聚集索引
CREATE CLUSTERED INDEX IX_Message_Kind ON [Message](Kind)
--在主键上面添加非聚集索引
ALTER TABLE [Message]
ADD CONSTRAINT PK_ID PRIMARY KEY(Id)
CREATE INDEX IX_Message_ID ON[Message](Id)
DROP INDEX [Message].IX_Message_ID 

--添加唯一约束
ALTER TABLE [Message]
ADD CONSTRAINT UQ_Message_FromUser UNIQUE(FromUser);
--建立唯一索引
CREATE UNIQUE INDEX IX_Message_FromUser ON[Message](FromUser)
SELECT [name],[type] FROM sys.indexes
WHERE OBJECT_ID=OBJECT_ID('Message')

CREATE CLUSTERED INDEX IX_Message_ID ON[Message](Id)
CREATE INDEX IX_Message_TOUser ON[Message](ToUser)
CREATE INDEX IX_Message_IsDelete ON[Message](isDelete)

--当在所有表中查询某一个非聚集索引的数据时，会进行lookup再次查询
SELECT * FROM [Message]
WHERE Id=3
--WHERE FromUser LIKE N'%飞%'

--建立主表

CREATE TABLE Teacher
(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(10)
)
--建立从表并添加外键约束

CREATE TABLE Student
(
--级联 在主表被删除是自动删除所有从表数据 ON DELETE CASCADE
Id INT IDENTITY(1,1) PRIMARY KEY CONSTRAINT FK_Teacher_ID REFERENCES teacher(Id) ON DELETE CASCADE,
  
[name] NVARCHAR(10)
)
DROP TABLE Student
--添加外键约束

ALTER TABLE Student
--ALTER COLUMN [name] INT 
--ADD TeacherID INT
ADD CONSTRAINT FK_Teacher_ID FOREIGN KEY(ID) REFERENCES Teacher(Id) ON UPDATE SET NULL
--DROP COLUMN TeacherID 

--观察并模拟17bang项目中的：

--    用户资料，新建用户资料（Profile）表，和User形成1:1关联（有无约束？）。用SQL语句演示：

--        新建一个填写了用户资料的注册用户

BEGIN TRANSACTION
CREATE TABLE [Profile]
(
[UserID] INT PRIMARY KEY CLUSTERED  CONSTRAINT FK_User_ID FOREIGN KEY REFERENCES [User](ID) ON DELETE CASCADE, 
Gender BIT ,
Birthday DATE,
SelfIntroduction NVARCHAR(400)
)
ROLLBACK
COMMIT
USE [17bang]
SELECT * FROM [User]
SELECT * FROM [Profile]

--        通过Id查找获得某注册用户及其用户资料

UPDATE [User] SET [Password]=4321
WHERE Id=1
INSERT [User] (Id, UserName,[Password]) VALUES(2, N'飞哥',123456)
INSERT [User] (Id, UserName,[Password]) VALUES(3, N'小鱼',1234564)
INSERT [User] (Id, UserName,[Password]) VALUES(4, N'张志民',1234567)
--
INSERT [Profile](UserID,Gender,Birthday,SelfIntroduction)
VALUES(0,NULL,'1970-1-1',N'......')
INSERT [Profile](UserID,Gender,Birthday,SelfIntroduction)
VALUES(1,NULL,'1970-1-1',N'......')
INSERT [Profile](UserID,Gender,Birthday,SelfIntroduction)
VALUES(2,1,'1970-1-1',N'......')
INSERT [Profile](UserID,Gender,Birthday,SelfIntroduction)
VALUES(3,1,'1970-1-1',N'......')
INSERT [Profile](UserID,Gender,Birthday,SelfIntroduction)
VALUES(4,1,'1970-1-1',N'......')

SELECT * FROM [User],[Profile]
WHERE Id=1 AND [UserID]=1
--        删除某个Id的注册用户

BEGIN TRANSACTION
DELETE [User]
WHERE Id=1
ROLLBACK
COMMIT
--帮帮点说明：新建Credit表，可以记录用户的每一次积分获得过程，即
--：某个用户，在某个时间，因为某某原因，获得若干积分 
CREATE TABLE Creait
(
[UserID] INT,
[DateTime] DATETIME,
Access NVARCHAR(30),
Integral INT 
)
BEGIN TRANSACTION
ALTER TABLE Creait
ADD CONSTRAINT FK_Creait_User_ID FOREIGN KEY(UserID) REFERENCES [User](Id) ON DELETE CASCADE
ROLLBACK
COMMIT

INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(0,'2020-10-10',N'点赞',10)
INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(0,'2020-10-10',N'评论',20)
INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(0,'2020-10-10',N'点赞',10)
INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(2,'2020-10-10',N'发布文章',40)
INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(2,'2020-10-10',N'发布求助',30)
INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(3,'2020-10-10',N'点赞',10)
INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(4,'2020-10-10',N'评论',20)
INSERT Creait([UserID],[DATETIME],Access,Integral) VALUES(3,'2020-10-10',N'点赞',10)
SELECT * FROM Creait

 --发布求助，在Problem和User之间建立1:n关联（含约束）。用SQL语句演示：

 --   某用户发布一篇求助，
 --   将该求助的作者改成另外一个用户
 --   删除该用户
 SELECT * FROM Problem
 ALTER TABLE Problem
ADD UserID INT CONSTRAINT FK_Problem_User_ID FOREIGN KEY REFERENCES [User](Id) ON DELETE CASCADE 
 --DROP COLUMN UserID
 INSERT Problem (Id,Title,Content,Reward,PUblishDateTime,NeedRemoteHelp,Author,UserID)
 VALUES (29,N'sql表之间的关系',N'....',100,'2021-4-19',1,N'飞哥',2)
 BEGIN TRANSACTION
 --UPDATE Problem SET UserID=3
 DELETE Problem
 WHERE Id=29
 ROLLBACK
 COMMIT

  --求助列表：新建Keyword表，和Problem形成n:n关联（含约束）。用SQL语句演示：

  SELECT * FROM Keyword
  SELECT * FROM [User]
  TRUNCATE TABLE Keyword
ALTER TABLE Keyword
--ALTER COLUMN Id INT NOT NULL
ADD CONSTRAINT PK_KeyID  PRIMARY KEY(Id) 

INSERT Keyword(Id,[Name]) VALUES(1,N'C#');
INSERT Keyword(Id,[Name]) VALUES(2,N'SQL');
INSERT Keyword(Id,[Name]) VALUES(3,N'Js');
INSERT Keyword(Id,[Name]) VALUES(4,N'CSS');
--新建一张表用来建立关系

CREATE TABLE Problem2Keyword
(
ProblemID INT,
KeywordID INT
)

ALTER TABLE Problem2Keyword
--ADD CONSTRAINT FK_ProblemID FOREIGN KEY(ProblemID) REFERENCES Problem(ID) ON DELETE CASCADE
ADD CONSTRAINT FK_KeywordID FOREIGN KEY(KeywordID) REFERENCES Keyword(Id) ON DELETE CASCADE

INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(15,1)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(15,2)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(15,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(16,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(17,4)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(18,1)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(20,2)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(21,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(22,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(23,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(24,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(25,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(25,1)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(25,1)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(25,1)

  --  查询获得：某求助使用了多少关键字，某关键字被多少求助使用

SELECT KeywordID ,COUNT(KeywordID) AS Problem FROM Problem2Keyword
GROUP BY KeywordID
SELECT ProblemID,COUNT(ProblemID) AS Keyword FROM Problem2Keyword
GROUP BY ProblemID

  --  发布了一个使用了若干个关键字的求助
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(26,1)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(26,2)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(26,3)
INSERT Problem2Keyword(ProblemID,KeywordID) VALUES(26,4)

  --  该求助不再使用某个关键字
  --  删除该求助

DELETE Problem2Keyword
  WHERE ProblemID =26 
  --AND KeywordID=4
    --  删除某关键字
DELETE Problem
WHERE Id= 4
SELECT * FROM Problem2Keyword
SELECT * FROM Keyword

--联表查出求助的标题和作者用户名 
SELECT * FROM Problem
SELECT * FROM [User]
SELECT u.Id,p.Title,p.Author FROM Problem p
JOIN [User] u
ON P.UserID=u.Id

--查找并删除从未发布过求助的用户
BEGIN TRANSACTION
DELETE u FROM [User] u
LEFT JOIN Problem P
ON u.Id=p.UserID
WHERE Title IS NULL
ROLLBACK
COMMIT

--用一句SELECT显示出用户和他的邀请人用户名
ALTER TABLE [User]
ADD INVITEDBY INT 
SELECT *FROM [user]U1 JOIN [User] U2
ON U1.Id=u2.Id

--17bang的关键字有“一级”“二级”和其他“普通（三）级”的区别：
--    请在表Keyword中添加一个字段，记录这种关系
--    然后用一个SELECT语句查出所有普通关键字的上一级、以及上上一级的关键字名称，比如：

SELECT k1.[Name],k2.[Name],k3.[Name] FROM Keyword K1 
LEFT JOIN Keyword K2 ON K1.Grade= K2.Id
LEFT JOIN Keyword K3 ON K2.Grade =k3.Id


ALTER TABLE Keyword
ADD Grade INT

SELECT *FROM Keyword
INSERT Keyword(Id,[Name],Grade) VALUES (5,N'编程语言',NULL)
INSERT Keyword(Id,[Name],Grade) VALUES (6,N'开发工具',NULL)
INSERT Keyword(Id,[Name],Grade) VALUES (7,N'VS',6)
INSERT Keyword(Id,[Name],Grade) VALUES (8,N'HB',6)
INSERT Keyword(Id,[Name],Grade) VALUES (9,N'VSCODE',6)
INSERT Keyword(Id,[Name],Grade) VALUES (12,N'事务',30)
INSERT Keyword(Id,[Name],Grade) VALUES (11,N'JOIN',30)
INSERT Keyword(Id,[Name],Grade) VALUES (30,N'三级关键字',NULL)


--17bang中除了求助（Problem），还有意见建议（Suggest）和文章（Article），
--他们都包含Title、Content、PublishTime和Auhthor四个字段，但是：
--    建议和文章没有悬赏（Reward）
--    建议多一个类型：Kind NVARCHAR(20)）
--    文章多一个分类：Category INT）
--请按上述描述建表。然后，用一个SQL语句显示某用户发表的求助、建议和文章的Title、Content，并按PublishTime降序排列 
USE [17bang]
CREATE TABLE Suggest
(
Title NVARCHAR(20),
Content NVARCHAR(400),
PublishTime DATETIME ,
Kind NVARCHAR (20),
AuhthorID INT CONSTRAINT FK_Suggest_AuhthorID FOREIGN KEY REFERENCES [User](Id)

)
CREATE TABLE Article
(
Title NVARCHAR(20),
Content NVARCHAR(400),
PublishTime DATETIME ,
Category INT,
AuhthorID INT CONSTRAINT FK_Article_AuhthorID FOREIGN KEY REFERENCES [User](Id)

)
SELECT * FROM Article
SELECT * FROM Suggest

select * from (
SELECT P.Title,p.Content,p.PUblishDateTime,p.UserID FROM Problem P
--WHERE p.UserID=2
UNION ALL
SELECT A.Title,a.Content,a.PublishTime,A.AuhthorID FROM Article A
--WHERE A.AuhthorID=2
UNION ALL
SELECT s.Title,s.Content,s.PublishTime,S.AuhthorID FROM Suggest S
--WHERE s.AuhthorID=2
) T
Where T.UserID=2
ORDER BY T.PUblishDateTime DESC



