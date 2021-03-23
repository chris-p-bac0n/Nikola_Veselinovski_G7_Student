// [Selectors]

// Navigation menu
const navMenu = document.querySelector('.navigation');
const searchUserNav = navMenu.querySelector('#search-nav');
const addNewUserNav = navMenu.querySelector('#addUser-nav');
const addUserDiv = document.querySelector('#add-user');
const searchUserDiv = document.querySelector('#search-user');

// Search form
const searchForm = document.querySelector('#search-section');
const searchBar = searchForm.querySelector('#search-bar');
const searchBtn = searchForm.querySelector('#search-button');
const resetBtn = searchForm.querySelector('#search-reset');
const searchError = searchForm.querySelector('#errorMessage');

// User listing 
const userListing = document.querySelector('#user-listing');
const userListTable = userListing.querySelector('#user-list-table');
// const deleteBtn = document.getElementsByClassName('deleteBtn');

// User submit form
const submitUserForm = document.querySelector('#addUser-form');
const submitUserBtn = submitUserForm.querySelector('#submitUser-button');
const firstNameInput = submitUserForm.querySelector('#firstName');
const lastNameInput = submitUserForm.querySelector('#lastName');
const ageInput = submitUserForm.querySelector('#age');
const cityInput = submitUserForm.querySelector('#city');
const countryInput = submitUserForm.querySelector('#country');
const spouseInput = submitUserForm.querySelector('#spouse');
const petsInput = submitUserForm.querySelector('#pets');
const petTypeInput = submitUserForm.querySelector('#petType');
const errorMessageSubmit = submitUserForm.querySelector('#errorMessageSubmit');
const addPetBtn = submitUserForm.querySelector('#addPet-button');
const removePetBtn = submitUserForm.querySelector('#removePet-button');

// Other elements, pages, etc.

// [Data]
arrayOfUsers = [];
const johnWayne = new User('John', 'Wayne', 45, 'Warsaw', 'Poland', ['Jimmy', 'Johnny', 'Jacky'], 'Jenny Wayne');
const johnWick = new User('John', 'Wick', 35, 'Chicago', 'USA', ['Daisy', 'Boy'], '');
const johnnyBravo = new User('Johnny', 'Bravo', 23, 'Cartoon', 'Network', ['Hey', 'There', 'Good', 'Looking'], '');
const jackBlack = new User('Jack', 'Black', 51, 'Santa Monica', 'USA', ['Tenacious', 'D'], 'Tanya Haden');
const jackNicholson = new User('Jack', 'Nicholson', 83, 'Neptune City', 'USA', ['Wacky', 'Looney'], 'Sandra Knight');
arrayOfUsers.push(johnWayne, johnWick, johnnyBravo, jackBlack, jackNicholson);
arrayOfInputs = [];
arrayOfInputs.push(firstNameInput, lastNameInput, ageInput, cityInput, countryInput, spouseInput, petsInput, petTypeInput);

// [Functions]

const addNewUsers = (name, lastName, age, city, county, pets, spouse) => {
    let newUser = new User(name, lastName, age, city, county, pets, spouse);
    arrayOfUsers.push(newUser);
}

const addNewUserStart = () => {
    let errorAddingUser = false;
    // for (const input of arrayOfInputs) {
    arrayOfInputs.forEach(input => {
        if (!validateInputs(input)) {
            if (input === spouseInput) {
                return
            }
            errorMessageSubmit.innerText = `* Please make sure you fill out all of the required form inputs`
            errorMessageSubmit.style.color = '#ff0000';
            input.style.backgroundColor = '#FFB7A8';
            errorAddingUser = true;
        }

        if (validateInputs(input)) {
            input.style.backgroundColor = '#ff000000';
        }
    })
    // }

    if (!errorAddingUser) {
        let newPet = new Pet(petsInput.value, petTypeInput.value)
        addNewUsers(firstNameInput.value, lastNameInput.value, ageInput.value, cityInput.value, countryInput.value, `${newPet.name}`, spouseInput.value);
        cleanUpInputs(arrayOfInputs);
        errorMessageSubmit.innerText = `User successfully added!`
        errorMessageSubmit.style.color = '#0ABD00';
        resetInputColor;
        listObjectProperties(arrayOfUsers);
    }
}

const searchForUsers = (array, input) => {
    let userFoundCheck = false;
    // for (const element of array) {
    const searchArray = array.filter(element => element.fullName.toLowerCase() === input.value.toLowerCase())
    if (searchArray.length >= 1) {
        userListTable.innerHTML = '';

        // *** I used filter instead of find in case we have two John Snow's as you said, so the search returns all users with the same full name which we can delete by the user ID (button)...

        searchArray.forEach((element) => {
            // userListTable.innerHTML = '';
            userFoundCheck = true
            let tableData = ``;
            for (const key in element) {
                if (element[key] == element.id) {
                    continue;
                }
                tableData += `<td>${element[key]}</td>`
            }

            // I couldn't utilize the selectors to find the buttons in order to add an event listener for them so I gave them an inline onclick...

            userListTable.innerHTML += `<tr>${tableData}<td><button type="button" class="deleteBtn" onclick="deleteUser(${element.id})">Delete user</button></td></tr>`

            return
        })
    }
    // }

    if (!validateInputs(searchBar)) {
        searchError.innerText = `* Please make sure you entered a name`;
    } else if (!userFoundCheck) {
        searchError.innerText = `*There is no user named ${input.value}, please try another name`;
    }
}

const searchStart = () => {
    searchError.innerText = '';
    if (!validateInputs(searchBar)) {
        searchError.innerText = `*Please type in a name and last name`;
    }

    searchForUsers(arrayOfUsers, searchBar);
    cleanUpInput(searchBar);
}

const cleanUpInputs = (inputs) => inputs.forEach(input => input.value = '')
    // for (const input of inputs) {
    // inputs.forEach(input => input.value = '')
    // }

const cleanUpInput = (input) => input.value = '';

const validateInputs = (input) => {
    if (!input.value) {
        return false;
    }
    return true;
}

const resetInputColor = () => arrayOfInputs.forEach(input => input.style.backgroundColor = '#ff000000')
    // for (const input of arrayOfInputs) {
    // arrayOfInputs.forEach(input => input.style.backgroundColor = '#ff000000')
    // }

const listObjectProperties = (array) => {
    userListTable.innerHTML = '';
    // for (let i = 0; i < array.length; i++) {
    array.forEach(user => {
        let tableData = ``;
        for (const key in user) {
            if (user[key] == user.id) {
                continue;
            }
            tableData += `<td>${user[key]}</td>`
        }
        userListTable.innerHTML += `<tr>${tableData}<td><button type="button" class="deleteBtn" onclick="deleteUser(${user.id})">Delete user</button></td></tr>`
    })
}
// }

const deleteUser = (id) => {
    arrayOfUsers.forEach(user => {
        if (user.id == id) {
            let userToDelete = arrayOfUsers.indexOf(user);
            arrayOfUsers.splice(userToDelete, 1)
        }
    })
    listObjectProperties(arrayOfUsers);
}

const changeView = (show, hide) => {
    show.style.display = 'block';
    hide.style.display = 'none';
}

// [Event Handlers]
searchBtn.addEventListener('click', searchStart)

resetBtn.addEventListener('click', () => listObjectProperties(arrayOfUsers))

addNewUserNav.addEventListener('click', e => {
    if (e.target && e.target.nodeName == "A") {
        changeView(addUserDiv, searchUserDiv);
        cleanUpInput(searchBar);
        searchError.innerText = ``;
    }
})

searchUserNav.addEventListener('click', e => {
    if (e.target && e.target.nodeName == "A") {
        changeView(searchUserDiv, addUserDiv);
        cleanUpInputs(arrayOfInputs);
        errorMessageSubmit.innerText = ``;
        resetInputColor();
    }
})

submitUserBtn.addEventListener('click', addNewUserStart)

// [Models]
function User(firstName, lastName, age, city, country, pets, spouse) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.fullName = `${firstName} ${lastName}`;
    this.age = age;
    this.city = city;
    this.country = country;
    this.spouse = spouse;
    this.pets = pets;
    this.isMarried = !!spouse;
    this.id = Math.floor(Math.random() * 100000);
}

function Pet(name, type) {
    this.name = name;
    this.type = type;
}

// [Initialization]

(() => {
    listObjectProperties(arrayOfUsers);
    changeView(searchUserDiv, addUserDiv);
})()
