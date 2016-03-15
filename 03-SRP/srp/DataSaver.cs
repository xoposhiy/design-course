using System;
using System.IO;

namespace Srp
{
	public class DataSaver
	{
		public static void SaveData(string filename, byte[] data)
		{
			using (var timeFile = new FileStream(filename + ".time", FileMode.OpenOrCreate))
			{
				using (var newFile = new FileStream(filename, FileMode.OpenOrCreate))
				{
					var backupFilename = Path.ChangeExtension(filename, "bkp");
					var backupFile = new FileStream(backupFilename, FileMode.OpenOrCreate);
					newFile.Write(data, 0, data.Length);
					backupFile.Write(data, 0, data.Length);
				}

				var time = BitConverter.GetBytes(DateTime.Now.Ticks);
				timeFile.Write(time, 0, time.Length);
			}
		}
	}
}