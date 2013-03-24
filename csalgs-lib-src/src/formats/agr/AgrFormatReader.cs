using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

// ReSharper disable CheckNamespace
namespace csalgs.formats
// ReSharper restore CheckNamespace
{
	public class AgrFormatReader
	{
		
		public BloodAggregationData[] Read(byte[] bytes)
		{
			return Read(new MemoryStream(bytes));
		}

		public BloodAggregationData[] Read(Stream stream)
		{
			long len = stream.Length;

			if (len == 0) return new BloodAggregationData[] {};

			var binaryReader = new BinaryReader(stream);
			var dataList = new List<BloodAggregationData>();
			
			while (stream.Position < len)
			{
				var sectorBytes = ReadSectorBytes(binaryReader);
				var data = ReadDataFromSectorBytes(sectorBytes);
				dataList.Add(data);
			}

			return dataList.ToArray();
		}

		private BloodAggregationData ReadDataFromSectorBytes(byte[] sectorBytes)
		{
			var result = new BloodAggregationData();
			var stream = new MemoryStream(sectorBytes);
			var reader = new BinaryReader(stream);

			var encoding = Encoding.GetEncoding(1251);

			result.DateOfTest = ReadDateTime(reader);
			result.PatientName = ReadString(reader, encoding);
			result.ReagentName = ReadString(reader, encoding);

			reader.ReadByte(); // unknown byte
			var dataCount = reader.ReadUInt16();
			reader.ReadByte(); // another unknown byte

			var transmittanceSelection = ReadFloatSelection(reader, dataCount);
			var radiusSelection = ReadFloatSelection(reader, dataCount);

			for (var index = 0; index < dataCount; index++)
			{
				var averageRadius = radiusSelection[index];
				var averageTransmittance = transmittanceSelection[index];

				result.AddExpirementData(averageRadius, averageTransmittance);
			}

			reader.Close();
			stream.Close();

			return result;
		}

		private static float[] ReadFloatSelection(BinaryReader reader, int dataCount)
		{
			var selection = new float[dataCount];
			for (uint i = 0; i < dataCount; i++)
			{
				selection[i] = reader.ReadSingle();
			}
			return selection;
		}

		private static string ReadString(BinaryReader reader, Encoding encoding)
		{
			var len = reader.ReadUInt16();
			var stringBytes = reader.ReadBytes(len);
			return encoding.GetString(stringBytes);
		}

		private static DateTime ReadDateTime(BinaryReader reader)
		{
			var seconds = reader.ReadByte();
			var minutes = reader.ReadByte();
			var hours = reader.ReadByte();
			var days = reader.ReadByte();
			var month = reader.ReadByte();
			var year = reader.ReadUInt16();

			reader.ReadByte();//skip separator data

			return new DateTime(
								Convert.ToInt32(year), 
								Convert.ToInt32(month), 
								Convert.ToInt32(days), 
								Convert.ToInt32(hours), 
								Convert.ToInt32(minutes), 
								Convert.ToInt32(seconds)
								);
		}

		private static byte[] ReadSectorBytes(BinaryReader reader)
		{
			return reader.ReadBytes(reader.ReadUInt16());
		}

	}
}
