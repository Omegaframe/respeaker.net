namespace Respeaker.Net.Devices
{
    public class DeviceDescription
    {
        internal int VendorId { get; set; }
        internal int ProductId { get; set; }
        internal string AlsaDeviceName { get; set; }
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }

        internal static DeviceDescription[] Known => new[]
        {
            new DeviceDescription
            {
                DeviceType = DeviceType.UsbMicArrayV2,
                Name = "UsbMicArrayV2",
                ProductId = 0x0018,
                VendorId = 0x2886,
                AlsaDeviceName = "ArrayUAC10"
            }
        };

        public override string ToString() => $"{Name} - vId: {VendorId} pId: {ProductId} alsa: {AlsaDeviceName}";
    }

    public enum DeviceType
    {
        UsbMicArrayV2
    }
}
