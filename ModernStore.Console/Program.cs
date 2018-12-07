using System;
using ModernStore.Domain.Entities;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("jhonesgoncalves", "123456");
            var customer = new Customer("Jh", "G", "j", user);

            customer.User.Activate();

            if (!customer.IsValid())
            {
                foreach (var notification in customer.Notifications)
                {
                    Console.WriteLine(notification.Message);
                }
            }

            //Console.WriteLine(customer.ToString());
            Console.ReadKey();
        }
    }
}
