using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.Files.Xml
{
    public class Xml<T> : IFile<T>
    {
        public bool Read(string file, out T data)
        {
            data = default;

            try
            {
                using (XmlReader reader = new XmlTextReader(file) )
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    data = (T)ser.Deserialize(reader);
                }

                return true;

            }
            finally
            {
                
            }

        }

        public bool Save(string file, T data)
        {
            if(data != null && file != null)
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(file, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    serializer.Serialize(xmlTextWriter, data);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
