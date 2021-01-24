function Book(name, author, read) {
  this.name = name;
  this.author = author;
  this.read = read;
  this.readingStatus = function () {
    if (read == 'Y' || read == 'y') {
      alert(`You've already read ${name} by ${author}!`);
    } else {
      alert(`You still need to read ${name} by ${author}!`);
    }
  };
}

let bookName = prompt(`Write the name of a good book from 2020`);
let bookAuthor = prompt(`Who wrote it?`);
let didYouRead = prompt(`Have you read it? (Y/N)`);

let newBook = new Book(bookName, bookAuthor, didYouRead);
newBook.readingStatus();
