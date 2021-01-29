// I found this funky fresh func(tion) online and it basically uses the browser to convert any input string into a CSS color string (if possible) and works with different browsers! (after a LOT of searching I can't begin to explain the level of happiness and sleep depravity I feel!)
function getColorCSS(c) {
  let ele = document.createElement("div");
  ele.style.color = c;
  return ele.style.color.replace(/\s+/, '').toLowerCase();
}
$('#createHeaderBtn').first().click(function () {
  let inputText = $('#headerTextInput').first().val();
  let inputColor = $('#headerColorInput').first().val();
  $('#headerTextInput').first().css('background-color', '');
  $('#headerColorInput').first().css('background-color', '');
  $('#headersDiv').html(``);
  $('h3').last().css('background-color', '');
  $('h3').first().hide();
  $('h3').last().hide();
  if (inputText == '') {
    $('h3').first().text(`* You must input text for the header`);
    $('h3').first().css('color', 'red');
    $('h3').first().css('font-size', '15px');
    $('h3').first().show();
    $('#headerTextInput').first().css('background-color', '#fdbaba');
  } else if (getColorCSS(inputColor) == '') {
    $('h3').last().text(`* You must input a valid color`);
    $('h3').last().css('color', 'red');
    $('h3').last().css('font-size', '15px');
    $('h3').last().show();
    $('#headerColorInput').first().css('background-color', '#fdbaba');
  } else {
    $('#headersDiv').html(`<h1>${inputText}</h1>`).css('color', `${inputColor}`);
    $('#headersDiv').css('text-align', 'center');
    $('#headersDiv').css('word-wrap', 'break-word');
  }
})