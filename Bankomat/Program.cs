using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GeneratorName;
using KKB.Bank.Module;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "";
            string password = "";

            try
            {
                Client client = new Client();
                Service.createClient(ref client);
                client.Login = "admin";
                client.Password = "admin";

                while (!client.isBlocked)
                {
                    #region

                    Console.Clear();
                    Console.Write("введите логин:");
                    login = Console.ReadLine();
                    Console.Write("введите пароль:");
                    password = Console.ReadLine();

                    if (login != client.Login && password != client.Password)
                    {
                        client.WrongField--;
                        Console.WriteLine("Некорректный введены данные. Осталось {0} попыток", client.WrongField);
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }
                    #endregion
                }

                if (login == client.Login && password == client.Password)
                {
                    #region
                    if (client.isBlocked)
                    {
                        Console.WriteLine("Пользователь заблокирован!");
                    }
                    else
                    {
                        #region 
                        do
                        {
                            Console.Clear();

                            Console.WriteLine("1) Список счетов");
                            Console.WriteLine("2) Создать счет");
                            Console.WriteLine("3) Пополнить счёт");
                            Console.WriteLine("4) Снять деньги со счёта");

                            Console.WriteLine("6) Выход");


                            int menu = 0;
                            Int32.TryParse(Console.ReadLine(), out menu);
                            if (menu > 6 || menu < 1)
                            {
                                throw new Exception("invalid choice");
                            }
                            else
                            {
                                switch (menu)
                                {
                                    //Список счетов
                                    case 1:
                                        {
                                            client.PrintAccountInfo();
                                            Console.WriteLine("\n---------------------------------------------\n");
                                            int choice = 0;
                                            Console.WriteLine("Введите любое число для возврата в меню, либо 0 для выхода");
                                            Int32.TryParse(Console.ReadLine(), out choice);
                                            if (choice == 0)
                                                return;
                                            else
                                                break;
                                        }
                                        break;
                                    //Создать счет
                                    case 2:
                                        {
                                            try
                                            {
                                                Account acc = Service.createAccount();
                                                client.ListAccount.Add(acc);
                                                Console.WriteLine("\nСчёт успешно добавлен!");
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            Console.WriteLine("\n---------------------------------------------\n");
                                            int choice = 0;
                                            Console.WriteLine("Введите любое число для возврата в меню, либо 0 для выхода");
                                            Int32.TryParse(Console.ReadLine(), out choice);
                                            if (choice == 0)
                                                return;
                                            else
                                                break;
                                        }
                                        break;
                                    case 3:
                                        {
                                            Console.WriteLine("Введите номер счёта: ");
                                            string accountNumber = Console.ReadLine();
                                            Console.WriteLine("Введите сумму ");
                                            string acconutSum = Console.ReadLine();
                                            try
                                            {
                                                foreach (var item in client.ListAccount)
                                                {
                                                    if (item.AccountNumber == accountNumber)
                                                    {
                                                        item.Balance += double.Parse(acconutSum);
                                                        Console.WriteLine("\nСчёт {0} успешно пополнен на сумму {1}", accountNumber, acconutSum);
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            Console.WriteLine("\n---------------------------------------------\n");
                                            int choice = 0;
                                            Console.WriteLine("Введите любое число для возврата в меню, либо 0 для выхода");
                                            Int32.TryParse(Console.ReadLine(), out choice);
                                            if (choice == 0)
                                                return;
                                            else
                                                break;
                                        }
                                        break;
                                    case 4:
                                        {
                                            Console.WriteLine("Введите номер счёта: ");
                                            string accountNumber = Console.ReadLine();
                                            Console.WriteLine("Введите сумму ");
                                            string acconutSum = Console.ReadLine();
                                            try
                                            {
                                                foreach (var item in client.ListAccount)
                                                {
                                                    if (item.AccountNumber == accountNumber)
                                                    {
                                                        if (double.Parse(acconutSum) > item.Balance)
                                                        {
                                                            Console.WriteLine("\nВведённая сумма превышает сумму счёта пользователя");
                                                        }
                                                        else
                                                        {
                                                            item.Balance -= double.Parse(acconutSum);
                                                            Console.WriteLine("\nСумма {0} успешно снята со счёта {1}", acconutSum, accountNumber);
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                            Console.WriteLine("\n---------------------------------------------\n");
                                            int choice = 0;
                                            Console.WriteLine("Введите любое число для возврата в меню, либо 0 для выхода");
                                            Int32.TryParse(Console.ReadLine(), out choice);
                                            if (choice == 0)
                                                return;
                                            else
                                                break;
                                        }
                                        break;
                                    case 6:
                                        return;
                                }

                            }
                        } while (true);

                        #endregion
                    }
                    #endregion
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("User blocked");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // List<Client> ListClient = new List<Client>();

            //GeneratorName.Generator g= new Generator();

            //Client c1 = new Client();

            //c1.DoB = DateTime.Now.AddYears(-60);
            //c1.FullName = g.GenerateDefault(Gender.man);
            //c1.IIN = "970131301448";
            //c1.Login = "Qwe";
            //c1.Password = "123";
            //c1.PhoneNumber = "87475458546";

            //ListClient.Add(c1);

            //c1.ClientInfoPrint();
        }
    }
}
