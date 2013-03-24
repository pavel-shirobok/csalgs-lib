using System;
using System.Text;
using System.IO;

namespace csalgs.formats
{
	public class AgrRecord
	{
		private bool _readFlag = false;
		private const int CODE_PAGE = 1251;

		private float[] _transmittence;
		private float[] _radius;
		private DateTime _date;
		private string _name;
		private string _reagent;
		private int _count;

		public AgrRecord() {
		
		}

		public void ReadBytes(byte[] bytes){
			if (_readFlag) return;
			Read(bytes);
			_readFlag = true;
		}

		private void Read(byte[] bytes) {
			MemoryStream byteStream = new MemoryStream(bytes, 0, bytes.Length);
			BinaryReader binaryReader = new BinaryReader(byteStream);

			byte seconds, minutes, hours, days, month, separator, digit, digit_2;
			UInt16 year, nameStringLen, reagentStringLen, dataCount;
			byte[] tempByteString;
			string nameString, reagentString;
			float[] transmittenceColumn, radiusColumn;

			seconds = binaryReader.ReadByte();
			minutes = binaryReader.ReadByte();
			hours = binaryReader.ReadByte();
			days = binaryReader.ReadByte();
			month = binaryReader.ReadByte();
			year = binaryReader.ReadUInt16();
			separator = binaryReader.ReadByte();

			nameStringLen = binaryReader.ReadUInt16();
			tempByteString = binaryReader.ReadBytes(nameStringLen);
			nameString = Encoding.GetEncoding(CODE_PAGE).GetString(tempByteString);

			reagentStringLen = binaryReader.ReadUInt16();
			tempByteString = binaryReader.ReadBytes(reagentStringLen);
			reagentString = Encoding.GetEncoding(CODE_PAGE).GetString(tempByteString);

			//unknow digit
			digit = binaryReader.ReadByte();
			dataCount = binaryReader.ReadUInt16();
			//second unknow digit
			digit_2 = binaryReader.ReadByte();


			transmittenceColumn = new float[dataCount];
			for (uint i = 0; i < dataCount; i++)
			{
				transmittenceColumn[i] = binaryReader.ReadSingle();
			}

			radiusColumn = new float[dataCount];
			for (uint i = 0; i < dataCount; i++)
			{
				radiusColumn[i] = binaryReader.ReadSingle();
			}

			binaryReader.Close();
			byteStream.Close();

			_date = ConvertDate(seconds, minutes, hours, days, month, year);
			_count = dataCount;
			_name = nameString;
			_reagent = reagentString;

			_transmittence = transmittenceColumn;
			_radius = radiusColumn;

		}

		private DateTime ConvertDate(byte seconds, byte minutes, byte hour, byte day, byte month, UInt16 year) {
			return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minutes), Convert.ToInt32(seconds));
		}

		public float TransmittenceAt(int i){
			return _transmittence[i]; 
		}

		public float[] RadiusData {
			get {
				return _radius;
			}
		}

		public float[] TransmittenceData {
			get {
				return _transmittence;
			}
		}

		public float RadiusAt(int i)
		{
			return _radius[i];
		}

		public string Reagent {
			get {
				return _reagent;
			}
		}

		public string Name { 
			get {
				return _name;
			} 
		}

		public DateTime DateOfTest {
			get {
				return _date;
			}
		}
	}
}
