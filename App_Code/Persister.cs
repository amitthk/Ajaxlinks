using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace ajaxPostDemo
{
    /// <summary>
    /// Summary description for Persister
    /// </summary>
    public class Persister<T>
    {
        private string _dataFileName;
        private List<T> _objList;

        public List<T> objList
        {
            get { return (_objList); }
        }

        public Persister(string dataFileName)
        {
            //
            // TODO: Add constructor logic here
            //
            this._dataFileName = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", dataFileName));
            this._objList = Activator.CreateInstance<List<T>>();
        }

        public void save()
        {
            lock (_dataFileName)
            {
                using (FileStream writer = File.Create(_dataFileName))
                {
                    XmlSerializer serializer = new XmlSerializer(_objList.GetType());
                    serializer.Serialize(writer, _objList);
                }
            }
        }

        public void load()
        {
            if (File.Exists(_dataFileName))
            {
                lock (_dataFileName)
                {
                    using (FileStream reader = File.Open(_dataFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                        _objList = (List<T>)serializer.Deserialize(reader);
                    }
                }
            }
            else
            {
                _objList = new List<T>();
                save();
            }
        }
    }
}