using System;
using System.Collections.Generic;
using System.IO;

namespace csalgs.formats
{
	public class AgrFile
	{

		private List<AgrRecord> _records;
		private string _path;
		public AgrFile() {
			Init();

			
		}

		private void Init() {
			if (_records!=null) {
				Deinit();
			}
			_records = new List<AgrRecord>();
			//_records.Add(new AgrRecord());
		}

		private void Deinit() {
			//clear memory
		}

		public void Open(string path){
			FileStream fileStream = File.OpenRead(path);
			_path = path;
			try
			{
				OpenFromStream(fileStream);
			}
			catch (Exception e) {
				fileStream.Close();
				throw e;
			}

			fileStream.Close();
		}

		private void OpenFromStream(Stream fileStream) {
			Init();
			BinaryReader reader = new BinaryReader(fileStream);

			long position = 0;
			long len = fileStream.Length;
			uint sectorsCount = 0;
			ushort sectorLength;
			AgrRecord tempRecord;
			if (len != 0)
			{
				while (position <= len - 1)
				{
					sectorLength = reader.ReadUInt16();

					tempRecord = new AgrRecord();
					tempRecord.ReadBytes(reader.ReadBytes(sectorLength));
					_records.Add(tempRecord);
					position = fileStream.Position;
					sectorsCount++;
				}
			}

			reader.Close();
		}

		public void Clear() {
			Deinit();
		}

		public AgrRecord this[int i] {
			get {
				return _records[i];
			}
		}

		public List<AgrRecord> Records {
			get {
				return _records;
			}
		}

		public int Count{
			get {
				if (_records == null) return -1;
				return _records.Count;
			}
		}

		public string Path {
			get {
				return _path;
			}
		}

	}
}
