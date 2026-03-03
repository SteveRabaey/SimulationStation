using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationSim.Core.Domain {
    public class PowerGenerator {
        public double CurrentOutputPerSecond { get; private set; }
        public double MaxOutputPerSecond = 5;
        public GeneratorStatus Status { get; set; }


        public PowerGenerator()
        {
            CurrentOutputPerSecond = 3.5;
        }
        
    }
    public enum GeneratorStatus {
        running,
        stopped,
    }
}
