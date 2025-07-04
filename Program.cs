// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Data;
using InventorySystem;
using Microsoft.VisualBasic.CompilerServices;

using InventorySystem.Repositories;

//Server: mtsql所在伺服器位置 (localhost or ip xxx.xxx.xxx.xxx)
//Port: mysql端口 (預設3306)
//Database: inventory_db (CREATE DATABASE inventory_db;)
//uid: mysql使用者名稱
//pwd: mysql使用者密碼
const string MYSQL_CONNECTION_STRING = "Server=localhost;Port=3306;Database=Inventory_db;uid=root;pwd=Qwas0321polk;";

MySqlProductRepository productRepository = new MySqlProductRepository(MYSQL_CONNECTION_STRING);

RunMenu();


//練習:
// Product testProduct = new Product (1, "testProduct", 100.0m, 5);
// testProduct.Quantity = 15;
// testProduct.UpdateStatus();
// Console.WriteLine(testProduct.ToString());

//練習:物件導向   
// List<Animal> animals = new List<Animal>();
// animals.Add(new Dog("小黑"));
// animals.Add(new Cat("花花"));
// animals.Add(new Bird("bird"));
// foreach (Animal animal in animals)
// {
//     animal.MakeSound();
// }


Console.WriteLine("Hello, World!");

//練習1:在主進入點呼叫test方法，此方法會進行Console.WriteLine動作
Test(); //Function名稱使用大寫駝峰

//練習2:在設定test1方法，呼叫此方法會出現"test!"字串
Test1("test!");

//練習3:先宣告一個變數，再讓此變數賦值
int age;
age = 30;

//練習4:宣告不同變數，並於等號後直接賦值
string name = "Alice";
double salary = 50000.76;
bool isAive = true;
char c = 'K';
decimal amount = 1000.00m; //decimal的數值結尾必須接 "m" !

//練習5:打印語法練習
Console.WriteLine($"Name: {name}, Age: {age}, Salary: {salary}, IsAlive: {isAive}"); //String.Format("%s, $s, name, age")

//練習6:var關鍵字
var value = "ten"; //此句value已自動編譯認知為字串string
//value = 10; //在此句又被定義為整數int，故顯示錯誤
//value = "Bob"; //在此句又被定義為字串string，但是不同字串所以可以更換

//練習7:const關鍵字
const string FINAL_NAME = "Bob"; //java: final String FINAL_NAME = "Bob";
//FINAL_NAME = "new name"; //FINAL_NAME在上一句已經被鎖定無法再改變，故顯示錯誤

//練習8-1:if-else語法呼應flag(true)
Flag1(true);

//練習8-2:用string配合條件運算子呼應flag(true)
Flag2(true);

//練習8-3:使用C#三元運算子-->條件 ? 表達式1 : 表達式2
Flag3(true);

//練習9:Switch
SwitchCase("Monday");
//練習10:if-else
IfElse("Monday");
ForLoop();
Test2();
ConsoleReadLine();


void RunMenu()
{
    while (true)
    {
        DisplayMenu();
        String input = Console.ReadLine();
        switch (input)
        {
            case "1": GetAllProduct(); break;
            case "2": SearchProduct(); break;
            case "3": AddProduct(); break;
            case "0":
                Console.WriteLine("Goodbye!");
                return;
        }
    }
}

void DisplayMenu()
{
    Console.WriteLine("Welcome to Inventory System");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. 查看所有產品");
    Console.WriteLine("2. 查詢產品");
    Console.WriteLine("3. 新增產品");
    Console.WriteLine("0. 離開");
}

void GetAllProduct()
{
    Console.WriteLine("\n--- 所有產品列表 ---");
    var products = productRepository.GetAllProducts();
    if (products.Any())
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("ID | Name | Price | Quantity | Status");
        Console.WriteLine("-----------------------------------------------");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine("------------------------------------------------");
    }
}

void SearchProduct()
{
    Console.WriteLine("輸入欲查詢的產品編號: ");
    string input = Console.ReadLine(); //string input：建立一個名為 input 的字串變數，用來存放輸入的產品編號。
    
    if (int.TryParse(input, out int productId))
    {
        var product = productRepository.GetProductById(productId);
        
        if (product == null)
        {
            Console.WriteLine($"找不到編號為 {productId} 的產品。");
        }
        else
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("ID | Name | Price | Quantity | Status");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(product);
            Console.WriteLine("-----------------------------------------------");
        }
    }
    else
    {
        Console.WriteLine("輸入錯誤！請輸入有效的數字編號。");
        return;
    }
}

void AddProduct()
{
    Console.WriteLine("輸入產品名稱: ");
    string name = Console.ReadLine();
    Console.WriteLine("輸入產品價格: ");
    decimal price = ReadDecimalLine();
    Console.WriteLine("輸入產品數量: ");
    int quantity = ReadIntLine("請輸入庫存狀態: ");
    productRepository.AddProduct(name, price, quantity);
}

int ReadInt(string input)
{
    try
    {
        return int.Parse(input);
    }
    catch (FormatException e)
    {
        Console.WriteLine("輸入格式錯誤，請輸入有效的整數數字。");
        throw;
    }
}

int ReadIntLine(string? s, int defaultValue = 0)
{
    while (true)
    {
        Console.Write(s);
        String input = Console.ReadLine();
        
        if (string.IsNullOrEmpty(input) && defaultValue != 0)
        {
            return defaultValue;
        }
        //string to int
        if (int.TryParse(input, out int productId))
        {
            return productId;
        }
        else
        {
            Console.WriteLine("請輸入一個有效的整數。");
        }
    }
}

int ReadDecimalLine(decimal defaultValue = 0.0m)
{
    while (true)
    {
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) && defaultValue != 0.0m)
        {
            return (int)defaultValue;
        }

        if (decimal.TryParse(input, out decimal value))
        {
            return (int)value;
        }
        else
        {
            Console.WriteLine("請輸入一個有效的數字（可包含小數點）。");
            Console.WriteLine("請重新輸入：");
        }
    }
}


//練習13
static void ConsoleReadLine()
{
    // 同JAVA中的Scanner寫法
    // Scanner sc = new Scanner();
    // sc.nextLine();
    
    Console.Write("請輸入您的名字: ");
    String userName = Console.ReadLine();
    //補充: String?表示這個變數可以是「string 或 null」 → nullable reference type（可為空參考型別）
    Console.WriteLine($"哈囉! {userName}");
    Console.Write("請輸入您的年齡: ");
    String userAge = Console.ReadLine();

    if (int.TryParse(userAge, out int age)) //TryParse是C#中專屬用法
    {
        Console.WriteLine($"您的年齡為， {age}");
    }
    else
    {
        Console.WriteLine("年齡輸入錯誤!");
    }
    
    // 同JAVA中讀取字串並嘗試轉成整數的寫法
    // try {
    //     Scanner sc = new Scanner(System.in); // 建立 Scanner 讀取系統輸入
    //     String ageStr = sc.nextLine();       // 讀一行字串
    //     Integer age = Integer.valueOf(ageStr);  // 嘗試將字串轉成 Integer
    //     System.out.println("你輸入的年齡是: " + age);
    // } catch (NumberFormatException e) {      // 捕捉轉換失敗例外
    //     System.out.println("年齡輸入錯誤!");
    // }
}  

//練習12
static void Test2()
{
    Console.WriteLine("這是一行文字，會自動換行"); //JAVA: System.out.println()
    Console.Write("這是一行文字，");
    Console.Write("不會自動換行。"); //JAVA: System.out.print()
    Console.WriteLine("\n換行了。"); // 可以用 \n 強制換行
}  

//練習11
static void ForLoop()
{
    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, };
    foreach (var number in numbers) //JAVA中是for；cSharp是foreach
    {
        if (number == 4) // 當遇到 4，就跳過這次，下面不執行
        {
            continue;
        } //當有其他條件時再加else，不需要時就不用硬加
        Console.WriteLine(number);
    }    
}    

//練習10
static void IfElse(string dayofWeek)
{
    if (dayofWeek == "Monday" || dayofWeek == "Tuesday" || dayofWeek == "Wednesday" || dayofWeek == "Thursday" 
        || dayofWeek == "Friday")
    {
        Console.WriteLine("工作日");
    }
    else if (dayofWeek == "Saturday" || dayofWeek == "Sunday")
    {
        Console.WriteLine("週末");
    }
    else
    {
        Console.WriteLine("未知日期");
    }
}

//練習9
static void SwitchCase(string dayofWeek)
{
    switch (dayofWeek)
    {
        case "Monday":
        case "Tuesday":
            Console.WriteLine("工作日");
            break;
        case "Saturday":
        case "Sunday":
            Console.WriteLine("週末");
            break;
        default:
            Console.WriteLine("未知日期");
            break;
    }
}

//練習8-3:三元運算子:條件 ? 表達式1 : 表達式2
static void Flag3(bool c)
{
    string msg2 = c ? "條件為真" : "條件為假";
    Console.WriteLine(msg2);
}
//練習8-2:用string配合條件運算子
static void Flag2(bool b)
{
    string msg1;
    if (b)
    {
        msg1= "條件為真";
    }
    else
    {
        msg1= "條件為假";
    }
}
//練習8-1:if-else
static void Flag1(bool a)
{
    if (a)
    {
        Console.WriteLine("條件為真");
    }
    else
    {
        Console.WriteLine("條件為假");
    }
}
    
//設定方法test1在被呼叫時，會出現"test!"字串
static void Test1(string message)
{
    Console.WriteLine(message);
}

//在主進入點呼叫test方法，此方法會進行Console.WriteLine動作
static void Test() //Function名稱使用大寫駝峰
{
    Console.WriteLine("test static function");
}

