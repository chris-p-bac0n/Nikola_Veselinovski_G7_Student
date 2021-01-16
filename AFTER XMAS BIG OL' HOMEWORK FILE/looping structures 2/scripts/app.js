
arrayOfStuff = [11, "red", 3, 68, "bear", NaN, 15];

function minMaxSumCalc (arr) {
    let maxNumber = 0;
    let minNumber = arr[0];
    let counter = 0;

    for (let i = 0; i < arr.length; i++) {
       let currentNumber = arr[i];
       if (typeof currentNumber === 'number') {
           if (currentNumber > maxNumber) {
        maxNumber = currentNumber;
        } 
    } else continue
            counter++;
        }

    console.log(`The largest number is ${maxNumber}`);
     
    for (let i = 0; i < arr.length; i++) {
        let currentNumber = arr[i];
        if (typeof currentNumber === 'number') {
        if (currentNumber < minNumber) {
            minNumber = currentNumber;
            } 
    } else continue
            counter++;
        }

    console.log(`The smallest number is ${minNumber}`);

    let sumMinMax = maxNumber + minNumber;

    console.log(`The sum of the Min and Max numbers is ${sumMinMax}` )
}

minMaxSumCalc (arrayOfStuff);