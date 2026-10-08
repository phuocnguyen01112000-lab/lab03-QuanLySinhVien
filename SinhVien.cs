using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public class SinhVien:Nguoi
    {
        public string MaSinhVien { get; set; }
        private double _DiemTrungBinh { get; set; }
        public string MaLop { get; set; }
        public double DiemTrungBinh
        {
            get => _DiemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Diem phai nam trong khoang tu 0-10");
                _DiemTrungBinh = value;
            }
        }
        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh,
                        string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien= maSinhVien;
            MaLop= maLop;
            DiemTrungBinh= diemTrungBinh;
        }
        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.0) return "Gioi";
            if (DiemTrungBinh >= 6.5) return "Kha";
            if (DiemTrungBinh >= 5.0) return "Trung binh";
            return "Yeu";
        }
        public override string LayThongTin()
        {
            return $"{MaSinhVien,-8} {HoTen,-22} {MaLop,-8} {DiemTrungBinh,5:0.0}  {XepLoai()}";

        }
    }
}
