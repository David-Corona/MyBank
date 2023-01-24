namespace MyBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("David", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());

            // Test initial balance
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("Pepe", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            account.MakeWithdrawal(50, DateTime.Now, "Shopping");
            Console.WriteLine(account.Balance);

            // Test negative balance
            try
            {
                account.MakeWithdrawal(20000, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}