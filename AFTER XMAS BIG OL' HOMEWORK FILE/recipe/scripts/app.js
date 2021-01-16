// let headingToPush = document.getElementById(`recipeNameHeading`);
// let divToPush = document.getElementById(`recipeTableDiv`);

// let recipeName = prompt(`Please type in the name of the recipe`);
// let numberOfIngredients = prompt(`Please type in the number of ingredients (up to 10)`);

// if (isNaN(numberOfIngredients)) {
//     alert (`The number of ingredients must be a number!`);
//     recipeName = `Please refresh and try again!`;
// } else if (numberOfIngredients > 10) {
//     alert (`That's too many ingredients!`);
//     recipeName = `Please refresh and try again!`;
// }

// function printRecipe (){

//     headingToPush.innerHTML = `${recipeName}`;
//     divToPush.innerHTML = ``;
//     let ingredientList = ``;

//     for (let i = 0; i < numberOfIngredients; i++) {
//         if (numberOfIngredients > 10){
//             break
//         } else {
//         let ingredient = prompt(`Please type in ingredient number ${(i+1)}`);
//         ingredientList += `<li>${ingredient}</li>`;
//         }
//         divToPush.innerHTML = `<ul>${ingredientList}</ul>`;
//     }
// }

// printRecipe ();



let headingToPush = document.getElementById(`recipeNameHeading`);
let divToPush = document.getElementById(`recipeTableDiv`);

let recipeName = prompt(`Please type in the name of the recipe`);
let numberOfIngredients = prompt(`Please type in the number of ingredients (up to 10)`);

if (isNaN(numberOfIngredients)) {
    alert (`The number of ingredients must be a number!`);
    recipeName = `Please refresh and try again!`;
} else if (numberOfIngredients > 10) {
    alert (`That's too many ingredients!`);
    recipeName = `Please refresh and try again!`;
}

function printRecipe (){

    headingToPush.innerHTML = `${recipeName}`;
    divToPush.innerHTML = ``;
    let ingredientList = ``;

    for (let i = 0; i < numberOfIngredients; i++) {
        if (numberOfIngredients > 10){
            break
        } else {
        let ingredient = prompt(`Please type in ingredient number ${(i+1)}`);
        ingredientList += `<tr><td class="recipeTableCss"><li class="dataPadding">${ingredient}</li></td></tr>`;
        }
        divToPush.innerHTML = `<table class="recipeTableCss"><ul class= "ulBullets">${ingredientList}</ul></table>`;
    }
}

printRecipe ();