using Nagarro.GrandCircus.Presentation;
using System.Collections.Generic;

namespace Nagarro.GrandCircus.CircusModel
{
    internal class Circus
    {
        private readonly List<AnimalBase> animals;
        private readonly Arena arena;
        public Circus(Arena arena)
        {
            this.arena = arena;
            animals = new List<AnimalBase>()
            {
                new Elephant("Ele"),
                new Snake("Kay"),
                new Lion("Lily")
            };
        }

        public void Perform()
        {
            arena.PresentCircus(" ~~~ Circus Room 305 ~~~ ");
            foreach (var animal in animals)
            {
                arena.AnnounceAnimal(animal.Name, animal.SpeciesName);
                arena.DisplayAnimalPerformance(animal.MakeSound());
            }  
        }
    }
}