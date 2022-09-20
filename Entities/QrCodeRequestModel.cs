using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class QrCodeRequestModel
    {      
            public string frame_name { get; set; } = null!;
            public string qr_code_text { get; set; } = null!;
            public string image_format { get; set; } = null!;
            public string qr_code_logo { get; set; } = null!;
        
    }
}
