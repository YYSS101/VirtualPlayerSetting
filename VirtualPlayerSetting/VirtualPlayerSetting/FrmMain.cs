using MLib;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Windows.Forms;

namespace VirtualPlayerSetting
{
	public partial class FrmMain : Form
	{
		public FrmMain()
		{
			InitializeComponent();
		}



		string IconFileName = "Icon.png";
		string SoundDirName = "Sound";



		private void Form1_Load( object sender, EventArgs e )
		{
			Directory.Delete( PathMgr.TempPath, true );
		}


		private void FrmMain_FormClosed( object sender, FormClosedEventArgs e )
		{
			Directory.Delete( PathMgr.TempPath, true );
		}





		void ViewAllClear()
		{
			PbIcon.Image = null;
		}



		private void BtnLoad_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Virtual Player File|*.ysvp",
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

					// PNG画像をPictureBoxに表示
					string imgPath = Path.Combine( PathMgr.TempPath, IconFileName );
					PbIcon.Image = Image.FromFile( imgPath );

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

				string packagePath = Path.Combine( PathMgr.VPlayerPath, TbName.Text + ".ysvp" );

				if( File.Exists( packagePath ) )
				{
					string message = $"{TbName.Text} is already exists. override Ok ?";

					var ret = MessageBox.Show( message, "Warning", MessageBoxButtons.YesNo );

					if( ret != DialogResult.Yes ) return;
				}

				ZipFile.CreateFromDirectory( PathMgr.TempPath, packagePath );

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
				MessageBox.Show( ofd.FileName );

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
							resizedImage.Save( destImgPath, ImageFormat.Png );

							// PNG画像をPictureBoxに表示
							PbIcon.Image = Image.FromFile( destImgPath );
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
				Filter = "Sound File|*.wav;*.mp3;*.ogg"
			};

			var result = ofd.ShowDialog();

			if( result == DialogResult.OK )
			{
				MessageBox.Show( ofd.FileName );
			}
		}

		private void BtnSoundDel_Click( object sender, EventArgs e )
		{

		}

	}
}