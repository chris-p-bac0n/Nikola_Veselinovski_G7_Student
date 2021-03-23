let anArrayOfThreeStrings = ["Micky", "tired", "work"];

function tellStory(arr) {
    let fullStory = "${}"
    let storyBase = `Hi there, this is a little story about my guy ${arr[0]}. My man ${arr[0]} is stupid because he's ${arr[1]}. Why is someone stupid for being ${arr[1]} you ask? Well it's because all he does whole day, every day is ${arr[2]}, ${arr[2]}, ${arr[2]}, ${arr[2]} and then he goes on and does some more, you guessed it, ${arr[2]}. Don't be like ${arr[0]}... Enjoy life a little...`;

    alert(storyBase);
}

tellStory(anArrayOfThreeStrings);