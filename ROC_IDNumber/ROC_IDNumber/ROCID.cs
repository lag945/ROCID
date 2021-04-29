using System;
using System.Collections.Generic;
using System.Text;

namespace ROC_IDNumber
{
    class ROCID
    {
        private int m_IDLength = 10;
        private Dictionary<string, int> m_AreaMap = new Dictionary<string, int>();
        public ROCID()
        {
            InitAreaMap();
        }

        /// <summary>
        /// 驗證身份證字號長度是否正確
        /// </summary>
        /// <param name="id">身分證字號</param>
        /// <returns></returns>
        public bool CheckLength(string id)
        {
            return (id.Length == m_IDLength);
        }

        /// <summary>
        /// 判斷區域碼是否正確
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckArea(string id)
        {
            return (GetAreaCode(id) >= 0);
        }

        /// <summary>
        ///取得區域碼值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int  GetAreaCode(string id)
        {
            int ret = -1;
            if (id.Length > 0)
            {
                int value;
                if (m_AreaMap.TryGetValue(id.Substring(0, 1), out value))
                {
                    ret = value;
                }
            }
            return ret;
        }

        /// <summary>
        ///計算驗證碼
        /// </summary>
        /// <param name="id"></param>
        /// <param name="checkCode"></param>
        /// <returns></returns>
        public bool CalcCheckCode(string id, out int checkCode)
        {
            bool ret = false;

            checkCode = new int();
            if (id.Length >= 9)
            {
                int areaCode = GetAreaCode(id.Substring(0, 1));
                if (areaCode >= 0)
                {
                    int total = (areaCode % 10) * 9 + areaCode / 10;
                    bool isNumberOk = true;
                    for (int i = 1; i < 9; i++)
                    {
                        int number;
                        if (int.TryParse(id.Substring(i, 1), out number))
                        {
                            total += number * (9 - i);
                        }
                        else
                        {
                            isNumberOk = false;
                            break;
                        }
                    }
                    if (isNumberOk)
                    {
                        checkCode = 10 - (total % 10);
                        ret = true;
                    }
                }
            }

            return ret;
        }


        /// <summary>
        /// 確認身份證字號是否有效
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool isValid(string id)
        {
            bool ret = false;

            if (CheckLength(id))
            {
                int checkCode;
                if (CalcCheckCode(id, out checkCode))
                {
                    int lastCode;
                    if (int.TryParse(id.Substring(9, 1), out lastCode))
                    {
                        if (lastCode == checkCode)
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// 初始化區域碼字典，會將每個區域碼轉換成對應數字
        /// </summary>
        private void InitAreaMap()
        {
            m_AreaMap.Add("A", 10);//台北市
            m_AreaMap.Add("B", 11);//台中市
            m_AreaMap.Add("C", 12);//基隆市
            m_AreaMap.Add("D", 13);//台南市
            m_AreaMap.Add("E", 14);//高雄市
            m_AreaMap.Add("F", 15);//台北縣
            m_AreaMap.Add("G", 16);//宜蘭縣
            m_AreaMap.Add("H", 17);//桃園縣
            m_AreaMap.Add("I", 34);//嘉義市
            m_AreaMap.Add("J", 18);//新竹縣
            m_AreaMap.Add("K", 19);//苗栗縣
            m_AreaMap.Add("L", 20);//台中縣
            m_AreaMap.Add("M", 21);//南投縣
            m_AreaMap.Add("N", 22);//彰化縣
            m_AreaMap.Add("O", 35);//新竹市
            m_AreaMap.Add("P", 23);//雲林縣
            m_AreaMap.Add("Q", 24);//嘉義縣
            m_AreaMap.Add("R", 25);//台南縣
            m_AreaMap.Add("S", 26);//高雄縣
            m_AreaMap.Add("T", 27);//屏東縣
            m_AreaMap.Add("U", 28);//花蓮縣
            m_AreaMap.Add("V", 29);//台東縣
            m_AreaMap.Add("W", 32);//金門縣
            m_AreaMap.Add("X", 30);//澎湖縣
            m_AreaMap.Add("Y", 31);//陽明山
            m_AreaMap.Add("Z", 33);//連江縣
        }

    }
}
