# RESPEAKER.NET
Simple .Net Standard Library to control Respeaker Microphone Arrays.

## Dependencies
Uses the [Alsa.Net](https://github.com/Omegaframe/alsa.net) package for audio device communication. Ensure all dependencies are installed on your target system.

## First Steps
1. Use the detector to obtain a handle on your device
```
 using var respeakerDevice = RespeakerDeviceDetector.Detect().First();
```

2. Read and output device settings
```
 Console.WriteLine(respeakerDevice.Configuration.ToString());
```

3. Control the LED ring (set it to red for 5s)
```
 respeakerDevice.LedRing.Mono(0xFF0000);
 await Task.Delay(5000);
 respeakerDevice.LedRing.Off();
```

4. Record 15s of audio
```
 using var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(15));
 using var wavStream = new MemoryStream();

 await respeakerDevice.AudioInput.Record(wavStream, tokenSource.Token);
```

5. Play recorded audio back to the device
```
 wavStream.Seek(0, SeekOrigin.Begin);
 await respeakerDevice.AudioOutput.Play(wavStream, CancellationToken.None);
```

Ensure to look into the example projects for more details on how to use this package.

## Supported Devices
- Respeaker UsbMicArrayV2