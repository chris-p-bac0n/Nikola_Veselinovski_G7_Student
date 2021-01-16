let divOne = document.getElementById(`first`);
let divTwo = divOne.nextElementSibling;
let divThree = divTwo.nextElementSibling;

let headerOne = document.getElementById(`myTitle`);
headerOne.innerText = 'I Changed this';

let paragraphOne = headerOne.nextElementSibling;
paragraphOne.innerText = 'Yup changed this too';

let paragraphTwo = divTwo.firstElementChild;
paragraphTwo.innerText = 'Also changed this';
let textTag = paragraphTwo.nextElementSibling;
textTag.innerText = 'And this';

let lastHeaderOne = divThree.firstElementChild;
let lastHeaderTwo = divThree.lastElementChild;
lastHeaderOne.innerText = 'I changed this as well';
lastHeaderTwo.innerText = 'Aaaand finally changed this too';