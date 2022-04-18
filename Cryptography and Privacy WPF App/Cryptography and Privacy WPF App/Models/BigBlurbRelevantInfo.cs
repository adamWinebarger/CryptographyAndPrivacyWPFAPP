using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_and_Privacy_WPF_App
{
    public struct BigBlurbRelevantInfo
    {

       public string title,
            blurbText, 
            okButtonText, 
            neatButtonText, 
            image1FilePath,  
            image2FilePath;

        public bool modifyNeatButtonText, 
            modifyOKButtonText, 
            image1Visible, 
            image2Visible;

        public BigBlurbRelevantInfo(string title, string blurbText, bool image1Visible, bool image2Visible,
            string okButtonText = "ok",   string neatButtonText = "Neat!", string image1FilePath = "", 
            string image2FilePath = "", bool modifyOKButtonText = false, bool modifyNeatButtonText = false)
        {
            this.title = title;
            this.blurbText = blurbText;
            this.okButtonText = okButtonText;
            this.neatButtonText = neatButtonText;
            this.image1FilePath = image1FilePath;
            this.image2FilePath = image2FilePath;

            this.modifyNeatButtonText = modifyNeatButtonText;
            this.modifyOKButtonText = modifyOKButtonText;
            this.image1Visible = image1Visible;
            this.image2Visible = image2Visible;
        }

    }
}
