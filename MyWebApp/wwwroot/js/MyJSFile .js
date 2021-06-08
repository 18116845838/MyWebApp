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

//使用JavaScript内置字符串函数，处理 “‘源栈’：飞哥小班教学，线下免费收看” ：将“飞哥”改成“大神”，“线下”改成“线上”。
{
    let str = " 飞哥小班教学，线下免费收看";
    str = str.replace("飞哥", "大神").replace("线上", "线下");

    console.log(str);

    //将数组['why', 'gIT', 'vs2019', 'community', 'VERSION']规范化，让所有元素：

    //首字母大写开头，其他字母小写
    //截去超过6个字符的部分，如'community'将变成'Commun'
    let array = ['why', 'gIT', 'vs2019', 'community', 'VERSION'];

    for (var i = 0; i < array.length; i++) {
        let string = array[i];
        string = string.toLowerCase();
        array[i] = string[0].toUpperCase() + string.substring(1, string.length);
        if (array[i].length > 6) {
            array[i] = array[i].slice(0, 6);
        }
    }
    console.log(array);
}
{
    //使用正则表达式判断某个字符串:
    //是否是合格的Email格式
    //是否是小数（正负小数都可以）
    //将所有以zyf - 开头的属性去掉zyf - （尽可能多的制造测试用例，比如：<a lzyf-old=''，或者：<span>zyf---+---fyz</span> ……）
    let regexp = /^\s*\w+@{1}\w+\.{1}\w+\s*$/;
    let str = "2811733392@qq.com";
    console.log(regexp.test(str));// true
    console.log(regexp.exec(str));
    console.log(str.match(regexp));
    console.log(str.search(regexp));//0

    let isFolat = /^\s*-*\d+\.\d+\s*$/;
    console.log(isFolat.test(-0.12));// true
    console.log(isFolat.exec(-0.12));
    console.log(isFolat.test(0.12));// true
    console.log(isFolat.test("ww"));//false
    console.log(isFolat.test(3));//false

    let Element = /(?<=zyf-)\w+/;
    console.log(Element.test("<a lzyf-old=''"));//false
    console.log(Element.test("<span>zyf---+---fyz</span>"));//false
    console.log(Element.test("<a lzyf-=''"));//false
    console.log(Element.test("<a zyf-=''"));//false
    console.log(Element.test("<a zyf-d=''"));// true

}