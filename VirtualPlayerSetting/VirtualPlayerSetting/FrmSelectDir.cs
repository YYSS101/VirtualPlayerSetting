using MLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VirtualPlayerSetting.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VirtualPlayerSetting
{
	public partial class FrmSelectDir : Form
	{
		public string SelectedPlayerDirPath { get; private set; } = "";




		public FrmSelectDir()
		{
			InitializeComponent();
		}


		void UpdatePlayerList()
		{
			var players = Directory.GetDirectories( PathMgr.VPlayer );

			LbPlayer.Items.Clear();
			foreach ( var player in players )
			{
				LbPlayer.Items.Add( Path.GetFileName( player )! );
			}
		}




		private void FrmSelectDir_Load( object sender, EventArgs e )
		{
			UpdatePlayerList();
		}



		private void LbPlayer_DoubleClick( object sender, EventArgs e )
		{
			SelectedPlayerDirPath = Path.Combine( PathMgr.VPlayer, LbPlayer.SelectedItem.ToString()! );
			DialogResult = DialogResult.OK;
			Close();
		}



		private void BtnLoad_Click( object sender, EventArgs e )
		{
			FolderBrowserDialog ofd = new()
			{
				InitialDirectory = PathMgr.VPlayer,
			};

			var result = ofd.ShowDialog();

			if( result == DialogResult.OK )
			{
				// Copy to VPlayer dir.
				string srcPath = ofd.SelectedPath;
				string srcName = Path.GetDirectoryName( srcPath )!;

				ParameterDefine src = new( srcPath );
				string destPath = Path.Combine( PathMgr.VPlayer, srcName );

				if( ParameterMgr.FileSave( destPath, src ) == false )
				{
					return;
				}

				UpdatePlayerList();
			}

		}


	}
}
