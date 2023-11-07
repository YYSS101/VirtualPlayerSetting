﻿using MLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPlayerSetting.Common
{
	static internal class ParameterMgr
	{
		/// <summary>
		//  Copy target sound files Only.
		/// </summary>
		static void SoundDirCopy( string srcPath, string destPath )
		{
			if( Directory.Exists( destPath ) == false )
			{
				Directory.CreateDirectory( destPath );
			}

			foreach( var it in Directory.GetFiles( destPath ) )
			{
				string ext = Path.GetExtension( it ).ToLower();

				if( ext is "mp3" or "wav" or "ogg" )
				{
					string fileName = Path.GetFileName( it );
					string destFilePath = Path.Combine( destPath, fileName );
					File.Copy( it, destFilePath, true );
				}
			}
		}


		static public bool FileLoad( string srcPath, ParameterDefine tempDirDef )
		{
			Directory.Delete( PathMgr.Temp, true );

			ParameterDefine srcDirDef = new( srcPath );


			// Copy Icon File
			if( File.Exists( srcDirDef.IconPath ) == false )
			{
				MessageBox.Show( "Icon Data Not Found." );
				return false;
			}

			using( var iconImg = Image.FromFile( srcDirDef.IconPath ) )
			{
				int sz = ParameterDefine.IconSize;

				if( iconImg.Width == sz && iconImg.Height == sz ) { }
				else
				{
					MessageBox.Show( $"Icon Size Not {sz}x{sz}." );
					return false;
				}
			}

			File.Copy( srcDirDef.IconPath, tempDirDef.IconPath, true );


			// Copy Cutin File
			if( File.Exists( srcDirDef.CutinPath ) )
			{
				using( var iconImg = Image.FromFile( srcDirDef.CutinPath ) )
				{
					int sz = ParameterDefine.CutinSize;

					if( iconImg.Width == sz && iconImg.Height == sz ) { }
					else
					{
						MessageBox.Show( $"Icon Size Not {sz}x{sz}." );
						return false;
					}
				}

				File.Copy( srcDirDef.CutinPath, tempDirDef.CutinPath, true );
			}


			// Copy Sound File
			if( Directory.Exists( srcDirDef.StartupSoundPath ) )
			{
				SoundDirCopy( srcDirDef.StartupSoundPath, tempDirDef.StartupSoundPath );
			}
			if( Directory.Exists( srcDirDef.AttackSoundPath ) )
			{
				SoundDirCopy( srcDirDef.AttackSoundPath, tempDirDef.AttackSoundPath );
			}
			if( Directory.Exists( srcDirDef.SkillSoundPath ) )
			{
				SoundDirCopy( srcDirDef.SkillSoundPath, tempDirDef.SkillSoundPath );
			}
			if( Directory.Exists( srcDirDef.DieSoundPath ) )
			{
				SoundDirCopy( srcDirDef.DieSoundPath, tempDirDef.DieSoundPath );
			}
			if( Directory.Exists( srcDirDef.WinnerSoundPath ) )
			{
				SoundDirCopy( srcDirDef.WinnerSoundPath, tempDirDef.WinnerSoundPath );
			}


			return true;
		}


		static public bool FileSave( string destPath, ParameterDefine tempDirDef )
		{

			// Create backup
			string backupPath = destPath + "_backup";
			ParameterDefine destDirDef = new( backupPath );

			// Copy Icon File
			if( File.Exists( tempDirDef.IconPath ) == false )
			{
				MessageBox.Show( "Icon Data Not Found." );
				return false;
			}
			File.Copy( tempDirDef.IconPath, destDirDef.IconPath, true );


			// Copy Cutin File
			if( File.Exists( tempDirDef.CutinPath ) )
			{
				File.Copy( tempDirDef.CutinPath, destDirDef.CutinPath, true );
			}


			// Copy Sound File
			if( Directory.Exists( tempDirDef.StartupSoundPath ) )
			{
				SoundDirCopy( tempDirDef.StartupSoundPath, destDirDef.StartupSoundPath );
			}
			if( Directory.Exists( tempDirDef.AttackSoundPath ) )
			{
				SoundDirCopy( tempDirDef.AttackSoundPath, destDirDef.AttackSoundPath );
			}
			if( Directory.Exists( tempDirDef.SkillSoundPath ) )
			{
				SoundDirCopy( tempDirDef.SkillSoundPath, destDirDef.SkillSoundPath );
			}
			if( Directory.Exists( tempDirDef.DieSoundPath ) )
			{
				SoundDirCopy( tempDirDef.DieSoundPath, destDirDef.DieSoundPath );
			}
			if( Directory.Exists( tempDirDef.WinnerSoundPath ) )
			{
				SoundDirCopy( tempDirDef.WinnerSoundPath, destDirDef.WinnerSoundPath );
			}


			// Old Dir Delete and Update
			Directory.Delete( destPath );
			Directory.Move( backupPath, destPath );


			return true;
		}



	}
}