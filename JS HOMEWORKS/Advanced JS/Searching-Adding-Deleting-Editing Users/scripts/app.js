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


// Edit user 
const editUserTitle = document.querySelector('#editUserTitle');
const saveEditUserBtn = submitUserForm.querySelector('#saveEditUser-button');
const editUserView = document.querySelectorAll('.editUserView');

// Other elements, pages, etc.

// [Data]
let arrayOfUsers = [];
const johnWayne = new User('John', 'Wayne', 45, 'Warsaw', 'Poland', ['Jimmy', 'Johnny', 'Jacky'], 'Jenny Wayne');
const johnWick = new User('John', 'Wick', 35, 'Chicago', 'USA', ['Daisy', 'Boy'], '');
const johnnyBravo = new User('Johnny', 'Bravo', 23, 'Cartoon', 'Network', ['Hey', 'There', 'Good', 'Looking'], '');
const jackBlack = new User('Jack', 'Black', 51, 'Santa Monica', 'USA', ['Tenacious', 'D'], 'Tanya Haden');
const jackNicholson = new User('Jack', 'Nicholson', 83, 'Neptune City', 'USA', ['Wacky', 'Looney'], 'Sandra Knight');
arrayOfUsers.push(johnWayne, johnWick, johnnyBravo, jackBlack, jackNicholson);
let arrayOfInputs = [firstNameInput, lastNameInput, ageInput, cityInput, countryInput, spouseInput, petsInput, petTypeInput];
// arrayOfInputs.push(firstNameInput, lastNameInput, ageInput, cityInput, countryInput, spouseInput, petsInput, petTypeInput);
let  userToEdit = '';

// [Functions]

const addNewUsers = (name, lastName, age, city, country, pets, spouse) => {
    let newUser = new User(name, lastName, age, city, country, pets, spouse);
    arrayOfUsers.push(newUser);
}

const addNewUserStart = () => {
    let errorAddingUser = false;
    arrayOfInputs.forEach(input => {
        if (!validateInput(input)) {
            if (input === spouseInput) {
                return
            }
            errorMessageSubmit.innerText = `* Please make sure you fill out all of the required form inputs`
            errorMessageSubmit.style.color = '#ff0000';
            input.style.backgroundColor = '#FFB7A8';
            errorAddingUser = true;
        } else {
            input.style.backgroundColor = '#ff000000';
        }
        // if (validateInput(input)) {
        //     input.style.backgroundColor = '#ff000000';
        // }
    })

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
    const searchArray = array.filter(element => element.fullName.toLowerCase() === input.value.toLowerCase())
    if (searchArray.length >= 1) {
        userListTable.innerHTML = '';
        searchArray.forEach((element) => {
            userFoundCheck = true
            let tableData = ``;
            for (const key in element) {
                if (element[key] == element.id) {
                    continue;
                }
                tableData += `<td>${element[key]}</td>`
            }
            userListTable.innerHTML +=
                `<tr>
            ${tableData}
            <td>
            <button type="button" class="deleteBtn" onclick="deleteUser(${element.id})">Delete user</button>
            <button type="button" class="deleteBtn" onclick="editUserStart(${element.id})">Edit user</button>
            </td>
            </tr>`
            return
        })
    }


    if (!validateInput(searchBar)) {
        searchError.innerText = `* Please make sure you entered a name`;
    } else if (!userFoundCheck) {
        searchError.innerText = `*There is no user named ${input.value}, please try another name`;
    }
}

const searchStart = () => {
    searchError.innerText = '';
    if (!validateInput(searchBar)) {
        searchError.innerText = `*Please type in a name and last name`;
    }

    searchForUsers(arrayOfUsers, searchBar);
    cleanUpInput(searchBar);
}

const editUserStart = (id) => {
    changeView(editUserView[0], submitUserBtn);
    changeView(editUserView[1]);
    changeView(addUserDiv, searchUserDiv);
    userToEdit = arrayOfUsers.find(user => user.id == id)
    editUserTitle.innerText = `Editing user - ${userToEdit.fullName} (${id})`

    firstNameInput.value = userToEdit.firstName;
    lastNameInput.value = userToEdit.lastName;
    ageInput.value = userToEdit.age;
    cityInput.value = userToEdit.city;
    countryInput.value = userToEdit.country;
    spouseInput.value = userToEdit.spouse;
    petsInput.value = userToEdit.pets;
    petTypeInput.value = userToEdit.petTypeInput;
}

const editUser = () => {
    let errorAddingUser = false;
    arrayOfInputs.forEach(input => {
        if (!validateInput(input)) {
            if (input === spouseInput) {
                return
            }
            errorMessageSubmit.innerText = `* Please make sure you fill out all of the required form inputs`
            errorMessageSubmit.style.color = '#ff0000';
            input.style.backgroundColor = '#FFB7A8';
            errorAddingUser = true;
        }

        if (validateInput(input)) {
            input.style.backgroundColor = '#ff000000';
        }
    })

    if (!errorAddingUser) {

        userToEdit.firstName = firstNameInput.value
        userToEdit.lastName = lastNameInput.value
        userToEdit.fullName = firstNameInput.value + lastNameInput.value
        userToEdit.age = ageInput.value
        userToEdit.city = cityInput.value
        userToEdit.country = countryInput.value
        userToEdit.spouse = spouseInput.value
        userToEdit.pets = petsInput.value

        cleanUpInputs(arrayOfInputs);
        errorMessageSubmit.innerText = `User successfully edited!`
        errorMessageSubmit.style.color = '#0ABD00';
        resetInputColor;
        listObjectProperties(arrayOfUsers);
    }

}

const cleanUpInputs = (inputs) => inputs.forEach(input => input.value = '');

const cleanUpInput = (input) => input.value = '';

const validateInput = (input) => !!input.value;
//     if (!input.value) {
//         return false;
//     }
//     return true;
// }

const resetInputColor = () => arrayOfInputs.forEach(input => input.style.backgroundColor = '#ff000000')

const listObjectProperties = (array) => {
    userListTable.innerHTML = '';
    array.forEach(user => {
        let tableData = ``;
        for (const key in user) {
            if (user[key] == user.id) {
                continue;
            }
            tableData += `<td>${user[key]}</td>`
        }
        userListTable.innerHTML +=
            `<tr>
        ${tableData}
        <td>
        <button type="button" class="deleteBtn" onclick="deleteUser(${user.id})">Delete user</button>
        <button type="button" class="deleteBtn" onclick="editUserStart(${user.id})">Edit user</button>
        </td>
        </tr>`
    })
}

const generatePet = (petName, petType) => { new Pet(petName, petType) };

const deleteUser = (id) => {
    // arrayOfUsers.forEach(user => {
    //     if (user.id == id) {
    //         let userToDelete = arrayOfUsers.indexOf(user);
    //         arrayOfUsers.splice(userToDelete, 1)
    //     }
    // })
    // listObjectProperties(arrayOfUsers);
    arrayOfUsers.splice(arrayOfUsers.findIndex(user => user.id == id),1);
    listObjectProperties(arrayOfUsers);
}

const changeView = (show, hide) => {
    if (show) {
        show.style.display = 'block';
    }
    if (hide) {
        hide.style.display = 'none';
    }
}

// [Event Handlers]
searchBtn.addEventListener('click', searchStart)

resetBtn.addEventListener('click', () => listObjectProperties(arrayOfUsers))

addNewUserNav.addEventListener('click', e => {
    if (e.target && e.target.nodeName == "A") {
        changeView(addUserDiv, searchUserDiv);
        cleanUpInput(searchBar);
        cleanUpInputs(arrayOfInputs);
        searchError.innerText = ``;
        errorMessageSubmit.innerText = ``;
        resetInputColor();
        changeView(submitUserBtn, editUserView[0]);
        changeView(null, editUserView[1]);
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

saveEditUserBtn.addEventListener('click', editUser)

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
    changeView(null, editUserView[0]);
    changeView(null, editUserView[1]);
})()
