using MLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPlayerSetting.Common
{
	/// <summary>
	/// Virtual Player Directory Define
	/// </summary>
	internal class ParameterDefine
	{
		public const string IconFileName = "Icon.png";
		public const int IconSize = 128;

		public const string CutinFileName = "Cutin.png";
		public const int CutinSize = 256;


		public const string StartupSoundDir = "01_SoundStartup";
		public const string AttackSoundDir = "02_SoundAttack";
		public const string SkillSoundDir = "03_SoundSkill";
		public const string DieSoundDir = "04_SoundDie";
		public const string WinnerSoundDir = "05_SoundWinner";

		// ----------------------------------------------------------------------------------------------------

		public readonly string IconPath;
		public readonly string CutinPath;

		public readonly string StartupSoundPath;
		public readonly string AttackSoundPath;
		public readonly string SkillSoundPath;
		public readonly string DieSoundPath;
		public readonly string WinnerSoundPath;

		// ----------------------------------------------------------------------------------------------------

		public ParameterDefine( string baseDir )
		{
			IconPath = Path.Combine( baseDir, IconFileName );
			CutinPath = Path.Combine( baseDir, CutinFileName );

			StartupSoundPath = Path.Combine( baseDir, StartupSoundDir );
			AttackSoundPath = Path.Combine( baseDir, AttackSoundDir );
			SkillSoundPath = Path.Combine( baseDir, SkillSoundDir );
			DieSoundPath = Path.Combine( baseDir, DieSoundDir );
			WinnerSoundPath = Path.Combine( baseDir, WinnerSoundDir );
		}


	}


}
