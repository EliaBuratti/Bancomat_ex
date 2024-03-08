namespace Bancomat_ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM newTransaction = new ATM(9876, 1500, 3);
            Console.WriteLine("Welcome in the Experis Bank, please insert your PIN: ");
            newTransaction.loginAttempt();


        }
    }
}
