namespace Respeaker.Net
{
    public interface IOnBoardConfiguration
    {
        int AECFREEZEONOFF { get; set; }
        float AECNORM { get; set; }
        int AECPATHCHANGE { get; }
        float AECSILENCELEVEL { get; set; }
        int AECSILENCEMODE { get; }
        float AGCDESIREDLEVEL { get; set; }
        float AGCGAIN { get; set; }
        float AGCMAXGAIN { get; set; }
        int AGCONOFF { get; set; }
        float AGCTIME { get; set; }
        int CNIONOFF { get; set; }
        int DOAANGLE { get; }
        int ECHOONOFF { get; set; }
        int FREEZEONOFF { get; set; }
        int FSBPATHCHANGE { get; }
        int FSBUPDATED { get; }
        float GAMMA_E { get; set; }
        float GAMMA_ENL { get; set; }
        float GAMMA_ETAIL { get; set; }
        float GAMMA_NN { get; set; }
        float GAMMA_NN_SR { get; set; }
        float GAMMA_NS { get; set; }
        float GAMMA_NS_SR { get; set; }
        float GAMMAVAD_SR { get; set; }
        int HPFONOFF { get; set; }
        float MIN_NN { get; set; }
        float MIN_NN_SR { get; set; }
        float MIN_NS { get; set; }
        float MIN_NS_SR { get; set; }
        int NLAEC_MODE { get; set; }
        int NLATTENONOFF { get; set; }
        int NONSTATNOISEONOFF { get; set; }
        int NONSTATNOISEONOFF_SR { get; set; }
        float RT60 { get; }
        int RT60ONOFF { get; set; }
        int SPEECHDETECTED { get; set; }
        int STATNOISEONOFF { get; set; }
        int STATNOISEONOFF_SR { get; set; }
        int TRANSIENTONOFF { get; set; }
        int VOICEACTIVITY { get; }
    }
}
