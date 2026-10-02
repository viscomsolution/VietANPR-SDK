using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer
{
    public class SessionRow
    {
        public object[] Values;
    }

    public class Session
    {
        [DisplayName("Biển số")]
        public string Text { get; set; }
        [Browsable(false)]
        public string Alphanumeric { get; set; }
        [DisplayName("Giờ vào")]
        public DateTime CheckinTime { get; set; }        
    }
}
