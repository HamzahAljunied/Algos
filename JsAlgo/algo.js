function circleOfNumbers(n, firstNumber) {
    let half = n / 2;

    let oppo = firstNumber + half;

    if(oppo >= n){
        return oppo - n;
    }

    return oppo;
}

function depositProfit(deposit, rate, threshold) {

    let year = 0;
    let percRate = (rate / 100) + 1;
    while(deposit < threshold){
        deposit *= percRate;
        year++;
    }

    return year;
}

function absDiffSum(arrayOfInt, num){
    let sum = 0;
    for(let i = 0; i < arrayOfInt.length; i++){
        sum += Math.abs(arrayOfInt[i] - num);
    }

    return sum;
}

function absoluteValuesSumMinimization(a) {
    
    let sumMin = absDiffSum(a, a[0]);
    let curMin = a[0];

    for(let i = 1 ; i < a.length; i++){

        let tempAbsDiffSum =  absDiffSum(a, a[i]);

        if(tempAbsDiffSum < sumMin){
            sumMin = tempAbsDiffSum;
            curMin = a[i];
        }
        // else if (tempAbsDiffSum >= sumMin){
        //     return curMin;
        // }
    }

    return curMin;    
}

function firstDigit(inputString) {
    var size = inputString.length;

    for(var i = 0; i < size; i++){

        var num = parseInt(inputString[i]);
        if(num >= 0 && num <= 9){
            return num;
        }
    }
}

function differentSymbolsNaive(s) {
    var fakeDict = {};
    var count = 0;

    for(var i = 0; i < s.length; i++){
        if(fakeDict[s[i]] == undefined){
            fakeDict[s[i]] = s[i];
            count++;
        }
    }
    return count;
}

function isPalindrome(st){
    backIndex = st.length - 1;
    for(let i = 0; i < backIndex;i++){        
        if(st[i] != st[backIndex]){
            return false;
        }
        backIndex--;
    }
    return true;
}

function reverse(str){
    return str.split("").reverse().join("");
  }

function buildPalindrome(st) {
    newSt = st;
    let end = 1;
    while(!isPalindrome(newSt)){
        newSt = st;        

        conc = newSt.substring(0, end);
        conc = reverse(conc);
        alert(conc);
        newSt = newSt.concat(conc);
        alert(newSt);
        end++;
    }

    return newSt;
}

function isMAC48Address(inputString) {
    arr = inputString.split("-");
    result = true;
    if(arr.length != 6){
        return false;
    }

    strDict = "ABCDEF1234567890";

    arr.forEach(s => {   
        fir = strDict.includes(s[0]);
        sec = strDict.includes(s[1])
        if(!fir || !sec){
            result = false;
        }
    });
    
    return result;
}

function isDigit(symbol) {
    return symbol.isDigit();
}

function lineEncoding(s) {
    //iterate thru string
    //once new char found, place prev chars in arr
    tokens = [];
    temp = s[0];
    for(let i = 1; i < s.length; i++){
        if(temp[0] == s[i]){
            temp = temp.concat(s[i]);
        }
        else{
            tokens.push(temp);
            temp = s[i];
        }
    }

    tokens.push(temp);
    newStr = "";
    tokens.forEach(token => {
        length = token.length == 1 ? "" : token.length;
        newStr = newStr.concat(length + token[0])
    });

    return newStr;
}

function chessKnight(cell) {

}


alert(lineEncoding("abbcc"));