let numberOfColumns = prompt(`Please insert the number of columns for your table`);

while (isNaN(numberOfColumns)) {
    alert('The value you inserted was not a number, please insert a number!');
    numberOfColumns = prompt(`Please insert the number of columns for your table`);
}

let numberOfRows = prompt(`Please insert the number of rows for your table`);

while (isNaN(numberOfRows)) {
    alert('The value you inserted was not a number, please insert a number!');
    numberOfRows = prompt(`Please insert the number of rows for your table`);
}

function printTable (columns, rows) {
    let divToPush = document.getElementById('tableDiv');
    divToPush.innerHTML = ``;
    let table = ``;

    for (let i = 0; i < rows; i++) {
        let tData = ``;

        for (let j = 0; j < columns; j++) {
            tData += `<td class="tableDataStyle" class="dataCellName">Row ${i+1} Column ${(j+1)}</td>`;
        }

        table += `<tr>${tData}</tr>`;

        divToPush.innerHTML = `<table class="tableStyle">${table}</table>`;
    }
}

printTable (numberOfColumns, numberOfRows);
