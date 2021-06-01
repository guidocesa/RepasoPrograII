using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Application.Files.Text
{
    public class Text<T> : IFile<T>
    {
        public bool Read(string file, out T data)
        {
            data = default;
            Stream fs = new FileStream(file, FileMode.Open);
            BinaryFormatter ser = new BinaryFormatter();

            try
            {
                data = (T) ser.Deserialize(fs);
                
            }
            finally
            {
                fs.Close();
            }

            return true;
        }

        public bool Save(string file, T data)
        {
            Stream writer = new FileStream(file, FileMode.Create);

            BinaryFormatter ser = new BinaryFormatter();

            try
            {
                ser.Serialize(writer, data);

                writer.Close();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return true;
        }
    }
}
