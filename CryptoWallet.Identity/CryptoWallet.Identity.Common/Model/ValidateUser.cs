using System.Runtime.Serialization;

namespace CryptoWallet.Identity.Common.Model
{
    [DataContract]
    public class ValidateUser
    {
        [DataMember]
        public string NetworkName { get; set; }

        [DataMember]
        public int? NextPasswordChange { get; set; }

        [DataMember]
        public int? Result { get; set; }

        [DataMember]
        public string SessionID { get; set; }

        [DataMember]
        public int? UserID { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
