function dogAgeCalc (dogYear) {
    let dogToHuman = dogYear * 7;
        return `Your dog is ${dogToHuman} human years old`;
}
   
function humanAgeCalc (humanYear) {
    let humanToDog = Math.round(humanYear / 7);
        return `You are ${humanToDog} dog years old`;
}

console.log (dogAgeCalc (2));
console.log ('-----------------');
console.log (humanAgeCalc (66));


// PROMPT VERSION

let ageType = prompt ('Hi, would you like to convert to dog or to human years? (write dog or human)');

if (ageType === 'dog') {
    let humanYears = prompt ('Please insert human years to convert to dog years');
        let dogYearConversion = Math.round(humanYears / 7);
            alert (`You are ${dogYearConversion} dog years old!`);

} else if (ageType === 'human') {
    let dogYears = prompt ('Please insert dog years to convert to human years');
        let humanYearConversion = Math.round(dogYears * 7);
            alert (`Your dog is ${humanYearConversion} human years old!`);
}