namespace Nagarro.GrandCircus.CircusModel
{
    internal abstract class AnimalBase
    {
        public string Name { get; set; }
        public abstract string SpeciesName { get; }

        public AnimalBase(string name)
        {
            this.Name = name;
        }

        public abstract string MakeSound();
    }
}
