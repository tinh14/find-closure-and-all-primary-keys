using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimBaoDong
{
    class ThuatToanTBD
    {
        public string timBaoDong(string baoDong, List<string> Trai, List<string> Phai)
        {
            int doDaiBaoDong = baoDong.Length - 1;

            while (doDaiBaoDong != baoDong.Length)
            {
                doDaiBaoDong = baoDong.Length;

                for (int i = 0; i < Trai.Count; i++)
                    if (kiemTra(Trai[i], baoDong))
                    {
                        for (int j = 0; j < Phai[i].Length; j++)
                            if (!kiemTra(Phai[i][j].ToString(), baoDong))
                                baoDong += Phai[i][j].ToString();
                    }
            }

            return baoDong;
        }


        public bool kiemTra(string con, string cha)
        {
            int chuoiCon = 0;

            if (con.Length > cha.Length)
                return false;

            for (int i = 0; i < con.Length; i++)
                for (int j = 0; j < cha.Length; j++)
                {
                    if (con[i] == cha[j])
                    {
                        chuoiCon++;
                        break;
                    }
                }
            if (chuoiCon == con.Length)
                return true;

            return false;
        }

        static void layTapCon(int[] x, int i, int n, List<string> TapCon, List<char> TapTrungGian){
            for (int j = 0; j <= 1; j++){
                x[i] = j;
                if (i == n){
                    string res = "";
                    for (int k = x.Length - 1; k >= 1; k--){
                        if (x[k] == 1){
                            res += TapTrungGian[n - k];
                        }
                    }
                    TapCon.Add(res);
                }else {
                    layTapCon(x, i + 1, n, TapCon, TapTrungGian);
                }
            }
        }

        public List<string> timKhoa(string Q, List<string> Trai, List<string> Phai)
        {
            List<char> TapNguon = new List<char>();
            List<char> TapTrungGian = new List<char>();
            HashSet<char> s1 = new HashSet<char>();
            HashSet<char> s2 = new HashSet<char>();

            foreach (string str in Trai)
            {
                foreach (char c in str)
                {
                    s1.Add(c);
                }
            }

            foreach (string str in Phai)
            {
                foreach (char c in str)
                {
                    s2.Add(c);
                }
            }

            foreach (char c in s1)
            {
                if (!s2.Contains(c))
                {
                    TapNguon.Add(c);
                }
            }

            foreach (char c in s2)
            {
                if (s1.Contains(c))
                {
                    TapTrungGian.Add(c);
                }
            }

            if (TapNguon.Count == 0)
            {
                TapNguon.Add('0');
            }

            if (TapTrungGian.Count == 0)
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < TapNguon.Count; i++)
                {
                    temp.Add("" + TapNguon[i]);
                }
                return temp;
            }

            int n = TapTrungGian.Count;
            int[] x = new int[n + 1];
            List<string> TapCon = new List<string>();
            layTapCon(x, 1, n, TapCon, TapTrungGian);
            TapCon[0] = "0";
            List<string> TapCon_TapNguon = new List<string>();

            string c1 = "";
            foreach (char c in TapNguon)
            {
                c1 += c;
            }
            foreach (string str in TapCon)
            {
                HashSet<char> set = new HashSet<char>();
                foreach (char c in c1)
                {
                    set.Add(c);
                }
                foreach (char c2 in str)
                {
                    set.Add(c2);
                }
                string res = "";
                foreach (char c in set)
                {
                    res += c;
                }
                res = res.Replace("0", string.Empty);
                TapCon_TapNguon.Add(res);
            }

            List<string> SieuKhoa = new List<string>();

            for (int i = 0; i < TapCon_TapNguon.Count; i++)
            {
                HashSet<char> set = new HashSet<char>();
                foreach (char c in Q)
                {
                    set.Add(c);
                }
                string str = TapCon_TapNguon[i];
                string strPlus = timBaoDong(str, Trai, Phai);
                char[] temp = strPlus.ToCharArray();
                Array.Sort(temp);
                strPlus = new string(temp);
                if (string.Compare(strPlus, Q) == 0)
                {
                    temp = TapCon_TapNguon[i].ToCharArray();
                    Array.Sort(temp);
                    SieuKhoa.Add(new string(temp));
                }
            }

            bool[] mark = new bool[SieuKhoa.Count];
            for (int i = 0; i < SieuKhoa.Count; i++)
            {
                for (int j = 0; j < SieuKhoa.Count; j++)
                {
                    if (i != j && !mark[j])
                    {
                        HashSet<char> set = new HashSet<char>();
                        int cnt = SieuKhoa[i].Length;
                        foreach (char c in SieuKhoa[j])
                        {
                            set.Add(c);
                        }
                        int cnt2 = 0;
                        foreach (char c in SieuKhoa[i])
                        {
                            if (set.Contains(c))
                            {
                                cnt2++;
                            }
                        }
                        if (cnt2 == cnt)
                        {
                            mark[j] = true;
                        }
                    }
                }
            }

            List<string> Khoa = new List<string>();

            for (int i = 0; i < SieuKhoa.Count; i++)
            {
                if (!mark[i])
                {
                    Khoa.Add(SieuKhoa[i]);
                }
            }
            return Khoa;
        }
    }
}
