using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace IwanaBuy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        /// <summary>
        /// 通过密钥文件获取rsaKey
        /// </summary>
        /// <param name="hashKey"></param>
        /// <param name="type">0获取私钥，1获取公钥</param>
        /// <returns></returns>
        public RSAParameters getKeyPara(string hashKey, int type)
        {
            RSAParameters rsaP = new RSAParameters();
            byte[] tmpKeyNoB64 = Convert.FromBase64String(hashKey);
            int pemModulus = 128;
            int pemPublicExponent = 3;
            int pemPrivateExponent = 128;
            int pemPrime1 = 64;
            int pemPrime2 = 64;
            int pemExponent1 = 64;
            int pemExponent2 = 64;
            int pemCoefficient = 64;

            byte[] arrPemModulus = new byte[128];
            byte[] arrPemPublicExponent = new byte[3];
            byte[] arrPemPrivateExponent = new byte[128];
            byte[] arrPemPrime1 = new byte[64];
            byte[] arrPemPrime2 = new byte[64];
            byte[] arrPemExponent1 = new byte[64];
            byte[] arrPemExponent2 = new byte[64];
            byte[] arrPemCoefficient = new byte[64];

            if (type == 0)//私钥
            {
                //Modulus
                for (int i = 0; i < pemModulus; i++)
                {
                    arrPemModulus[i] = tmpKeyNoB64[11 + i];
                }
                rsaP.Modulus = arrPemModulus;
                
                //PublicExponent
                for (int i = 0; i < pemPublicExponent; i++)
                {
                    arrPemPublicExponent[i] = tmpKeyNoB64[141 + i];
                }
                rsaP.Exponent = arrPemPublicExponent;
                //PrivateExponent
                for (int i = 0; i < pemPrivateExponent; i++)
                {
                    arrPemPrivateExponent[i] = tmpKeyNoB64[147 + i];
                }
                rsaP.D = arrPemPrivateExponent;
                //Prime1
                for (int i = 0; i < pemPrime1; i++)
                {
                    arrPemPrime1[i] = tmpKeyNoB64[278 + i];
                }
                rsaP.P = arrPemPrime1;
                //Prime2
                for (int i = 0; i < pemPrime2; i++)
                {
                    arrPemPrime2[i] = tmpKeyNoB64[345 + i];
                }
                rsaP.Q = arrPemPrime2;
                //Exponent1
                for (int i = 0; i < pemExponent1; i++)
                {
                    arrPemExponent1[i] = tmpKeyNoB64[412 + i];
                }
                rsaP.DP = arrPemExponent1;
                //Exponent2
                for (int i = 0; i < pemExponent2; i++)
                {
                    arrPemExponent2[i] = tmpKeyNoB64[478 + i];
                }
                rsaP.DQ = arrPemExponent2;

                //Coefficient
                for (int i = 0; i < pemCoefficient; i++)
                {
                    arrPemCoefficient[i] = tmpKeyNoB64[545 + i];
                }
                rsaP.InverseQ = arrPemCoefficient;
            }

            else//公钥
            {
                for (int i = 0; i < pemModulus; i++)
                {
                    arrPemModulus[i] = tmpKeyNoB64[29 + i];
                }
                rsaP.Modulus = arrPemModulus;

                for (int i = 0; i < pemPublicExponent; i++)
                {
                    arrPemPublicExponent[i] = tmpKeyNoB64[159 + i];
                }
                rsaP.Exponent = arrPemPublicExponent;
            }
            return rsaP;
        }
        public static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key)
        {
            try
            {
                // Create a new instance of RSACryptoServiceProvider using the 
                // key from RSAParameters.  
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(Key);

                // Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
                // to specify the use of SHA1 for hashing.
                return RSAalg.SignData(DataToSign, new SHA1CryptoServiceProvider());
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
        public static bool VerifySignedHash(byte[] DataToVerify, byte[] SignedData, RSAParameters Key)
        {
            try
            {
                // Create a new instance of RSACryptoServiceProvider using the 
                // key from RSAParameters.
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(Key);

                // Verify the data using the signature.  Pass a new instance of SHA1CryptoServiceProvider
                // to specify the use of SHA1 for hashing.
                return RSAalg.VerifyData(DataToVerify, new SHA1CryptoServiceProvider(), SignedData);

            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}