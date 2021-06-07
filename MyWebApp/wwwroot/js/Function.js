///构建函数
//has9(number) ，可以判断number中是否带有数字9；
//has8(number) ，可以判断number中是否带有数字8；
//has6(number) ，可以判断number中是否带有数字6；
//让get986()通过调用has9() / has8() / has6() ，能找出number以内有多少个数字包含：9或者8或6。
/*function has9() {
    var sum = 0;
    for (var i = 0; i < arguments.length; i++) {
        arguments[i] = arguments[i] + '';
        for (var j = 0; j < arguments[i].length; j++) {
            if (arguments[i][j] == 9) {
                sum++;
            } //else
        }
    }
    return sum;
}
function has8() {
    var sum = 0;
    for (var i = 0; i < arguments.length; i++) {
        arguments[i] = arguments[i] + '';
        for (var j = 0; j < arguments[i].length; j++) {
            if (arguments[i][j] == 8) {
                sum++;
            }//else
        }
    }
    return sum;
}
function has6() {
    var sum = 0;
    for (var i = 0; i < arguments.length; i++) {
        arguments[i] = arguments[i] + '';
        for (var j = 0; j < arguments[i].length; j++) {
            if (arguments[i][j] == 6) {
                sum++;
            }//else
        }
    }
    return sum;
}
function get986() {
    var sum = 0;
    for (var i = 0; i < arguments.length; i++) {
        sum += arguments[i];
    }
    return sum;
}

console.log(get986(has9(19, 29, 39, 4), has8(1, 2, 5, 18, 9), has6(1, 6, 16, 5)));*/





//将之前“找出素数”的代码封装成一个函数findPrime(max) ，可以打印出max以内的所有素数。


/*function findPrime(max) {
    for (var i = 2; i <= max; i++) {
        isPrime = true;
        for (var j = 2; j < i; j++) {
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
    var number = 0;

    for (var i = startNumber; i < endNumber; i += stepSize) {
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
    var MaxNumber = 0;
    for (var i = 0; i < arguments.length; i++) {
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
    var temp;
    temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}
var arr = [7,1, 2,1,3,4,7,5,6,3,];
//console.log(swap(arr, 0, 1));

//利用上面的swap()函数，将“冒泡排序”封装成函数bubbleSort() 
function bubbleSort(arr) {
    for (var i = 0; i < arr.length; i++) {
        for (var j = 0; j < arr.length-1-i; j++) {
            if (arr[j]>arr[j+1]) {
                swap(arr, j, j + 1);
            }//else=
        }
    }
}
bubbleSort(arr);
//封装函数deleteDuplicated()删除一个数组里面重复的元素
function deleteDuplicated(arr) {
    for (var i = 0; i < arr.length; i++) {
        for (var j = i + 1; j < arr.length; j++) {
            if (arr[i] === arr[j]) {
                arr.splice(j, 1);
                j--;
            }
        }
    }
}
deleteDuplicated(arr);