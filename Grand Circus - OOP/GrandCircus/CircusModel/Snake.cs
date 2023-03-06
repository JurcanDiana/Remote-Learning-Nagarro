namespace Nagarro.GrandCircus.CircusModel
{
    internal class Snake : AnimalBase
    {
        public override string SpeciesName { get; } = "snake";
        public Snake(string name) : base(name)
        {
            this.Name = name;
        }

        public override string MakeSound()
        {
            return "sssSSSSssss";
        }
    }
}
