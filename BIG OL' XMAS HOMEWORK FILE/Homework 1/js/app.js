let lastYear = null;
let ourFuture;
let newYearWillBeBetter = true;

function parameterTypeFunc (parameter) {
    return typeof parameter;
}

console.log (parameterTypeFunc (lastYear));
console.log ('-----------------');
console.log (parameterTypeFunc (newYearWillBeBetter));
console.log ('-----------------');
console.log (parameterTypeFunc (12));
console.log ('-----------------');
console.log (parameterTypeFunc ('dog'));
console.log ('-----------------');
console.log (parameterTypeFunc (ourFuture));