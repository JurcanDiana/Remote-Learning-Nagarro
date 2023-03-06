namespace Nagarro.GrandCircus.CircusModel
{
    internal class Elephant : AnimalBase
    {
        public override string SpeciesName { get; } = "elephant";
        public Elephant(string name) : base(name)
        {
            this.Name = name; 
        }

        public override string MakeSound()
        {
            return "pfffffuuuuhhhhh";
        }
    }
}
