namespace InventorySystem;

public class Product            //class的命名必須是大寫駝峰!
{
    public enum ProductStatus                  //宣告一個新的列舉型別:ProductStatus
    {
        InStock,    //有庫存
        LowStock,   //庫存偏低
        OutOfStock, //沒有庫存
    }
    public int Id { get; set; }                //public-->命名第一個字母須大寫；private-->命名第一個字母須小寫
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public ProductStatus Status { get; set; }  //public:存取修飾詞；ProductStatus:屬性的資料型別；Status:屬性的名稱，應使用大寫。
      

    public Product()
    {
    }
    
    //建構子
    public Product(int id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        UpdateStatus();                        //自動根據庫存數量更新狀態
        //Status = status; 此寫法表示使用傳進來的值，不自動判斷故建構子內部不需要"ProductStatus status"
    }

    public override string ToString()          //覆寫(override)可以讓物件在印出時顯示清楚有意義的資訊
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";
    }

    public void UpdateStatus()
    {
        if (Quantity == 0)
        {
            Status = ProductStatus.OutOfStock;
        }
        else if (Quantity <= 5)
        {
            Status = ProductStatus.LowStock;
        }
        else
        {
            Status = ProductStatus.InStock;
        }
    }
}