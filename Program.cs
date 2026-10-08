using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{

    internal class Program
    {
        static readonly QuanLySinhVien ql = new QuanLySinhVien();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int chon;
            do
            {
                HienMenu();
                chon = NhapSoNguyen("Chon chuc nang: ");
                switch (chon)
                {
                    case 1: ThemSinhVien(); break;
                    case 2: InDanhSach(ql.LayDanhSach()); break;
                    case 3: TimTheoMa(); break;
                    case 4: TimTheoTen(); break;
                    case 5: SuaDiem(); break;
                    case 6: XoaSinhVien(); break;
                    case 7: InDanhSach(ql.SapXepTheoDiem()); break;
                    case 8: InDanhSach(ql.LocDat()); break;
                    case 0: Console.WriteLine("Tam biet!"); break;
                    default: Console.WriteLine("Lua chon khong hop le."); break;
                }
                Console.WriteLine();
            } while (chon != 0);
        }

        static void HienMenu()
        {
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
        }
        static string NhapChuoi(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string s = (Console.ReadLine() ?? "").Trim();
                if (s != "") return s;
                Console.WriteLine("Khong duoc de trong.");
            }
        }
        static int NhapSoNguyen(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (int.TryParse(Console.ReadLine(), out int kq)) return kq;
                Console.WriteLine("Vui long nhap so nguyen.");
            }
        }

        static double NhapDiem(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string s = (Console.ReadLine() ?? "").Replace(',', '.');
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double d)
                    && d >= 0 && d <= 10)
                    return d;
                Console.WriteLine("Diem khong hop le (0-10), nhap lai.");
            }
        }
        static DateTime NhapNgaySinh(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngay))
                    return ngay;
                Console.WriteLine("Ngay sinh sai dinh dang (dd/MM/yyyy).");
            }
        }
        static void ThemSinhVien()
        {
            string ma = NhapChuoi("Ma sinh vien: ");
            if (ql.TimTheoMa(ma) != null)
            {
                Console.WriteLine("Ma sinh vien da ton tai.");
                return;
            }
            string ten = NhapChuoi("Ho ten: ");
            DateTime ns = NhapNgaySinh("Ngay sinh (dd/MM/yyyy): ");
            string lop = NhapChuoi("Ma lop: ");
            double diem = NhapDiem("Diem trung binh (0-10): ");

            ql.Them(new SinhVien(ma, ten, ns, lop, diem));
            Console.WriteLine("Them thanh cong.");
        }

        static void InDanhSach(List<SinhVien> ds)
        {
            if (ds.Count == 0) { Console.WriteLine("Danh sach trong."); return; }
            Console.WriteLine($"{"Ma",-8} {"Ho ten",-22} {"Lop",-8} {"Diem",5}  Xep loai");
            foreach (var sv in ds) Console.WriteLine(sv.LayThongTin());
        }

        static void TimTheoMa()
        {
            var sv = ql.TimTheoMa(NhapChuoi("Nhap ma can tim: "));
            if (sv == null) Console.WriteLine("Khong tim thay.");
            else InDanhSach(new List<SinhVien> { sv });
        }

        static void TimTheoTen()
        {
            InDanhSach(ql.TimTheoTen(NhapChuoi("Nhap tu khoa ho ten: ")));
        }

        static void SuaDiem()
        {
            string ma = NhapChuoi("Nhap ma sinh vien: ");
            if (ql.TimTheoMa(ma) == null) { Console.WriteLine("Khong tim thay."); return; }
            double diem = NhapDiem("Diem moi (0-10): ");
            ql.SuaDiem(ma, diem);
            Console.WriteLine("Cap nhat thanh cong.");
        }

        static void XoaSinhVien()
        {
            string ma = NhapChuoi("Nhap ma can xoa: ");
            Console.WriteLine(ql.Xoa(ma) ? "Da xoa." : "Khong tim thay.");
        }
    }
}