using System;
using System.Collections.Generic;
using System.Text;
using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Systems;

namespace SpaceStationSim.Core.Simulation {
    public class SimulationKernel
    {
        private readonly List<ISystem> systems = new List<ISystem>();
        public void RegisterSystem(ISystem system)
        {
            systems.Add(system);
        }
        public void Step(StationState state, long tick, TimeSpan delta, TimeSpan total)
        {
            var time = new SimTime(tick, delta, total);
            foreach (var system in systems)
            {
                system.Update(state, time);
            }
        }

    }
}
