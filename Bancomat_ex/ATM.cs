namespace Bancomat_ex
{
    internal class ATM
    {
        private int pin;
        private double balance;
        private int attempts;

        public ATM(int pin, double balance, int attempts)
        {
            this.pin = pin;
            this.balance = balance;
            this.attempts = attempts;
        }

        public void loginAttempt()
        {
            int userPin = Convert.ToInt32(Console.ReadLine());
            string userLoggedMessage = CheckPin(userPin).message;
            bool userLogged = CheckPin(userPin).confirm;

            if (userLogged)
            {
                Console.WriteLine(userLoggedMessage);
                TakeMoney();
            } 
            else if (!userLogged)
            {
                --attempts;
                Console.WriteLine(userLoggedMessage);
                WrongPin();
            }

        }

        private void WrongPin()
        {
            if (attempts > 0)
            {
                //Console.WriteLine(message);
                Console.WriteLine("Please, insert your pin.");
                loginAttempt();
            }          
        }

        private (string message, bool confirm) CheckPin(int pinUser)
        {

            if (attempts > 0 && pin == pinUser)
            {
                return ("Welcome! Your balance is: " + balance , true);
            }
            else if (attempts > 1)
            {
                return ("Wrong pin, you have left: " + (attempts - 1) + " attempt.", false);
            }
            
            return ("Limit reach. Your account has been blocked, please contact your bank!", false);

        }

        private void TakeMoney()
        {
            double moneyUser = 0;
            bool continueOperations = false;


            Console.WriteLine("How much money do you want?");
            moneyUser = Convert.ToDouble(Console.ReadLine());

            if (moneyUser > 250 || moneyUser > balance)
            {
                Console.WriteLine("You exceed maximum to take or balance in your bank!\nTerminated.");

                //takeMoney(); uncomment if u would to answer to take money

                return; //interrupt and terminated execution
            }

            Console.WriteLine("You have choice to take " + moneyUser + " ? (Y/N)");
            continueOperations = Console.ReadLine().ToLower() == "y" ? true : false;


            if (!continueOperations)
            {
                TakeMoney();
            } 
            else if (continueOperations)
            {
                balance -= moneyUser;
                Console.WriteLine("Your new balance is: " + balance);

                Console.WriteLine("Do you want to take another money? (Y/N)");

                if (Console.ReadLine().ToLower() == "y" ? true : false)
                {
                    TakeMoney();
                } else
                {
                    Console.WriteLine("Terminated.");
                }
            }
        }
    }
}
