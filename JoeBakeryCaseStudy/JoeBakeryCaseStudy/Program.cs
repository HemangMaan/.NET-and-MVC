using System;

namespace JoeBakeryCaseStudy
{
    public class Item
    {
        string itemName;
        int price, quantity;
        public void setItems(string itemName,int price)
        {
            this.itemName = itemName;
            this.price = price;
        }
        public void getItems()
        {
            Console.WriteLine("Name: "+itemName+" \t Price: "+price);
        }
        public string getName()
        {
            return itemName;
        }
        public int getPrice()
        {
            return price;
        }
        public void setQuantity(int q)
        {
            this.quantity=q;
        }
        public int getquantity()
        {
            return quantity;
        }
    }
    public class Menu
    {
        int no = 1;
        public void DisplayItems(Item[] i)
        {
            Console.WriteLine("------Welcome to Joe Bakery------");
            Console.WriteLine("--------------Menu--------------");
            foreach (Item item in i)
            {
                Console.Write(no++ + " ");
                item.getItems();
            }
            Console.WriteLine("--------------------------------");
        }

    }
    public class Order
    {
        Item[] item;
        int i = 0,totalamount=0;
        public Order(int n)
        {
            item = new Item[n];
        }

        public void getOrder(Item[] it)
        {
            for (int i = 0; i < item.Length; i++)
            {
                Console.WriteLine("Enter the order no. to order the item");
                int ordno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the quantity of " + it[ordno - 1].getName());
                int qty = Convert.ToInt32(Console.ReadLine());
                Item orditm = new Item();
                orditm = it[ordno - 1];
                orditm.setQuantity(qty);
                AddItemToOrder(orditm);
                Console.WriteLine("Item Added.");
            }
        }

        public void AddItemToOrder(Item it)
        {
            item[i++] = it;
        }
        public void DisplayTotalAmount(Order o)
        {
            for(int j = 0; j < o.item.Length; j++)
            {
                totalamount += o.item[j].getPrice() * o.item[j].getquantity();
            }
            Console.WriteLine("Total amount: "+totalamount);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Item[] items = new Item[5];
            int p;
            items[0] = new Item();
            items[0].setItems("Burger", 50);
            items[1] = new Item();
            items[1].setItems("Fries", 80);
            items[2]=new Item();
            items[2].setItems("Wraps",65);
            items[3]=new Item();
            items[3].setItems("Pizza",150);
            items[4]=new Item();
            items[4].setItems("Cola",60);
            Menu menu = new Menu();
            menu.DisplayItems(items);
            do
            {
                Console.WriteLine("Enter the total no. of items you want to order.");
                int n = Convert.ToInt32(Console.ReadLine());
                Order order = new Order(n);
                order.getOrder(items);
                order.DisplayTotalAmount(order);
                Console.WriteLine("Do you want to place order? Enter 1 to confirm 0 to cancel.");
                p = Convert.ToInt32(Console.ReadLine());
                if(p == 0)
                {
                    Console.WriteLine("Order Rejected.");
                }
                if (p == 1)
                {
                    Console.WriteLine("Order Confirmed.");
                }
                Console.WriteLine("Do you want to give another Order? Enter 1 for YES 0 for NO");
                p=Convert.ToInt32(Console.ReadLine());
            } while (p==1);
        }
    }
}
