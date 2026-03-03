using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationSim.Core.Domain {
    public class Shield {
        public bool ShieldEnabled { get; set; }
        public double CurrentStrength { get; set; }
        public double RequiredPowerPerSecond = 3;

        public Shield()
        {
            ShieldEnabled = true;
            CurrentStrength = 100;
        }


    }
}
