namespace InventorySystem;

public class Bird : Animal
{
    public Bird(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} is chirping!");
    }
}