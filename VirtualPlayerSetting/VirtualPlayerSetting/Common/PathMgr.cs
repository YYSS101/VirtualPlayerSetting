using System.IO;
using System;

namespace MLib
{
	/// <summary>
	/// 色んなプロジェクトで共通で使えるLib
	/// 2023.9.19 .Netで単一ファイル出力に対応、Assembly.GetExecutingAssembly()の使用を廃止
	/// </summary>
	public static class PathMgr
	{

		/// <summary>
		/// 実行フォルダパス
		/// </summary>
		public static string AppPath
		{
			// System.Reflection.Assembly.GetExecutingAssembly().Locationは、
			// .Netで単一ファイル出力するとnullになるので廃止
			get { return AppContext.BaseDirectory; }
		}

		/// <summary>
		/// ログフォルダパス
		/// </summary>
		public static string LogPath
		{
			get { return GetAndCreateDirectoryPath( AppPath, "Log" ); }
		}

		/// <summary>
		/// 一時フォルダパス
		/// </summary>
		public static string TempPath
		{
			get { return GetAndCreateDirectoryPath( AppPath, "Temp" ); }
		}

		/// <summary>
		/// 音声フォルダパス
		/// </summary>
		public static string SoundPath
		{
			get { return GetAndCreateDirectoryPath( AppPath, "Sound" ); }
		}



		/// <summary>
		/// パッケージパス
		/// </summary>
		public static string VPlayerPath
		{
			get { return GetAndCreateDirectoryPath( AppPath, "VPlayer" ); }
		}



		/// <summary>
		/// パス取得、存在しなければディレクトリとして作成する
		/// </summary>
		/// <param name="dirPath1">メインディレクトリ</param>
		/// <param name="dirPath2">サブディレクトリ</param>
		/// <returns>引数を結合したパス</returns>
		private static string GetAndCreateDirectoryPath( string dirPath1, string dirPath2 )
		{
			string path = Path.Combine( dirPath1, dirPath2 );

			if( Directory.Exists( path ) is false )
			{
				Directory.CreateDirectory( path );
			}

			return path;
		}


	}
}
