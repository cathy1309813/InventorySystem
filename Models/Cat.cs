namespace InventorySystem;

public class Cat : Animal
{
    public Cat() : base("Cat")
    {
    }
    
    public Cat(string name) : base(name)
    {
    }
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} is meowing");
    }
}