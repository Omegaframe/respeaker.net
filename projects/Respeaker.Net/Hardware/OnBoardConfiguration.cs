using Device.Net.LibUsb;
using Respeaker.Net.Exceptions;
using System;

namespace Respeaker.Net.Hardware
{
    public class OnBoardConfiguration : IDisposable
    {
        public int AECFREEZEONOFF { get => Read<int>(18, 7, 1); set => Write(18, 7, 1, 1, 0, value, nameof(AECFREEZEONOFF)); }
        public float AECNORM { get => Read<float>(18, 19, 0); set => Write(18, 19, 0, 16, 0.25, value, nameof(AECNORM)); }
        public int AECPATHCHANGE => Read<int>(18, 25, 1);
        public float AECSILENCELEVEL { get => Read<float>(18, 30, 1); set => Write(18, 30, 0, 1, 1e-09, value, nameof(AECSILENCELEVEL)); }
        public int AECSILENCEMODE => Read<int>(18, 31, 1);
        public float AGCDESIREDLEVEL { get => Read<float>(19, 2, 0); set => Write(19, 2, 0, 0.99, 1e-08, value, nameof(AGCDESIREDLEVEL)); }
        public float AGCGAIN { get => Read<float>(19, 3, 0); set => Write(19, 3, 0, 1000, 1, value, nameof(AGCGAIN)); }
        public float AGCMAXGAIN { get => Read<float>(19, 1, 0); set => Write(19, 1, 0, 1000, 1, value, nameof(AGCMAXGAIN)); }
        public int AGCONOFF { get => Read<int>(19, 0, 1); set => Write(19, 0, 1, 1, 0, value, nameof(AGCONOFF)); }
        public float AGCTIME { get => Read<float>(19, 4, 0); set => Write(19, 4, 0, 1, 0.1, value, nameof(AGCTIME)); }
        public int CNIONOFF { get => Read<int>(19, 5, 1); set => Write(19, 5, 1, 1, 0, value, nameof(CNIONOFF)); }
        public int DOAANGLE => Read<int>(21, 0, 1);
        public int ECHOONOFF { get => Read<int>(19, 14, 1); set => Write(19, 14, 1, 1, 0, value, nameof(ECHOONOFF)); }
        public int FREEZEONOFF { get => Read<int>(19, 6, 1); set => Write(19, 6, 1, 1, 0, value, nameof(FREEZEONOFF)); }
        public int FSBPATHCHANGE => Read<int>(19, 24, 1);
        public int FSBUPDATED => Read<int>(19, 23, 1);
        public float GAMMAVAD_SR { get => Read<float>(19, 39, 0); set => Write(19, 39, 0, 1000, 0, value, nameof(GAMMAVAD_SR)); }
        public float GAMMA_E { get => Read<float>(19, 15, 0); set => Write(19, 15, 0, 3, 0, value, nameof(GAMMA_E)); }
        public float GAMMA_ENL { get => Read<float>(19, 17, 0); set => Write(19, 17, 0, 5, 0, value, nameof(GAMMA_ENL)); }
        public float GAMMA_ETAIL { get => Read<float>(19, 16, 0); set => Write(19, 16, 0, 3, 0, value, nameof(GAMMA_ETAIL)); }
        public float GAMMA_NN { get => Read<float>(19, 12, 0); set => Write(19, 12, 0, 3, 0, value, nameof(GAMMA_NN)); }
        public float GAMMA_NN_SR { get => Read<float>(19, 36, 0); set => Write(19, 36, 0, 3, 0, value, nameof(GAMMA_NN_SR)); }
        public float GAMMA_NS { get => Read<float>(19, 9, 0); set => Write(19, 9, 0, 3, 0, value, nameof(GAMMA_NS)); }
        public float GAMMA_NS_SR { get => Read<float>(19, 35, 0); set => Write(19, 35, 0, 3, 0, value, nameof(GAMMA_NS_SR)); }
        public int HPFONOFF { get => Read<int>(18, 27, 1); set => Write(18, 27, 1, 3, 0, value, nameof(HPFONOFF)); }
        public float MIN_NN { get => Read<float>(19, 13, 0); set => Write(19, 13, 0, 1, 0, value, nameof(MIN_NN)); }
        public float MIN_NN_SR { get => Read<float>(19, 38, 0); set => Write(19, 38, 0, 1, 0, value, nameof(MIN_NN_SR)); }
        public float MIN_NS { get => Read<float>(19, 10, 0); set => Write(19, 10, 0, 1, 0, value, nameof(MIN_NS)); }
        public float MIN_NS_SR { get => Read<float>(19, 37, 0); set => Write(19, 37, 0, 1, 0, value, nameof(MIN_NS_SR)); }
        public int NLAEC_MODE { get => Read<int>(19, 20, 1); set => Write(19, 20, 1, 2, 0, value, nameof(NLAEC_MODE)); }
        public int NLATTENONOFF { get => Read<int>(19, 18, 1); set => Write(19, 18, 1, 1, 0, value, nameof(NLATTENONOFF)); }
        public int NONSTATNOISEONOFF { get => Read<int>(19, 11, 1); set => Write(19, 11, 1, 1, 0, value, nameof(NONSTATNOISEONOFF)); }
        public int NONSTATNOISEONOFF_SR { get => Read<int>(19, 34, 1); set => Write(19, 34, 1, 1, 0, value, nameof(NONSTATNOISEONOFF_SR)); }
        public float RT60 => Read<float>(18, 26, 0);
        public int RT60ONOFF { get => Read<int>(18, 28, 1); set => Write(18, 28, 1, 1, 0, value, nameof(RT60ONOFF)); }
        public int SPEECHDETECTED { get => Read<int>(19, 22, 1); set => Write(19, 22, 1, 1, 0, value, nameof(SPEECHDETECTED)); }
        public int STATNOISEONOFF { get => Read<int>(19, 8, 1); set => Write(19, 8, 1, 1, 0, value, nameof(STATNOISEONOFF)); }
        public int STATNOISEONOFF_SR { get => Read<int>(19, 33, 1); set => Write(19, 33, 1, 1, 0, value, nameof(STATNOISEONOFF_SR)); }
        public int TRANSIENTONOFF { get => Read<int>(19, 29, 1); set => Write(19, 29, 1, 1, 0, value, nameof(TRANSIENTONOFF)); }
        public int VOICEACTIVITY => Read<int>(19, 32, 1);

        readonly LibUsbDevice _usbDevice;

        public OnBoardConfiguration(LibUsbDevice usbDevice)
        {
            _usbDevice = usbDevice;
        }

        void Write<T>(int id, int offset, int type, T max, T min, T value, string parameter) where T : IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new RespeakerArgumentOutOfRangeException(ExceptionMessages.ParameterOutOfRange.Replace("{VALUE}", value.ToString()).Replace("{MIN}", min.ToString()).Replace("{MAX}", max.ToString()).Replace("{NAME}", parameter));

            var data = new[]
            {
                (byte)offset,
                Convert.ToByte(value),
                (byte)type
            };

            UsbControl.WriteControlTransfer(id, data, _usbDevice);
        }

        T Read<T>(int id, int offset, int type) where T : IComparable
        {
            var cmd = 0x80 | offset;
            if (type == 0)
                cmd |= 0x40;

            var response = UsbControl.ReadControlTransfer(id, cmd, _usbDevice);

            return (T)Convert.ChangeType(response, typeof(T));
        }

        public override string ToString()
        {
            return $"{nameof(AECFREEZEONOFF)}: {AECFREEZEONOFF}\n" +
                   $"{nameof(AECNORM)}: {AECNORM}\n" +
                   $"{nameof(AECPATHCHANGE)}: {AECPATHCHANGE}\n" +
                   $"{nameof(AECSILENCELEVEL)}: {AECSILENCELEVEL}\n" +
                   $"{nameof(AECSILENCEMODE)}: {AECSILENCEMODE}\n" +
                   $"{nameof(AGCDESIREDLEVEL)}: {AGCDESIREDLEVEL}\n" +
                   $"{nameof(AGCGAIN)}: {AGCGAIN}\n" +
                   $"{nameof(AGCMAXGAIN)}: {AGCMAXGAIN}\n" +
                   $"{nameof(AGCONOFF)}: {AGCONOFF}\n" +
                   $"{nameof(AGCTIME)}: {AGCTIME}\n" +
                   $"{nameof(CNIONOFF)}: {CNIONOFF}\n" +
                   $"{nameof(DOAANGLE)}: {DOAANGLE}\n" +
                   $"{nameof(ECHOONOFF)}: {ECHOONOFF}\n" +
                   $"{nameof(FREEZEONOFF)}: {FREEZEONOFF}\n" +
                   $"{nameof(FSBPATHCHANGE)}: {FSBPATHCHANGE}\n" +
                   $"{nameof(FSBUPDATED)}: {FSBUPDATED}\n" +
                   $"{nameof(GAMMAVAD_SR)}: {GAMMAVAD_SR}\n" +
                   $"{nameof(GAMMA_E)}: {GAMMA_E}\n" +
                   $"{nameof(GAMMA_ENL)}: {GAMMA_ENL}\n" +
                   $"{nameof(GAMMA_ETAIL)}: {GAMMA_ETAIL}\n" +
                   $"{nameof(GAMMA_NN)}: {GAMMA_NN}\n" +
                   $"{nameof(GAMMA_NN_SR)}: {GAMMA_NN_SR}\n" +
                   $"{nameof(GAMMA_NS)}: {GAMMA_NS}\n" +
                   $"{nameof(GAMMA_NS_SR)}: {GAMMA_NS_SR}\n" +
                   $"{nameof(HPFONOFF)}: {HPFONOFF}\n" +
                   $"{nameof(MIN_NN)}: {MIN_NN}\n" +
                   $"{nameof(MIN_NN_SR)}: {MIN_NN_SR}\n" +
                   $"{nameof(MIN_NS)}: {MIN_NS}\n" +
                   $"{nameof(MIN_NS_SR)}: {MIN_NS_SR}\n" +
                   $"{nameof(NLAEC_MODE)}: {NLAEC_MODE}\n" +
                   $"{nameof(NLATTENONOFF)}: {NLATTENONOFF}\n" +
                   $"{nameof(NONSTATNOISEONOFF)}: {NONSTATNOISEONOFF}\n" +
                   $"{nameof(NONSTATNOISEONOFF_SR)}: {NONSTATNOISEONOFF_SR}\n" +
                   $"{nameof(RT60)}: {RT60}\n" +
                   $"{nameof(RT60ONOFF)}: {RT60ONOFF}\n" +
                   $"{nameof(SPEECHDETECTED)}: {SPEECHDETECTED}\n" +
                   $"{nameof(STATNOISEONOFF)}: {STATNOISEONOFF}\n" +
                   $"{nameof(STATNOISEONOFF_SR)}: {STATNOISEONOFF_SR}\n" +
                   $"{nameof(TRANSIENTONOFF)}: {TRANSIENTONOFF}\n" +
                   $"{nameof(VOICEACTIVITY)}: {VOICEACTIVITY}\n";
        }

        public void Dispose()
        {
            _usbDevice?.Dispose();
        }
    }
}
