{
    //构建函数
    //has9(number) ，可以判断number中是否带有数字9；
    //has8(number) ，可以判断number中是否带有数字8；
    //has6(number) ，可以判断number中是否带有数字6；
    //让get986()通过调用has9() / has8() / has6() ，能找出number以内有多少个数字包含：9或者8或6。
    function has9() {
        let sum = 0;
        for (let i = 0; i < arguments.length; i++) {
            arguments[i] = arguments[i] + '';
            for (let j = 0; j < arguments[i].length; j++) {
                if (arguments[i][j] === '9') {
                    sum++;
                } //else
            }
        }
        return sum;
    }
    function has8() {
        let sum = 0;
        for (let i = 0; i < arguments.length; i++) {
            arguments[i] = arguments[i] + '';
            for (let j = 0; j < arguments[i].length; j++) {
                if (arguments[i][j] === '8') {
                    sum++;
                }//else
            }
        }
        return sum;
    }
    function has6() {
        let sum = 0;
        for (let i = 0; i < arguments.length; i++) {
            arguments[i] = arguments[i] + '';
            for (let j = 0; j < arguments[i].length; j++) {
                if (arguments[i][j] === '6') {
                    sum++;
                }//else
            }
        }
        return sum;
    }
    function get986() {
        let sum = 0;
        for (let i = 0; i < arguments.length; i++) {
            sum += arguments[i];
        }
        return sum;
    }

    console.log(get986(has9(19, 29, 39, 4), has8(1, 2, 5, 18, 9), has6(1, 6, 16, 5)));





    //将之前“找出素数”的代码封装成一个函数findPrime(max) ，可以打印出max以内的所有素数。


    /*function findPrime(max) {
        for (let i = 2; i <= max; i++) {
            isPrime = true;
            for (let j = 2; j < i; j++) {
                if (i % j === 0) {
                    isPrime = false;
                    break;
                }//else
            }
            if (isPrime) {
                console.log(i);
            }
        }
    }
    findPrime(101);*/

    //自行设计参数，将之前“累加求和”的代码封装成一个函数Sum() ，可以计算任意起始位置、任意步长（如：1, 3, 5……或者0, 5, 10, 15……）的等差数列之和。
    /*function sum(startNumber, stepSize, endNumber) {
        let number = 0;
    
        for (let i = startNumber; i < endNumber; i += stepSize) {
            startNumber += stepSize;
            if (startNumber<= endNumber) {
               
                number += startNumber;
            }//else
    
        }
        return number;
    }
    console.log(sum(2, 49, 100));*/
    //封装一个函数，建立一个函数getMaxNumber() ，可以接受任意多各种类型的参数，并找出里面最大的数（忽略数值以外的其他类型） 
    /*function getMaxNumber() {
        let MaxNumber = 0;
        for (let i = 0; i < arguments.length; i++) {
            if (typeof(arguments[i])==="number") {
                if (arguments[i]>MaxNumber) {
                    MaxNumber = arguments[i];
                }//else
            } //else 
    
        }
        return MaxNumber;
    }
    console.log(getMaxNumber(9,[],17+3,NaN,"100",undefined,99, 3, 4, 7));*/

    //封装一个函数swap(arr, i, j) ，可以交换数组arr里下标 i 和 j 的值
    function swap(arr, i, j) {
        let temp;
        temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    let arr = [7, 1, 2, 1, 3, 4, 7, 5, 6, 3,];
    //console.log(swap(arr, 0, 1));

    //利用上面的swap()函数，将“冒泡排序”封装成函数bubbleSort() 
    function bubbleSort(arr) {
        for (let i = 0; i < arr.length; i++) {
            for (let j = 0; j < arr.length - 1 - i; j++) {
                if (arr[j] > arr[j + 1]) {
                    swap(arr, j, j + 1);
                }//else=
            }
        }
    }
    bubbleSort(arr);
    //封装函数deleteDuplicated()删除一个数组里面重复的元素
    function deleteDuplicated(arr) {
        for (let i = 0; i < arr.length; i++) {
            for (let j = i + 1; j < arr.length; j++) {
                if (arr[i] === arr[j]) {
                    arr.splice(j, 1);
                    j--;
                }
            }
        }
    }
    deleteDuplicated(arr);

    //不使用JaKvaScript内置函数

    /*将一个字符串顺序颠倒，比如：'hello,yuanzhan' 变成 'nahznauy,olleh'。
    统计出这段文字中有多少个单词：
    There are two ways to create a RegExp object: a literal notation and a constructor.To indicate strings, the parameters to the literal notation do not use 
    quotation marks while the parameters to the constructor function do use quotation - marks.So the following expressions create the same regular expression*/
    let str = 'hello,yuanzhan';
    function getAnagram(str) {
        let Newstr = '';

        for (let i = 1; i <= str.length; i++) {
            Newstr += str[str.length - i];
        }
        return Newstr;
    }
    console.log(getAnagram(str));
    let text = 'There are two ways to create a RegExp object : a literal notation and a constructor. To indicate strings , the parameters to the literal notation do not use quotation marks while the parameters to the constructor function do use quotation-marks. So the following expressions create the same regular expression';
    function getWordCount(text) {
        let Count = 1;
        for (let i = 0; i < text.length; i++) {
            if (text[i] === " ") {
                Count++;
            }//else
            if (text[i] === "," || text[i] === "." || text[i] === ":") {
                if (text[i - 1] === " " && text[i + 1] === " ") {
                    Count--;
                }//else
            }//else

        }
        return Count;
    }
    console.log(getWordCount(text));

    //使用“模拟名称空间”技术，构建一个函数函数yz.fei.get(number) ； 

    //yz.fei.get(number, handler)除number以外，还可以接受回调函数handler做参数，得到：0到number间有多少个满足handler条件的整数。

    /*回调函数handler能对number进行运算，并返回bool值的，比如has6()
    get()函数调用回调函数进行运算，只要回调函数运行结果为真，就累加计数
    最后返回累加值
    
    让yz.fei.get(number)调用实现之前“统计含9 / 8 / 6数字个数”的作业*/
    let yz = {};
    yz.fei = {};
    yz.fei.get = function (number, handler) {
        let Count = 0;
        for (let i = 0; i < number; i++) {
            if (handler(i)) {
                Count++;
            }//else
        }
        return Count;
    };
    console.log(yz.fei.get(100, handler));

    function handler(number) {
        number = number + '';
        for (let i = 0; i <= number.length; i++) {
            if (number[i] === '6' || number[i] === '8' || number[i] === '9') {
                return true;
            }//else
        }
        return false;
    }


}

//创建一个函数getRandomArray(length, max) ，能返回一个长度不大于length，每个元素值不大于max的随机整数数组

{
    function getRandomArray(lenth, max) {

        let array = [];
        for (var i = 0; i < lenth; i++) {
            array[i] = Math.round(Math.random() * max);
        }
        return array;
    }
    console.log(getRandomArray(10, 100));

}
//生成一个函数toChinese() ，可将传入的日期参数（如：new Date() ）转换成中文日期格式（如：2019年10月4日 16点54分）
{
    function toChinese(date) {
        let year = date.getFullYear(),
            month = (date.getMonth() + 1) + '',
            day = date.getDate() + '',
            hours = date.getHours() + '',
            minutes = date.getMinutes() + '';
        let dateTime = year + "年" + month + "月" + day + "日" + ' ' + hours + "时" + minutes + "分";
        return dateTime;
    }
    console.log(toChinese(new Date()));
    console.log(toChinese(new Date('2019/4/20')));
}
//生成一个函数addDays(number) ，可在当前日期的基础上增加number天 
{
    function addDays(number) {
        let dateTime = new Date().setDate(new Date().getDate() + number);
        dateTime = new Date(dateTime);
        return dateTime;
    }
    console.log(addDays(33));
}
/*完成猜数字的游戏：

弹出游戏玩法说明，等待用户点击“确认”，开始游戏；
浏览器生成一个不大于1000的随机正整数；（Math.floor(Math.random() * 1000) ）
用户输入猜测；
如果用户没有猜对，浏览器比较后告知结果：“大了”或者“小了”。如果用户：
只用了不到6次就猜到，弹出：碉堡了！
只用了不到8次就猜到，弹出：666！
用了8 - 10次猜到，弹出：猜到了。
用了10次都还没猜对，弹出：^ (*￣(oo) ￣)^

*/

{
    let start = confirm("下面要进行一次猜数字的游戏，请输入1000以内的数字，共有十次机会，请点击确认开始");
    if (start) {
        let number = Math.floor(Math.random() * 1000);
        for (var i = 0; i < 10; i++) {
            let input = +prompt();
            if (!isNaN(input) && i < 9) {
                if (input < number) {
                    alert("小了");
                } else if (input > number) {
                    alert("大了");
                } else {
                    if (i < 6) {
                        alert("碉堡了！");
                    } else if (i < 8) {
                        alert("666！");
                    } else {
                        alert("猜到了");
                    }
                    break;
                }
            } else {
                alert("^ (*￣(oo) ￣)^");
                break;
            }
        }
    }//else

}
//分别使用setInterval()使用setTimeout()实现：每隔1秒钟依次显示：第n周，源栈同学random人。（n逐次递增，random随机）
{

    let n = 1;
    //setInterval(function () {
    //    let random = Math.floor(Math.random() * 1000);
    //    console.log(`第${n++}周,源栈同学${random}人`);
    //}, 1000);


    //let getStudentNumber = function () {
    //    let random = Math.floor(Math.random() * 1000);
    //    console.log(`第${n++}周,源栈同学${random}人`);
    //    setTimeout(getStudentNumber, 1000);
    //}
    //setTimeout(getStudentNumber, 1000);

}
//模拟求助首页，并：

//统计有多少个悬赏大于1的求助
//将状态为“协助中”的求助背景改成灰黑色
//如果总结数为0，将其从DOM树中删除

{
    let reaward = document.getElementsByClassName("reaward");//悬赏
    let conclusion = document.getElementsByClassName("fa fa-key");//总结
    let problemCount = 0;
    for (let i = 0; i < reaward.length; i++) {
        let reawards = +(reaward[i].innerText[reaward[i].innerText.length - 2]);
        let reawardBackground = document.getElementsByTagName("h4")[i].firstElementChild;//背景色
        if (reawards > 1) {
            problemCount++;
        }//else
        if (conclusion[i].innerText[conclusion[i].innerText.length - 1] === '0') {
            conclusion[i].parentNode.parentElement.remove();
        } //else
        if (reawardBackground.innerHTML === "协助中") {
            reawardBackground.style = "background-color: #516f79 !important";
        }  //else

    }
    console.log(problemCount);
}
//写一个函数getKeywordsCount() ，可以统计某个求助使用了多少关键字
{
    function getKeywordsCount(problemTitle) {
        let KeywordsCount = document.getElementsByTagName("h4");
        for (var i = 0; i < KeywordsCount.length; i++) {

            if (KeywordsCount[i].innerText.indexOf(problemTitle) !== -1) {
                return KeywordsCount[i].nextElementSibling.nextElementSibling.getElementsByClassName("badge rounded-pill bg-success").length;
            } //else
        }
        return "没找到";
    }
    console.log(getKeywordsCount("python爬虫"));
}
//参考用户注册页面，显示错误提示：

//密码的长度不能小于4
//密码和确认密码必须一致
{
    function ConfirmPassword() {
        let password = document.getElementById("password");
        let ConfirmPassword = document.getElementById("ConfirmPassword");
        if (password.value.length < 4) {
            alert("密码的长度不能小于四");
        }//else
        if (ConfirmPassword.value !== password.value) {
            alert("密码和确认密码必须一致");
        }//else
    }
}
//参考用户资料页面，控制台显示出用户的：性别 / 出生年月 / 关注（关键字）/ 自我介绍
{
    //let inputMessage = document.getElementsByTagName("input");

    //let userMessage = '';
    //for (let i = 0; i < inputMessage.length; i++) {
    //    if (inputMessage[i].name ==="IsFemale" &&inputMessage[i].checked===true) {
    //        userMessage += inputMessage[i].value + "那么、\n";
    //        userMessage = document.getElementsByTagName("select")[0].value + "\n";
    //    } //else
    //    userMessage += inputMessage[i].value + "\n";
    //}
    //userMessage += document.getElementsByTagName("textarea")[0].value+"\n";
    //alert(userMessage);
}
//实现铃铛（没有学bootstrap的同学用文字代替）闪烁效果
{
    let smallBell = document.getElementsByClassName("bi bi-bell-fill");
   
    setInterval(function () {
        smallBell[0].style = "color:rebeccapurple";
    }, 1000);
    setInterval(function () {
        smallBell[0].style ="color:#1a1818"
    },2000)
}

