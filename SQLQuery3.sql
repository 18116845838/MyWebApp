--新建一个数据库：17bang，能指定/查看该数据库存放位置 
CREATE DATABASE [17bang];
--依次备份/删除/恢复该数据库 --
BACKUP DATABASE [17bang] TO DISK='D:\\yz\\17bang.bak';

DROP DATABASE [17bang];

RESTORE DATABASE [17bang] FROM DISK='D:\\yz\\17bang.bak';

