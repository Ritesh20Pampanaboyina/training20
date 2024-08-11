
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace assignment1
{
    public partial class Validation : System.Web.UI.Page
    {
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string familyname = txtFamilyName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string zipcode = txtZipCode.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            if (name == familyname)
            {
                lblResult.Text = "Name and Family Name cannot be same.";
                return;
            }
            if (address.Length < 2)
            {
                lblResult.Text = "Address must contain at least 2 letters.";
                return;
            }
            if (city.Length < 2)
            {
                lblResult.Text = "City must contain at least 2 letters.";
                return;
            }
            if (!Regex.IsMatch(zipcode, @"^\d{6}$"))
            {
                lblResult.Text = "Zip Code must be exactly 6 digits. ";
                return;
            }
            if (!Regex.IsMatch(phone, @"^\d{10}$"))
            {
                lblResult.Text = "Phone must be exactly 10 digits.";
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblResult.Text = "Email is not valid.";
                return;
            }
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "Validation Successful";
        }
    }
}
