let num = prompt('Please enter a number up to which you want to divide with 7 and 3');
while (isNaN(num)) {
    alert('Make sure you entered a number')
    num = prompt('Please enter a number up to which you want to divide with 7 and 3');
}

function getNumbers(num) {
    arrayOfNumbers = [];
    result = [];

    for (let i = 1; i <= num; i++) {
        arrayOfNumbers.push(i)
    }

    for (let j = 0; j <= arrayOfNumbers.length; j++) {
        if (arrayOfNumbers[j] % 7 == 0 && arrayOfNumbers[j] % 3 == 0) {
            result.push(arrayOfNumbers[j]);
        }
    }
    return alert(`Numbers that are dividable both by 7 and 3 are : ${result}`);

}

getNumbers(num);
