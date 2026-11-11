class RemoteControlCar
{
    private int _battery = 100;
    private int _distance;

    public static RemoteControlCar Buy()
        => new();

    public string DistanceDisplay()
        => $"Driven {_distance} meters";

    public string BatteryDisplay()
        => _battery == 0
            ? "Battery empty"
            : $"Battery at {_battery}%";

    public void Drive()
    {
        if (_battery == 0) return;

        _battery -= 1;
        _distance += 20;
    }
}
