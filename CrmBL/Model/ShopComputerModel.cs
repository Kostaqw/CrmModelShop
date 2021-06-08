using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Random rnd = new Random();
        bool isWorking = false;
        Generator Generator = new Generator();
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();

        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;
        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSeller(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }
            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            isWorking = true;

            Task.Run(()=> CreateCarts(10, CustomerSpeed));

            var cashDeskTaksks = CashDesks.Select(c => new Task(() => CashDeskWork(c, CashDeskSpeed)));
            foreach (var task in cashDeskTaksks)
            {
                task.Start();
            }


        }

        private void CashDeskWork(CashDesk cashDesk, int sleep)
        {
            if (isWorking)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(sleep);
                }
            }
        }

        private void CreateCarts(int customerCount, int sleep)
        {
            while (isWorking)
            {
                var customers = Generator.GetNewCustomers(customerCount);
               

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach (var product in Generator.GetRandomProduct(10,30))
                    {
                        cart.Add(product);
                    }

                    var cash = CashDesks[rnd.Next(CashDesks.Count)];

                    cash.Enqueue(cart);
                }
                Thread.Sleep(sleep);
            }
        }

        public void Stop()
        {
            isWorking = false;
        }


    }
}
