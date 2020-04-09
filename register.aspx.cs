using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TwitterCopy_V2 {
    public partial class register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void submitClick(object sender, EventArgs e) {
            dbedit db = new dbedit();

            string[] inputs = { usernameField.Text.Trim(), emailField.Text.Trim(), pwField.Text.Trim(), pwconfirmField.Text.Trim() };

            if (inputs[0] == "" || inputs[1] == "" || inputs[2] == "" || inputs[3] == "") outputLabel.Text = "These fields must be filled!";
            else if (inputs[2] != inputs[3]) outputLabel.Text = "Your passwords don't match.";
            else {
                switch (db.register(inputs[1], inputs[0], inputs[2])) {
                    case 1:
                        outputLabel.Text = "Username or email is in use.";
                        break;
                    case 2:
                        outputLabel.Text = "Success!";
                        break;
                    default:
                        outputLabel.Text = "Error!";
                        break;
                }
            }
        }
    }
}