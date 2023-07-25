using System.Runtime.InteropServices;

namespace SpellWork.DBC
{
    static class DBCReader
    {
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        /// <exception cref="FileNotFoundException"><c>FileNotFoundException</c>.</exception>
        public static async Task<Dictionary<uint, T>> ReadDBC<T>(Dictionary<uint, string> strDict) where T : unmanaged
        {
            var dict = new Dictionary<uint, T>();
            var fileName = Path.Combine(DBC.DbcPath, typeof(T).Name + ".dbc").Replace("Entry", String.Empty);

            var bytes = await Globals.FileSystem.ReadFile(fileName);
            
            var reader = new MemoryBinaryReader(bytes);
            if (!Globals.FileSystem.Exists(fileName))
                throw new FileNotFoundException();
            // read dbc header
            var header = reader.ReadStruct<DbcHeader>();
            var size = Marshal.SizeOf<T>();

            if (!header.IsDBC)
                throw new Exception(fileName + " is not DBC files!");

            if (header.RecordSize != size)
                throw new Exception(string.Format("Size of row in DBC file ({0}) != size of DBC struct ({1}) in DBC: {2}", header.RecordSize, size, fileName));

            dict.EnsureCapacity(header.RecordsCount);
            
            // read dbc data
            for (var r = 0; r < header.RecordsCount; ++r)
            {
                var key = reader.ReadUInt32();
                reader.Position -= 4;

                var entry = reader.ReadStruct<T>();

                dict.Add(key, entry);
            }

            // read dbc strings
            if (strDict != null)
            {
                strDict.EnsureCapacity(header.StringTableSize);
                var startStringPosition = header.StartStringPosition;
                while (reader.Position != reader.Length)
                {
                    var offset = (uint)(reader.Position - startStringPosition);
                    var str    = reader.ReadCString();
                    strDict.Add(offset, str);
                }
            }
            return dict;
        }
    }
}
