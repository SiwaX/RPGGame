namespace RPGGame
{
    abstract class Hero : Unit
    {
        int _mana;
        public Hero(int hp, int damage, string nick, int mana) : base(hp, damage, nick)
        {
            nick = null;
            _mana = mana;
        }

        public int Mana
        {
            get
            {
                return _mana;
            }
            set
            {
                _mana = value;
            }
        }

        abstract public void Hit(Unit u);
        abstract public void Hit(Unit[] u);


        abstract public void Skill(Unit[] u, Skills sk);

        abstract public void HeroStats();
        abstract public void levelUp();

    }

    //Воин, Хантер , Визард, Юниты, Враги , Арена, боссы.

}
