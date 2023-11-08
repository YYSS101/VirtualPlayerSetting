using MLib;
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Media;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using VirtualPlayerSetting.Common;
using VirtualPlayerSetting.Model;


namespace VirtualPlayerSetting
{
	public partial class FrmMain : Form
	{

		SoundPlayer SoundPlayClient = new();

		ParameterDefine TempDirDef;




		public FrmMain()
		{
			InitializeComponent();


			var sysParam = new SystemParam();

			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				WriteIndented = true,
			};

			string json = JsonSerializer.Serialize( sysParam, options );

			string jsonPath = Path.Combine( PathMgr.Parameter, "SystemParam.json" );

			File.WriteAllText( jsonPath, json );


			string dJson = File.ReadAllText( jsonPath );

			var sysParam2 = JsonSerializer.Deserialize<SystemParam>( dJson );

		}




		private void Form1_Load( object sender, EventArgs e )
		{
			TempDirInit();
		}


		private void FrmMain_FormClosed( object sender, FormClosedEventArgs e )
		{
			ViewAllClear();
			TempDirInit();
		}



		void TempDirInit()
		{
			Directory.Delete( PathMgr.Temp, true );
			TempDirDef = new( PathMgr.Temp );
		}





		void ViewAllClear()
		{
			TbName.Clear();

			ClearIcon();
			ClearCutin();
			Rb1.Checked = true;
			LbSounds.Items.Clear();
		}


		void ClearIcon()
		{
			if( PbIcon.Image != null )
			{
				PbIcon.Image.Dispose();
				PbIcon.Image = null;
			}
		}
		void ClearCutin()
		{
			if( PbCutin.Image != null )
			{
				PbCutin.Image.Dispose();
				PbCutin.Image = null;
			}
		}



		void UpdateIcon()
		{
			ClearIcon();
			string imgPath = TempDirDef.IconPath;
			PbIcon.Image = Image.FromFile( imgPath );
		}

		void UpdateCutin()
		{
			ClearCutin();
			string imgPath = TempDirDef.CutinPath;
			PbCutin.Image = Image.FromFile( imgPath );
		}

		void UpdateSound()
		{
			LbSounds.Items.Clear();

			string[] files = Directory.GetFiles( SelectingSoundPath );

			foreach( string file in files )
			{
				LbSounds.Items.Add( Path.GetFileName( file ) );
			}
		}


		private void BtnNew_Click( object sender, EventArgs e )
		{
			if( TbName.Text != "" )
			{
				string mes = "Are you sure you want to be cleared?";
				var ret = MessageBox.Show( mes );

				if( ret != DialogResult.OK ) return;
			}

			ViewAllClear();
			TempDirInit();
		}


		private void BtnLoad_Click( object sender, EventArgs e )
		{
			FolderBrowserDialog ofd = new()
			{
				InitialDirectory = PathMgr.VPlayer
			};

			var result = ofd.ShowDialog();

			if( result == DialogResult.OK )
			{
				ViewAllClear();

				TempDirInit();

				if( ParameterMgr.FileLoad( ofd.SelectedPath, TempDirDef ) == false )
				{
					return;
				}

				// UI更新
				TbName.Text = Path.GetFileName( ofd.SelectedPath );


				UpdateIcon();
				UpdateCutin();
				UpdateSound();

			}
		}


		private void BtnSave_Click( object sender, EventArgs e )
		{
			try
			{
				if( TbName.Text == "" )
				{
					MessageBox.Show( "No name has been entered." );
					return;
				}

				string destPath = Path.Combine( PathMgr.VPlayer, TbName.Text );

				if( File.Exists( destPath ) )
				{
					string message = $"{TbName.Text} is already exists. override Ok ?";

					var ret = MessageBox.Show( message, "Warning", MessageBoxButtons.YesNo );

					if( ret != DialogResult.Yes ) return;
				}

				if( ParameterMgr.FileSave( destPath, TempDirDef ) == false )
				{
					return;
				}

				MessageBox.Show( "Success!" );
			}
			catch( Exception ex )
			{
				MessageBox.Show( "Save Failed." );

				SimpleLog.WriteLine( $"{ex.Message}" );
			}
		}



		private void BtnIconAdd_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Image File|*.jpg;*.png;*.gif"
			};

			var result = ofd.ShowDialog();
			if( result == DialogResult.OK )
			{
				ImageAdd( ofd.FileName, TempDirDef.IconPath, ParameterDefine.IconSize );
				UpdateIcon();
			}
		}


		private void BtnCutinAdd_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Image File|*.jpg;*.png;*.gif"
			};

			var result = ofd.ShowDialog();
			if( result == DialogResult.OK )
			{
				ImageAdd( ofd.FileName, TempDirDef.CutinPath, ParameterDefine.CutinSize );
				UpdateCutin();
			}
		}



		private void ImageAdd( string srcImgPath, string destImgPath, int imgSize )
		{
			try
			{
				// 画像をPNG形式に変換して保存
				using Image inputImage = Image.FromFile( srcImgPath );
				int w = imgSize;
				int h = imgSize;

				using Bitmap resizedImage = new Bitmap( w, h );
				using Graphics graphics = Graphics.FromImage( resizedImage );

				// 画像をリサイズ
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.DrawImage( inputImage, 0, 0, w, h );

				// リサイズされた画像をPNG形式で保存
				if( File.Exists( destImgPath ) )
				{
					string backupPath = destImgPath + "_backup";

					// 生成や削除に失敗した時にファイルを復元出来るようバックアップしておく
					resizedImage.Save( backupPath, ImageFormat.Png );
					ClearIcon();
					File.Delete( destImgPath );
					File.Move( backupPath, destImgPath );
				}
				else
				{
					resizedImage.Save( destImgPath, ImageFormat.Png );
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( "非対応の画像形式です。" );
				SimpleLog.WriteLine( $"src:{srcImgPath}, dest:{destImgPath}, {ex.Message}" );
			}
		}




		/// <summary>
		/// Get directory path from selected radio button
		/// </summary>
		string SelectingSoundPath
		{
			get
			{
				if( Rb1.Checked ) return TempDirDef.OpeningSoundPath;
				if( Rb2.Checked ) return TempDirDef.AttackSoundPath;
				if( Rb3.Checked ) return TempDirDef.SkillSoundPath;
				if( Rb4.Checked ) return TempDirDef.DieSoundPath;
				if( Rb5.Checked ) return TempDirDef.WinSoundPath;

				return "";
			}
		}





		private void BtnSoundAdd_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Sound File|*.wav;*.mp3;",
				Multiselect = true,
			};

			var result = ofd.ShowDialog();

			if( result == DialogResult.OK )
			{

				foreach( var item in ofd.FileNames )
				{
					string fileName = Path.GetFileName( item );
					LbSounds.Items.Add( fileName );

					string soundPath = Path.Combine( SelectingSoundPath, fileName );
					File.Copy( item, soundPath, true );
				}
			}
		}

		private void BtnSoundDel_Click( object sender, EventArgs e )
		{
			ListRemove( LbSounds, PathMgr.TempSound );
		}


		private void ListRemove( ListBox lb, string dataDirPath )
		{
			if( lb.SelectedIndex != -1 )
			{
				string[] files = Directory.GetFiles( dataDirPath );
				string delFileName = lb.SelectedItem.ToString()!;

				foreach( string file in files )
				{
					if( file.Contains( delFileName ) )
					{
						File.Delete( file );
						break;
					}
				}

				lb.Items.RemoveAt( lb.SelectedIndex );
			}
		}




		private void TbName_KeyPress( object sender, KeyPressEventArgs e )
		{
			var tb = (System.Windows.Forms.TextBox)sender;

			string inputText = tb.Text + e.KeyChar;
			if( !Regex.IsMatch( inputText, "^[a-zA-Z0-9!@#$%&()\\-_+]*$" ) && e.KeyChar != (char)Keys.Back )
			{
				e.Handled = true; // 非英語の文字を無効にする
			}
		}



		void PlaySound( ListBox lb )
		{
			string soundName = lb.SelectedItem.ToString()!;
			string soundPath = Path.Combine( PathMgr.TempSound, soundName );

			if( File.Exists( soundPath ) == false )
			{
				MessageBox.Show( "対象の音声が存在しません。" );
				return;
			}

			SoundPlayClient.SoundLocation = soundPath;
			SoundPlayClient.Play();

		}


		private void BtnSoundPlay_Click( object sender, EventArgs e )
		{
			PlaySound( LbSounds );
		}


		private void LbSounds_DoubleClick( object sender, EventArgs e )
		{
			PlaySound( LbSounds );
		}



		private void SoundSelect_CheckedChanged( object sender, EventArgs e )
		{
			UpdateSound();
		}


	}
}