--练习
CREATE TABLE ONLYYOU
(
 ID INT  IDENTITY(1,2) CONSTRAINT PF_ONLY UNIQUE,
 [name] NVARCHAR(20)
)
--ALTER TABLE ONLYYOU
--ADD CONSTRAINT FK_NAME CHECK ([name]=N'feige')
CREATE UNIQUE CLUSTERED INDEX IX_ONLYYOU_ID ON ONLYYOU(Id)
CREATE UNIQUE NONCLUSTERED INDEX IX_ONLYYOU_NAME ON ONLYYOU([name])
SELECT * FROM ONLYYOU o1
JOIN ONLYYOU o2 ON
o1.ID=o2.ID
SELECT * FROM ONLYYOU o1
UNION ALL
SELECT * FROM ONLYYOU o2

GO
CREATE VIEW V_FETCH
WITH SCHEMABINDING
AS 
SELECT ID ,[name] FROM ONLYYOU
GO
SELECT * INTO NEW
FROM ONLYYOU
-- 创建求助的应答表 TResponse(Id, Content, AuthorId, ProblemId, CreateTime)

CREATE TABLE TResponse
(
Id INT IDENTITY(1,1) ,
Content NVARCHAR(MAX),
AuthorID INT CONSTRAINT FK_TResponse_UserID FOREIGN KEY REFERENCES [User](id) ON DELETE CASCADE,
ProblemID INT CONSTRAINT FK_TResponse_ProblemID FOREIGN KEY REFERENCES Problem(id) ON DELETE CASCADE ,
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
WITH SCHEMABINDING,ENCRYPTION
	AS SELECT 
	R.ID ResponseID,
	R.Content Content,
	R.AuthorId  ResponseAuthorId,
	Ru.UserName ResponseName,
	R.ProblemId ProblemId,
	PU.UserName ProblemAuthorname,
	R.CreateTime CreateTime
	FROM dbo.TResponse R
	JOIN dbo.Problem p ON R.ProblemId=p.id
	JOIN dbo.[User] Ru ON R.AuthorId =Ru.Id
	JOIN dbo.[User] PU  ON p.UserID= PU.Id
	--WHERE R.CreateTime>'2020-5-27'
	GO
	ROLLBACK 
	COMMIT
	GO
	ALTER  VIEW VResponse
(ResponseId,Content,AuthorId,AuthorName,
ProblemId,ProblemTitle, CreateTime)
--WITH SCHEMABINDING,ENCRYPTIONk
	AS SELECT 
	R.ID ResponseID,
	R.Content Content,
	R.AuthorId  ResponseAuthorId,
	Ru.UserName ResponseName,
	R.ProblemId ProblemId,
	PU.UserName ProblemAuthorname,
	R.CreateTime CreateTime
	FROM dbo.TResponse R
	JOIN dbo.Problem p ON R.ProblemId=p.id
	JOIN dbo.[User] Ru ON R.AuthorId =Ru.Id
	JOIN dbo.[User] PU  ON p.UserID= PU.Id
	WHERE R.CreateTime<'2020-5-27'
	GO
	SELECT *  FROM VResponse
	SELECT *  FROM [User]
	SELECT *  FROM Problem

--演示：在VResponse中插入一条数据，却不能在视图中显示
INSERT VResponse(Content,AuthorId,AuthorName,ProblemId,ProblemTitle,CreateTime)
VALUES(N'.....',4,N'da飞哥',58,N'C#基础','2019-2-13')
INSERT VResponse(Content,ResponseAuthorID,ProblemId,CreateTime)
VALUES( N'.....',2,19,'2019-2-13')
--修改VResponse，让其能避免上述情形
--创建视图VProblemKeyword(ProblemId, ProblemTitle, ProblemReward, KeywordAmount)，要求该视图：

--    能反映求助的标题、使用关键字数量和悬赏
--    在ProblemId上有一个唯一聚集索引
--    在ProblemReward上有一个非聚集索引

--在基表中插入/删除数据，观察VProblemKeyword是否相应的发生变化

BEGIN TRY
BEGIN TRAN 
COMMIT
	SAVE TRAN inner_tran
	ROLLBACK TRAN inner_tran 
	COMMIT TRAN
END TRY
BEGIN CATCH
	IF @@TRANCOUNT>0
	ROLLBACK;
END  CATCH

BEGIN TRANSACTION
UPDATE Problem SET NeedRemoteHelp =1 WHERE ID=100
SET TRANSACTION ISOLATION LEVEL   REPEATABLE READ
ROLLBACK
SELECT @@TRANCOUNT
SELECT * FROM Problem
DBCC USEROPTIONS



--添加索引
CREATE UNIQUE CLUSTERED INDEX IX_USER_ID ON [user](ID)
--添加约束
ALTER TABLE [User]
--ADD BMoney INT
ADD CONSTRAINT CK_USER_BMoney CHECK(BMoney>=0)
-- 18是默认值,作用于Age列
ALTER TABLE Student
ADD CONSTRAINT DF_Age DEFAULT 18 FOR Age; -- 注意写法的差异
--查看事务状态
SELECT @@TRANCOUNT--查看事务
DBCC USEROPTIONS--查看隔离级别
--各种开关语句
--升级事务隔离级别
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;--可重复读
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE --序列化 解决幻影读问题

--开启事务
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED --读未提交
SET TRANSACTION ISOLATION LEVEL READ COMMITTED   --读已提交
-- 设置只要有错误（无论级别）就回滚事务
SET XACT_ABORT ON
SET XACT_ABORT OFF
--开启关闭自增列
SET IDENTITY_INSERT Keyword ON
SET IDENTITY_INSERT Keyword OFF
--打开隐式事务
SET IMPLICIT_TRANSACTIONS ON
SET IMPLICIT_TRANSACTIONS OFF
--启用/禁用指定表所有外键约束   
ALTER TABLE TBNAME  NOCHECK CONSTRAINT ALL  
ALTER TABLE TBNAME  CHECK CONSTRAINT ALL
--禁用/恢复某个表的某个触发器
ALTER TABLE tbname DISABLE TRIGGER trigname
ALTER TABLE tbname ENABLE TRIGGER trigname
--禁用恢复某个表上的所有触发器
ALTER TABLE tbname DISABLE TRIGGER all
ALTER TABLE tbname ENABLE TRIGGER all

--常用变量全局
print @@VERSION--版本号查看
PRINT @@IDENTITY--查看最后一个插入的自增列值
print @@ROWCOUNT--查看看上一次影响的行数


--变量的声明
DECLARE @name NVARCHAR(20) ;
SET @name = N'飞哥'
PRINT @name

DECLARE @name NVARCHAR(20) = N'feige'
PRINT @name

--if 不加begin end 就只影响一行
IF(@name IS NULL) 
	BEGIN 
		PRINT 'NULL'
	END
ELSE
	PRINT 'NOT NULL'
--循环
	DECLARE @num INT =0 
WHILE(@num<50)
BEGIN 
	SET @num+=1;
	PRINT FLOOR(RAND()*1000)
END 
PRINT CHARINDEX(N'栈',N'源栈欢迎您',-1) 
PRINT GETDATE()

PRINT DATEPART(hour,GETDATE())

GO
--普通函数
	CREATE FUNCTION RANDINT(@max INT)
RETURNS INT 
AS 
BEGIN 
	RETURN @max
END
go
PRINT dbo.RANDINT (100)
	--表值函数返回单行
	Go
	CREATE FUNCTION NUMCOUNT(@i INT)
	RETURNS TABLE
	RETURN SELECT TOP (@i) * FROM Problem
	go
SELECT * FROM NUMCOUNT(5)
Go
--函数返回表值
CREATE FUNCTION TAB(@i INT,@n NVARCHAR(20))
RETURNS @t TABLE([id] INT,[name] NVARCHAR(20))
AS 
BEGIN 
	INSERT @t VALUES(@i,@n)
	RETURN 
END
go
SELECT * FROM TAB(1,N'飞哥')
--存储过程
GO
 ALTER PROCEDURE T
@i INT --,
--@j INT OUTPUT
AS
SET NOCOUNT ON 
UPDATE Problem SET Reward += 5
SELECT * FROM  Problem WHERE Reward>@i
RETURN(SELECT COUNT(*) FROM Problem WHERE Reward >@i)
SET NOCOUNT OFF

DECLARE @Q INT 
EXECUTE @Q= T 80
SELECT @Q

--得到返回值方法	
	DECLARE @i INT
	  EXEC @i= UserRegister N'zai此测试' ,125, 2,1233
	  PRINT @i 