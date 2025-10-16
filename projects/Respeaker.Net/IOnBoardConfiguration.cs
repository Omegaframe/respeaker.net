namespace Respeaker.Net;

/// <summary>set or get the current device settings</summary>
public interface IOnBoardConfiguration
{
    /// <summary>
    /// Adaptive Echo Canceler updates inhibit.
    /// </summary>
    int AECFREEZEONOFF { get; set; }

    /// <summary>
    /// Limit on norm of AEC filter coefficients
    /// </summary>
    float AECNORM { get; set; }

    /// <summary>
    /// AEC Path Change Detection.
    /// </summary>
    int AECPATHCHANGE { get; }


    /// <summary>
    /// Threshold for signal detection in AEC [-inf .. 0] dBov (Default: -80dBov = 10log10(1x10-8))
    /// </summary>
    float AECSILENCELEVEL { get; set; }

    /// <summary>
    /// AEC far-end silence detection status.
    /// </summary>
    int AECSILENCEMODE { get; }

    /// <summary>
    /// Target power level of the output signal.
    /// </summary>
    float AGCDESIREDLEVEL { get; set; }

    /// <summary>
    /// Current AGC gain factor.
    /// </summary>
    float AGCGAIN { get; set; }

    /// <summary>
    /// Maximum AGC gain factor.
    /// </summary>
    float AGCMAXGAIN { get; set; }

    /// <summary>
    /// Automatic Gain Control.
    /// </summary>
    int AGCONOFF { get; set; }

    /// <summary>
    /// Ramps-up / down time-constant in seconds.
    /// </summary>
    float AGCTIME { get; set; }

    /// <summary>
    /// Comfort Noise Insertion.
    /// </summary>
    int CNIONOFF { get; set; }

    /// <summary>
    /// DOA angle. Current value. Orientation depends on build configuration.
    /// </summary>
    int DOAANGLE { get; }

    /// <summary>
    /// Echo suppression
    /// </summary>
    int ECHOONOFF { get; set; }

    /// <summary>
    /// Adaptive beamformer updates.
    /// </summary>
    int FREEZEONOFF { get; set; }

    /// <summary>
    /// FSB Path Change Detection.
    /// </summary>
    int FSBPATHCHANGE { get; }

    /// <summary>
    /// FSB Update Decision.
    /// </summary>
    int FSBUPDATED { get; }

    /// <summary>
    /// Over-subtraction factor of echo (direct and early components). min ... max attenuation
    /// </summary>
    float GAMMA_E { get; set; }

    /// <summary>
    /// Over-subtraction factor of non-linear echo. min ... max attenuation
    /// </summary>
    float GAMMA_ENL { get; set; }

    /// <summary>
    /// Over-subtraction factor of echo (tail components). min ... max attenuation
    /// </summary>
    float GAMMA_ETAIL { get; set; }

    /// <summary>
    /// Over-subtraction factor of non-stationary noise. min ... max attenuation
    /// </summary>
    float GAMMA_NN { get; set; }


    /// <summary>
    /// Over-subtraction factor of non-stationary noise for ASR. 
    /// </summary>
    float GAMMA_NN_SR { get; set; }

    /// <summary>
    /// Over-subtraction factor of stationary noise. min ... max attenuation
    /// </summary>
    float GAMMA_NS { get; set; }

    /// <summary>
    /// Over-subtraction factor of stationary noise for ASR.
    /// </summary>
    float GAMMA_NS_SR { get; set; }

    /// <summary>
    /// Set the threshold for voice activity detection
    /// </summary>
    float GAMMAVAD_SR { get; set; }

    /// <summary>
    /// High-pass Filter on microphone signals.
    /// </summary>
    int HPFONOFF { get; set; }

    /// <summary>
    /// Gain-floor for non-stationary noise suppression.
    /// </summary>
    float MIN_NN { get; set; }

    /// <summary>
    /// Gain-floor for non-stationary noise suppression for ASR
    /// </summary>
    float MIN_NN_SR { get; set; }

    /// <summary>
    /// Gain-floor for stationary noise suppression
    /// </summary>
    float MIN_NS { get; set; }

    /// <summary>
    /// Gain-floor for stationary noise suppression for ASR
    /// </summary>
    float MIN_NS_SR { get; set; }

    /// <summary>
    /// Non-Linear AEC training mode
    /// </summary>
    int NLAEC_MODE { get; set; }

    /// <summary>
    /// Non-Linear echo attenuation
    /// </summary>
    int NLATTENONOFF { get; set; }

    /// <summary>
    /// Non-stationary noise suppression.
    /// </summary>
    int NONSTATNOISEONOFF { get; set; }

    /// <summary>
    /// Non-stationary noise suppression for ASR
    /// </summary>
    int NONSTATNOISEONOFF_SR { get; set; }

    /// <summary>
    /// Current RT60 estimate in seconds
    /// </summary>
    float RT60 { get; }

    /// <summary>
    /// RT60 Estimation for AES. 0 = OFF 1 = ON
    /// </summary>
    int RT60ONOFF { get; set; }

    /// <summary>
    /// Speech detection status
    /// </summary>
    int SPEECHDETECTED { get; set; }

    /// <summary>
    /// Stationary noise suppression
    /// </summary>
    int STATNOISEONOFF { get; set; }

    /// <summary>
    /// Stationary noise suppression for ASR
    /// </summary>
    int STATNOISEONOFF_SR { get; set; }

    /// <summary>
    /// Transient echo suppression
    /// </summary>
    int TRANSIENTONOFF { get; set; }

    /// <summary>
    /// VAD voice activity status
    /// </summary>
    int VOICEACTIVITY { get; }
}