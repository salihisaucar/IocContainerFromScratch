using Ioc.Container.Abstract;
using Ioc.Container.Concrete;
using System;


namespace Example.Ioc.Container
{
    interface ICustomer
    {
        void WriteCustomerName();
    }
    class Customer : ICustomer
    {
        private string _customerName = "Salih Isa UCAR";
        public void WriteCustomerName()
        {
            Console.WriteLine($"Customer Name is  {_customerName}");
        }
    }

    interface IPerson
    {
        void WritePersonName();
    }
    class Person : IPerson
    {
        private string _personName = "Salih Isa UCAR";
        public void WritePersonName()
        {
            Console.WriteLine($"Person Name is  {_personName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new IoCContainer();

            container.Apply<ICustomer>().For<Customer>();
            container.Apply<IPerson>().For<Person>();

            container.Build();

            var customer= container.Resolve<ICustomer>();

            var person= container.Resolve<IPerson>();

            person.WritePersonName();

            customer.WriteCustomerName();


        }
    }
}
