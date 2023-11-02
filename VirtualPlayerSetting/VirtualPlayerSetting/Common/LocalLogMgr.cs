using System;
using System.IO;

namespace MLib
{
    /// <summary>
    /// システム設定管理
    /// </summary>
    public class SimpleLog
    {
        /// <summary>
        /// Logに吐き出す
        /// </summary>
        public static void WriteLine(string errStr)
        {
            try
            {
                var dt = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                File.AppendAllText(CreateFilePath(), $"{dt}, {errStr}{Environment.NewLine}");
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 日付のログファイル名を生成
        /// </summary>
        private static string CreateFilePath()
        {
            var dt = DateTime.Now.ToString("yyyyMMdd");
            return $"{PathMgr.LogPath}/{dt}.log";
        }

    }

}
