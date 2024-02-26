// See https://aka.ms/new-console-template for more information

using Exchange.Classes;
using Exchange.Controllers;

public static class Program
{
    public static void Main(string[] args)
    {
        Wallet<Dollar> walletDollar = new();
        Wallet<Euro> walletEuro = new();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Choose Dollar Wallet");
            Console.WriteLine("2. Choose Euro Wallet");
            Console.WriteLine("3. Transfer between wallets");
            Console.WriteLine("4. Quit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WalletController.HandleWalletOperations(walletDollar);
                    break;
                case 2:
                    WalletController.HandleWalletOperations(walletEuro);
                    break;
                case 3:
                    WalletController.ExchangeFunds(walletDollar, walletEuro);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again!");
                    break;
            }
        }
    }
}