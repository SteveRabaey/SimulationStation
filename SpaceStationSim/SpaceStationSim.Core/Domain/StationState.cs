using System;
using System.Collections.Generic;
using System.Text;
//StationState  Is responsible for maintaining the current state of the space station, inlucding everything
namespace SpaceStationSim.Core.Domain {
    public class StationState {

        public Battery Battery { get;  }
        public PowerGenerator PowerGenerator { get; }
        public Shield Shield { get; }

        public StationState()
        {
            Battery = new Battery(60);
            PowerGenerator = new PowerGenerator();
            Shield = new Shield();
        }

    }
}
