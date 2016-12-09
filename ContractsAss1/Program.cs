namespace ContractsAss1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var acc = new Account();
            acc.Deposit(400); // OK
            acc.Withdraw(-100); // Triggers Exception
        }
    }
}