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
