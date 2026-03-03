using System;
using System.Collections.Generic;
using System.Text;
using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Simulation;

namespace SpaceStationSim.Core.Systems {
    public class PowerSystem : ISystem {
      
        public void Update(StationState state, SimTime time)
        {
            double dt = time.Delta.TotalSeconds;
            double output = state.PowerGenerator.CurrentOutputPerSecond * dt;
            double consumption = state.Shield.RequiredPowerPerSecond * dt;
            
            double net = output - consumption;

            if (net < 0)
            {
                state.Battery.DeCharge(-net);
            }
            else
            {
                state.Battery.Charge(net);
            }
        }
    }
}
