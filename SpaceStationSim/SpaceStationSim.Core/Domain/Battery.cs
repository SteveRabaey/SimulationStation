using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SpaceStationSim.Core.Domain {
    /// <summary>
    /// The battery class is for helping manage the power storage. Adding where the powergenerator needs help.
    /// </summary>
    public class Battery {
        public double CurrentChargeLevel { get; private set; } // Current charge level of the battery
        public static readonly double MaxChargeLevel = 100; // Maximum charge level of the battery
        public static readonly double MinChargeLevel = 0;

        //events
        public event Action? OnLowCharge;
        public event Action? OnCriticalCharge;
        public Battery(double currentChargeLevel)
        {
            SetCurrentCharge(currentChargeLevel);
        }

        private void SetCurrentCharge(double currentChargeLevel)
        {
            if (currentChargeLevel > MaxChargeLevel) throw new  ArgumentOutOfRangeException($"Charge level {currentChargeLevel} is too Heigh");
            if(currentChargeLevel < MinChargeLevel) throw new ArgumentOutOfRangeException($"Charge level {currentChargeLevel} is too Low");
            CurrentChargeLevel = currentChargeLevel;
        }
        public void Charge(double amount) {
            CurrentChargeLevel = Math.Min(CurrentChargeLevel + amount, MaxChargeLevel);
        }

        public double DeCharge(double amount)
        {
            var provided = Math.Min(amount , CurrentChargeLevel);
            CurrentChargeLevel -= provided;

            if(CurrentChargeLevel < 30 && CurrentChargeLevel > 10) {
                OnLowCharge?.Invoke();
            }
            if (CurrentChargeLevel < 10) {
                OnCriticalCharge?.Invoke();
            }

            return provided;
        }

    }
}
