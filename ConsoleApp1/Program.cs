// See https://aka.ms/new-console-template for more information
int x = 3;
x = x + 1;

Task<int> task = Task.Factory.StartNew(() => {
    var res = 0;
    for(int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);
        Thread.Sleep(300);
        res += i;
    }
    return res;
});

for (int i = 10; i < 20; i++)
{
    Console.WriteLine(i);
    Thread.Sleep(100);
}

x = task.Result;
Console.WriteLine("the result is " + x);

for(int i = 100; i < 110; i++)
{
    Console.WriteLine(i);
    Thread.Sleep(100);
}

Console.WriteLine("Hello, World!"+x);
