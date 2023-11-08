using NAudio.Vorbis;
using NAudio.Wave;

namespace VirtualPlayerSetting.Common
{
	internal class SoundManager
	{
		AudioFileReader? Reader = null;
		VorbisWaveReader? VorbisRdr = null;
		WaveOut? WaveOut = null;


		public void LoadSound( string soundFilePath )
		{
			DeleteSound();

			string ext = Path.GetExtension( soundFilePath ).ToLower();

			// OGG
			if( ext == ".ogg" )
			{
				VorbisRdr = new( soundFilePath );
				WaveOut = new();
				WaveOut.Init( VorbisRdr );
			}
			// MP3 / Wave
			else
			{
				Reader = new( soundFilePath );
				WaveOut = new();
				WaveOut.Init( Reader );
			}

		}


		public void DeleteSound()
		{
			// Nullじゃなければ開放される
			WaveOut?.Stop();
			WaveOut?.Dispose();
			WaveOut = null;

			Reader?.Dispose();
			Reader = null;

			VorbisRdr?.Dispose();
			VorbisRdr = null;
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
