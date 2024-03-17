namespace AppConHilosATM;


    class Program
    {
        static int accountBalance = 1000;
        static Random random = new Random();
    

    static void PerformTransation(object? threadid)
    {
        for (int i = 0; i < 5; i++)
        {
            int amountToWithdraw = random.Next(10,101);

            Thread.Sleep(500);

            lock(typeof(Program)){
                if(accountBalance >= amountToWithdraw){
                    accountBalance -= amountToWithdraw;
                    Console.WriteLine($"Thread {threadid}: se retiraron ${amountToWithdraw}, Quedan ${accountBalance} pesos");
                }
                else{
                    Console.WriteLine($"Thread {threadid}: Fondos insuficientes, se requieren: ${amountToWithdraw} pesos");
                }
            }
        }

    }

    static void Main(string[] args){
        Console.WriteLine("Bienvenido al cajero automatico");
        Console.WriteLine($"Cuentass con ${accountBalance} pesos");
        Console.WriteLine("Presione la tecla enter par inicar transacciones ..");
        Console.ReadLine();

        Thread[] threads = new Thread[5];

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] =new Thread(PerformTransation);
            threads[i].Start(i+1);
        }
        foreach (var item in threads)
        {
            item.Join();
        }
        Console.WriteLine("Todas las transacciones completadas");
        Console.WriteLine($"Saldo final de la cuenta ${accountBalance} pesos");
    }
    }
