using System;
using System.Threading;

public class CuentaBancaria()
{
    private decimal saldo = 0;
    private object bloqueo = new object();

    public void Depositar(decimal cantidad)
    {
        lock (bloqueo)
        {
            saldo += cantidad;
            Console.WriteLine("Deposito de " + cantidad + "Saldo actual:" +  saldo);

        }
    }
}

public class Program
{
    public static void Main()
    {
        CuentaBancaria cuenta = new CuentaBancaria();

        Thread hilo1 = new Thread(() => cuenta.Depositar(100));
        Thread hilo2 = new Thread(() => cuenta.Depositar(200));
        Thread hilo3 = new Thread(() => cuenta.Depositar(300));

        hilo1.Start();
        hilo2.Start();
        hilo3.Start();

    }
}
