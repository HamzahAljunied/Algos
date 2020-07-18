def arrayMaxConsecutiveSum(inputArray, k):
    # k = 3
    # 0 1 2 3 4
    # 7 2 4 1 3

    #init first sum
    maxSum = 0
    for i in range(k):
        maxSum = maxSum + inputArray[i]    

    temp = maxSum
    for i in range (1, len(inputArray)-k+1):
        temp = temp - inputArray[i-1] + inputArray[i+k-1]        
        if temp > maxSum:
            maxSum = temp

    return maxSum

def growingPlant(upSpeed, downSpeed, desiredHeight):
    currGro = 0
    day = 1

    while currGro < desiredHeight:
        currGro = currGro + upSpeed
        if currGro >= desiredHeight:
            break
        
        currGro = currGro - downSpeed

        day = day + 1
    
    return day

def knapsackLight(value1, weight1, value2, weight2, maxW):
    val1 = int(weight1 <= maxW)*value1
    val2 = int(weight2 <= maxW)*value2
    val1and2 = int(weight1 + weight2 <= maxW)*(value1+value2)
    arr = [val1, val2, val1and2]
    
    return max(arr)

def longestDigitsPrefix(inputString):

    if not inputString[0].isdigit():
        return ""
    else:
        temp = ""
        print(str(inputString))
        for i in str(inputString):
            if i.isdigit():
                temp += i
            else:
                break
        
        return temp

def digitSum(n):
    assert type(n) is int,"n must be a string"
    sum = 0
    for i in str(n):
        sum += int(i)

    return sum

def digitDegree(n):    
    assert type(n) is int,"n must be a string"
    if n < 10:
        return 0
    else:        
        degree = 1
        temp = digitSum(n)
        while temp >= 10:
            temp = digitSum(temp)
            degree += 1

    return degree

def getIndex(char):
    alp = "abcdefgh"
    for i in range(len(alp)):
        if(alp[i] == char):
            return i + 1

def bishopAndPawn(bishop, pawn):
    rowDiff = getIndex(bishop[0]) - getIndex(pawn[0])
    colDiff = int(bishop[1]) - int(pawn[1])

    return abs(rowDiff) == abs(colDiff)

def isBeautifulString(inputString):
    alp = "abcdefghijklmnopqrstuvwxyz"
    alpList = []
    for a in alp:        
        alpList.append(inputString.count(a)) 

    for i in range(0,len(alpList)-1):
        if alpList[i] < alpList[i+1]:
            return False
    
    return True


print(isBeautifulString("bbbaacdafe"))