using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Project_4
{
    class DonHang
    {
        private int soThuTu;
        private string maHang, tenKhachHang, diaChiKhachHang, soDienThoai;
        private int soLuong, tongTien;
        private DateTime ngayDatHang;

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

        public string TenKhachHang
        {
            get
            {
                return tenKhachHang;
            }

            set
            {
                tenKhachHang = value;
            }
        }

        public string DiaChiKhachHang
        {
            get
            {
                return diaChiKhachHang;
            }

            set
            {
                diaChiKhachHang = value;
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

        public int TongTien
        {
            get
            {
                return tongTien;
            }

            set
            {
                tongTien = value;
            }
        }

        public string SoDienThoai
        {
            get
            {
                return soDienThoai;
            }

            set
            {
                soDienThoai = value;
            }
        }

        public DateTime NgayDatHang
        {
            get
            {
                return ngayDatHang;
            }

            set
            {
                ngayDatHang = value;
            }
        }

        public int SoThuTu { get => soThuTu; set => soThuTu = value; }

        public DonHang() { }
        
        public DonHang(int stt, string maHang, int soLuong, string tenKhachHang, string diaChiKhachHang, int tongTien, string soDienThoai, DateTime ngayDatHang)
        {
            this.soThuTu = stt;
            this.MaHang = maHang;
            this.TenKhachHang = tenKhachHang;
            this.DiaChiKhachHang = diaChiKhachHang;
            this.SoLuong = soLuong;
            this.TongTien = tongTien;
            this.SoDienThoai = soDienThoai;
            this.NgayDatHang = ngayDatHang;
        }

        // Tạo thành 1 dòng để ghi xuống file txt
        public string ToLine()
        {
            return $"{soThuTu}#{MaHang}#{SoLuong}#{TenKhachHang}#{DiaChiKhachHang}#{TongTien}#{SoDienThoai}#{NgayDatHang.ToString("dd/MM/yyyy")}";
        }
    }
}
