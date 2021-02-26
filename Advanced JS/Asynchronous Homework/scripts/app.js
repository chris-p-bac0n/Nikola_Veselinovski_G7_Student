function Animal(name, age, colors, tail) {
    this.name = name;
    this.age = age;
    this.colors = colors;
    this.tail = tail;
}

arrayOfAnimals = [];

// [With white animals]

const panda = arrayOfAnimals.push(new Animal('Miki', 6, ['black', 'white'], true));
const fox = arrayOfAnimals.push(new Animal('Kwiki', 3, ['white', 'red'], true));
const cat = arrayOfAnimals.push(new Animal('Kikiriki', 8, ['orange', 'black', 'brown'], false));
const monkey = arrayOfAnimals.push(new Animal('Rafiki', 5, ['black', 'blue'], true));

// [Without white animals]

// const panda = arrayOfAnimals.push(new Animal('Miki', 6, ['black', 'green'], true));
// const fox = arrayOfAnimals.push(new Animal('Kwiki', 3, ['green', 'red'], true));
// const cat = arrayOfAnimals.push(new Animal('Kikiriki', 8, ['orange', 'black', 'brown'], false));
// const monkey = arrayOfAnimals.push(new Animal('Rafiki', 5, ['black', 'blue'], true));

const checkAnimals = (array) => {
    return new Promise((resolve, reject) => {
        if (!array.length) {
            reject('No animals');
        } else {
            resolve(array);
        }
    })
}

const getWhiteAnimals = (array) => {
    const animalArray = array.filter(animal => animal.colors.includes('white'));
    return new Promise((resolve, reject) => {
        if (!animalArray.length) {
            reject('No white animals');
        } else {
            resolve(animalArray);
        }
    })

}

const printAnimalsA = () => {
    checkAnimals(arrayOfAnimals)
        .then(array => {
            return getWhiteAnimals(array);
        })
        .then(animalArray => {
            if (animalArray.length) {
                (animalArray.forEach(animal => console.log('Print A :', animal)))
            }
        })
        .catch(error => {
            console.log('Print A ERROR: ', error);
        })

}

printAnimalsA()

printAnimalsB = async () => {
    try {
        let array = await checkAnimals(arrayOfAnimals);
        const animalArray = await getWhiteAnimals(array);
        animalArray.forEach(animal => console.log('Print B :', animal));
    } catch (error) {
        console.log('Print B ERROR: ', error);
    }
}

printAnimalsB()
