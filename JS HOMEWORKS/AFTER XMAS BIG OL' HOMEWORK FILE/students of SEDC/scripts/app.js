let studentsOfSedcArr = ["Hello", "there", "students", "of", "SEDC", "!"];

function oneBigStringMaker (Arr) {
   let oneBigString = "";
    for (let string of Arr) {
        oneBigString += ` ${string}`
    }
    return oneBigString;
}

alert (oneBigStringMaker (studentsOfSedcArr))