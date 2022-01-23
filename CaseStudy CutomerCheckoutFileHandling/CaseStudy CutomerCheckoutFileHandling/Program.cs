using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace CaseStudy_CutomerCheckoutFileHandling
{
    internal class Program
    {
        [Serializable]
        public class Products
        {
            string productname;
            int price, quantity;

            public Products(string productname, int price, int quantity)
            {
                this.productname = productname;
                this.price = price;
                this.quantity = quantity;
            }

            public string getProductname()
            {
                return productname;
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
                Console.WriteLine("Name: " + productname + "\t Price: " + price + "\t Quantity: " + quantity);
            }

        }
        [Serializable]
        public class Customer
        {
            public int custid;
            string custname, email, shippingaddress, billingaddress;

            public Customer(int custid, string custname, string email, string shippingaddress, string billingaddress)
            {
                this.custid = custid;
                this.custname = custname;
                this.email = email;
                this.shippingaddress = shippingaddress;
                this.billingaddress = billingaddress;
            }
            public void PrintCustomer()
            {
                Console.WriteLine("Customer Details");
                Console.WriteLine("Name: " + custname + "\t Email: " + email + "\t Shipping Address: " + shippingaddress + "\t Billing Address: " + billingaddress);
            }

        }

        [Serializable]
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
                foreach (var product in prodlist)
                {
                    Console.Write(idx + " ");
                    product.printProdDetail();
                    idx++;
                }
                Console.WriteLine("Total amount: " + total_amount);
            }

            public void getCustomer(Customer c)
            {
                customer = c;
            }

            public Customer giveCustomer()
            {
                return customer;
            }
            public void addToCart(List<Products> products)
            {
                this.prodlist = products;
                foreach (var product in prodlist)
                {
                    total_amount += product.getPrice() * product.getQuantity();
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
                Console.WriteLine("There are " + carts.Count + " Orders done today. Enter the no. of cart you want to see.");
                int i = Convert.ToInt32(Console.ReadLine());
                Cart c = carts[i - 1];
                c.printProducts();
            }
        }

        public static void WritetoProductFile(List<Products> p)
        {
            string path = "D://dotNETGithub//Products.txt";
            Stream savefilestream = File.Create(path);
            BinaryFormatter serializable = new BinaryFormatter();
            serializable.Serialize(savefilestream, p);
            savefilestream.Close();
        }

        public static List<Products> ReadFromProductsFile()
        {
            string filelocation = "D://dotNETGithub//products.txt";
            if (File.Exists(filelocation))
            {
                Console.WriteLine("Reading Products file");
                Stream openfilestream = File.OpenRead(filelocation);
                BinaryFormatter deserializer = new BinaryFormatter();
                List<Products> prod = (List<Products>)deserializer.Deserialize(openfilestream);
                openfilestream.Close();
                return prod;
            }
            else
            {
                Console.WriteLine("Products File Doesn't Exist");
            }
            return null;
        }
        public Customer EnterCustomer()
        {
            Console.WriteLine("Enter Customer Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string custname = Console.ReadLine();
            Console.WriteLine("Enter Email ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Billing Address");
            string billadd = Console.ReadLine();
            Console.WriteLine("Enter Shipping Address");
            string shipAdd = Console.ReadLine();
            Customer c = new Customer(id, custname, email, shipAdd, billadd);
            return c;
        }

        public static void WritetoCustomerFile(Customer cust)
        {
            Stream savefilestream = File.Create("D://dotNETGithub//" + cust.custid.ToString());
            BinaryFormatter serializable = new BinaryFormatter();
            serializable.Serialize(savefilestream, cust);
            savefilestream.Close();
        }

        public static Customer ReadFromCustomerFile(string filename)
        {
            string filelocation = "D://dotNETGithub/" + filename;
            if (File.Exists(filelocation))
            {
                Console.WriteLine("Reading Customer file");
                Stream openfilestream = File.OpenRead(filelocation);
                BinaryFormatter deserializer = new BinaryFormatter();
                Customer emp = (Customer)deserializer.Deserialize(openfilestream);
                return emp;
            }
            else
            {
                Console.WriteLine("Customer doesn't exist.");
            }
            return null;
        }

        public static void WritetoCartFile(Cart cart)
        {
            Stream savefilestream = File.Create("D://dotNETGithub//cart_" + cart.giveCustomer().custid.ToString());
            BinaryFormatter serializable = new BinaryFormatter();
            serializable.Serialize(savefilestream, cart);
            savefilestream.Close();
        }

        public static Cart ReadFromCartFile(string filename)
        {
            string filelocation = "D://dotNETGithub/" + filename;
            if (File.Exists(filelocation))
            {
                Console.WriteLine("Reading Cart file");
                Stream openfilestream = File.OpenRead(filelocation);
                BinaryFormatter deserializer = new BinaryFormatter();
                Cart c = (Cart)deserializer.Deserialize(openfilestream);
                return c;
            }
            else
            {
                Console.WriteLine("Cart doesn't exist.");
            }
            return null;
        }


        static void Main(string[] args)
        {
            List<Products> productlist = new List<Products>();
            List<Products> prodlist1 = new List<Products>();
            List<Products> prodList2 = new List<Products>();

            //Products work
            Products p = new Products("Shirt", 2000, 2);
            Products p2 = new Products("Tshirt", 500, 2);
            Products p3 = new Products("Shoes", 2500, 1);
            Products p4 = new Products("Cap", 200, 2);
            productlist.Add(p);
            productlist.Add(p2);
            productlist.Add(p3);
            productlist.Add(p4);
            WritetoProductFile(productlist);
            List<Products> list = ReadFromProductsFile();

            //Customer work
            List<Customer> customerlist = new List<Customer>();
            Customer cust1 = new Customer(1, "hemang", "dfghghgn", "dfghfdv", "fdge");
            Customer cust2 = new Customer(2, "Maan", "dfg", "hgrd", "gfd");
            WritetoCustomerFile(cust1);
            WritetoCustomerFile(cust2);
            Customer cu1 = ReadFromCustomerFile(cust1.custid.ToString());
            Customer cu2 = ReadFromCustomerFile(cust2.custid.ToString());
            cu1.PrintCustomer();
            cu2.PrintCustomer();


            prodlist1.Add(p);
            prodlist1.Add(p3);
            prodlist1.Add(p4);

            prodList2.Add(p);
            prodList2.Add(p2);
            prodList2.Add(p3);

            //Cart Work
            List<Cart> carts = new List<Cart>();
            Cart c1 = new Cart();
            c1.getCustomer(cust1);
            c1.addToCart(prodlist1);
            Cart c2 = new Cart();
            c2.getCustomer(cust2);
            c2.addToCart(prodList2);

            WritetoCartFile(c1);
            WritetoCartFile(c2);
            Cart cc = ReadFromCartFile("cart_" + c1.giveCustomer().custid.ToString());
            Cart cc2 = ReadFromCartFile("cart_" + c2.giveCustomer().custid.ToString());
            cc.printProducts();
            cc2.printProducts();



            c1.ConfirmOrder(true);
            c2.ConfirmOrder(true);

            if (c1.isconfirmed())
                carts.Add(c1);
            if (c2.isconfirmed())
                carts.Add(c2);

            Order order = new Order();
            order.addOrder(carts);

            //order.ShowCarts();
        }
    }
}
