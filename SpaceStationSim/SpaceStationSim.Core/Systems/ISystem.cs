using System;
using System.Collections.Generic;
using System.Text;
using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Simulation;

namespace SpaceStationSim.Core.Systems {
    public interface ISystem {
        void Update(StationState state, SimTime time);
    }
}
