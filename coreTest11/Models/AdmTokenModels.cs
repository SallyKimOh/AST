using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace coreTest11.Models
{
    public class AdmTokenModels
    {
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public string expires_in { get; set; }
        [DataMember]
        public string scope { get; set; }
        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string issued { get; set; }
        [DataMember]
        public string expires { get; set; }

    }
}
