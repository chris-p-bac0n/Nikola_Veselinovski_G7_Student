let array = [0, 2, 5, 4, 6, 8];

function mapToEvenNumbersWithDash(arr) {
    resultString = ``;

    for (let i = 0; i < arr.length; i++) {

        if ((arr[i] + arr[i + 1]) % 2 == 0) {
            resultString += `${arr[i]}-`;
        } else {
            resultString += `${arr[i]}`;
        }

    }
    return console.log(resultString);
}

mapToEvenNumbersWithDash(array);