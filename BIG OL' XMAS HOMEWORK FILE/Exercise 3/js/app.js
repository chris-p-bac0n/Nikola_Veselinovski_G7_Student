let d = new Date();
let n = d.getFullYear();

function calculateAge (birthYear) {
    let currentAge = n - birthYear;
    return currentAge;
}

console.log (calculateAge (1994));
console.log ('-----------------');
console.log (calculateAge (1986));
console.log ('-----------------');
console.log (calculateAge (1903));


// PROMPT VERSION

let birthYear = prompt ('Hi, please insert your birth year in order to convert your age');
let currentAge = n - birthYear;
alert (`You are ${currentAge} years old!`);
