using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TwitterCopy_V2{
    public class dbedit {

        protected static string conString = WebConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        protected SqlConnection con = new SqlConnection(conString);
        protected security sec = new security();
        protected SqlCommand cmd;
        protected SqlDataAdapter sda;
        protected DataTable dt;

        protected internal int imgcount() {
            con.Open();
            cmd = new SqlCommand("select count(*) from Images");
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            cmd.ExecuteNonQuery();
            return int.Parse(dt.Rows[0][0].ToString());
        }

        //kepeket adatbazisba rakja
        protected internal void imgup(string url) {
            con.Open();
            cmd = new SqlCommand("insert into imgTest values(@url);", con);
            cmd.Parameters.Add(new SqlParameter("url", url));
            cmd.ExecuteNonQuery();
        }

        //regisztralas az adatbazisba
        protected internal byte register(string email, string user, string password) {
            string[] saltandhash = sec.generation(password);

            try {
                con.Open();
                cmd = new SqlCommand("select count(*) from Users where username=@username or email=@email;", con);
                cmd.Parameters.Add(new SqlParameter("username", user));
                cmd.Parameters.Add(new SqlParameter("email", email));
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                if (int.Parse(dt.Rows[0][0].ToString()) > 0) {
                    con.Close();
                    return 1;
                } else {
                    cmd = new SqlCommand("insert into Users(username, email, pw1, pw2,registerdate) values(@username,@email,@pw1,@pw2,@registerdate);", con);
                    cmd.Parameters.Add(new SqlParameter("username", user));
                    cmd.Parameters.Add(new SqlParameter("email", email));
                    cmd.Parameters.Add(new SqlParameter("pw1", saltandhash[0]));
                    cmd.Parameters.Add(new SqlParameter("pw2", saltandhash[1]));
                    cmd.Parameters.Add(new SqlParameter("registerdate", DateTime.Now.ToString("yyyy/MM/dd")));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return 2;
                }
            } catch (Exception) {
                con.Close();
                return 0;
            }
        }
        //belepes check
        protected internal byte login(string usermail, string password) {
            //try {
                con.Open();
                cmd = new SqlCommand("select count(*) from Users where BINARY_CHECKSUM(username)=BINARY_CHECKSUM(@usermail) or BINARY_CHECKSUM(email)=BINARY_CHECKSUM(@usermail);", con);
                cmd.Parameters.Add(new SqlParameter("usermail", usermail));
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                if (int.Parse(dt.Rows[0][0].ToString()) > 0) {
                    cmd = new SqlCommand("select pw1 from Users where BINARY_CHECKSUM(username)=BINARY_CHECKSUM(@usermail) or BINARY_CHECKSUM(email)=BINARY_CHECKSUM(@usermail);", con);
                    cmd.Parameters.Add(new SqlParameter("usermail", usermail));
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    cmd.ExecuteNonQuery();
                    string HashedPass = sec.recode(password, dt.Rows[0][0].ToString().Trim()).Trim();
                    cmd = new SqlCommand("select count(*) from Users where (BINARY_CHECKSUM(username)=BINARY_CHECKSUM(@usermail) or BINARY_CHECKSUM(email)=BINARY_CHECKSUM(@usermail)) and BINARY_CHECKSUM(pw2)=BINARY_CHECKSUM(@hashedpass); ", con);
                    cmd.Parameters.Add(new SqlParameter("usermail", usermail));
                    cmd.Parameters.Add(new SqlParameter("hashedpass", HashedPass));
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    if (int.Parse(dt.Rows[0][0].ToString()) > 0) {
                        con.Close();
                        return 2;
                    } else {
                        con.Close();
                        return 3;
                    }
                } else {
                    con.Close();
                    return 1;
                }
            //} catch (Exception) {
            //    con.Close();
            //    return 0;
            //}

        }
    }
}