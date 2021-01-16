let firstNames = ["Jack", "John", "James", "Johnny", "Jeff",];
let lastNames = ["Black", "Wayne", "Dean", "Depp", "Beck",];

function matchFirstLastName (arr1, arr2) {
    let resultArr = []
    for (let i = 0; i < arr1.length; i++) {
        numericValue = i + 1 + ".";
        resultArr.push(`${numericValue} ${arr1[i]} ${arr2[i]}`);
    }
    console.log(resultArr);
}

matchFirstLastName (firstNames, lastNames);