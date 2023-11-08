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


		public const string OpeningSoundDir = "01_SoundOpening";
		public const string AttackSoundDir = "02_SoundAttack";
		public const string SkillSoundDir = "03_SoundSkill";
		public const string DieSoundDir = "04_SoundDie";
		public const string WinSoundDir = "05_SoundWin";

		// ----------------------------------------------------------------------------------------------------

		public readonly string IconPath;
		public readonly string CutinPath;

		public readonly string OpeningSoundPath;
		public readonly string AttackSoundPath;
		public readonly string SkillSoundPath;
		public readonly string DieSoundPath;
		public readonly string WinSoundPath;

		// ----------------------------------------------------------------------------------------------------

		public ParameterDefine( string baseDir, bool createDir = true )
		{
			IconPath = Path.Combine( baseDir, IconFileName );
			CutinPath = Path.Combine( baseDir, CutinFileName );

			OpeningSoundPath = Path.Combine( baseDir, OpeningSoundDir );
			AttackSoundPath = Path.Combine( baseDir, AttackSoundDir );
			SkillSoundPath = Path.Combine( baseDir, SkillSoundDir );
			DieSoundPath = Path.Combine( baseDir, DieSoundDir );
			WinSoundPath = Path.Combine( baseDir, WinSoundDir );

			if( createDir )
			{
				CreateDirectory();
			}
		}

		public void CreateDirectory()
		{
			if( Directory.Exists( OpeningSoundPath ) == false )
			{
				Directory.CreateDirectory( OpeningSoundPath );
			}
			if( Directory.Exists( AttackSoundPath ) == false )
			{
				Directory.CreateDirectory( AttackSoundPath );
			}
			if( Directory.Exists( SkillSoundPath ) == false )
			{
				Directory.CreateDirectory( SkillSoundPath );
			}
			if( Directory.Exists( DieSoundPath ) == false )
			{
				Directory.CreateDirectory( DieSoundPath );
			}
			if( Directory.Exists( WinSoundPath ) == false )
			{
				Directory.CreateDirectory( WinSoundPath );
			}
		}


	}


}
