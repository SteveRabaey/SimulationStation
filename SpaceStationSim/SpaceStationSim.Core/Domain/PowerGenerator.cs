using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationSim.Core.Domain {
    public class PowerGenerator {
        private double _currentOutput;
        private double _maxOutput;
        private GeneratorStatus _status;
    }
    public enum GeneratorStatus {
        running,
        stopped,
    }
}
