////分别用HTML页面内嵌和.js文件引用的方式，弹出你的入栈口号。
////声明一个变量sname，表示同学的姓名；通过更改变量值，弹出至少3个同学的姓名
////配置Visual Studio，让其能自动检测从你Javascript中不规范 / 错误的代码
//var slogan = "键盘敲烂,月薪过万!";
//alert(slogan);
//var sname = "张志民";
//alert(sname);

//sname = "周丁浩";
//alert(sname);

//sname = "杨家栋";
//alert(sname);
//观察“一起帮”的求助，定义一个problem对象，其中包含title、body、reward、needRemote等属性 
//var problem = {
//    title: null,
//    body: null,
//    reward: null,
//    needRemote: null
//}
//用JavaScript变量pBody存储这行Html代码：
    //< a href = 'http://17bang.ren' target = "_blank" > 源栈·一起帮</a>，助你实现 < span style = "font-size:16px;" > 编程</span > 梦想！
var pBody = "<a href='http://17bang.ren' target=\"_blank\" > '源栈·一起帮</a>，助你实现<span style=\"font - size: 16px;\" >编程</span>梦想！"
//用一个变量替换“编程”，以便输出更多内容。比如：助你实现{ 职业 } 梦想、助你实现{ 人生 } 梦想 
//var dream = "编程";
//alert('祝你实现' + dream + '梦想 ');
//dream = "职业";
//alert('祝你实现' + dream + '梦想 ');
//dream = "人生";
//alert('祝你实现' + dream + '梦想 ');

/*//设计一段代码，实现以下逻辑：

//某用户有一定数量的帮帮豆（sum）
//每点赞一次就会消耗若干帮帮豆（consume）
//现在用户点赞若干次（count）
//计算用户剩余了多少帮帮豆（banlance）并用bool值显示他是否还有帮帮豆（isAvailable）

//以上皆需设置变量（变量名见圆括号），并代入计算*/
/*var sum, consume, count, banlance, isavailable;
banlance = sum-consume * count;
isavailable = banlance > 0;*/

//写一段代码，能根据一起帮用户的帮帮点（bCredit）输出他对应的等级（可适度精简） 
/*var bCredit = NaN;
var grade;
if (isNaN(bCredit)) {
    grade = "错误";
} else {
    if (bCredit <= 10) {
        grade = "入门";
    } else if (bCredit <= 20) {
        grade = "聚气";

    } else if (bCredit <= 30) {
        grade = "凝水";

    } else if (bCredit <= 50) {
        grade = "萌芽";

    } else {
        grade = "单叶"
    }
}
console.log(grade);*/
//用switch表示一起帮身份代号
/*var user;
var rank;
switch (user) {
    case 0:
        rank = "访客";
        break;
    case 1:  
        rank = "注册用户";
        break;
    case 2: 
        rank = "文章发布者";
        break;
    case 3:   
        rank = "管理员";
        break;
    case 4:    
        rank = "超级管理员";
        break;
    default:
        rank = "身份有误";
        break;
}
console.log(rank);*/