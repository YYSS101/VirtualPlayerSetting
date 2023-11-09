using MLib;
using NAudio.Wave;
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

		SoundManager SoundMgr = new();

		ParameterDefine TempDirDef = new( "", false );


		// ------------------------------------------------------------------------------------------------------------------------
		public FrmMain()
		{
			InitializeComponent();

			// バージョンの取得
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			Version ver = asm.GetName().Version!;

			Text += $" - Ver{ver.Major}.{ver.Minor}.{ver.Build}";


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


		// ------------------------------------------------------------------------------------------------------------------------
		private void Form1_Load( object sender, EventArgs e )
		{
			TempDirInit();
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void FrmMain_FormClosed( object sender, FormClosedEventArgs e )
		{
			ViewAllClear();
			TempDirInit();

			SoundMgr.DeleteSound();
		}



		// ------------------------------------------------------------------------------------------------------------------------
		void TempDirInit()
		{
			Directory.Delete( PathMgr.Temp, true );
			TempDirDef = new( PathMgr.Temp );
		}

		// ------------------------------------------------------------------------------------------------------------------------
		void ViewAllClear()
		{
			TbName.Clear();

			ClearIcon();
			ClearCutin();
			Rb1.Checked = true;
			LbSounds.Items.Clear();
		}


		// ------------------------------------------------------------------------------------------------------------------------
		void ClearIcon()
		{
			if( PbIcon.Image != null )
			{
				PbIcon.Image.Dispose();
				PbIcon.Image = null;
			}
		}
		void UpdateIcon()
		{
			ClearIcon();
			string imgPath = TempDirDef.IconPath;
			PbIcon.Image = Image.FromFile( imgPath );
		}

		// ------------------------------------------------------------------------------------------------------------------------
		void ClearCutin()
		{
			if( PbCutin.Image != null )
			{
				PbCutin.Image.Dispose();
				PbCutin.Image = null;
			}
		}
		void UpdateCutin()
		{
			ClearCutin();
			string imgPath = TempDirDef.CutinPath;
			if( File.Exists( imgPath ) )
			{
				PbCutin.Image = Image.FromFile( imgPath );
			}
		}

		// ------------------------------------------------------------------------------------------------------------------------
		void UpdateSoundList()
		{
			LbSounds.Items.Clear();

			string[] files = Directory.GetFiles( SelectingSoundPath );

			foreach( string file in files )
			{
				LbSounds.Items.Add( Path.GetFileName( file ) );
			}
		}





		// ------------------------------------------------------------------------------------------------------------------------
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


		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnLoad_Click( object sender, EventArgs e )
		{
			FrmSelectDir dialog = new();

			var result = dialog.ShowDialog();

			if( result != DialogResult.OK ) return;

			ViewAllClear();

			string srcPath = dialog.SelectedDirPath;

			if( ParameterMgr.FileCheckCopy( srcPath, TempDirDef.BaseDir ) == false )
			{
				return;
			}

			string srcName = Path.GetFileName( srcPath )!;

			// UI更新
			TbName.Text = srcName;


			UpdateIcon();
			UpdateCutin();
			UpdateSoundList();

		}


		// ------------------------------------------------------------------------------------------------------------------------
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

				if( ParameterMgr.FileCheckCopy( TempDirDef.BaseDir, destPath ) == false )
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


		// ------------------------------------------------------------------------------------------------------------------------
		private void TbName_KeyPress( object sender, KeyPressEventArgs e )
		{
			var tb = (System.Windows.Forms.TextBox)sender;

			string inputText = tb.Text + e.KeyChar;
			if( !Regex.IsMatch( inputText, "^[a-zA-Z0-9!@#$%&()\\-_+]*$" ) && e.KeyChar != (char)Keys.Back )
			{
				e.Handled = true; // 非英語の文字を無効にする
			}
		}



		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnIconAdd_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Image File|*.jpg;*.png;*.gif"
			};

			var result = ofd.ShowDialog();
			if( result == DialogResult.OK )
			{
				ClearIcon();
				ImageAdd( ofd.FileName, TempDirDef.IconPath, ParameterDefine.IconSize );
				UpdateIcon();
			}
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnCutinAdd_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Image File|*.jpg;*.png;*.gif"
			};

			var result = ofd.ShowDialog();
			if( result == DialogResult.OK )
			{
				ClearCutin();
				ImageAdd( ofd.FileName, TempDirDef.CutinPath, ParameterDefine.CutinSize );
				UpdateCutin();
			}
		}


		// ------------------------------------------------------------------------------------------------------------------------
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

					try
					{
						// 生成や削除に失敗した時にファイルを復元出来るようバックアップしておく
						resizedImage.Save( backupPath, ImageFormat.Png );
						File.Delete( destImgPath );
						File.Move( backupPath, destImgPath );
					}
					catch( Exception ex )
					{
						MessageBox.Show( "Non-supported images." );
						SimpleLog.WriteLine( $"src:{srcImgPath}, dest:{destImgPath}, {ex.Message}" );
					}
					finally
					{
						if( File.Exists( backupPath ) )
						{
							File.Delete( backupPath );
						}
					}
				}
				else
				{
					resizedImage.Save( destImgPath, ImageFormat.Png );
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( "Non-supported images." );
				SimpleLog.WriteLine( $"src:{srcImgPath}, dest:{destImgPath}, {ex.Message}" );
			}
		}

		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnCutinDel_Click( object sender, EventArgs e )
		{
			if( File.Exists( TempDirDef.CutinPath ) == false ) return;

			string mes = "Do you want to delete it?";
			var result = MessageBox.Show( mes, "Info", MessageBoxButtons.YesNo );

			if( result != DialogResult.Yes ) return;

			ClearCutin();

			if( File.Exists( TempDirDef.CutinPath ) )
			{
				File.Delete( TempDirDef.CutinPath );
			}
		}




		// ------------------------------------------------------------------------------------------------------------------------
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


		// ------------------------------------------------------------------------------------------------------------------------
		private void SoundSelect_CheckedChanged( object sender, EventArgs e )
		{
			UpdateSoundList();
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnSoundAdd_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Sound File|*.wav;*.mp3;*.ogg",
				Multiselect = true,
			};

			var result = ofd.ShowDialog();

			if( result == DialogResult.OK )
			{
				foreach( var item in ofd.FileNames )
				{
					string fileName = Path.GetFileName( item );
					string soundPath = Path.Combine( SelectingSoundPath, fileName );
					File.Copy( item, soundPath, true );
				}
				UpdateSoundList();
			}
		}

		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnSoundDel_Click( object sender, EventArgs e )
		{
			ListRemove( LbSounds, SelectingSoundPath );
		}


		// ------------------------------------------------------------------------------------------------------------------------
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

				UpdateSoundList();
			}
		}






		// ------------------------------------------------------------------------------------------------------------------------
		void PlaySound( ListBox lb )
		{
			string soundName = lb.SelectedItem.ToString()!;
			string soundPath = Path.Combine( SelectingSoundPath, soundName );

			if( File.Exists( soundPath ) == false )
			{
				MessageBox.Show( $"{soundName} is not found." );
				return;
			}

			SoundMgr.LoadSound( soundPath );
			SoundMgr.Play();
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnSoundPlay_Click( object sender, EventArgs e )
		{
			PlaySound( LbSounds );
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void LbSounds_DoubleClick( object sender, EventArgs e )
		{
			PlaySound( LbSounds );
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnSoundStop_Click( object sender, EventArgs e )
		{
			SoundMgr?.Stop();
		}


	}
}