using System.Diagnostics;

namespace _12Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> user = new List<User>
            {
                new User("123", "Екатерина", true)  { },
                new User("132", "Дмитрий", false) { }
            };
            Enter(user);
        }
        
        static void Enter(List<User> user)
        {
            Exception exception = new Exception("Не найден пользователь");
            Console.WriteLine("Введите логин!");
            try
            {
                string enter;
                enter = Console.ReadLine();
                bool flag = true;
                foreach (var item in user)
                {
                    if (enter == item.Login)
                    {
                        flag = true;
                        break;
                    }
                    else
                        flag = false;
                }
                if (flag == true)
                {
                    foreach (var item in user)
                    {
                        if (enter == item.Login)
                        {
                            if (item.IsPremium == false)
                            {
                                Console.WriteLine("{0}, здравствуйте!", item.Name);
                                Console.WriteLine("У Вас нет премиум подписки, посмотрите рекламу");
                                ShowAds();
                            }
                            else if (item.IsPremium == true)
                            {
                                Console.WriteLine("{0}, здравствуйте!", item.Name);
                                Console.WriteLine("У вас премиум подписка, реклама отключена");
                            }
                        }
                    }
                }
                else
                {
                    throw exception;
                }
            }
            catch (Exception e) when (e == exception)
            {
                CheckUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CheckUser(List<User> user)
        {
            Console.WriteLine("Такого пользователя нет. Для тестирования программы выберите:" +
                          " \n1.Список логинов для проверки программы \n2. Зарегестрироваться самому");
            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    {
                        Console.WriteLine("Список пользователей: ");
                        ShowLogin(user);
                        Enter(user);
                        break;
                    }
                case 2:
                    {
                        var Newuser = NewUser(user);
                        Console.WriteLine("Вот новый список пользователей:");
                        ShowLogin(Newuser);
                        Enter(Newuser);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
        
        static void ShowLogin(List<User> users)
        {
            int count = 1;
            foreach (var item in users)
            {
                Console.WriteLine(count + ". " + item.Login + " " + item.Name + " " + item.IsPremium);
                count++;
            }
        }
        
        static List<User> NewUser(List<User> users)
        {
            try
            {
                Console.WriteLine("Введите имя: ");
                string name = Console.ReadLine();
                if (name.Length == 0) throw new Exception("Null значение");

                Console.WriteLine("Введите логин: ");
                string login = Console.ReadLine();
                if (login.Length == 0) throw new Exception("Null значение");

                Console.WriteLine("Хотите премиум подписку? Для этого Вам надо оценить нашу программу на высший балл");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет");
                int answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        {
                            users.Add(new User(login, name, true));
                            return users;
                        }
                        case 2:
                        {
                            users.Add(new User(login, name, false));
                            return users;
                        }
                        default:
                        {
                            break;
                        }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Один из параметров имеет значение Null. Введите снова. \n" + ex.Message);
                NewUser(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                NewUser(users);
            }
            return users;
           
        }
    }
}