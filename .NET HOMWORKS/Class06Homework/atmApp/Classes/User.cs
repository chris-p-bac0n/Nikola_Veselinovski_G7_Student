namespace atmApp.Classes
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private int Balance { get; set; }
        private int Pin { get; set; }
        public long CardNumber { get; set; }

        public User(string name, string surname, int balance, int pin, long cardNumber)
        {
            Name = name;
            Surname = surname;
            Balance = balance;
            Pin = pin;
            CardNumber = cardNumber;
        }
        public User()
        {

        }

        public bool CheckPin(int pin)
        {
            bool pinCheck = false;
            if (pin == Pin)
                pinCheck = true;
            return pinCheck;
        }

        public int CheckBalance()
        {
            int balance = Balance;
            return balance;
        }

        public void Withdraw(int amountToWithdraw)
        {
            Balance = Balance - amountToWithdraw;
        }

        public void Deposit(int amountToDeposit)
        {
            Balance = Balance + amountToDeposit;
        }
    }
}
