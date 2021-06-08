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