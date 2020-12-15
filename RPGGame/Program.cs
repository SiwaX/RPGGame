using Microsoft.VisualBasic;
using System;


namespace RPGGame
{
    public enum Skills
    {
        файрболл,
        Землятресение,
        УдарнаяВолна,
        ВодянаСтрела,
        Бешенство,
        БросокКобры
    }

    class Program
    {
        static void Main(string[] args)
        {


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Привет странник!\nВыбери класс за который будешь играть!");
            Console.WriteLine($"Укажи цифру класса для выбора:\n1.Воин\n2.Маг\n3.Охотник");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Warrior w1 = new Warrior("----", 200, 25, 50);
                    Console.Clear();
                    Console.WriteLine("Введи имя персонажа.");
                    w1.Nick = Console.ReadLine();
                    Console.Clear();
                    w1.HeroStats();
                    Console.ReadLine();
                A:
                    Console.WriteLine("Молодец, ты сделал свой выбор!\n А теперь пора отправиться в путеществие!\nВыбирай куда отправимся:\n1.На поиск монстров\n2.На геройскую Арену\n3.Путешествие по миру");
                    int choise2 = int.Parse(Console.ReadLine());
                    switch (choise2)
                    {
                        case 1:
                            Console.Clear();
                            Enemy e1 = new Enemy(100, 11, "Истеричка");
                            Console.WriteLine("Охх, кажется мы забрели в УКСИфТ\nНам надо скорее бежать, пока не поздно\nО нет, нас заметила Истеричка!\n Цель: убить эту тварь!");
                            w1.Hit(e1);
                            Console.WriteLine($"Вы отомстили за всех нас, о наконец-то мы не услышим её причитания, и мольбы к богу!Вы герой{w1.Nick}!");
                            w1.levelUp();
                            w1.HeroStats();
                            Console.ReadKey(true);
                            goto A;
                        case 2:
                            Console.Clear();
                            Console.Clear();
                            Console.WriteLine("Добро пожаловать на Арену!\nВыбери своего противника:\n1.Великий Оояз,\n2.Кашалот,\n3.Охранница");
                            int choise5 = int.Parse(Console.ReadLine());
                            if (choise5 == 1)
                            {

                                Wither ww = new Wither("Великий Оояз", 250, 30, 100);
                                Console.WriteLine($"Бой начался:{w1.Nick} vs {ww.Nick}");
                                Arena.HeroBattle(w1, ww);
                                if (w1.Hp > 0)
                                {
                                    w1.levelUp();
                                    w1.HeroStats();
                                }
                            }
                            else if (choise5 == 2)
                            {

                                Warrior wa = new Warrior("Кашалот", 400, 14, 10);
                                Console.WriteLine($"Бой начался:{w1.Nick} vs {wa.Nick}");

                                Arena.HeroBattle(w1, wa);
                                if (w1.Hp > 0)
                                {
                                    w1.levelUp();
                                    w1.HeroStats();
                                }
                            }
                            else if (choise == 3)
                            {
                                Hunter h1 = new Hunter("Охранница", 300, 30, 3000);
                                Console.WriteLine($"Бой начался:{w1.Nick} vs{h1.Nick}");

                                Arena.HeroBattle(w1, h1);
                                if (w1.Hp > 0)
                                {
                                    w1.levelUp();
                                    w1.HeroStats();
                                }
                            }
                            goto A;
                        case 3:
                            Console.Clear();
                            Enemy e11 = new Enemy(2000, 1, "ЕнемиТанк");
                            Enemy e22 = new Enemy(1000, 15, "ЕнемиНормал");
                            Enemy e33 = new Enemy(200, 12, "ЕнимиПросто");
                            Console.WriteLine("Во время ваших странствий вы встертили группу монстров!\nЦель выжить.");
                            Console.WriteLine($"Вы наткнулись на {e11.Nick},Здоровье {e11.Hp},Атака {e11.Damage}\nВы наткнулись на {e22.Nick},Здоровье {e22.Hp},Атака {e22.Damage}\nВы наткнулись на {e33.Nick},Здоровье {e33.Hp},Атака {e33.Damage}");
                            j:
                            Console.WriteLine($"Используйте скилл что бы сразить группу монстров\n1.{Skills.Землятресение}\n2.{Skills.УдарнаяВолна}");
                            Unit[] array = new Unit[] { e11, e22, e33 };
                            int choiseSkill = int.Parse(Console.ReadLine());
                            switch (choiseSkill)
                            {
                                case 1:
                                    w1.Skill(array, Skills.Землятресение);
                                    for (int i = 0; i < 1; i++)
                                    {
                                        if (array[i].Hp <= 0)
                                        {
                                            w1.levelUp();
                                        }
                                    }
                                    w1.HeroStats();
                                    goto case 3;
                                case 2:
                                    w1.Skill(array, Skills.УдарнаяВолна);
                                    for (int i = 0; i < 1; i++)
                                    {
                                        if (array[i].Hp <= 0)
                                        {
                                            w1.levelUp();
                                        }
                                    }
                                    w1.HeroStats();
                                    goto case 3;
                                case 3:
                                   
                                        Console.WriteLine("Желаете ли продожить использовать магию?\n1.Да\n2.НЕТ");
                                        int choise11 = int.Parse(Console.ReadLine());
                                        switch (choise11)
                                        {
                                            case 1:
                                            if (w1.Mana > 0)
                                            {
                                                goto j;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Недостаточно маны!");
                                                goto case 2;
                                            }
                                            case 2:
                                                Console.WriteLine("Сражайся до конца!");
                                                w1.Hit(array);
                                                if (w1.Hp > 0)
                                                {
                                                    Console.WriteLine("Победа");
                                                }
                                                else if (w1.Hp <= 0)
                                                {
                                                    Console.WriteLine("Попробуйте еще раз");
                                                }
                                                break;
                                        }
                                    break;
                                    
                            }

                            break;


                    }
                    break;
                case 2:
                    Wither w2 = new Wither("----", 200, 25, 50);
                    Console.Clear();
                    Console.WriteLine("Введи имя персонажа.");
                    w2.Nick = Console.ReadLine();
                    Console.Clear();
                    w2.HeroStats();
                    Console.ReadLine();
                s:
                    Console.WriteLine("Молодец, ты сделал свой выбор!\n А теперь пора отправиться в путеществие!\nВыбирай куда отправимся:\n1.На поиск монстров\n2.На геройскую Арену\n3.Путешествие по миру");
                    int choise3 = int.Parse(Console.ReadLine());
                    switch (choise3)
                    {
                        case 1:
                            Console.Clear();
                            Enemy e1 = new Enemy(100, 11, "Истеричка");
                            Console.WriteLine("Охх, кажется мы забрели в УКСИфТ\nНам надо скорее бежать, пока не поздно\nО нет, нас заметила Истеричка!\n Цель: убить эту тварь!");
                            w2.Hit(e1);
                            Console.WriteLine($"Вы отомстили за всех нас, о наконец-то мы не услышим её причитания, и мольбы к богу!Вы герой{w2.Nick}!");
                            w2.levelUp();
                            w2.HeroStats();
                            goto s;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Добро пожаловать на Арену!\nВыбери своего противника:\n1.Великий Оояз,\n2.Кашалот,\n3.Охранница");
                            int choise5 = int.Parse(Console.ReadLine());
                            if (choise5 == 1)
                            {

                                Wither ww = new Wither("Великий Оояз", 250, 30, 100);
                                Console.WriteLine($"Бой начался:{w2.Nick} vs {ww.Nick}");
                                Arena.HeroBattle(w2, ww);
                                if (w2.Hp > 0)
                                {
                                    w2.levelUp();
                                    w2.HeroStats();
                                }
                            }
                            else if (choise5 == 2)
                            {

                                Warrior wa = new Warrior("Кашалот", 400, 14, 10);
                                Console.WriteLine($"Бой начался:{w2.Nick} vs {wa.Nick}");

                                Arena.HeroBattle(w2, wa);
                                if (w2.Hp > 0)
                                {
                                    w2.levelUp();
                                    w2.HeroStats();
                                }
                            }
                            else if (choise == 3)
                            {
                                Hunter h1 = new Hunter("Охранница", 300, 30, 3000);
                                Console.WriteLine($"Бой начался:{w2.Nick} vs{h1.Nick}");

                                Arena.HeroBattle(w2, h1);
                                if (w2.Hp > 0)
                                {
                                    w2.levelUp();
                                    w2.HeroStats();
                                }
                            }

                            goto s;
                    }
                    break;
                case 3:
                    Hunter w3 = new Hunter("----", 200, 25, 50);
                    Console.Clear();
                    Console.WriteLine("Введи имя персонажа.");
                    Console.Clear();
                    w3.Nick = Console.ReadLine();
                    w3.HeroStats();
                    Console.ReadLine();


                    Console.WriteLine("Молодец, ты сделал свой выбор!\n А теперь пора отправиться в путеществие!\nВыбирай куда отправимся:\n1.На поиск монстров\n2.На геройскую Арену\n3.Путешествие по миру");
                M:
                    int choise4 = int.Parse(Console.ReadLine());
                    switch (choise4)
                    {
                        case 1:
                            Console.Clear();
                            Enemy e1 = new Enemy(100, 11, "Истеричка");
                            Console.WriteLine("Охх, кажется мы забрели в УКСИфТ\nНам надо скорее бежать, пока не поздно\nО нет, нас заметила Истеричка!\n Цель: убить эту тварь!");
                            w3.Hit(e1);
                            Console.WriteLine($"Вы отомстили за всех нас, о наконец-то мы не услышим её причитания, и мольбы к богу!Вы герой{w3.Nick}!");
                            w3.levelUp();
                            w3.HeroStats();
                            goto M;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Добро пожаловать на Арену!\nВыбери своего противника:\n1.Великий Оояз,\n2.Кашалот,\n3.Охранница");
                            int choise5 = int.Parse(Console.ReadLine());
                            if (choise5 == 1)
                            {

                                Wither ww = new Wither("Великий Оояз", 250, 30, 100);
                                Console.WriteLine($"Бой начался:{w3.Nick} vs {ww.Nick}");
                                Arena.HeroBattle(w3, ww);
                                if (w3.Hp > 0)
                                {
                                    w3.levelUp();
                                    w3.HeroStats();
                                }
                            }
                            else if (choise5 == 2)
                            {

                                Warrior wa = new Warrior("Кашалот", 400, 14, 10);
                                Console.WriteLine($"Бой начался:{w3.Nick} vs {wa.Nick}");

                                Arena.HeroBattle(w3, wa);
                                if (w3.Hp > 0)
                                {
                                    w3.levelUp();
                                    w3.HeroStats();
                                }
                            }
                            else if (choise == 3)
                            {
                                Hunter h1 = new Hunter("Охранница", 300, 30, 3000);
                                Console.WriteLine($"Бой начался:{w3.Nick} vs{h1.Nick}");


                                Arena.HeroBattle(w3, h1);
                                if (w3.Hp > 0)
                                {
                                    w3.levelUp();
                                    w3.HeroStats();
                                }
                            }

                            goto M;
                    }
                    break;
            }




        }
    }

    abstract class Unit
    {
        bool _alive;
        int _hp;
        int _level;
        int _damage;

        string _nick;

        public Unit(int hp, int damage, string nick)
        {
            _hp = hp;
            _damage = damage;
            _nick = nick;
            _alive = true;
            _level = 1;
        }
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }
        public bool Alive
        {
            get
            {
                return _alive;
            }
            set
            {
                _alive = value;
            }
        }

        public string Nick
        {
            get
            {
                return _nick;
            }
            set
            {

                _nick = value;
            }
        }
        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }


        public void Move()
        {
            Console.WriteLine($"{Nick} Бежит");
        }

    }
    class Enemy : Unit
    {

        public Enemy(int hp, int damage, string nick) : base(hp, damage, nick)
        {

        }


    }
    class Arena
    {
        public static void HeroBattle(Hero st1, Hero st2)
        {
            for (int i = 0; st1.Hp <= 0 || st2.Hp <= 0; i++)
            {
                st1.Hp -= st2.Damage;
                st2.Hp -= st1.Damage;
            }
            if (st1.Hp <= 0)
            {
                Console.WriteLine($"{st2.Nick} побеждает!");
            }
            else if (st2.Hp <= 0)
            {
                Console.WriteLine($"{st1.Nick} побеждает!");
            }


        }
    }

    //Воин, Хантер , Визард, Юниты, Враги , Арена, боссы.

}
