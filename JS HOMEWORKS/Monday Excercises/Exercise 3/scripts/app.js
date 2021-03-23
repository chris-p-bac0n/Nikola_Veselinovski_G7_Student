// let input = 376;
// let coins = [50, 20, 10, 5, 1];

// function changeCalculator(input, coins) {
//     let result = [];
//     for (let i = 0; i <= coins.length;) {
//         if ((input - coins[i]) >= 0) {
//             result.push(coins[i]);
//             input = input - coins[i];
//         } else {
//             i++;
//         }
//     }
//     return console.log(result);
// }

// changeCalculator(input, coins);

let input = prompt('How much change should the machine give you?');
while (isNaN(input) || input == '' || input < 0) {
    alert('Make sure you entered a valid positive number')
    input = prompt('Please enter a valid number... How much change should the machine give you?');
}
let coins = [50, 20, 10, 5, 1];

function changeCalculator(input, coins) {
    let numberOfCoins = [];
    let coinsFifty = prompt('How many 50 coins does the machine have? An empty field implies 0')
    while (isNaN(coinsFifty) || coinsFifty < 0) {
        alert('Make sure you entered a valid positive number')
        coinsFifty = prompt('Please enter a valid number... How many 50 coins does the machine have? An empty field implies 0');
    }
    numberOfCoins.push(coinsFifty);
    let coinsTwenty = prompt('How many 20 coins does the machine have? An empty field implies 0')
    while (isNaN(coinsTwenty) || coinsTwenty < 0) {
        alert('Make sure you entered a valid positive number')
        coinsTwenty = prompt('Please enter a valid number... How many 20 coins does the machine have? An empty field implies 0');
    }
    numberOfCoins.push(coinsTwenty);
    let coinsTen = prompt('How many 10 coins does the machine have? An empty field implies 0')
    while (isNaN(coinsTen) || coinsTen < 0) {
        alert('Make sure you entered a valid positive number')
        coinsTen = prompt('Please enter a valid number... How many 10 coins does the machine have? An empty field implies 0');
    }
    numberOfCoins.push(coinsTen);
    let coinsFive = prompt('How many 5 coins does the machine have? An empty field implies 0')
    while (isNaN(coinsFive) || coinsFive < 0) {
        alert('Make sure you entered a valid positive number')
        coinsFive = prompt('Please enter a valid number... How many 5 coins does the machine have? An empty field implies 0');
    }
    numberOfCoins.push(coinsFive);
    let coinsOne = prompt('How many 1 coins does the machine have? An empty field implies 0')
    while (isNaN(coinsOne) || coinsOne < 0) {
        alert('Make sure you entered a valid positive number')
        coinsOne = prompt('Please enter a valid number... How many 1 coins does the machine have? An empty field implies 0');
    }
    numberOfCoins.push(coinsOne);

    let arrWithCoins = [];
    for (let i = 0; i <= coins.length;) {
        if ((input - coins[i]) >= 0 && numberOfCoins[i] > 0) {
            arrWithCoins.push(coins[i]);
            input = input - coins[i];
            numberOfCoins[i] = numberOfCoins[i] - 1;
        } else {
            i++;
        }
    }
    coinFiftyChange = 0;
    coinTwentyChange = 0;
    coinTenChange = 0;
    coinFiveChange = 0;
    coinOneChange = 0;

    for (let j = 0; j < arrWithCoins.length; j++) {
        if (arrWithCoins[j] == 50) {
            coinFiftyChange = coinFiftyChange + 1;
        } else if (arrWithCoins[j] == 20) {
            coinTwentyChange = coinTwentyChange + 1;
        } else if (arrWithCoins[j] == 10) {
            coinTenChange = coinTenChange + 1;
        } else if (arrWithCoins[j] == 5) {
            coinFiveChange = coinFiveChange + 1;
        } else if (arrWithCoins[j] == 1) {
            coinOneChange = coinOneChange + 1;
        } else {
            continue
        }
    }

    if (input == 0) {
        return alert(`The machine will return ${coinFiftyChange} - 50 coins, ${coinTwentyChange} - 20 coins, ${coinTenChange} - 10 coins, ${coinFiveChange} - 5 coins and ${coinOneChange} - 1 coins.`);
    } else {
        return alert(`The machine will return ${coinFiftyChange} - 50 coins, ${coinTwentyChange} - 20 coins, ${coinTenChange} - 10 coins, ${coinFiveChange} - 5 coins and ${coinOneChange} - 1 coin. The machine will be unable to return ${input} coin(s) in currency.`);
    }

}

changeCalculator(input, coins);