using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterCopy_V2 {
    public class security {
        protected internal string[] generation(string input) {
            string salt = CreateSalt(32);
            string hashedpass = SHA256(input, salt);
            string[] Output = { salt, hashedpass };
            return Output;
        }

        protected internal string recode(string input, string salt) {
            string Output = SHA256(input, salt);
            return Output;
        }

        protected string CreateSalt(int size) {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        protected string SHA256(string input, string salt) {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}