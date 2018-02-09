using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Switches.Models
{
    public class Switch
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string VLan { get; set; }
        public string Serial { get; set; }
        public DateTime DateBuy { get; set; }
        public DateTime DateInstallation{ get; set; }
        public int Floor { get; set; }
        public string Сomment { get; set; }
    }
}