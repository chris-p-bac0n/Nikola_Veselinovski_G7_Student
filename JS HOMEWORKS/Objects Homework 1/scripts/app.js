function Dog(dogName, dogKind) {
  this.name = dogName;
  this.kind = dogKind;
  this.speak = function () {
    alert("Bark! Bark!");
  };
}

function validateInputs(inputs) {
  for (let input of inputs) {
    if (!input.value) {
      return false;
    }
  }
  return true;
}

submitBtn = document.getElementById("trainDogButton");

submitBtn.addEventListener("click", function () {
  dogName = document.getElementById("dogNameInput");
  dogKind = document.getElementById("dogKindInput");
  if (validateInputs([dogName, dogKind])) {
    let newDog = new Dog(dogName.value, dogKind.value);
    newDog.speak();
    alert(
      `Congratulations! Your dog ${newDog.name}, who is a ${newDog.kind}, just learned how to speak!`
    );
  } else {
    alert('Please make sure you typed in both the name and the kind of dog!');
  }
});
