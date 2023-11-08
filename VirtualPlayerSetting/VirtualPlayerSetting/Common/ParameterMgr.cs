using MLib;
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
			if( Directory.Exists( srcPath ) == false ) return;

			if( Directory.Exists( destPath ) == false )
			{
				Directory.CreateDirectory( destPath );
			}

			foreach( var it in Directory.GetFiles( srcPath ) )
			{
				string ext = Path.GetExtension( it ).ToLower();

				if( ext is ".mp3" or ".wav" or ".ogg" )
				{
					string fileName = Path.GetFileName( it );
					string destFilePath = Path.Combine( destPath, fileName );
					File.Copy( it, destFilePath, true );
				}
			}
		}


		static public bool FileLoad( string srcPath, ParameterDefine tempDirDef )
		{
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
			SoundDirCopy( srcDirDef.OpeningSoundPath, tempDirDef.OpeningSoundPath );
			SoundDirCopy( srcDirDef.AttackSoundPath, tempDirDef.AttackSoundPath );
			SoundDirCopy( srcDirDef.SkillSoundPath, tempDirDef.SkillSoundPath );
			SoundDirCopy( srcDirDef.DieSoundPath, tempDirDef.DieSoundPath );
			SoundDirCopy( srcDirDef.WinSoundPath, tempDirDef.WinSoundPath );

			return true;
		}


		static public bool FileSave( string destPath, ParameterDefine tempDirDef )
		{
			// Create backup
			string backupPath = destPath + "_backup";

			try
			{
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
				SoundDirCopy( tempDirDef.OpeningSoundPath, destDirDef.OpeningSoundPath );
				SoundDirCopy( tempDirDef.AttackSoundPath, destDirDef.AttackSoundPath );
				SoundDirCopy( tempDirDef.SkillSoundPath, destDirDef.SkillSoundPath );
				SoundDirCopy( tempDirDef.DieSoundPath, destDirDef.DieSoundPath );
				SoundDirCopy( tempDirDef.WinSoundPath, destDirDef.WinSoundPath );


				// フォルダが存在しないときにDeleteすると例外になるのでチェックする
				if( Directory.Exists( destPath ) )
				{
					Directory.Delete( destPath, true );
				}
				Directory.Move( backupPath, destPath );
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message );
			}
			finally
			{
				// Delete backup directory.
				if( Directory.Exists( backupPath ) )
				{
					Directory.Delete( backupPath, true );
				}
			}

			return true;
		}



	}
}
