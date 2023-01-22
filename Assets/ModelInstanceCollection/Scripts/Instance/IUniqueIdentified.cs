using System;

namespace ModelInstanceCollection
{
    public class IUniqueIdentified
    {

        public string uid = "0";
        public string UID
        {
            get
            {
                if (uid == "0")
                {
                    uid = Guid.NewGuid().ToString();
                }
                return uid;
            }
        }
        public void InitializeUID()
        {
            var localUID = UID;
        }
    }
}