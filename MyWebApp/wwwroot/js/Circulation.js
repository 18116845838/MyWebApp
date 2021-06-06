
//显示一段数中不重复的值（仔细思考需求）

/*var array = [1, 2, 11, 1, true, "", '', " ", ' ', ' ', " ", true, '123', '123', "1234", "1234"];

for (var i = 0; i < array.length; i++) {
    for (var j = i+1; j < array.length; j++) {
        if (array[i]===array[j]) {
            array.splice(j, 1);
            j--;
        }
    }
}
console.log(array);
*/
/*var rows = 5, columns = rows * 2 - 1;
var yh = [];
for (var i = 0; i < rows; i++) {
    yh[i] = [];
    var lines = '';
    for (var j = 0; j < columns; j++) {
        if (i===0) {
            yh[i][j] = j === rows - 1 ? 1 : ' ';
        } else {
            var perRows = i - 1,
                perColumns = j - 1 >= 0 ? +yh[perRows][j - 1] :0,
                nextColunms = j + 1 < columns - 1 ? +yh[perRows][j + 1] : 0;
           
            var current = perColumns + nextColunms;
            yh[i][j] = current  ? current:" ";
        }
        lines += yh[i][j];
    }

    console.log(lines);
}*/
