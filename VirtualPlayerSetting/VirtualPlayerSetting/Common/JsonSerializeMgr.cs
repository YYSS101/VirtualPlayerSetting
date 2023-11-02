using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace MLib
{
	/// <summary>
	/// シリアライズクラス
	/// </summary>
	/// <remarks>
	/// 2022.1.25 m.ueda
	/// </remarks>
	[Serializable()]
	public static class JsonSerializeMgr
	{
		///  <summary>
		/// 指定ファイルへシリアライズする処理（JSON形式ファイルの書き込み処理）
		/// </summary>
		/// <param name="target">JSONへ保存するオブジェクト</param>
		/// <param name="filePath">保存XJSONファイルパス</param>
		/// <param name="mode">ファイル作成モード</param>
		/// <returns>True:成功　False:失敗</returns>
		public static bool Serialize( object target, string filePath, FileMode mode = FileMode.Create )
		{
			bool isResult = false;
			FileStream? sysFs = null;

			try
			{
				//ターゲットが空の場合
				if( target == null )
				{
					return false;
				}

				Directory.CreateDirectory( Path.GetDirectoryName( filePath )! );

				DataContractJsonSerializer sysJson = new DataContractJsonSerializer( target.GetType() );

				sysFs = new FileStream( filePath, mode, FileAccess.Write, FileShare.Read );

				var sysWriter = JsonReaderWriterFactory.CreateJsonWriter( sysFs, Encoding.UTF8, true, true, "    " );

				sysJson.WriteObject( sysWriter, target );

				sysWriter.Dispose();

				isResult = true;

			}
			catch( Exception ex )
			{
				Debug.WriteLine( $"SerializeJson:{ex.Message}" );
			}
			finally
			{
				if( !( sysFs is null ) )
				{
					sysFs.Close();
				}
			}

			return isResult;
		}

		///  <summary>
		/// 指定ファイルからデシリアライズする処理（XML形式ファイルの読み込み処理）
		/// </summary>
		/// <param name="targetType">XMLから読み込むするオブジェクトタイプ</param>
		/// <param name="filePath">読込XMLファイルパス</param>
		/// <returns>True:成功　False:失敗</returns>
		public static object? DeSerialize( Type targetType, string filePath )
		{
			object? objReturn = null;
			FileStream? sysFs = null;

			try
			{
				objReturn = null;

				if( File.Exists( filePath ) == false )
				{
					//ファイルがない場合
					return null;
				}

				DataContractJsonSerializer sysJson = new DataContractJsonSerializer( targetType );
				sysFs = new FileStream( filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );

				var reader = JsonReaderWriterFactory.CreateJsonReader( sysFs, System.Xml.XmlDictionaryReaderQuotas.Max );

				objReturn = sysJson.ReadObject( reader );

				reader.Dispose();
			}
			catch( Exception ex )
			{
				Debug.WriteLine( $"DeSerializeJson:{ex.Message}" );
			}
			finally
			{
				if( !( sysFs is null ) )
				{
					sysFs.Close();
				}
			}

			return objReturn;

		}


	}

}