using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationSim.Core.Domain {
    /// <summary>
    /// The battery class is for helping manage the power storage. Adding where the powergenerator needs helpt.
    /// </summary>
    public class Battery {
        private double _currentChargeLevel; // Current charge level of the battery
        private double _maxChargeLevel; // Maximum charge level of the battery


        private void Charge(double amount) {
            _currentChargeLevel = Math.Min(_currentChargeLevel + amount, _maxChargeLevel);
        }

    }
}
