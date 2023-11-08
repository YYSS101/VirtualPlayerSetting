using NAudio.Wave;

namespace VirtualPlayerSetting.Common
{
	internal class SoundManager
	{
		AudioFileReader? Reader = null;
		WaveOut? WaveOut = null;


		public void LoadSound( string soundFilePath )
		{
			DeleteSound();

			Reader = new( soundFilePath );

			WaveOut = new();
			WaveOut.Init( Reader );
		}


		public void DeleteSound()
		{
			// Nullじゃなければ開放される
			WaveOut?.Stop();
			WaveOut?.Dispose();
			WaveOut = null;

			Reader?.Dispose();
			Reader = null;
		}


		public void Play()
		{
			WaveOut?.Stop();
			WaveOut?.Play();
		}


		public void Stop()
		{
			WaveOut?.Stop();
		}


	}
}
