using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TienTrinh1
{
    class PhepTinh
    {
        public string ToanHang1;
        public string ToanTu;
        public string ToanHang2;    
        public string KetQua;

        private int _soA;
        private int _soB;

        public PhepTinh(string toanHang1, string toanTu, string toanHang2)
        {
            this.ToanHang1 = toanHang1;
            this.ToanHang2 = toanHang2;
            this.ToanTu = toanTu;

            try
            {
                this._soA = Convert.ToInt32(this.ToanHang1);
                this._soB = Convert.ToInt32(this.ToanHang2);
                byte maDau = Convert.ToByte(this.ToanTu);
                if (maDau == 42)
                {
                    this.KetQua = Convert.ToString(this._soA * this._soB);
                }
                else if (maDau == 43)
                {
                    this.KetQua = Convert.ToString(this._soA + this._soB);
                }
                else if (maDau == 45)
                {
                    this.KetQua = Convert.ToString(this._soA - this._soB);
                }
                else if (maDau == 47)
                {
                    this.KetQua = Convert.ToString(this._soA / this._soB);
                }
                else
                {
                    this.KetQua = null;
                }
            }
            catch(Exception ex)
            {
                this.KetQua = null;
            }
        }
    }
}
