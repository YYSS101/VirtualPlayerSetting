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
		// ------------------------------------------------------------------------------------------------------------------------
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


		// ------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Playerファイルやフォルダをチェックしながらコピーする
		/// </summary>
		/// <param name="srcPath">コピー元</param>
		/// <param name="tempDirDef">コピー先</param>
		/// <returns></returns>
		static public bool FileCheckCopy( string srcPath, string destPath )
		{
			// 直接コピーするとエラーのときに元に戻せなくなるので一時フォルダに一旦コピーする
			string destTempPath = destPath + "_temp";

			try
			{
				ParameterDefine srcDirDef = new( srcPath );
				ParameterDefine destDirDef = new( destTempPath );

				// Copy Icon File
				if( File.Exists( srcDirDef.IconPath ) == false )
				{
					MessageBox.Show( "Icon Data Not Found." );
					return false;
				}

				// Check image size
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

				File.Copy( srcDirDef.IconPath, destDirDef.IconPath, true );


				// Copy Cutin File
				if( File.Exists( srcDirDef.CutinPath ) )
				{
					// Check image size
					using( var iconImg = Image.FromFile( srcDirDef.CutinPath ) )
					{
						int sz = ParameterDefine.CutinSize;

						if( iconImg.Width == sz && iconImg.Height == sz ) { }
						else
						{
							MessageBox.Show( $"Cutin Size Not {sz}x{sz}." );
							return false;
						}
					}

					File.Copy( srcDirDef.CutinPath, destDirDef.CutinPath, true );
				}

				// Copy Sound File
				SoundDirCopy( srcDirDef.OpeningSoundPath, destDirDef.OpeningSoundPath );
				SoundDirCopy( srcDirDef.AttackSoundPath, destDirDef.AttackSoundPath );
				SoundDirCopy( srcDirDef.SkillSoundPath, destDirDef.SkillSoundPath );
				SoundDirCopy( srcDirDef.DieSoundPath, destDirDef.DieSoundPath );
				SoundDirCopy( srcDirDef.WinSoundPath, destDirDef.WinSoundPath );

				// フォルダが存在しないときにDeleteすると例外になるのでチェックする
				if( Directory.Exists( destPath ) )
				{
					Directory.Delete( destPath, true );
				}
				Directory.Move( destTempPath, destPath );
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message );
			}
			finally
			{
				// Delete temp directory.
				if( Directory.Exists( destTempPath ) )
				{
					Directory.Delete( destTempPath, true );
				}
			}

			return true;
		}



	}
}
