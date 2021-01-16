let arrayOfFiveNumbers = [4, 7, 23, 54, 2];

function sumNumbers (arr) {

    alert(arr[0] + arr[1] + arr[2] + arr[3] + arr[4]);
}

sumNumbers(arrayOfFiveNumbers);

let arrayOfFiveNumbersWhereOneIsFake = [4, 7, '23', 54, 2,];

function validateNumber (arr) {

    let resultMessage = `All of the following elements are validated numbers : `
    let errorMessage = `Error! The following elements are not valid numbers : `
    for (let number of arr) {
        if (typeof number !== 'number') {
            errorMessage += (`${number} `)
        } else {
            resultMessage += (`${number} `)
        }
    }
    if (errorMessage.length > 54) {
        alert(errorMessage);
    } else {
        alert(resultMessage);
    }
}

validateNumber(arrayOfFiveNumbersWhereOneIsFake);

