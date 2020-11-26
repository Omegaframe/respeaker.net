namespace Respeaker.Net.Exceptions
{
    static class ExceptionMessages
    {
        public const string ControlTransferFailed = "Control Transfer failed - {MESSAGE} - Request: {REQUEST} Command: {COMMAND} Payload: {PAYLOAD}";
        public const string ParameterOutOfRange = "Parameter {NAME} is out of Range. Value: {VALUE} Min: {MIN} Max: {MAX}";
    }
}
