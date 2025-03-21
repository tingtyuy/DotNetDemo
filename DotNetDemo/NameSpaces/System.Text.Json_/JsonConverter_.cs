using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNetDemo.NameSpaces.System.Text.Json_
{
    public class LseDateTimeConverter : JsonConverter<DateTime>
    {
        private const string _formatDate = "yyyy-MM-dd HH:mm:ss";

        private static DateTime _dateTimeUtc1970 = Convert.ToDateTime("1970-1-1");

        //private const string _formatBeiJingDate = "yyyy-MM-ddTHH:mm:ss";

        //private const string _formatISODate = "yyyy-MM-ddTHH:mm:ss.000Z";

        public LseDateTimeConverter()
        {
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? dataStr = reader.GetString();
            if (string.IsNullOrEmpty(dataStr))
                return _dateTimeUtc1970;

            DateTime date = DateTime.Now;
            if (DateTime.TryParse(dataStr, out date))
                return date;

            return _dateTimeUtc1970;

        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_formatDate, CultureInfo.InvariantCulture));
        }
    }


    /// <summary>
    /// 类型转换
    /// </summary>
    public class ResModelDiscriminator : JsonConverter<ResModel>
    {

        public override bool CanConvert(Type typeToConvert) =>
           typeof(ResModel).IsAssignableFrom(typeToConvert);

        public override ResModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            Utf8JsonReader readerClone = reader;
            if (readerClone.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            readerClone.Read();
            if (readerClone.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = readerClone.GetString();
            if (!"ResType".Equals(propertyName, StringComparison.OrdinalIgnoreCase))
            {
                throw new JsonException();
            }

            readerClone.Read();
            if (readerClone.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            //ResTypeEnum typeDiscriminator = (ResTypeEnum)readerClone.GetInt32();
            //Type resType = TypeConverter.GetResType(typeDiscriminator);

            //ResModel? myRes = JsonSerializer.Deserialize(ref reader, resType, JsonSerializerOptions_.Options)! as ResModel;
            ResModel? myRes = JsonSerializer.Deserialize(ref reader, null, JsonSerializerOptions_.Options)! as ResModel;

            return myRes;





            //while (reader.Read())
            //{
            //    if (reader.TokenType == JsonTokenType.EndObject)
            //    {
            //        return myRes;
            //    }
            //    switch (reader.TokenType)
            //    {
            //        case JsonTokenType.String when (_converterOptions & EnumConverterOptions.AllowStrings) != 0:
            //            if (TryParseEnumFromString(ref reader, out T result))
            //            {
            //                return result;
            //            }
            //            break;

            //        case JsonTokenType.Number when (_converterOptions & EnumConverterOptions.AllowNumbers) != 0:
            //            switch (s_enumTypeCode)
            //            {
            //                case TypeCode.Int32 when reader.TryGetInt32(out int int32): return Unsafe.As<int, T>(ref int32);
            //                case TypeCode.UInt32 when reader.TryGetUInt32(out uint uint32): return Unsafe.As<uint, T>(ref uint32);
            //                case TypeCode.Int64 when reader.TryGetInt64(out long int64): return Unsafe.As<long, T>(ref int64);
            //                case TypeCode.UInt64 when reader.TryGetUInt64(out ulong uint64): return Unsafe.As<ulong, T>(ref uint64);
            //                case TypeCode.Byte when reader.TryGetByte(out byte ubyte8): return Unsafe.As<byte, T>(ref ubyte8);
            //                case TypeCode.SByte when reader.TryGetSByte(out sbyte byte8): return Unsafe.As<sbyte, T>(ref byte8);
            //                case TypeCode.Int16 when reader.TryGetInt16(out short int16): return Unsafe.As<short, T>(ref int16);
            //                case TypeCode.UInt16 when reader.TryGetUInt16(out ushort uint16): return Unsafe.As<ushort, T>(ref uint16);
            //            }
            //            break;
            //    }






            //}

        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, ResModel value, JsonSerializerOptions options)
        {
            try
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), JsonSerializerOptions_.Options);

                //writer.WriteStartObject();

                //if (value is EquipmentModel)
                //{
                //    writer.WriteNumber("EquipmentModel", value.Health);
                //}
                //else
                //{
                //    writer.WriteString("OfficeNumber", "Other");
                //}

                //writer.WriteString("Name", value.Name);

                //writer.WriteEndObject();
            }
            catch (Exception ex)
            {
                if (ex is not null)
                {

                }
            }
        }

    }

    public class ResModel
    {

    }
}
