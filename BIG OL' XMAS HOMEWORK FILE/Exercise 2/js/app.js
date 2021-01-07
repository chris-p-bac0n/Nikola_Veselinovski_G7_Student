let whatToConvert = prompt ('Hi, would you like to convert to celsius or to fahrenheit ? Please write which one');

if (whatToConvert === 'fahrenheit') {
    let celsiusValue = prompt ('Please insert Celsius value to convert');
        let fahrenheitConversion = Math.round((celsiusValue * 1.8) + 32);
            alert (`${celsiusValue} Celsius is equal to ${fahrenheitConversion} Fahrenheit`);

} else if (whatToConvert === 'celsius') {
    let fahrenheitValue = prompt ('Please insert Fahrenheit value to convert');
        let celsiusConversion = Math.round((5 / 9) * (fahrenheitValue - 32));
            alert (`${fahrenheitValue} Fahrenheit is equal to ${celsiusConversion} Celsius`);
}
