namespace worker;
using Linux.Bluetooth;
using Linux.Bluetooth.Extensions;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var adapter = (await BlueZManager.GetAdaptersAsync()).First();

        while (!stoppingToken.IsCancellationRequested)
        {
            
            int newDevices = 0;
            using (await adapter.WatchDevicesAddedAsync(async device =>
            {
                newDevices++;
                // Write a message when we detect new devices during the scan.
                string deviceDescription = await GetDeviceDescriptionAsync(device);
                 _logger.LogInformation("[NEW] {deviceDescription}", deviceDescription);
            }))
            {
                await adapter.StartDiscoveryAsync();
                await Task.Delay(TimeSpan.FromSeconds(5));
                await adapter.StopDiscoveryAsync();
            }
        }
    }

    private static async Task<string> GetDeviceDescriptionAsync(IDevice1 device)
    {
      var deviceProperties = await device.GetAllAsync();
      return $"{deviceProperties.Alias} (Address: {deviceProperties.Address}, RSSI: {deviceProperties.RSSI})";
    }
}
