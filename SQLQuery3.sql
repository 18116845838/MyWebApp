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

 --为求助添加一个发布时间（TPublishTime），使用子查询：

 USE [17bang]
 SELECT * FROM Problem
 ALTER TABLE Problem
 ADD TPublishTime DATETIME

 --   删除每个作者悬赏最低的求助

 BEGIN TRANSACTION
DELETE Problem
WHERE Reward IN (
SELECT MIN(Reward) FROM Problem  WHERE Author IS NOT NULL GROUP BY UserID
)
  ROLLBACK
  COMMIT

   --   找到从未成为邀请人的用户
   SELECT Author FROM Problem
  
   SELECT * FROM  [User] 
   SELECT * FROM  [User] U1
   WHERE Id NOT IN(
   SELECT INVITEDBY FROM [User]U2
	WHERE INVITEDBY IS NOT NULL 
   )

 --   如果一篇求助的关键字大于3个，将它的悬赏值翻倍
 BEGIN TRANSACTION
 UPDATE Problem SET Reward*=2
 WHERE Id IN
 (
	SELECT ProblemID FROM Problem2Keyword
	GROUP BY ProblemID
	HAVING COUNT(ProblemID)>3
	)
	ROLLBACK
	COMMIT
	 SELECT * FROM Problem
	 SELECT * FROM Problem2Keyword
	 SELECT * FROM Keyword

 --   查出所有发布一篇以上（不含一篇）文章的用户信息
 SELECT * FROM [User]
 WHERE ID IN(
 SELECT UserID FROM Problem
 GROUP BY UserID
 HAVING  COUNT(UserID)>1
 )

 --   查找每个作者最近发布的一篇文章
 Use [17bang]

 SELECT * FROM Problem P1
 WHERE PUblishDateTime IN
 (
 SELECT MAX(PUblishDateTime) FROM Problem P2
 WHERE p1.Author=P2.Author
 )
 --   查出每一篇求助的悬赏都大于5个帮帮币的作者

SELECT Author   FROM Problem p2
GROUP BY Author
HAVING MIN(Reward)>5

-- 创建求助的应答表 TResponse(Id, Content, AuthorId, ProblemId, CreateTime)
CREATE TABLE TResponse
(
	Id INT IDENTITY(1,1),
	Content NVARCHAR(MAX),
	AuthorID INT CONSTRAINT FK_Tesponse_UserID FOREIGN KEY REFERENCES [User](Id) ON DELETE CASCADE,
	ProblemID INT CONSTRAINT FK_Tesponse_ProblemID FOREIGN KEY REFERENCES Problem(Id) ON DELETE CASCADE,
	CreateTime DATETIME
)
--然后生成一个视图VResponse(ResponseId, Content, AuthorId, AuthorName, ProblemId, ProblemTitle, CreateTime)，要求该视图：
--    能展示应答作者的用户名、应答对应求助的标题和作者用户名
--    只显示求助悬赏值大于5的数据
--    已被加密
--    保证其使用的基表结构无法更改

BEGIN TRAN
GO
ALTER VIEW VResponse
(ResponseId, Content, AuthorId, AuthorName, ProblemId, ProblemTitle, CreateTime)
WITH SCHEMABINDING,ENCRYPTION
AS SELECT 
	TR.Id,
	TR.Content,
	TR.AuthorID,
	UT.UserName,
	TR.ProblemID,
	P.Title,
	TR.CreateTime
	FROM dbo.TResponse TR
	JOIN dbo.Problem P ON TR.ProblemID =P.Id
	JOIN dbo.[User] UT ON UT.Id =TR.AuthorID
	JOIN dbo.[User] UP ON UP.Id= P.UserID
	WHERE P.Reward >5
	GO
	ROLLBACK
	COMMIT

	SELECT * FROM VResponse
	SELECT * FROM Problem
--演示：在VResponse中插入一条数据，却不能在视图中显示
INSERT VResponse(Content,AuthorId,ProblemId,CreateTime)
VALUES(N'3333',2,19,'2020-12-19')
INSERT VResponse(Content,AuthorId,ProblemId,CreateTime)
VALUES(N'3333',3,21,'2020-12-19')
--修改VResponse，让其能避免上述情形
GO
ALTER VIEW VResponse
(ResponseId, Content, AuthorId, AuthorName, ProblemId, ProblemTitle, CreateTime)
WITH SCHEMABINDING,ENCRYPTION
AS SELECT 
	TR.Id,
	TR.Content,
	TR.AuthorID,
	UT.UserName,
	TR.ProblemID,
	P.Title,
	TR.CreateTime
	FROM dbo.TResponse TR
	JOIN dbo.Problem P ON TR.ProblemID =P.Id
	JOIN dbo.[User] UT ON UT.Id =TR.AuthorID
	JOIN dbo.[User] UP ON UP.Id= P.UserID
	WHERE P.Reward >5
	WITH CHECK OPTION
	GO
		SELECT * FROM VResponse
--创建视图VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)，要求该视图：

--    能反映求助的标题、使用关键字数量和悬赏

GO
ALTER VIEW VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)
WITH SCHEMABINDING 
AS SELECT 
p.Id,p.Title,p.Reward,COUNT_BIG(*) [COUNT]
FROM dbo.Problem2Keyword P2K
JOIN dbo.Problem p ON P2K.ProblemID= p.Id
GROUP BY p.Id,p.Title,p.Reward
GO




--    在ProblemId上有一个唯一聚集索引
--    在ProblemReward上有一个非聚集索引
CREATE UNIQUE CLUSTERED INDEX IX_VProblemKeyword_ProblemId 
ON VProblemKeyword(ProblemId)

CREATE UNIQUE INDEX IX_VProblemKeyword_ProblemReward
ON VProblemKeyword(ProblemReward)
DROP  INDEX  VProblemKeyword.IX_VProblemKeyword_ProblemReward
SELECT * FROM Keyword
SELECT * FROM Problem2Keyword
--在基表中插入/删除数据，观察VProblemKeyword是否相应的发生变化
BEGIN TRAN
DELETE Problem
WHERE id=31
ROLLBACK
INSERT Problem
VALUES(30,N'视图添加option',N'ENCRYPTION',55,'2021-6-22',1,N'飞哥',2,NULL)
INSERT Problem2Keyword
VALUES(30,2)


SELECT * FROM   VProblemKeyword
SELECT * FROM   Problem2Keyword


   --测试
  SELECT * FROM Problem p1
WHERE Reward=(
SELECT MIN(Reward) FROM Problem p2
WHERE P1.Author=p2.Author
--GROUP BY (Author)
)
	
	SELECT ROW_NUMBER ()
	OVER(
	PARTITION BY Reward
	ORDER BY Reward )
	FROM Problem
SELECT TOP  2 * FROM Problem p1 
UNION ALL SELECT * FROM Problem p2 

 --分别使用派生表和CTE，查询求助表（表中只有一列整体的发布时间，没有年月的列），以获得：

 --   一起帮每月各发布了求助多少篇
 SELECT COUNT(*) Number, [month],[year] FROM(
 SELECT 
 MONTH(PUblishDateTime)[month],
 YEAR(PUblishDateTime)[year]
 FROM Problem
 ) myp
 GROUP BY myp.[month],myp.[year]

 GO
 WITH MYP
 AS(
 SELECT MONTH(PUblishDateTime)[month],
 YEAR(PUblishDateTime)[year]
 FROM Problem
 ) 
 SELECT COUNT(*),[month],[year] FROM MYP
 GROUP BY MYP.[month],MYP.[year]
 --   每个作者，每月发布的，悬赏最多的3篇

 SELECT * FROM (
	 SELECT *,ROW_NUMBER() OVER(
	 PARTITION BY MONTH(PUblishDateTime),YEAR(PUblishDateTime),Author
	 ORDER BY Reward
	 ) GID FROM Problem
 ) amyp

 WITH AMYP
 AS(
	 SELECT * ,ROW_NUMBER() OVER(
	  PARTITION BY MONTH(PUblishDateTime),YEAR(PUblishDateTime),Author
	 ORDER BY Reward) GID FROM Problem
 )
 SELECT * FROM AMYP
 --   每月发布的求助中，悬赏最多的3篇

 SELECT * FROM 
 (
	 SELECT *, ROW_NUMBER() OVER
	 ( PARTITION BY MONTH(PUblishDateTime),YEAR(PUblishDateTime)
	 ORDER BY Reward) GID FROM Problem
 ) myrp
 WHERE myrp.GID<=3
 GO
 WITH MYRP
 AS(
	 SELECT *, ROW_NUMBER() OVER
	 (
	 PARTITION BY MONTH(PUblishDateTime),YEAR(PUblishDateTime)
	 ORDER BY Reward
	 ) GID FROM Problem
 )
 SELECT * FROM MYRP
 WHERE MYRP.GID<=3
 --   分别按发布时间和悬赏数量进行分页查询的结果

SELECT TOP 3 * FROM Problem
WHERE Id NOT IN (
SELECT TOP 3 Id FROM Problem
ORDER BY PUblishDateTime
)

SELECT * FROM (
	SELECT *, ROW_NUMBER() OVER(
	--PARTITION BY PUblishDateTime
	ORDER BY PUblishDateTime
	) GID FROM Problem
) pp
WHERE pp.GID  BETWEEN 1 AND 4

SELECT * FROM Problem
ORDER BY PUblishDateTime
OFFSET 0 ROWS 
FETCH NEXT 4 ROWS ONLY 

SELECT TOP 4 * FROM Problem
WHERE Id NOT IN(
SELECT TOP 4 Id FROM Problem
ORDER BY Reward
)

SELECT * FROM (
	SELECT *, ROW_NUMBER() OVER(
	--PARTITION BY Reward
	ORDER BY Reward
	) GID FROM Problem
) pp
WHERE pp.GID BETWEEN 1 AND 4
SELECT * FROM Problem
ORDER BY Reward
OFFSET 0 ROWS
FETCH NEXT 4 ROWS ONLY  

--用户发布一篇悬赏币若干的求助（TProblem），他（TReigister）的帮帮币（BMoney）
--也会相应减少，但他的帮帮币总额不能少于0分：请综合使用TRY...CATCH和事务完成上述需求。 

SELECT * FROM BangMoney
--创建BangMoney表--添加约束
CREATE TABLE BangMoney
(
ID INT NOT NULL PRIMARY KEY,
Amount INT ,
Balace INT CONSTRAINT CK_BangMoney_Balace CHECK (Balace>=0),
UserID INT CONSTRAINT FK_USERID FOREIGN KEY REFERENCES [user](Id) ON DELETE CASCADE,
)
UPDATE BangMoney SET Balace = 100

BEGIN TRY
	BEGIN TRANSACTION
	INSERT BangMoney VALUES(3,+10,-110,2)
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK;
	THROW;
END CATCH

DBCC USEROPTIONS
SELECT @@TRANCOUNT
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

--序列化
SET TRANSACTION ISOLATION LEVEL   REPEATABLE READ
INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
(100,N'当前',N'我是正文',0,10,'2020/1/1')
INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
(98,N'当前',N'我是正文',0,10,'2020/1/1')
BEGIN TRAN
SELECT * FROM Problem
ROLLBACK
SELECT * FROM Problem
BEGIN TRANSACTION
UPDATE Problem SET NeedRemoteHelp =1 WHERE ID=99


    --打印如下所示的等腰三角形： 

    --      1

    --    333

    --  55555

    --7777777

DECLARE @i INT=1
DECLARE @count INT = 3
while(@i<=7)
	BEGIN 
	PRINT SPACE(@count)+REPLICATE(@i,@i)
	SET @i+=2
	SET @count -=1
	END

    --TProblem中：
    --    找出所有周末发布的求助（添加CreateTime列，如果还没有的话）
	SELECT * FROM Problem
	WHERE DATEPART(dw,PUblishDateTime)=1

    --    找出每个作者所有求助悬赏的平均值，精确到小数点后两位
	SELECT Author, CONVERT(DECIMAL(6,2), SUM(Reward*1.00)/COUNT(Reward))	FROM Problem
	GROUP BY Author

    --    有一些标题以test、[test]后者Test-开头的求助，找打他们并把这些前缀都换成大写
	INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
	(114,N'test当前',N'我是正文',0,10,'2020/1/1')
	INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
	(110,N'【test】当前',N'我是正文',0,10,'2020/1/1')
	INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
	(112,N'【test】-当前',N'我是正文',0,10,'2020/1/1')
	INSERT Problem(Id,Title,Content,NeedRemoteHelp,Reward,PUblishDateTime) VALUES
	(113,N'test-当前',N'我是正文',0,10,'2020/1/1')
	SELECT * FROM Problem
	BEGIN TRAN 
	UPDATE Problem SET Title = REPLACE(Title,N'test',N'TEXT')
		SELECT * FROM Problem

	BEGIN TRANSACTION
	UPDATE Problem SET Title =
	CASE 
		WHEN SUBSTRING([Title],1,4) = N'test' THEN ( N'TEST'+ SUBSTRING([Title],5,LEN(Title)-4) )
		WHEN SUBSTRING(Title,1,6) = N'【TexT】' THEN N'【TEST】'+SUBSTRING(Title,7,LEN(Title)-6) 
		WHEN SUBSTRING(Title,1,4) = N'Text'  THEN N'TEST'+SUBSTRING(Title,5,LEN(Title)-4) 
		ELSE TITLE
	END
	


	PRINT @@TRANCOUNT
	ROLLBACK
	COMMIT

    --定义一个函数RANDINT(INT max)，可以取0-max之间的最大值
	GO
CREATE FUNCTION RANDINT(@max INT)
RETURNS INT 
AS 
BEGIN 
	RETURN @max
END
GO
PRINT dbo.RANDINT (100)

DECLARE @max INT 
EXECUTE @max= RANDINT 100
PRINT @max
	
	 --编写存储过程“一起帮用户注册”，包含以下逻辑：

  --  检查用户名是否重复。如果重复，返回错误代码：1

  --  检查用户名密码是否符合“长度不小于4位”的要求。如果不符合，返回错误代码：2

  --  如果有邀请人：
  --      检查邀请人是否存在，如果不存在，返回错误代码：10
  --      检查邀请码是否正确，如果邀请码不正确，返回错误代码：11
  --  将用户名、密码和邀请人存入数据库（TRegister）
  --  给邀请人增加10个帮帮点积分
  --  通知邀请人（TMessage中生成一条数据）某人使用了他作为邀请人。
  GO
  ALTER PROCEDURE UserRegister
  @USERNAME NVARCHAR(20),
  @PASSWORD NVARCHAR(20),
  @INVITERID  INT ,
  @INVITERCODE NVARCHAR(20)
  AS 
	IF(LEN(@PASSWORD)>4)
	BEGIN 
		IF(EXISTS(SELECT UserName  FROM [User] WHERE UserName = @USERNAME))
			BEGIN 
				RETURN 1
			END
			ELSE
			BEGIN
					DECLARE @invitedbycode NCHAR(20) =(SELECT INVITEDBYCODE FROM [User] WHERE ID =@INVITERID)
					IF(@invitedbycode IS NULL)
					BEGIN
						RETURN 10
					END
					ELSE
					BEGIN 
						BEGIN TRY
						BEGIN TRAN
								IF(@invitedbycode=@INVITERCODE)
								BEGIN 
								INSERT TRegister VALUES(@USERNAME,@PASSWORD,@INVITERID)

								DECLARE @Balace  INT =  (SELECT TOP 1 Balace FROM BangMoney
								WHERE UserID = 2 ORDER BY Id DESC)
								INSERT BangMoney (Amount,Balace,UserID) 
								VALUES(10,@Balace+10,@INVITERID)

								DECLARE @INVITERNAME NVARCHAR(20)= (SELECT UserName FROM [User] WHERE ID = @INVITERID)
								INSERT TMessage([Message]) VALUES (@USERNAME+N'使用了'+@INVITERNAME+N'作为邀请人')
								END
								COMMIT
						END TRY
						BEGIN CATCH
							ROLLBACK;
							THROW;
						END CATCH
						end
					END
			END
	ELSE 
	RETURN 2

	DECLARE @i INT
	  EXEC @i= UserRegister N'2021年10月10日此测试' ,12555, 2,1233
	  PRINT @i
	SELECT * FROM BangMoney

	SELECT * FROM TRegister
	SELECT * FROM TMessage

 CREATE TABLE TRegister
 ( 
 UserName NVARCHAR(20),
 [PASSWORD] NVARCHAR(20),
 INVITERID INT
 )

CREATE TABLE TMessage
(
ID INT PRIMARY KEY IDENTITY(1,1),
[MESSAGE] NVARCHAR(500)
)
--DECLARE @INVITERNAME NVARCHAR(20)= SELECT UserName FROM [User] WHERE ID = 2
--PRINT @INVITERNAME


--确保Peoblem有发布时间（PublishTime） 和最后更新时间（LatestUpdateTime）两列，创建触发器实现

--1更新一条数据，自动将当前时间计入该行数据的LatestUpdateTime
  SELECT * FROM Problem
  ALTER TABLE Problem
  ADD LatestUpdateTime DATETIME
  GO
ALTER  TRIGGER TR_Problem	
ON Problem    
 AFTER  UPDATE 
AS 
UPDATE Problem SET LatestUpdateTime = GETDATE()
FROM Problem p JOIN INSERTED i ON P.id= i.id
SELECT  * FROM INSERTED

UPDATE Problem SET  Reward =15
WHERE id =105
--2插入一条数据，自动将当前时间计入该行数据的PublishTime（提示 ：inserted伪表）
GO
ALTER TRIGGER TR_INS_Problem
ON Problem
AFTER INSERT 
AS UPDATE Problem SET PUblishDateTime=GETDATE()
FROM Problem p JOIN INSERTED i ON P.id =i.id
--SELECT * FROM INSERTED

INSERT Problem VALUES(117,N'DML触发器',N'INSERTED伪表',100,NULL,1,NULL,NULL,NULL,NULL)

SELECT * FROM Problem
SELECT * FROM INSERTED
ROLLBACK
COMMIT
SELECT * FROM [User]
WHERE ID IN (1,2,3,4,5,6)
--WHERE [UserName]=N'飞哥
--';UPDATE [User] SET [Password] = N'zxcvvb' ; --
--'
