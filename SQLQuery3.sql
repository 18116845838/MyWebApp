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
