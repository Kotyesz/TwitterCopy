using System;
using System.Threading;
using System.IO;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace TwitterCopy_V2 {
    public partial class imagetest : System.Web.UI.Page {

        protected dbedit db = new dbedit();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void submitClick(object sender, EventArgs e) {
            FileInfo file = new FileInfo(FileUpload1.FileName);
            outtext.Text = file.Extension;
            string folderPath = Server.MapPath("~/Files/");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            FileUpload1.SaveAs($"{folderPath}{db.imgcount()}{file.Extension}");
            /Output.ImageUrl = images.Upload(folderPath);
        }
    }
}