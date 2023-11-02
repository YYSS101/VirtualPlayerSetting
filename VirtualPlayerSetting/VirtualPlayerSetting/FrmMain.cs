using MLib;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace VirtualPlayerSetting
{
	public partial class FrmMain : Form
	{

		SoundPlayer SoundPlayClient = new();


		public FrmMain()
		{
			InitializeComponent();
		}



		string IconFileName = "Icon.png";

		string PackageExt = ".zip";     // テスト用拡張子
																		//		string PackageExt = ".ysvp";



		private void Form1_Load( object sender, EventArgs e )
		{
			Directory.Delete( PathMgr.TempPath, true );
		}


		private void FrmMain_FormClosed( object sender, FormClosedEventArgs e )
		{
			PbIcon.Image = null;
			Directory.Delete( PathMgr.TempPath, true );
		}





		void ViewAllClear()
		{
			TbName.Clear();

			ClearIcon();
		}


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
			string imgPath = Path.Combine( PathMgr.TempPath, IconFileName );
			PbIcon.Image = Image.FromFile( imgPath );
		}

		void UpdateSound()
		{
			LbSounds.Items.Clear();

			string[] files = Directory.GetFiles( PathMgr.SoundPath );

			foreach( string file in files )
			{
				LbSounds.Items.Add( Path.GetFileName( file ) );
			}
		}


		private void BtnLoad_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = $"Virtual Player File|*{PackageExt}",
				InitialDirectory = PathMgr.VPlayerPath

			};

			var result = ofd.ShowDialog();

			if( result == DialogResult.OK )
			{
				ViewAllClear();

				string zipPath = ofd.FileName;

				using( var archive = ZipFile.OpenRead( zipPath ) )
				{
					foreach( var entry in archive.Entries )
					{
						Debug.WriteLine( entry );
					}

					Directory.Delete( PathMgr.TempPath, true );
					ZipFile.ExtractToDirectory( zipPath, PathMgr.TempPath );

					// UI更新
					TbName.Text = Path.GetFileNameWithoutExtension( zipPath );

					UpdateIcon();
					UpdateSound();
				}

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

				string packagePath = Path.Combine( PathMgr.VPlayerPath, TbName.Text + PackageExt );

				if( File.Exists( packagePath ) )
				{
					string message = $"{TbName.Text} is already exists. override Ok ?";

					var ret = MessageBox.Show( message, "Warning", MessageBoxButtons.YesNo );

					if( ret != DialogResult.Yes ) return;

					string backupPath = packagePath + "_backup";

					// 生成や削除に失敗した時にファイルを復元出来るようバックアップしておく
					ZipFile.CreateFromDirectory( PathMgr.TempPath, backupPath );
					File.Delete( packagePath );
					File.Move( backupPath, packagePath );
				}
				else
				{
					ZipFile.CreateFromDirectory( PathMgr.TempPath, packagePath );
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
				string srcImgPath = ofd.FileName;
				string destImgPath = Path.Combine( PathMgr.TempPath, IconFileName );

				try
				{
					// 画像をPNG形式に変換して保存
					using( Image inputImage = Image.FromFile( srcImgPath ) )
					{
						int w = 128;
						int h = 128;

						using( Bitmap resizedImage = new Bitmap( w, h ) )
						using( Graphics graphics = Graphics.FromImage( resizedImage ) )
						{
							// 画像をリサイズ
							graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
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

							// アイコン更新
							UpdateIcon();

						}
					}
				}
				catch( Exception ex )
				{
					MessageBox.Show( "非対応の画像形式です。" );

					SimpleLog.WriteLine( $"src:{srcImgPath}, dest:{destImgPath}, {ex.Message}" );
				}

			}

		}

		private void BtnIconDel_Click( object sender, EventArgs e )
		{

		}

		private void BtnSoundAdd_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				//				Filter = "Sound File|*.wav;*.mp3;"
				Filter = "File|*.*",
				Multiselect = true,
			};

			var result = ofd.ShowDialog();

			if( result == DialogResult.OK )
			{

				foreach( var item in ofd.FileNames )
				{
					string fileName = Path.GetFileName( item );
					LbSounds.Items.Add( fileName );

					string soundPath = Path.Combine( PathMgr.SoundPath, fileName );
					File.Copy( item, soundPath, true );
				}
			}
		}

		private void BtnSoundDel_Click( object sender, EventArgs e )
		{
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
			string soundPath = Path.Combine( PathMgr.SoundPath, soundName );

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



	}
}