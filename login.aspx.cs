using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterCopy_V2 {
    public partial class login : System.Web.UI.Page {

        dbedit db = new dbedit();

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void submitClick(object sender, EventArgs e) {
            if (usermail.Text.Trim() == "" || password.Text.Trim() == "") outputLabel.Text = "Fields cannot be empty!";
            else {
                switch (db.login(usermail.Text.Trim(), password.Text.Trim())) {
                    case 1:
                        outputLabel.Text = "User doesn't exist";
                        break;
                    case 2:
                        outputLabel.Text = "Success";
                        break;
                    case 3:
                        outputLabel.Text = "Invalid password";
                        break;
                    default:
                        outputLabel.Text = "Error!";
                        break;
                }
            }
        }
    }
}