using System;


namespace RPGGame
{
    class Wither : Hero
    {
        public Wither(string nick, int hp, int damage, int mana) : base(hp, damage, nick, mana)
        {
            mana = 145;

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
            Console.WriteLine($"Создан маг: {Nick}\n Характеристики:Уровень{Level}, Здоровье({Hp}),Дамаге{Damage},Мана{Mana}");
        }
        public override void Skill(Unit[] u, Skills sk)
        {
            for (int i = 0; Hp >= 0; i++)
            {


                if (u[i].Hp >= 0 && Mana >= 0)
                {
                    for (int j = 0; j < u.Length; j++)
                    {
                        switch (sk)
                        {
                            case Skills.ВодянаСтрела:
                                u[j].Hp -= 80;
                                Hp -= u[i].Damage;
                                Console.WriteLine($"{u[j].Nick} получил урон от {Skills.ВодянаСтрела} в размере 80.\nЗдровья осталось{u[j].Hp}");
                                break;
                            case Skills.файрболл:
                                u[j].Hp -= 40;
                                Hp -= u[i].Damage;
                                Console.WriteLine($"{u[j].Nick} получил урон от {Skills.файрболл} в размере 40.\nЗдровья осталось{u[j].Hp}");
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
                if (sk == Skills.ВодянаСтрела)
                {
                    Mana -= 20;
                }
                else if (sk == Skills.файрболл)
                {
                    Mana -= 10;
                }
                if (Hp <= 0)
                {
                    Console.WriteLine("Повышайте уровень в других локация");
                }
                else
                {
                    Console.WriteLine("ПОздровляю с победой!");
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
        M: for (int i = 0; i < 1; i++)
            {
                u[i].Hp -= Damage;
                Hp -= u[i].Damage;
                Console.WriteLine($"{Nick} vs {u[i].Nick}\nЗдоровье{Hp}               {u[i].Hp}");
                Console.ReadLine();
            }
            for (int i = 0; i < u.Length; i++)
            {
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

    //Воин, Хантер , Визард, Юниты, Враги , Арена, боссы.

}
