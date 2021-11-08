using System;

namespace Owoda
{
    class Program
    {
        static void Main(string[] args)
        {
            owoda ow = new owoda();
            ow.menu();
        }
    }

    class owoda
    {
        int[] generatedNumber = new int[100];
        string[] name = new string[100];
        int[] amount = new int[100];
        int commission;
        int count = 0;
        int[] sum = new int[100];

        public void menu()
        {
            Console.WriteLine("Choose an Option\n1: To Book Ticket\n2: To View Generated Amount");
            int ch = int.Parse(Console.ReadLine());

            if(ch==1)
            {
                book();
            }
            else if(ch==2)
            {
                AmountGenerate();
            }
            else
            {
                Console.WriteLine("Choice Unavailable, Choose from 1 - 2\n");
                menu();
            }
        }

        public void book()
        {
            Console.WriteLine("Enter your Name");
            name[count] = Console.ReadLine();
            Ticket();
            //Console.WriteLine(Ticket());
            generatedNumber[count] = 10000001 + count;

            Console.WriteLine("Booked Successful");
            Console.WriteLine("Receipts Generated");
            Console.WriteLine("Name: "+name[count] +"\nTicket No: "+generatedNumber[count] +"\ngenerated amount " +amount[count] + "\n");

            count = count + 1;
            menu();
        }

        public int Ticket()
        {
            amount[count] = 0;
            Console.WriteLine("Choose Ticket Type\n1:Daily\n2:Monthly");
            int type = int.Parse(Console.ReadLine());

            if(type == 1)
            {
                amount[count] = 570;
            }

            else if(type == 2)
            {
                amount[count] = 570 * 30 / 2;
            }
            else
            {
                Console.WriteLine("No such Ticket");
                menu();
            }
            return amount[count];
        }

        public void AmountGenerate()
        {
            for (int i = 0; i < count; i++)
            {
                commission = amount[i] * 65 / 100;
                int remitAmount = amount[i] - commission;
                Console.WriteLine("Ticket No: " + generatedNumber[i] + " Name: " + name[i] + " Amount: " + amount[i]);
                Console.WriteLine("Remit Ammount " + commission + "and Your Percentage is: " + remitAmount+"\n"); 
                
            }
            TotalSales();
        }
        public void TotalSales()
        {
            int sum = 0;
            Array.ForEach(amount, delegate (int i)
            {
                sum += i;
            });
            Console.WriteLine("The amount generated is  " + sum + " and your percentage is " + ( sum - commission) + "\n");
            menu();
        }
    }
}
