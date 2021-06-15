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