using Device.Net.LibUsb;
using Respeaker.Net.Exceptions;
using System;

namespace Respeaker.Net.Hardware
{
    // todo: defaults checken
    public class OnBoardConfiguration
    {
        public int AECFREEZEONOFF { get => Read<int>(18, 7, 1); set => Write(18, 7, 1, 1, 0, value, nameof(AECFREEZEONOFF)); }
        public float AECNORM { get => Read<float>(18, 19, 0); set => Write(18, 19, 0, 16, 0.25, value, nameof(AECNORM)); }
        public int AECPATHCHANGE { get => Read<int>(18, 25, 1); }
        public float AECSILENCELEVEL { get => Read<float>(18, 30, 1); set => Write(18, 30, 1, 1, 1e-09, value, nameof(AECNORM)); }
        public int AECSILENCEMODE { get => Read<int>(18, 31, 1); }
        public float AGCDESIREDLEVEL { get; set; }
        public float AGCGAIN { get; set; }
        public float AGCMAXGAIN { get; set; }
        public int AGCONOFF { get; set; }
        public float AGCTIME { get; set; }
        public int CNIONOFF { get; set; }
        public int DOAANGLE { get; }
        public int ECHOONOFF { get; set; }
        public int FREEZEONOFF { get; set; }
        public int FSBPATHCHANGE { get; }
        public int FSBUPDATED { get; }
        public float GAMMAVAD_SR { get; set; }
        public float GAMMA_E { get; set; }
        public float GAMMA_ENL { get; set; }
        public float GAMMA_ETAIL { get; set; }
        public float GAMMA_NN { get; set; }
        public float GAMMA_NN_SR { get; set; }
        public float GAMMA_NS { get; set; }
        public float GAMMA_NS_SR { get; set; }
        public int HPFONOFF { get; set; }
        public float MIN_NN { get; set; }
        public float MIN_NN_SR { get; set; }
        public float MIN_NS { get; set; }
        public float MIN_NS_SR { get; set; }
        public int NLAEC_MODE { get; set; }
        public int NLATTENONOFF { get; set; }
        public int NONSTATNOISEONOFF { get; set; }
        public int NONSTATNOISEONOFF_SR { get; set; }
        public float RT60 { get; }
        public int RT60ONOFF { get; set; }
        public int SPEECHDETECTED { get; }
        public int STATNOISEONOFF { get; set; }
        public int STATNOISEONOFF_SR { get; set; }
        public int TRANSIENTONOFF { get; set; }
        public int VOICEACTIVITY { get; }

        readonly LibUsbDevice _usbDevice;

        public OnBoardConfiguration(LibUsbDevice usbDevice)
        {
            _usbDevice = usbDevice;
        }

        void Write<T>(int id, int offset, int type, T max, T min, T value, string parameter) where T : IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new RespeakerArgumentOutOfRangeException(ExceptionMessages.HardwareExceptionMessages.ParameterOutOfRange.Replace("{VALUE}", value.ToString()).Replace("{MIN}", min.ToString()).Replace("{MAX}", max.ToString()).Replace("{NAME}", parameter));

            var data = new byte[]
            {
                (byte)offset,
                Convert.ToByte(value),
                (byte)type
            };

            UsbControl.WriteControlTransfer(id, data, _usbDevice);
        }

        T Read<T>(int id, int offset, int type) where T : IComparable
        {
            throw new NotImplementedException();
        }
    }
}
