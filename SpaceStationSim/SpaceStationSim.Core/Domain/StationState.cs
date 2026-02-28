using System;
using System.Collections.Generic;
using System.Text;
//StationState  Is responsible for maintaining the current state of the space station, inlucding everything
namespace SpaceStationSim.Core.Domain {
    public class StationState {

        public required Battery Battery { get; set; }
        public required PowerGenerator PowerGenerator { get; set; }
        public required Shield Shield { get; set; }



    }
}
