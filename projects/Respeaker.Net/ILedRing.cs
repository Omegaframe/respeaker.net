namespace Respeaker.Net
{
    public interface ILedRing
    {
        void Custom(int[] colors);
        void Listen();
        void Mono(int color);
        void Off();
        void SetBrightness(int brightness);
        void SetColorPalette(int a, int b);
        void SetVadLed(LedState state);
        void Speak();
        void Spin();
        void Think();
        void Trace();
        void Volume(int volume);
    }

    public enum LedState
    {
        Off = 0,
        On = 1,
        DependOnVad = 2
    }
}
