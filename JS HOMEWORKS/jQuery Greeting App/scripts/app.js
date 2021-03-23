$('#greetingButton').first().click(function () {
    let inputName = $('#greetingNameInput').first().val();
    if (inputName == '') {
        alert('Hey pal, no name = no game!');
    } else {
        $('h1').first().text(`Greetings ${inputName} this is by far THE greatest greeting you have ever been greeted with!`);
        $('h1').css('color', 'green', 'text-align', 'center');
        $('body').css('background-color', 'yellow');
        $('#greetingForm').hide();
    }
})