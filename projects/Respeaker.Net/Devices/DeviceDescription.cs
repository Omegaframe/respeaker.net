namespace Respeaker.Net.Devices;

/// <summary>device description contains vendor and device type information required to talk to the device</summary>
public class DeviceDescription
{
    internal int VendorId { get; set; }
    internal int ProductId { get; set; }
    internal string AlsaDeviceName { get; set; }

    /// <summary>name of the device</summary>
    public string Name { get; set; }

    /// <summary>specific type of the device</summary>
    /// <see cref="DeviceType"/>
    public DeviceType DeviceType { get; set; }

    internal DeviceDescription(int vendorId, int productId, string alsaDeviceName, string name, DeviceType deviceType)
    {
        VendorId = vendorId;
        ProductId = productId;
        AlsaDeviceName = alsaDeviceName;
        Name = name;
        DeviceType = deviceType;
    }

    internal static DeviceDescription[] Known =>
    [
        new(0x2886,0x0018,  "ArrayUAC10",  "UsbMicArrayV2", DeviceType.UsbMicArrayV2)
    ];

    /// <inheritdoc cref="ToString"/>
    public override string ToString() => $"{Name} - vId: {VendorId} pId: {ProductId} alsa: {AlsaDeviceName}";
}

/// <summary>specific type of the device</summary>
public enum DeviceType
{
    /// <summary>ReSpeaker Mic Array v2.0 - https://wiki.seeedstudio.com/ReSpeaker_Mic_Array_v2.0/</summary>
    UsbMicArrayV2
}