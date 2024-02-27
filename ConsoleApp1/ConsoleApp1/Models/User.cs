namespace ConsoleApp1.Models;


public class User
{
    public int ID { get; private set; }
    public string Username { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Status { get; private set; }

    // авторизация пользователя

}


public class Customer: User
{
    public int UserID { get; private set; }
    public List<string> PurchaseHistory { get; private set; } 
    
    // добавление объектов в историю покупок 
}


public class Realtor: User
{
    public int RealtorID { get; private set; }

    // назначается на объявление
    // список сделок, добавление сделок
}


public class Seller: User
{
    public int SellerID { get; private set; }

    // размещение объявления
    // настройки цены, параметров объекта
    // назначает риелтора
}


public class Object
{
    public string TypeID { get; private set; }
    public Seller SellerID { get; private set; }
    public Realtor RealtorID { get; private set; }
    public int Square { get; private set; }
    public string Area { get; private set; }
    public int RoomNumber { get; private set; }
    
}


public class Deal
{
    public Object Object { get; private set; }
    public DateTime DateDeal { get; private set; }
    public Customer Buyer { get; private set; }
    public Deal DealStatus { get; private set; }
    public Object ObjectStatus { get; private set; }
    
}


public class Review
{
    public Object ObjectID { get; private set; }
    public Customer BuyerID { get; private set; }
    public DateTime DateDeal { get; private set; }
    public int RealtorRating { get; private set; }
    public int SellerRating { get; private set; }
    
}
