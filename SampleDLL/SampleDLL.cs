/*
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml.Linq;
*/


namespace SampleDLL
{
	public class Class1
	{
		[DllExport]
		public static int Sum( int a, int b )
		{
			return a + b;
		}

		/*
		[DllExport]
		public static bool UnZip( string name )
		{
			string zipPath = @"C:\WorkSpace\VirtualPlayerSetting\VirtualPlayerSetting\VirtualPlayerSetting\bin\Debug\net6.0-windows\VPlayer\Alice.zip";

			using( var archive = ZipFile.OpenRead( zipPath ) )
			{
				foreach( var entry in archive.Entries )
				{
					Debug.WriteLine( entry );
				}

				string dir = Path.GetDirectoryName( zipPath )!;
				string testPath = Path.Combine( dir, "test" );

				Directory.Delete( testPath, true );
				ZipFile.ExtractToDirectory( zipPath, testPath );

			}

			return true;
		}
		*/

	}
}