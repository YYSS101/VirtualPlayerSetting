using MLib;
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Media;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using VirtualPlayerSetting.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace VirtualPlayerSetting
{
	public partial class FrmMain : Form
	{

		SoundPlayer SoundPlayClient = new();


		string IconFileName = "Icon.png";

		string PackageExt = ".zip";     // �e�X�g�p�g���q
																		//		string PackageExt = ".ysvp";







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
			Directory.Delete( PathMgr.Temp, true );
		}


		private void FrmMain_FormClosed( object sender, FormClosedEventArgs e )
		{
			ViewAllClear();
			Directory.Delete( PathMgr.Temp, true );
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
			string imgPath = Path.Combine( PathMgr.Temp, IconFileName );
			PbIcon.Image = Image.FromFile( imgPath );
		}

		void UpdateSound()
		{
			LbSounds.Items.Clear();

			string[] files = Directory.GetFiles( PathMgr.TempSound );

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
				InitialDirectory = PathMgr.VPlayer
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

					Directory.Delete( PathMgr.Temp, true );
					ZipFile.ExtractToDirectory( zipPath, PathMgr.Temp );

					// UI�X�V
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

				string packagePath = Path.Combine( PathMgr.VPlayer, TbName.Text + PackageExt );

				if( File.Exists( packagePath ) )
				{
					string message = $"{TbName.Text} is already exists. override Ok ?";

					var ret = MessageBox.Show( message, "Warning", MessageBoxButtons.YesNo );

					if( ret != DialogResult.Yes ) return;

					string backupPath = packagePath + "_backup";

					// ������폜�Ɏ��s�������Ƀt�@�C���𕜌��o����悤�o�b�N�A�b�v���Ă���
					ZipFile.CreateFromDirectory( PathMgr.Temp, backupPath );
					File.Delete( packagePath );
					File.Move( backupPath, packagePath );
				}
				else
				{
					ZipFile.CreateFromDirectory( PathMgr.Temp, packagePath );
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
				string destImgPath = Path.Combine( PathMgr.Temp, IconFileName );

				try
				{
					// �摜��PNG�`���ɕϊ����ĕۑ�
					using( Image inputImage = Image.FromFile( srcImgPath ) )
					{
						int w = 128;
						int h = 128;

						using( Bitmap resizedImage = new Bitmap( w, h ) )
						using( Graphics graphics = Graphics.FromImage( resizedImage ) )
						{
							// �摜�����T�C�Y
							graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
							graphics.DrawImage( inputImage, 0, 0, w, h );


							// ���T�C�Y���ꂽ�摜��PNG�`���ŕۑ�
							if( File.Exists( destImgPath ) )
							{
								string backupPath = destImgPath + "_backup";

								// ������폜�Ɏ��s�������Ƀt�@�C���𕜌��o����悤�o�b�N�A�b�v���Ă���
								resizedImage.Save( backupPath, ImageFormat.Png );
								ClearIcon();
								File.Delete( destImgPath );
								File.Move( backupPath, destImgPath );
							}
							else
							{
								resizedImage.Save( destImgPath, ImageFormat.Png );
							}

							// �A�C�R���X�V
							UpdateIcon();

						}
					}
				}
				catch( Exception ex )
				{
					MessageBox.Show( "��Ή��̉摜�`���ł��B" );

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

					string soundPath = Path.Combine( PathMgr.TempSound, fileName );
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
				e.Handled = true; // ��p��̕����𖳌��ɂ���
			}
		}



		void PlaySound( ListBox lb )
		{
			string soundName = lb.SelectedItem.ToString()!;
			string soundPath = Path.Combine( PathMgr.TempSound, soundName );

			if( File.Exists( soundPath ) == false )
			{
				MessageBox.Show( "�Ώۂ̉��������݂��܂���B" );
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