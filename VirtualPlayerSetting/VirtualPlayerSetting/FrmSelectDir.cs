using MLib;
using System.IO.Compression;
using VirtualPlayerSetting.Common;

namespace VirtualPlayerSetting
{
	public partial class FrmSelectDir : Form
	{
		/// <summary>
		/// 選択されたフォルダのパス
		/// </summary>
		public string SelectedDirPath { get; private set; } = "";


		// ------------------------------------------------------------------------------------------------------------------------
		public FrmSelectDir()
		{
			InitializeComponent();
		}


		// ------------------------------------------------------------------------------------------------------------------------
		void UpdatePlayerList()
		{
			var players = Directory.GetDirectories( PathMgr.VPlayer );

			LbPlayer.Items.Clear();
			foreach( var player in players )
			{
				LbPlayer.Items.Add( Path.GetFileName( player )! );
			}
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void FrmSelectDir_Load( object sender, EventArgs e )
		{
			UpdatePlayerList();
		}


		// ------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// ダブルクリックで読み込み
		/// </summary>
		private void LbPlayer_DoubleClick( object sender, EventArgs e )
		{
			var name = LbPlayer.SelectedItem;
			if( name == null ) return;

			if( LbPlayer.SelectedItems.Count > 1 )
			{
				MessageBox.Show( "Please select only one." );
				return;
			}

			SelectedDirPath = Path.Combine( PathMgr.VPlayer, name.ToString()! );
			DialogResult = DialogResult.OK;
			Close();
		}


		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnDelete_Click( object sender, EventArgs e )
		{
			var name = LbPlayer.SelectedItem;
			if( name == null ) return;

			string mes = "Do you want to delete it?";
			var ret = MessageBox.Show( mes, "Warning", MessageBoxButtons.YesNo );

			if( ret != DialogResult.Yes ) return;

			foreach( var it in LbPlayer.SelectedItems )
			{
				var fullPath = Path.Combine( PathMgr.VPlayer, it.ToString()! );

				if( Directory.Exists( fullPath ) )
				{
					Directory.Delete( fullPath, true );
				}
			}

			UpdatePlayerList();
		}

		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnExport_Click( object sender, EventArgs e )
		{
			var name = LbPlayer.SelectedItem;
			if( name == null )
			{
				MessageBox.Show( "Please select player." );
				return;
			}

			FolderBrowserDialog dlg = new()
			{
				InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory ),
			};
			var result = dlg.ShowDialog();

			if( result != DialogResult.OK ) return;

			int cnt = 0;

			foreach( var it in LbPlayer.SelectedItems )
			{
				string srcPath = Path.Combine( PathMgr.VPlayer, it.ToString()! );
				string srcName = Path.GetFileName( it.ToString()! );
				string destPath = Path.Combine( dlg.SelectedPath, srcName + ".ysvp" );

				try
				{
					ZipFile.CreateFromDirectory( srcPath, destPath );
				}
				catch( Exception ex )
				{
					MessageBox.Show( ex.Message );
				}
				cnt++;
			}

			MessageBox.Show( $"{cnt} files successfully exported." );
		}

		// ------------------------------------------------------------------------------------------------------------------------
		private void BtnImport_Click( object sender, EventArgs e )
		{
			OpenFileDialog dlg = new()
			{
				InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory ),
				Filter = "Virtual Player File(*.ysvp)|*.ysvp",
				Multiselect = true,
			};
			var result = dlg.ShowDialog();

			if( result != DialogResult.OK ) return;

			int cnt = 0;

			foreach( string it in dlg.FileNames )
			{
				string srcPath = it;
				string srcName = Path.GetFileNameWithoutExtension( srcPath );
				string destPath = Path.Combine( PathMgr.VPlayer, srcName );

				try
				{
					if( Directory.Exists( destPath ) )
					{
						string mes = $"[ {srcName} ] already exists.\r\nDo you want to overwrite it?";
						var ret = MessageBox.Show( mes, "Warning", MessageBoxButtons.YesNo );

						if( ret != DialogResult.Yes ) continue;

						string tempPath = destPath + "_temp";
						ZipFile.ExtractToDirectory( srcPath, tempPath, true );
						Directory.Delete( destPath, true );
						Directory.Move( tempPath, destPath );
					}
					else
					{
						ZipFile.ExtractToDirectory( srcPath, destPath, true );
					}
				}
				catch( Exception ex )
				{
					MessageBox.Show( ex.Message );
				}
				cnt++;
			}

			MessageBox.Show( $"{cnt} files successfully imported." );

			UpdatePlayerList();
		}


	}
}
