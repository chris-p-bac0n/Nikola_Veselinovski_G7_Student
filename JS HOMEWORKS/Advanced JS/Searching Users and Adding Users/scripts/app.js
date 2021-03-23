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
const userList = userListing.querySelector('#user-list');
const searchList = userListing.querySelector('#search-list');
const registeredUserList = userListing.querySelector('#registeredUser-list');

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
const JohnWayne = new User('John', 'Wayne', 45, 'Warsaw', 'Poland', ['Jimmy', 'Johnny', 'Jacky'], 'Jenny Wayne');
const JohnWick = new User('John', 'Wick', 35, 'Chicago', 'USA', ['Daisy', 'Boy']);
const JohnnyBravo = new User('Johnny', 'Bravo', 23, 'Cartoon', 'Network', ['Hey', 'There', 'Good', 'Looking']);
const JackBlack = new User('Jack', 'Black', 51, 'Santa Monica', 'USA', ['Tenacious', 'D'], 'Tanya Haden');
const JackNicholson = new User('Jack', 'Nicholson', 83, 'Neptune City', 'USA', ['Wacky', 'Looney'], 'Sandra Knight');
arrayOfUsers.push(JohnWayne, JohnWick, JohnnyBravo, JackBlack, JackNicholson);
arrayOfInputs = [];
arrayOfInputs.push(firstNameInput, lastNameInput, ageInput, cityInput, countryInput, spouseInput, petsInput, petTypeInput);

// [Functions]

const addNewUsers = (name, lastName, age, city, county, pets, spouse) => {
    let newUser = new User(name, lastName, age, city, county, pets, spouse);
    arrayOfUsers.push(newUser);
}

const addNewUserStart = () => {

    let errorAddingUser = false;
    // arrayOfInputs = []
    // arrayOfInputs.push(firstNameInput, lastNameInput, ageInput, cityInput, countryInput, spouseInput, petsInput, petTypeInput)

    for (const input of arrayOfInputs) {
        if (!validateInputs(input)) {
            if (input === spouseInput) {
                continue
            }
            errorMessageSubmit.innerText = `* Please make sure you fill out all of the required form inputs`
            errorMessageSubmit.style.color = '#ff0000';
            input.style.backgroundColor = '#FFB7A8';
            errorAddingUser = true;
        } 

        if (validateInputs(input)) {
            input.style.backgroundColor = '#ff000000';
        }
    }

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
    for (const element of array) {
        if (element.fullName.toLowerCase() === input.value.toLowerCase()) {
            userFoundCheck = true
            let tableData = ``;
            for (const key in element) {
                tableData += `<td>${element[key]}</td>`
            }
            searchList.innerHTML += `<tr>${tableData}</tr>`

            changeView(searchList, userList);

            return
        }
    }

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

const cleanUpInputs = (inputs) => {
    for (const input of inputs) {
        input.value = ''
    }
}

const cleanUpInput = (input) => {
    input.value = ''
}


const validateInputs = (input) => {
    if (!input.value) {
        return false;
    }

    return true;
}

const resetInputColor = () => {
    for (const input of arrayOfInputs) {
        input.style.backgroundColor = '#ff000000';
    }
}

// const spouseCheck = () => {
//     if (spouseInput.value == '') {
//         return 'none'
//     }
//     return spouseInput.value
// }

const listObjectProperties = (array) => {
    userList.innerHTML =
        `
    <tr>
    <th>First Name</th>
    <th>Last Name</th>
    <th>Full Name</th>
    <th>Age</th>
    <th>City</th>
    <th>Country</th>
    <th>Spouse</th>
    <th>Pets</th>
    <th>Is Married</th>
    </tr>
    `
    for (let i = 0; i < array.length; i++) {
        let tableData = ``;
        for (const key in array[i]) {
            tableData += `<td>${array[i][key]}</td>`
        }
        userList.innerHTML += `<tr>${tableData}</tr>`
    }
}

const changeView = (show, hide) => {
    show.style.display = 'block';
    hide.style.display = 'none';
}

const resetView = () => {
    searchList.innerHTML =
        `
    <tr>
    <th>First Name</th>
    <th>Last Name</th>
    <th>Full Name</th>
    <th>Age</th>
    <th>City</th>
    <th>Country</th>
    <th>Spouse</th>
    <th>Pets</th>
    <th>Is Married</th>
    </tr>
    `

    changeView(userList, searchList);
}

const init = () => {
    listObjectProperties(arrayOfUsers);
    changeView(userList, searchList);
    changeView(searchUserDiv, addUserDiv);
}


// [Event Handlers]
searchBtn.addEventListener('click', searchStart)
resetBtn.addEventListener('click', resetView)
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
    this.isMarried = spouse ? true : false;
}

function Pet(name, type) {
    this.name = name;
    this.type = type;
}

// [Initialization]

init();
