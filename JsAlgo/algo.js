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

alert(isPalindrome("abccba"));