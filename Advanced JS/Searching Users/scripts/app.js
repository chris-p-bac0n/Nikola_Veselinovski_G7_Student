// [Selectors]

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

// Other elements, pages, etc.

// [Data]
arrayOfUsers = []
const JohnWayne = new User('John', 'Wayne', 45, 'Warsaw', 'Poland', ['Jimmy', 'Johnny', 'Jacky'], 'Jenny Wayne');
const JohnWick = new User('John', 'Wick', 35, 'Chicago', 'USA', ['Daisy', 'Boy']);
const JohnnyBravo = new User('Johnny', 'Bravo', 23, 'Cartoon', 'Network', ['Hey', 'There', 'Good', 'Looking']);
const JackBlack = new User('Jack', 'Black', 51, 'Santa Monica', 'USA', ['Tenacious', 'D'], 'Tanya Haden');
const JackNicholson = new User('Jack', 'Nicholson', 83, 'Neptune City', 'USA', ['Wacky', 'Looney'], 'Sandra Knight');
arrayOfUsers.push(JohnWayne, JohnWick, JohnnyBravo, JackBlack, JackNicholson)

// [Functions]

function searchForUsers(array, input) {
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

    if (!userFoundCheck) {
        searchError.innerText = `*There is no user named ${input.value}, please try another name`;
    }
}

function searchStart() {
    searchError.innerText = '';
    if (!validateInputs(searchBar)) {
        searchError.innerText = `*Please type in a name and last name`;
    }

    searchForUsers(arrayOfUsers, searchBar);
    cleanUpInputs(searchBar);
}

function cleanUpInputs(input) {
    input.value = ''
}

function validateInputs(input) {
    if (!input.value) {
        return false;
    }

    return true;
}

function listObjectProperties(array) {
    for (let i = 0; i < array.length; i++) {
        let tableData = ``;
        for (const key in array[i]) {
            tableData += `<td>${array[i][key]}</td>`
        }
        userList.innerHTML += `<tr>${tableData}</tr>`
    }
}

function changeView(show, hide) {
    show.style.display = 'block';
    hide.style.display = 'none';
}

function resetView() {
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

function init() {
    listObjectProperties(arrayOfUsers);

}


// [Event Handlers]
searchBtn.addEventListener('click', searchStart)
resetBtn.addEventListener('click', resetView)


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

// [Initialization]

init();
