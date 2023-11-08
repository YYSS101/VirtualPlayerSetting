using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPlayerSetting.Common
{
	internal class SoundManager
	{
		AudioFileReader? Reader = null;
		WaveOut? WaveOut = null;



		public void LoadSound( string soundFilePath )
		{
			// Nullなら開放される
			WaveOut?.Dispose();
			Reader?.Dispose();

			Reader = new( soundFilePath );

			WaveOut = new();
			WaveOut.Init( Reader );
		}


		public void Play()
		{
			if( WaveOut == null ) return;

			WaveOut.Stop();
			WaveOut.Play();
		}


		public void Stop()
		{
			if( WaveOut == null ) return;

			WaveOut.Stop();
		}


	}
}
