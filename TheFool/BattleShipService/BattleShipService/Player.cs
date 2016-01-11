using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace BattleShipService
{
    [DataContract]
    public class Player
    {
        public string name;
        public string passwd;
        public IPortalCallback iPortal_Callback;
        public IChatCallback IchatCallBack;

        public Player(string name, string passwd)
        {
            this.Name = name;
            this.Passwd = passwd;
        }
        [DataMember]
        public string Name { get { return this.name; } set { this.name = value; } }
        [DataMember]
        public string Passwd { get { return this.passwd; } set { this.passwd = value; } }

        public IPortalCallback IPortal_Callback { get; set; }
    }
}
