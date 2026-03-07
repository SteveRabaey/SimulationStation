using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Simulation;
using SpaceStationSim.Core.Systems;

namespace SpaceStationSim.App {
    internal class Program {
        static async Task Main(string[] args) {

            var services = new ServiceCollection();

            services.AddLogging(builder => {
                builder.AddConsole();
            });

            services.AddSingleton<PowerSystem>();
            services.AddSingleton<SimulationKernel>();
            services.AddSingleton<StationState>();
            services.AddSingleton<SimulationRunner>();

            var serviceProvidor = services.BuildServiceProvider();

            var logger = serviceProvidor.GetRequiredService<ILogger<Program>>();
            logger.Log(LogLevel.Information, "Logging starts :)");

            var kernelServies = serviceProvidor.GetRequiredService<SimulationKernel>();
            var powerSystem = serviceProvidor.GetRequiredService<PowerSystem>();
            kernelServies.RegisterSystem(powerSystem);

           

            // Running the simulation
            var  runner = serviceProvidor.GetRequiredService<SimulationRunner>();


            //Making the clr c cancelation event to send cancelationtoken
            using var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };
            await runner.RunSimulation(cts.Token);


        }
    }
}
