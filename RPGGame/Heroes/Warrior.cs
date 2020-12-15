using System;


namespace RPGGame
{
    class Warrior : Hero
    {
        public Warrior(string nick, int hp, int damage, int mana) : base(hp, damage, nick, mana)
        {

        }
        public override void levelUp()
        {
            Console.WriteLine("Поздровляем ваш уровень повышен!");
            Level++;
            Hp += 150;
            Damage += 45;
            Mana += 45;
        }
        public override void HeroStats()
        {
            Console.WriteLine($"Создан воин: {Nick}\nХарактеристики:Уровень{Level} Здоровье{Hp},Дамаге{Damage},Мана{Mana}\nСтатус: {Alive}");
        }

        public override void Skill(Unit[] u, Skills sk)
        {
            for (int i = 0; i < u.Length; i++)
            {


                if (u[i].Hp >= 0 && Mana >= 0)
                {
                    for (int j = 0; j < u.Length; j++)
                    {
                        switch (sk)
                        {
                            case Skills.УдарнаяВолна:
                                u[j].Hp -= 80;
                                Hp -= u[i].Damage;
                                Console.WriteLine($"{u[j].Nick} получил урон от {Skills.УдарнаяВолна} в размере 80.\nЗдровья осталось{u[j].Hp}");
                                break;
                            case Skills.Землятресение:
                                u[j].Hp -= 40;
                                Hp -= u[j].Damage;
                                Console.WriteLine($"{u[j].Nick} получил урон от {Skills.Землятресение} в размере 40.\nЗдровья осталось{u[j].Hp}");
                                break;
                        }

                    }
                }
                else if (Mana < 0)
                {
                    Console.WriteLine("Недостаточно маны:");
                }
                else if (u[i].Hp <= 0)
                {
                    Console.WriteLine($"МЕрт {u[i].Nick}");
                }
                if (sk == Skills.УдарнаяВолна)
                {
                    Mana -= 20;
                }
                else if (sk == Skills.Землятресение)
                {
                    Mana -= 10;
                }
                if (Hp <= 0)
                {
                    Console.WriteLine("Повышайте уровень в других локация");
                }
                else if (u[i].Hp <= 0)
                {

                    Console.WriteLine("С победой");

                }
            }

        }
        override public void Hit(Unit u)
        {


        M: for (int i = 0; i < 1; i++)
            {
                u.Hp -= Damage;
                Hp -= u.Damage;
                Console.WriteLine($"{Nick} vs {u.Nick}\nЗдоровье{Hp}               {u.Hp}");
                Console.ReadLine();
            }
            if (u.Hp > 0)
            {
                goto M;
            }
            else if (u.Hp <= 0)
            {
                u.Alive = false;
                Console.WriteLine($"{u.Nick} умер,Статус: {u.Alive}");
            }


        }
        public override void Hit(Unit[] u)
        {

        M: for (int j = 0; j < 3; j++)
            {


                for (int i = 0; u[j].Hp >= 0; i++)
                {
                    u[i].Hp -= Damage;
                    Hp -= u[i].Damage;
                    Damage += 10;
                    Console.WriteLine($"{Nick} vs {u[i].Nick}\nЗдоровье{Hp}               {u[i].Hp}");
                    Console.ReadLine();
                    if (u[i].Hp > 0)
                    {
                        goto M;
                    }
                    else if (u[i].Hp <= 0)
                    {
                        u[i].Alive = false;
                        Console.WriteLine($"{u[i].Nick} умер,Статус: {u[i].Alive}");
                    }
                }
            }
        }
    }

    //Воин, Хантер , Визард, Юниты, Враги , Арена, боссы.

}
