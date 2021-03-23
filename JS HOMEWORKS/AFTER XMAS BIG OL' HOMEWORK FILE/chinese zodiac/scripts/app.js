function chineseZodiacCalc () {
    let inputYear = prompt(`Please insert your birth year`);
    yearCalc = (inputYear - 4) % 12;
    if (yearCalc === 0) {
        alert (`Your chinese zodiac sign is the Rat`)
    } else if (yearCalc === 1) {
        alert (`Your chinese zodiac sign is the Ox`)
    } else if (yearCalc === 2) {
        alert (`Your chinese zodiac sign is the Tiger`)
    } else if (yearCalc === 3) {
        alert (`Your chinese zodiac sign is the Rabbit`)
    } else if (yearCalc === 4) {
        alert (`Your chinese zodiac sign is the Dragon`)
    } else if (yearCalc === 5) {
        alert (`Your chinese zodiac sign is the Snake`)
    } else if (yearCalc === 6) {
        alert (`Your chinese zodiac sign is the Horse`)
    } else if (yearCalc === 7) {
        alert (`Your chinese zodiac sign is the Goat`)
    } else if (yearCalc === 8) {
        alert (`Your chinese zodiac sign is the Monkey`)
    } else if (yearCalc === 9) {
        alert (`Your chinese zodiac sign is the Rooster`)
    } else if (yearCalc === 10) {
        alert (`Your chinese zodiac sign is the Dog`)
    } else if (yearCalc === 11) {
        alert (`Your chinese zodiac sign is the Pig`)
    }
}

chineseZodiacCalc ()
