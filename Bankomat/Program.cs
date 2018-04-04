using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
using KKB.Bank.Module;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите логин:");
                string login = Console.ReadLine();
                Console.Write("Введите пароль:");
                string password = Console.ReadLine();
                if (login == "admin" && password == "admin")
                {
                    
                    Client client = new Client();
                    Service.createClient(ref client);
                    client.Login = "admin";
                    client.Password = "admin";
                    Console.Clear();
                    Console.Write("1) Список счетов\n2) Создать счёт");
                    int menu = 0;
                    Int32.TryParse(Console.ReadLine(), out menu);
                    if(menu > 2 || menu < 1)
                    {
                        throw new Exception("invalid choice");
                    }
                    else
                    {
                        switch (menu)
                        {
                            case 1: {
                                    client.PrintAccountInfo();
                                    } break;
                            case 2: { }break;
                        }
                    }
                }else
                {
                    throw new Exception("Invalid login or password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            List<Client> ListClient = new List<Client>();

            GeneratorName.Generator g= new Generator();

            Client c1 = new Client();

            c1.DoB = DateTime.Now.AddYears(-60);
            c1.FullName = g.GenerateDefault(Gender.man);
            c1.IIN = "970131301448";
            c1.Login = "Qwe";
            c1.Password = "123";
            c1.PhoneNumber = "87475458546";

            ListClient.Add(c1);

            c1.ClientInfoPrint();
        }
    }
}
