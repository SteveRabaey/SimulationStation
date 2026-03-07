using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Simulation;
using SpaceStationSim.Core.Systems;

namespace SpaceStationSim.App;

public class SimulationRunner
{
    public SimulationRunner(SimulationKernel kernel, StationState state) {
        Kernel = kernel;
        State = state;
    }

    public SimulationKernel Kernel { get; private set; }
    public StationState State { get; private set; }
   

    public async Task RunSimulation(CancellationToken ct){
        long tick = 0;
        TimeSpan delta = TimeSpan.FromSeconds(0.1);
        TimeSpan total = TimeSpan.FromSeconds(0);

        TimeSpan logTimer = TimeSpan.Zero;


        while (!ct.IsCancellationRequested) {
            Kernel.Step(State, tick, delta, total);
            tick += delta.Ticks;
            total += delta;

            logTimer += delta;

            if (logTimer >= TimeSpan.FromSeconds(1)) {
                Console.Clear();
                Console.WriteLine("Battery: " + State.Battery.CurrentChargeLevel);
                Console.WriteLine("ShieldStatus: " + State.Shield.ShieldEnabled);
                Console.WriteLine("Seconden in simulation: " + total.TotalSeconds);
                logTimer = TimeSpan.Zero;
            }
            await Task.Delay(delta, ct);

        }
    }
}