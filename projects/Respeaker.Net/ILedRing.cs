namespace Respeaker.Net;

/// <summary>constrols the LED ring</summary>
public interface ILedRing
{
    /// <summary>
    /// custom mode, set each LED to its own color
    /// </summary>
    /// <param name="colors">array of colors to set each in 6 part hexadecimal format. must be exactly 12 (one per led)</param>
    void Custom(int[] colors);

    /// <summary>
    /// listen mode, similar with trace mode, but does not turn LEDs off
    /// </summary>
    void Listen();

    /// <summary>
    /// mono mode, set all RGB LED to a single color.
    /// for example Red(0xFF0000), Green(0x00FF00) Blue(0x0000FF)
    /// </summary>
    /// <param name="color">color as 6 part hexadecimal Value</param>
    void Mono(int color);

    /// <summary>
    /// turn off all leds
    /// </summary>
    void Off();

    /// <summary>
    /// set brightness
    /// </summary>
    /// <param name="brightness">brightness with range: 0x00 - 0x1F</param>
    void SetBrightness(int brightness);

    /// <summary>
    /// set color palette to use together with e.g. Think()
    /// </summary>
    /// <param name="a">start color in 6 part hexadecimal format (0xFF0000)</param>
    /// <param name="b">end color in 6 part heyadecimal format(0x00FF00)</param>
    void SetColorPalette(int a, int b);

    /// <summary>
    /// set center led state
    /// </summary>
    /// <param name="state">on, off or depend on VAD</param>
    void SetVadLed(LedState state);

    /// <summary>
    /// speak mode
    /// </summary>
    void Speak();

    /// <summary>
    /// spin mode
    /// </summary>
    void Spin();

    /// <summary>
    /// wait mode
    /// </summary>
    void Think();

    /// <summary>
    /// trace mode, LEDs changing depends on VAD and DOA
    /// </summary>
    void Trace();

    /// <summary>
    /// volume mode, range: 0 - 12
    /// </summary>
    /// <param name="volume">volume in range 0 - 12</param>
    void Volume(int volume);
}

/// <summary>states a LED on the ring might be in</summary>
public enum LedState
{
    /// <summary>LED is turned off</summary>
    Off = 0,

    /// <summary>LED is always on</summary>
    On = 1,

    /// <summary>LED depends on VAD (Voice Activity Detection)</summary>
    DependOnVad = 2
}