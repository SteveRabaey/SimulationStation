using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Simulation;

namespace SpaceStationSim.Core.Systems {
    public class PowerSystem : ISystem {
        private readonly ILogger<PowerSystem> _logger;
        private StationState _state { get; }
        private bool _logged30 = false;
        private bool _logged10 = false;

        public PowerSystem(ILogger<PowerSystem> logger, StationState stationState) {
            _logger = logger;
            _state = stationState;
           
            _state.Battery.OnLowCharge += HandleLowCharge;
            _state.Battery.OnCriticalCharge += HandleCriticalCharge;
        }

        public void Update(StationState state, SimTime time)
        {
            double dt = time.Delta.TotalSeconds;
            double output = state.PowerGenerator.CurrentOutputPerSecond * dt;
            double consumption = state.Shield.RequiredPowerPerSecond * dt;
            
            double net = output - consumption;

            if (net < 0)
            {
                state.Battery.DeCharge(-net);
              

            } else
            {
                state.Battery.Charge(net);
                if (_logged30 == true) _logger.Log(LogLevel.Information, "BatteryLevels are back above 30");
            }
        }

        private void HandleLowCharge() {

            if (_state.Battery.CurrentChargeLevel > 10 && _logged30 == false) {
                _logger.Log(LogLevel.Warning, "Warining: Battery levels are under 30%");
                _logged30 = true;
                _logged10 = false;
            }
            
        }
        private void HandleCriticalCharge() {
            if (_logged10 == false) {
                _logger.Log(LogLevel.Critical, "Critical: Battery levels are under 10%");
                _logged10 = true;
            }
        }
            
        
    }
}
