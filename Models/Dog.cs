namespace InventorySystem;

public class Dog : Animal
{
    public Dog() : base("Dog")
    {
    }

    public Dog(string name) : base(name)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} is barking!");
    }
}