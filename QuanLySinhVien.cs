using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    internal class QuanLySinhVien
    {
        private readonly List<SinhVien> _danhSach = new List<SinhVien>();

        public bool Them(SinhVien sv)
        {
            if (TimTheoMa(sv.MaSinhVien) != null) return false; // trùng mã
            _danhSach.Add(sv);
            return true;
        }

        public bool SuaDiem(string ma, double diemMoi)
        {
            var sv = TimTheoMa(ma);
            if (sv == null) return false;
            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        public bool Xoa(string ma)
        {
            var sv = TimTheoMa(ma);
            if (sv == null) return false;
            return _danhSach.Remove(sv);
        }

        public SinhVien TimTheoMa(string ma)
        {
            return _danhSach.FirstOrDefault(s =>
                s.MaSinhVien.Equals(ma, StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return _danhSach
                .Where(s => s.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase)>=0)
                .ToList();
        }

        public List<SinhVien> SapXepTheoDiem()
        {
            return _danhSach.OrderByDescending(s => s.DiemTrungBinh).ToList();
        }

        public List<SinhVien> LocDat()
        {
            return _danhSach.Where(s => s.DiemTrungBinh >= 5).ToList();
        }

        public List<SinhVien> LayDanhSach() => _danhSach.ToList();
    }
}
