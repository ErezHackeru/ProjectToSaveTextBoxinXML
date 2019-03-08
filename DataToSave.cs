using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SaveLoadState
{
    public class DataToSave
    {
        public string Textbox1 { get; set; }
        public string Textbox2 { get; set; }
        public string Textbox3 { get; set; }

        public List<string> AllCheckeditems { get; set; }

        public DataToSave()
        {

        }
        public DataToSave(string textbox1, string textbox2, string textbox3, List<string> allCheckeditems)
        {
            this.Textbox1 = textbox1;
            this.Textbox2 = textbox2;
            this.Textbox3 = textbox3;
            this.AllCheckeditems = allCheckeditems;
        }

        //===========================
        //Static Part of the Class
        //===========================
        static XmlSerializer myXmlSerializer = new XmlSerializer(typeof(DataToSave));
        public static void SerializeADataToSave(string FilePath , DataToSave dataBlock)
        {
            using (Stream file = new FileStream (FilePath, FileMode.Create))
            {
                myXmlSerializer.Serialize(file, dataBlock);
            }
        }

        public static DataToSave DeserializeACar(string fileName)
        {
            DataToSave dataBlockResult;            
            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                dataBlockResult = myXmlSerializer.Deserialize(file) as DataToSave;
            }
            return dataBlockResult;
        }
    }
}
