﻿using MLib;
using VirtualPlayerSetting.Common;

namespace VirtualPlayerSetting
{
	public partial class FrmSelectDir : Form
	{
		/// <summary>
		/// 選択されたフォルダのパス
		/// </summary>
		public string SelectedDirPath { get; private set; } = "";




		// ----------------------------------------------------------------------------------------------------
		public FrmSelectDir()
		{
			InitializeComponent();
		}


		// ----------------------------------------------------------------------------------------------------
		void UpdatePlayerList()
		{
			var players = Directory.GetDirectories( PathMgr.VPlayer );

			LbPlayer.Items.Clear();
			foreach( var player in players )
			{
				LbPlayer.Items.Add( Path.GetFileName( player )! );
			}
		}


		// ----------------------------------------------------------------------------------------------------
		/// <summary>
		/// フォーム表示時にファイルからリスト読み込み
		/// </summary>
		private void FrmSelectDir_Load( object sender, EventArgs e )
		{
			UpdatePlayerList();
		}


		// ----------------------------------------------------------------------------------------------------
		/// <summary>
		/// ダブルクリックで読み込み
		/// </summary>
		private void LbPlayer_DoubleClick( object sender, EventArgs e )
		{
			var name = LbPlayer.SelectedItem;
			if( name == null ) return;

			SelectedDirPath = Path.Combine( PathMgr.VPlayer, name.ToString()! );
			DialogResult = DialogResult.OK;
			Close();
		}


		// ----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 外部ファイル読み込み
		/// </summary>
		private void BtnLoad_Click( object sender, EventArgs e )
		{
			FolderBrowserDialog ofd = new()
			{
				InitialDirectory = PathMgr.VPlayer,
			};

			var result = ofd.ShowDialog();

			if( result != DialogResult.OK ) return;

			// Copy to VPlayer dir.
			string srcPath = ofd.SelectedPath;
			string srcName = Path.GetFileName( srcPath )!;
			string destPath = Path.Combine( PathMgr.VPlayer, srcName );

			if( ParameterMgr.FileCheckCopy( srcPath, destPath ) == false )
			{
				return;
			}

			UpdatePlayerList();

		}


	}
}
