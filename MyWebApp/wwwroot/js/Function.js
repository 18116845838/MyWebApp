///构建函数
//has9(number) ，可以判断number中是否带有数字9；
//has8(number) ，可以判断number中是否带有数字8；
//has6(number) ，可以判断number中是否带有数字6；
//让get986()通过调用has9() / has8() / has6() ，能找出number以内有多少个数字包含：9或者8或6。
function has9() {
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

console.log(get986(has9(19, 29, 39, 4), has8(1, 2, 5, 18,9), has6(1, 6,16, 5)));