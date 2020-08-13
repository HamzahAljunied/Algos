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

def chessKnight(cell):
    r = 0
    c = [ord(cell[0])-96,int(cell[1])]
    
    m = [[1,2],[2,1],[1,-2],[-2,1],[-1,2],[2,-1],[-1,-2],[-2,-1]]
    
    for i in m:
        if 0<c[0]+i[0]<9 and 0<c[1]+i[1]<9:
            r +=1
    return r

def deleteDigit(n):
    numInStr = str(n)
    size = len(numInStr)        
    numList = []
    for num in numInStr:
        numList.append(num)

    temp = numList.copy()
    max = 0
    for index in range(size):
        del temp[index]
        newNum = int(''.join([str(elem) for elem in temp]))
        if newNum > max:
            max = newNum
        temp = numList.copy()
        
    return max

def longestWord(text):
    #loop thru str
    #check if char.toLower is between 97 and 122
    #add char to tempList
    #if char.toLower is not between, compare tempList with currLong for a swap
    tempList = []
    currLong = [] 

    for char in text:
        if ord(char.lower()) >= 97 and ord(char.lower()) <= 122:
            tempList.append(char)
        else:
            if len(tempList) > len(currLong):
                currLong = tempList.copy()
            tempList.clear()

    if len(tempList) > len(currLong):
        currLong = tempList.copy()

    return ''.join([str(elem) for elem in currLong])



print(longestWord("Ready, steady, go!"))
