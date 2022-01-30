using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace ConsoleApp1
{

    public class CustomEventArgs: EventArgs
    {
        public int Number { get; set; }
        public string Message { get; set; }
    }
    //step 2: Declare a Delegate using .NET Event Pattern
    public delegate void CustomEventHandler(object sender, CustomEventArgs e);
    //Step 3: Define Publisher class
    internal class Publisher 
    {
        //3.1 : Declare a variable for the Delegate. Part of Instantiation
        public CustomEventHandler MyEvent;

        //3.2 Method to trigger the notification. Standard .NET practice
        protected void OnMyEvent(CustomEventArgs e) => MyEvent?.Invoke(this, e);
       
        public void RaiseNotifications()
        {
            for(int i = 0; i < 10; i++)
            {
                if(i==5 || i == 6)
                {
                    CustomEventArgs e = new CustomEventArgs { Number = i, Message = "Limits Reached" };
                    OnMyEvent(e);
                }
            }
        }
    }
    //Step 4: Define the subscriber class
    internal class Subscriber
    {
        //4.1 Define a method which matches the delegate signature
        public void HandleEvent(object sender,CustomEventArgs e)
        {

            WriteLine($"SUBSCRIBER SAYS: [ Number: {e.Number}, Message: {e.Message}");
        }
    }

    //step 5: Define a class which helps in mapping the publisher with the subscriber.
    internal class EventDelegationModel
    {
        //5.1 Define the mapping function
        internal static void Test()
        {
            //5.2 Create the publisher object 
            Publisher pub = new Publisher();
            //5.3 create the subscriber object;
            Subscriber sub = new Subscriber();
            //5.4 Map the subscriber function to the publisher delegate object
            pub.MyEvent += new CustomEventHandler(sub.HandleEvent);

            //5.5 Mapping the subscriptions can be done inline
            //Anonymous methods
            pub.MyEvent += delegate (object sender, CustomEventArgs e)
             {
                 WriteLine($"Anonymous SAYS: [ Number: {e.Number}, Message: {e.Message}");
             };
            //5.6 Simpler way of handling the notification
            //LAMBDAS
            pub.MyEvent += (s, e) => WriteLine($"LAMBDAS SAYS: [ Number: {e.Number}, Message: {e.Message}");

            //Expression Lambdas = single statement lambdas   ()=>statement;
            //Statement Lambdas - multiple statement(s) expression  ()=> { ... }
            // Arguments to lambdas can be passed as 
            //No arguments   => () => {}
            //1 arguments   => (arg) => { } OR arg => { }
            //2 or more arguments   => (arg1,arg2, ...) => { }

            //5.7 Invoke the Publishers raise notification method
            pub.RaiseNotifications();

            WriteLine("Press a key to terminate");
            ReadKey();
        }
    }
}
