namespace InventorySystem;

public abstract class Animal
{
    public String Name {get; set;}
    public Animal(String name)
    {
        Name = name;
    }

    public abstract void MakeSound();
    
}