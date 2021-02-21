let users = [
    { name: 'John', gender: 'm', title: '', hasCar: true, age: 30, eyeColor: 'green', hairColor: 'black', address: 'Skopje, MK', job: 'developer' },
    { name: 'Jack', gender: 'm', title: '', hasCar: false, age: 19, eyeColor: 'brown', hairColor: 'brown', address: 'Tetovo, MK', job: 'realtor' },
    { name: 'Elisabeth', gender: 'f', title: '', hasCar: true, age: 45, eyeColor: 'blue', hairColor: 'black', address: 'Bitola, MK', job: 'project manager' },
    { name: 'Ana', gender: 'f', title: '', hasCar: true, age: 98, eyeColor: 'brown', hairColor: 'blonde', address: 'Shtip, MK', job: 'designer' },
    { name: 'Carroll', gender: 'f', title: '', hasCar: false, age: 17, eyeColor: 'green', hairColor: 'blonde', address: 'Kumanovo, MK', job: 'bushiness analyst' },
    { name: 'Michael', gender: 'm', title: '', hasCar: true, age: 40, eyeColor: 'blue', hairColor: null, address: 'Sofija, BG', job: 'developer' },
    { name: 'Beth', gender: 'f', title: '', hasCar: false, age: 35, eyeColor: 'brown', hairColor: 'blonde', address: 'Atina, GR', job: 'database engineer' },
    { name: 'Clara', gender: 'f', title: '', hasCar: true, age: 67, eyeColor: 'blue', hairColor: 'brown', address: 'Tirana, AL', job: 'designer' },
    { name: 'Jay', gender: 'm', title: '', hasCar: true, age: 39, eyeColor: 'green', hairColor: null, address: 'Dojran, MK', job: 'manager' }
]

console.log('----------------------------------------------------------------');

// [Array with updated titles]

console.log('[Array with updated titles]');

const usersUpdatedTitles = users.map(user => {
    if (user.gender == 'm') {
        user = {...user};
        user.title = 'Mr';
    } else if (user.gender == 'f') {
        user = {...user};
        user.title = 'Ms';
    }
    return user
})

console.log('Updated array - usersUpdatedTitles', usersUpdatedTitles);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Array with male users]

console.log('[Array with male users]');

const usersMaleUsers = users.slice().filter(user => user.gender == 'm');

console.log('Updated array - usersMaleUsers', usersMaleUsers);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Array with users not from MK]

console.log('[Array with users not from MK]');

const usersNotFromMK = users.slice().filter(user => !user.address.includes('MK'));

console.log('Updated array - usersNotFromMK', usersNotFromMK);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Array with users that have a car]

console.log('[Array with users that have a car]');

const usersWithCar = users.slice().filter(user => user.hasCar == true);

console.log('Updated array - usersWithCar', usersWithCar);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Array with message for users with hair]

console.log('[Array with message for users with hair]');

const usersWithHairAndMessage = (() => {
    const usersWithHair = users.slice().filter(user => user.hairColor === null);
    const userCarValidate = (user) => {
        let result = ''
        if (user.hasCar == true) {
            result = 'has'
        } else if (user.hasCar == false) {
            result = `hasn't`
        }
        return result
    }
    usersWithHair.forEach(user => console.log(`${user.name} which is ${user.age} years old, living in ${user.address} is working as a ${user.job} and ${userCarValidate(user)} got a car`))
    console.log('Updated array - usersWithHair', usersWithHair);
})()

console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Array with users older than 28]

console.log('[Array with users older than 28]');

const usersOlderThanTwentyEight = users.slice().filter(user => user.age > 28);

console.log('Updated array - usersOlderThanTwentyEight', usersOlderThanTwentyEight);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Array with users that have a car and it's white]

console.log(`[Array with users that have a car and it's white]`);

const usersWithCarWhite = users.map(user => {
    if (user.hasCar == true) {
        user = {...user, carColor: 'white'};
    }
    return user;
})
console.log('Updated array - usersWithCarWhite', usersWithCarWhite);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Variable with info if all users have hair]

console.log(`[Variable with info if all users have hair]`);

const infoUserHair = (() => {
    let userHairValidate = users.some(user => user.hairColor === null)
    let result = ''
    if (userHairValidate) {
        result = `Not all users have hair`
    } else if (!userHairValidate) {
        result = `All users have hair`
    }
    return result
})()

console.log(`Info - `,infoUserHair);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Variable with info if some users work as a manager]

console.log(`[Variable with info if some users work as a manager]`);

const infoWorkAsManager = (() => {
    let userWorkAsManager = users.some(user => user.job === 'manager')
    let result = ''
    if (userWorkAsManager) {
        result = `Some users work as a manager`
    } else if (!userWorkAsManager) {
        result = `None of the users work as a manager`
    }
    return result
})()

console.log(`Info - `, infoWorkAsManager);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Variable with index of a user that lives in Dojran]

console.log(`[Variable with index of a user that lives in Dojran]`);

const indexUserDojran = (() => users.findIndex(user => user.address.includes('Dojran')))()


console.log(`The index of the user that lives in Dojran is `, indexUserDojran);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Save the user Clara in a separate variable]

console.log(`Save the user Clara in a separate variable`);

const claraVariable = (() => users.filter(user => user.name === 'Clara'))()

console.log(`The variable where Clara is saved is claraVariable and returns the following `, `claraVariable`, claraVariable);
console.log('Original array - users', users);
console.log('----------------------------------------------------------------');

// [Log 'TITLE NAME' as a text for each uer in the array]

console.log(`[Log 'TITLE NAME' as a text for each uer in the array]`);

const logTitleName1 = (() => users.forEach(user => console.log('TITLE NAME')))()
const logTitleName2 = (() => users.forEach(user => console.log('TITLE NAME', user.name)))()

console.log(`DIDN'T KNOW WHAT YOU MEANT BY LOGGING 'TITLE NAME' FOR EACH USER SO I LOGGED IN THAT TEXT FOR EACH USER AND ALSO LOGGED IN THAT TEXT FOLLOWED BY THE USERS NAME`)
console.log('----------------------------------------------------------------');
