using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Project_4
{
    class HangHoa
    {
        private string maHang, tenHang, noiSanXuat, mauSac;
        private int giaBan, soLuong;
        private DateTime ngayNhapKho;

        public string MaHang
        {
            get
            {
                return maHang;
            }

            set
            {
                maHang = value;
            }
        }

        public string TenHang
        {
            get
            {
                return tenHang;
            }

            set
            {
                tenHang = value;
            }
        }

        public string NoiSanXuat
        {
            get
            {
                return noiSanXuat;
            }

            set
            {
                noiSanXuat = value;
            }
        }

        public string MauSac
        {
            get
            {
                return mauSac;
            }

            set
            {
                mauSac = value;
            }
        }

        public int GiaBan
        {
            get
            {
                return giaBan;
            }

            set
            {
                giaBan = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public DateTime NgayNhapKho
        {
            get
            {
                return ngayNhapKho;
            }

            set
            {
                ngayNhapKho = value;
            }
        }

        public HangHoa() { }

        public HangHoa(string maHang, string tenHang, string noiSanXuat, string mauSac, int giaBan, int soLuong, DateTime ngayNhapKho)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.noiSanXuat = noiSanXuat;
            this.mauSac = mauSac;
            this.giaBan = giaBan;
            this.soLuong = soLuong;
            this.ngayNhapKho = ngayNhapKho;
        }

        // Tạo thành 1 dòng để ghi xuống file txt
        public string ToLine()
        {
            return $"{MaHang}#{TenHang}#{NoiSanXuat}#{MauSac}#{GiaBan}#{SoLuong}#{NgayNhapKho.ToString("dd/MM/yyyy")}";
        }
    }
}
