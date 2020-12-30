namespace Respeaker.Net.Exceptions
{
    static class ExceptionMessages
    {
        public const string UnknownDevice = "The Device {NAME} is unknown";
        public const string DeviceNotFound = "Can not find USB Device {NAME}. Ensure it is attached and working properly.";
        public const string UnableToReadConfigParameter = "Unable to read Configuration Parameter from device";
        public const string UnableToWriteConfigParameter = "Unable to write Configuration Parameter to device";
        public const string ControlTransferFailed = "Control Transfer failed - {MESSAGE} - Request: {REQUEST} Command: {COMMAND} Payload: {PAYLOAD}";
        public const string ParameterOutOfRange = "Parameter {NAME} is out of Range. Value: {VALUE} Min: {MIN} Max: {MAX}";
    }
}
