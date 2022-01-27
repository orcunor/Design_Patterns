using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EMailSender(); // new SMSSender()
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    public abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!!");
        }
        public abstract void Send(Body body);
    }

    public class SMSSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SMSSender", body.Text);
        }
    }

    public class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EMailSender", body.Text);
        }
    }

    public class Body
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }


    public class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body {  Subject = "Test" , Text = "Text Message"});
            Console.WriteLine("Customer updated");
        }
    }
}
