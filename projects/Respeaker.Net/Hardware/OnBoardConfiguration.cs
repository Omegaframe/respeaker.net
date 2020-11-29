using LibUsbDotNet;
using Respeaker.Net.Exceptions;
using System;
using System.Linq;

namespace Respeaker.Net.Hardware
{
    public class OnBoardConfiguration
    {
        /// <summary>
        /// Adaptive Echo Canceler updates inhibit.
        /// </summary>
        public int AECFREEZEONOFF { get => Read<int>(18, 7); set => Write(18, 7, 1, 1, 0, value, nameof(AECFREEZEONOFF)); }

        /// <summary>
        /// Limit on norm of AEC filter coefficients
        /// </summary>
        public float AECNORM { get => Read<float>(18, 19); set => Write(18, 19, 0, 16, 0.25, value, nameof(AECNORM)); }

        /// <summary>
        /// AEC Path Change Detection.
        /// </summary>
        public int AECPATHCHANGE => Read<int>(18, 25);

        /// <summary>
        /// Threshold for signal detection in AEC [-inf .. 0] dBov (Default: -80dBov = 10log10(1x10-8))
        /// </summary>
        public float AECSILENCELEVEL { get => Read<float>(18, 30); set => Write(18, 30, 0, 1, 1e-09, value, nameof(AECSILENCELEVEL)); }

        /// <summary>
        /// AEC far-end silence detection status.
        /// </summary>
        public int AECSILENCEMODE => Read<int>(18, 31);

        /// <summary>
        /// Target power level of the output signal.
        /// </summary>
        public float AGCDESIREDLEVEL { get => Read<float>(19, 2); set => Write(19, 2, 0, 0.99, 1e-08, value, nameof(AGCDESIREDLEVEL)); }

        /// <summary>
        /// Current AGC gain factor.
        /// </summary>
        public float AGCGAIN { get => Read<float>(19, 3); set => Write(19, 3, 0, 1000, 1, value, nameof(AGCGAIN)); }

        /// <summary>
        /// Maximum AGC gain factor.
        /// </summary>
        public float AGCMAXGAIN { get => Read<float>(19, 1); set => Write(19, 1, 0, 1000, 1, value, nameof(AGCMAXGAIN)); }

        /// <summary>
        /// Automatic Gain Control.
        /// </summary>
        public int AGCONOFF { get => Read<int>(19, 0); set => Write(19, 0, 1, 1, 0, value, nameof(AGCONOFF)); }

        /// <summary>
        /// Ramps-up / down time-constant in seconds.
        /// </summary>
        public float AGCTIME { get => Read<float>(19, 4); set => Write(19, 4, 0, 1, 0.1, value, nameof(AGCTIME)); }

        /// <summary>
        /// Comfort Noise Insertion.
        /// </summary>
        public int CNIONOFF { get => Read<int>(19, 5); set => Write(19, 5, 1, 1, 0, value, nameof(CNIONOFF)); }

        /// <summary>
        /// DOA angle. Current value. Orientation depends on build configuration.
        /// </summary>
        public int DOAANGLE => Read<int>(21, 0);

        /// <summary>
        /// Echo suppression
        /// </summary>
        public int ECHOONOFF { get => Read<int>(19, 14); set => Write(19, 14, 1, 1, 0, value, nameof(ECHOONOFF)); }

        /// <summary>
        /// Adaptive beamformer updates.
        /// </summary>
        public int FREEZEONOFF { get => Read<int>(19, 6); set => Write(19, 6, 1, 1, 0, value, nameof(FREEZEONOFF)); }

        /// <summary>
        /// FSB Path Change Detection.
        /// </summary>
        public int FSBPATHCHANGE => Read<int>(19, 24);

        /// <summary>
        /// FSB Update Decision.
        /// </summary>
        public int FSBUPDATED => Read<int>(19, 23);

        /// <summary>
        /// Set the threshold for voice activity detection
        /// </summary>
        public float GAMMAVAD_SR { get => Read<float>(19, 39); set => Write(19, 39, 0, 1000, 0, value, nameof(GAMMAVAD_SR)); }

        /// <summary>
        /// Over-subtraction factor of echo (direct and early components). min .. max attenuation
        /// </summary>
        public float GAMMA_E { get => Read<float>(19, 15); set => Write(19, 15, 0, 3, 0, value, nameof(GAMMA_E)); }

        /// <summary>
        /// Over-subtraction factor of non-linear echo. min .. max attenuation
        /// </summary>
        public float GAMMA_ENL { get => Read<float>(19, 17); set => Write(19, 17, 0, 5, 0, value, nameof(GAMMA_ENL)); }

        /// <summary>
        /// Over-subtraction factor of echo (tail components). min .. max attenuation
        /// </summary>
        public float GAMMA_ETAIL { get => Read<float>(19, 16); set => Write(19, 16, 0, 3, 0, value, nameof(GAMMA_ETAIL)); }

        /// <summary>
        /// Over-subtraction factor of non- stationary noise. min .. max attenuation
        /// </summary>
        public float GAMMA_NN { get => Read<float>(19, 12); set => Write(19, 12, 0, 3, 0, value, nameof(GAMMA_NN)); }

        /// <summary>
        /// Over-subtraction factor of non-stationary noise for ASR. 
        /// </summary>
        public float GAMMA_NN_SR { get => Read<float>(19, 36); set => Write(19, 36, 0, 3, 0, value, nameof(GAMMA_NN_SR)); }

        /// <summary>
        /// Over-subtraction factor of stationary noise. min .. max attenuation
        /// </summary>
        public float GAMMA_NS { get => Read<float>(19, 9); set => Write(19, 9, 0, 3, 0, value, nameof(GAMMA_NS)); }

        /// <summary>
        /// Over-subtraction factor of stationary noise for ASR.
        /// </summary>
        public float GAMMA_NS_SR { get => Read<float>(19, 35); set => Write(19, 35, 0, 3, 0, value, nameof(GAMMA_NS_SR)); }

        /// <summary>
        /// High-pass Filter on microphone signals.
        /// </summary>
        public int HPFONOFF { get => Read<int>(18, 27); set => Write(18, 27, 1, 3, 0, value, nameof(HPFONOFF)); }

        /// <summary>
        /// Gain-floor for non-stationary noise suppression.
        /// </summary>
        public float MIN_NN { get => Read<float>(19, 13); set => Write(19, 13, 0, 1, 0, value, nameof(MIN_NN)); }

        /// <summary>
        /// Gain-floor for non-stationary noise suppression for ASR
        /// </summary>
        public float MIN_NN_SR { get => Read<float>(19, 38); set => Write(19, 38, 0, 1, 0, value, nameof(MIN_NN_SR)); }

        /// <summary>
        /// Gain-floor for stationary noise suppression
        /// </summary>
        public float MIN_NS { get => Read<float>(19, 10); set => Write(19, 10, 0, 1, 0, value, nameof(MIN_NS)); }

        /// <summary>
        /// Gain-floor for stationary noise suppression for ASR
        /// </summary>
        public float MIN_NS_SR { get => Read<float>(19, 37); set => Write(19, 37, 0, 1, 0, value, nameof(MIN_NS_SR)); }

        /// <summary>
        /// Non-Linear AEC training mode
        /// </summary>
        public int NLAEC_MODE { get => Read<int>(19, 20); set => Write(19, 20, 1, 2, 0, value, nameof(NLAEC_MODE)); }

        /// <summary>
        /// Non-Linear echo attenuation
        /// </summary>
        public int NLATTENONOFF { get => Read<int>(19, 18); set => Write(19, 18, 1, 1, 0, value, nameof(NLATTENONOFF)); }

        /// <summary>
        /// Non-stationary noise suppression.
        /// </summary>
        public int NONSTATNOISEONOFF { get => Read<int>(19, 11); set => Write(19, 11, 1, 1, 0, value, nameof(NONSTATNOISEONOFF)); }

        /// <summary>
        /// Non-stationary noise suppression for ASR
        /// </summary>
        public int NONSTATNOISEONOFF_SR { get => Read<int>(19, 34); set => Write(19, 34, 1, 1, 0, value, nameof(NONSTATNOISEONOFF_SR)); }

        /// <summary>
        /// Current RT60 estimate in seconds
        /// </summary>
        public float RT60 => Read<float>(18, 26);

        /// <summary>
        /// RT60 Estimation for AES. 0 = OFF 1 = ON
        /// </summary>
        public int RT60ONOFF { get => Read<int>(18, 28); set => Write(18, 28, 1, 1, 0, value, nameof(RT60ONOFF)); }

        /// <summary>
        /// Speech detection status
        /// </summary>
        public int SPEECHDETECTED { get => Read<int>(19, 22); set => Write(19, 22, 1, 1, 0, value, nameof(SPEECHDETECTED)); }

        /// <summary>
        /// Stationary noise suppression
        /// </summary>
        public int STATNOISEONOFF { get => Read<int>(19, 8); set => Write(19, 8, 1, 1, 0, value, nameof(STATNOISEONOFF)); }

        /// <summary>
        /// Stationary noise suppression for ASR
        /// </summary>
        public int STATNOISEONOFF_SR { get => Read<int>(19, 33); set => Write(19, 33, 1, 1, 0, value, nameof(STATNOISEONOFF_SR)); }

        /// <summary>
        /// Transient echo suppression
        /// </summary>
        public int TRANSIENTONOFF { get => Read<int>(19, 29); set => Write(19, 29, 1, 1, 0, value, nameof(TRANSIENTONOFF)); }

        /// <summary>
        /// VAD voice activity status
        /// </summary>
        public int VOICEACTIVITY => Read<int>(19, 32);

        readonly IUsbDevice _usbDevice;

        internal OnBoardConfiguration(IUsbDevice usbDevice)
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

        T Read<T>(int id, int offset) where T : IComparable
        {
            const int responseLength = 8;

            var cmd = 0x80 | offset;
            if (typeof(T) == typeof(int))
                cmd |= 0x40;

            var response = UsbControl.ReadControlTransfer(cmd, id, responseLength, _usbDevice);
            var i1 = BitConverter.ToInt32(response.Take(4).ToArray(), 0);
            var i2 = BitConverter.ToInt32(response.Skip(4).ToArray(), 0);

            T result;
            if (typeof(T) == typeof(int))
                result = (T)Convert.ChangeType(i1, typeof(T));
            else
                result = (T)Convert.ChangeType((float)i1 * (Math.Pow(2.0f, i2)), typeof(T));

            return result;
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
    }
}
