using Microsoft.Extensions.Logging;
using SpaceStationSim.Core.Domain;
using SpaceStationSim.Core.Simulation;
using SpaceStationSim.Core.Systems;

namespace SpaceStationSim.App {
    internal class Program {
        static async Task Main(string[] args) {

            //logfactory to create loggers and writing to the console
            using ILoggerFactory factory = LoggerFactory.Create(builder =>
                builder.AddConsole()
            );
            ILogger logger = factory.CreateLogger<Program>();
            logger.LogInformation("Logger starting up");


            SimulationKernel kernel = new SimulationKernel();

            StationState state = new StationState();

            var powerSystemLogger = factory.CreateLogger<PowerSystem>();
            kernel.RegisterSystem(new PowerSystem(powerSystemLogger));

            // Running the simulation
            SimulationRunner runner = new SimulationRunner(kernel, state);


            //Making the clr c cancelation event to send cancelationtoken
            using var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };
            await runner.RunSimulation(cts.Token);


        }
    }
}
