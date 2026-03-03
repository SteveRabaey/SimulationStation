using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Simulation;
using SpaceStationSim.Core.Systems;

namespace SpaceStationSim.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimulationKernel kernel = new SimulationKernel();
            
            kernel.RegisterSystem(new PowerSystem());
            StationState state = new StationState();
            
            long tick = 0;
            TimeSpan delta = TimeSpan.FromSeconds(0.1);
            TimeSpan total = TimeSpan.FromSeconds(0);
            
            TimeSpan logTimer = TimeSpan.Zero;

            while (true)
            {
                kernel.Step(state, tick, delta, total);
                tick += delta.Ticks;
                total += delta;
                
                logTimer += delta;

                if (logTimer >= TimeSpan.FromSeconds(1))
                {
                    Console.WriteLine(state.Battery.CurrentChargeLevel);
                    logTimer = TimeSpan.Zero;
                }
                Thread.Sleep(delta);

            }
        }
    }
}
