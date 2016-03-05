namespace Assets.Scripts.Utilities.Mana
{
    class BaseMana
    {
        protected float MaxMana { private set; get; }
        public float CurrentMana { private set; get; }

        public delegate void onEndedMana();
        public event onEndedMana eventEndedMana;

        public BaseMana(float MaxMana)
        {
            this.MaxMana = MaxMana;
            CurrentMana = MaxMana;
        }

        public void Reduce(float count)
        {
            CurrentMana -= count;
            if (CurrentMana <= 0)
            {
                CurrentMana = 0;
                if (eventEndedMana != null)
                    eventEndedMana();
            }
        }

        public void Increase(float count)
        {
            CurrentMana += count;
            if (CurrentMana > MaxMana)
                CurrentMana = MaxMana;
        }
    }
}
