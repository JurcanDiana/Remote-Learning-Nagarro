namespace Nagarro.GrandCircus.CircusModel
{
    internal class Lion : AnimalBase
    {
        public override string SpeciesName { get; } = "lion";
        public Lion(string name) : base(name)
        {
            this.Name = name;
        }

        public override string MakeSound()
        {
            return "roOOoar";
        }
    }
}
