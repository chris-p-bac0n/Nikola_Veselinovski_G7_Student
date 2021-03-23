let accountBalance = 500;
let amountToWithdraw = prompt ('Hello, how much would you like to withdraw?');
let amountLeft = accountBalance - amountToWithdraw;


    if (amountToWithdraw > 500) {
        alert (`Not enough money`);
    } else {
        alert (`You just withdrew ${amountToWithdraw} and you have ${amountLeft} left on your account `);
    }


