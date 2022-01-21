using System;
using System.Collections.Generic;
namespace CaseStudyCustomer_21Jan
{
    internal class Program
    {
        public class Products
        {
            string productname;
            int price, quantity;

            public void AddProducts(string productname,int price,int quantity)
            {
                this.productname = productname;
                this.price = price;
                this.quantity = quantity;
            }

            public int getPrice()
            {
                return price;
            }
            public int getQuantity()
            {
                return quantity;
            }

            public void printProdDetail()
            {
                Console.WriteLine("Name: "+productname+"\t Price: "+price+"\t Quantity: "+quantity);
            }

        }

        public class Customer
        {
            string custname,email,shippingaddress,billingaddress;
            
            public void AddCustomer(string custname,string email,string shippingaddress,string billingaddress)
            {
                this.custname = custname;
                this.email = email;
                this.shippingaddress = shippingaddress;
                this.billingaddress = billingaddress;
            }
            public void PrintCustomer()
            {
                Console.WriteLine("Customer Details");
                Console.WriteLine("Name: "+custname+"\t Email: "+email+"\t Shipping Address: "+shippingaddress+"\t Billing Address: "+billingaddress);
            }

        }

        public class Cart
        {
            Customer customer;
            List<Products> prodlist;
            float total_amount;
            bool status = false;
            int idx = 1;
            public void printProducts()
            {
                customer.PrintCustomer();
                foreach(var product in prodlist)
                {
                    Console.Write(idx+" ");
                    product.printProdDetail();
                    idx++;
                }
                Console.WriteLine("Total amount: " + total_amount);
            }

            public void getCustomer(Customer c)
            {
                customer = c;
            }
            public void addToCart(List<Products> products)
            {
                this.prodlist = products;
                foreach(var product in prodlist)
                {
                    total_amount += product.getPrice()*product.getQuantity();
                }
            }

            public bool isconfirmed()
            {
                return status;
            }

            public void ConfirmOrder(bool status)
            {
                this.status = status;                
            }
        }

        public class Order
        {
            List<Cart> carts;
            public void addOrder(List<Cart> c)
            {
                carts = c;
            }
            public void ShowCarts()
            {
                Console.WriteLine("There are "+carts.Count+" Orders done today. Enter the no. of cart you want to see.");
                int i = Convert.ToInt32(Console.ReadLine());
                Cart c = carts[i-1];
                c.printProducts();
            }
        }

        static void Main(string[] args)
        {
            List<Products> prodlist1 = new List<Products>();
            List<Products> prodList2 = new List<Products>();
            
            Products p = new Products();
            p.AddProducts("Shirt", 2000, 2);
            Products p2 = new Products();
            p2.AddProducts("Tshirt", 500, 2);
            Products p3 = new Products();
            p3.AddProducts("Shoes", 2500, 1);
            Products p4 = new Products();
            p4.AddProducts("Cap",200, 2);
            
            Customer cust1 = new Customer();
            cust1.AddCustomer("hemang", "dfghghgn", "dfghfdv", "fdge");
            Customer cust2 = new Customer();
            cust2.AddCustomer("Maan", "dfg", "hgrd", "gfd");

            prodlist1.Add(p);
            prodlist1.Add(p3);
            prodlist1.Add(p4);
            prodList2.Add(p);
            prodList2.Add(p2);
            prodList2.Add(p3);

            List<Cart> carts = new List<Cart>();
            Cart c1 = new Cart();
            c1.getCustomer(cust1);
            c1.addToCart(prodlist1);
            Cart c2 = new Cart();
            c2.getCustomer(cust2);
            c2.addToCart(prodList2);
            c1.ConfirmOrder(true);
            c2.ConfirmOrder(true);

            if(c1.isconfirmed())
                carts.Add(c1);
            if(c2.isconfirmed())
                carts.Add(c2);

            Order order = new Order();
            order.addOrder(carts);

            order.ShowCarts();
        }
    }
}
