namespace SpaceStationSim.Core.Simulation;

 public readonly record struct SimTime(long Tick,TimeSpan Delta,TimeSpan Total);
