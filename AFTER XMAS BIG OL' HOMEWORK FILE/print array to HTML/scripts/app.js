let arrayWithNumbers = [2, 4, 5];

let divToPush = document.getElementById(`thisDiv`);
let divToPushTwo = document.getElementById(`thatDiv`);


function printArrNumbers (arr) {
    divToPush.innerHTML = '';
    let printNumbers = '';
    for (let number of arr) {
        printNumbers += `<li>${number}</li>`;
    }
    divToPush.innerHTML += `<ul>${printNumbers}</ul>`;
}

printArrNumbers (arrayWithNumbers);

function printSumArrNumbers (arr) {
    let printNumbers = 0;
    for (let number of arr) {
        printNumbers = printNumbers + number;
    }
    divToPush.innerHTML += `The sum of the numbers is ${printNumbers}`;
}

printSumArrNumbers (arrayWithNumbers);



function printEquation (arr) {
    divToPushTwo.innerHTML = `<br/>Aaaand the whole equation is `;
    let sumOfNumbers = 0
    for (let number of arr) {
        sumOfNumbers = sumOfNumbers + number;
    }
    for (let i = 0; i < arr.length; i++) {
        if (i < arr.length - 1) {
             divToPushTwo.innerHTML += `${arr[i]} + `;
            } else if (i = arr.length - 1) {
                divToPushTwo.innerHTML += `${arr[i]} = ${sumOfNumbers}`;
             }
        }
}

printEquation (arrayWithNumbers);
