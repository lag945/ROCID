using System;
using System.Collections.Generic;

namespace ROC_IDNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            ROCID rocid = new ROCID();
            //8個3是否成立
            //"3333333"
            List<string> ids = new List<string>();
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            //所有縣市
            for (int i = 65; i <= 90; i++)
            {
                string letter = ascii.GetString(new byte[] { (byte)i });
                for (int j = 1; j <= 2; j++)//男或女
                {
                    string id = letter + j.ToString() + "33333333";
                    System.Diagnostics.Debug.WriteLine(id);
                    if (rocid.isValid(id))
                    {
                        ids.Add(id);
                    }
                }
            }

            Console.WriteLine("共有: {0} 位:", ids.Count);
            for (int i = 0; i < ids.Count; i++)
            {
                Console.WriteLine(ids[i]);
            }

        }
    }
}
