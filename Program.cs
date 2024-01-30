using System;




class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }

    public void Display()
    {
        Console.WriteLine($"Bilgisayar bilgileri: CPU={CPU}, RAM={RAM}, Storage={Storage}");
    }
}





interface IComputerBuilder
{
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    Computer GetComputer();
}





class StandardComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void BuildCPU()
    {
        computer.CPU = "Intel Core i5";
    }

    public void BuildRAM()
    {
        computer.RAM = "8GB";
    }

    public void BuildStorage()
    {
        computer.Storage = "256GB SSD";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}



class ComputerDirector
{
    private IComputerBuilder computerBuilder;

    public ComputerDirector(IComputerBuilder builder)
    {
        computerBuilder = builder;
    }

    public void ConstructComputer()
    {
        computerBuilder.BuildCPU();
        computerBuilder.BuildRAM();
        computerBuilder.BuildStorage();
    }
}

// Kullanım
class Program
{
    static void Main()
    {
        IComputerBuilder builder = new StandardComputerBuilder();

        ComputerDirector director = new ComputerDirector(builder);

        director.ConstructComputer();

        Computer computer = builder.GetComputer();

        computer.Display();

        Console.ReadKey();
    }
}
