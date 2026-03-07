using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationSim.Core.Domain {
    public class Shield {
        public bool ShieldEnabled { get; private set; }
        public double CurrentStrength { get; private set; }
        public  double  RequiredPowerPerSecond { get; private set; }

        public Shield()
        {
            ShieldEnabled = true;
            CurrentStrength = 100;
            RequiredPowerPerSecond = 8;
        }


    }
}
