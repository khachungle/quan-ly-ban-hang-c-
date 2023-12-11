using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kích thước cửa sổ windows
            Console.WindowWidth = 140;
            Console.WindowHeight = 40;

            // Sử dụng 3 Linked List để chứa dữ liệu từ 3 file
            LinkedList<HangHoa> listHangHoa = DocFileHangHoa();
            Queue<DonHang> listDonHang = DocFileDonHang();
            LinkedList<Admin> listAdmin = DocFileAdmin();

            // Hiển thị màn hình chính
            HomeScreen(listHangHoa, listDonHang, listAdmin);
        }

        /// <summary>
        /// Màn hình chính, khi chọn chức năng sẽ gọi tới màn hình của các chức năng con
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void HomeScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear man hinh, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "HOME";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t********     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("HOME PAGE");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     ********\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Lựa chọn chức năng
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\t\t\t1. Hien thi thong tin hang hoa\n");
            Console.WriteLine("\t\t\t\t\t2. Tim kiem hang hoa\n");
            Console.WriteLine("\t\t\t\t\t3. Dat hang\n");
            Console.WriteLine("\t\t\t\t\t4. Quan ly hang hoa\n\n"); Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        DisplayScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        FindScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "3":
                        OrderScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "4":
                        LoginScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        // CÁC MÀN HÌNH
        /// <summary>
        /// Màn hình hiển thị danh sách hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void DisplayScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear màn hình, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Danh sách hàng hóa";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t****     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Danh sach hang hoa");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ****\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Goị hàm thực hiện chức năng hiển thị bảng hàng hóa
            ShowListProduct(listHangHoa);

            Console.WriteLine("Nhan phim ESC de thoat chuong trinh, phim khac de quay ve trang chu");
            // Dừng màn hình và kiểm tra xem người dùng nhấn phím nào
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            // Kiểm tra nếu người dùng nhấn phím Esc
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }

            // Nếu người dùng nhập phím bất kì trừ ESC thì sẽ quay lại màn hình chính
            HomeScreen(listHangHoa, listDonHang, listAdmin);
        }

        /// <summary>
        /// Màn hình tìm kiếm hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void FindScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear màn hình, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Tìm kiếm sản phẩm";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t****     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Tim kiem san pham");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     ****\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Gọi hàm thực hiện chức năng tìm kiếm
            ShowListProduct(listHangHoa);
            FindProduct(listHangHoa);

            // Lựa chọn sau khi thực hiện xong
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\t\t1. Tiep tuc\t2. Quay lai");
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        FindScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        HomeScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        /// <summary>
        /// Màn hình đặt hàng
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void OrderScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear màn hình, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Đặt hàng";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t*********    ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Dat hang");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     *********\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Gọi hàm thực hiện chức năng đặt hàng
            ShowListProduct(listHangHoa);
            DatHang(listHangHoa, listDonHang);

            // Lựa chọn sau khi thực hiện xong
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\t\t1. Tiep tuc\t2. Quay lai");
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        OrderScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        HomeScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        /// <summary>
        /// Màn hình Login
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void LoginScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear màn hình, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "LOGIN";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t*********    ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Dang nhap");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     *********\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Gọi hàm thực hiện chức năng đăng nhập
            Login(listHangHoa, listDonHang, listAdmin);
        }

        /// <summary>
        /// Màn hình quản lý (Sau khi đăng nhập thành công)
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void ManagerScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear man hinh, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Quản lý";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t*********     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Quan ly");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     *********\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Lựa chọn chức năng
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\t\t\t1. Xu li don hang\n");
            Console.WriteLine("\t\t\t\t\t2. Them hang hoa\n");
            Console.WriteLine("\t\t\t\t\t3. Xoa hang hoa\n");
            Console.WriteLine("\t\t\t\t\t4. Sua hang hoa\n");
            Console.WriteLine("\t\t\t\t\t5. Dang xuat\n\n"); Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        XuLiDonHangScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        ThemHangHoaScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "3":
                        XoaHangHoaScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "4":
                        SuaHangHoaScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "5":
                        HomeScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        /// <summary>
        /// Màn hình thêm hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void ThemHangHoaScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear man hinh, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Thêm hàng hóa";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t******     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Them hang hoa");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("     ******\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Gọi hàm thực hiện chức năng thêm hàng hóa
            ThemHangHoa(listHangHoa);
            // Lựa chọn sau khi thực hiện xong
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\t\t1. Tiep tuc\t2. Quay lai");
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        ThemHangHoaScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        ManagerScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        /// <summary>
        /// Màn hình xóa hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void XoaHangHoaScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear man hinh, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Xóa hàng hóa";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t******     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Xoa hang hoa");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ******\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Gọi hàm thực hiện chức năng xóa hàng hóa
            ShowListProduct(listHangHoa);
            XoaHangHoa(listHangHoa);

            // Lựa chọn sau khi thực hiện xong
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\t\t1. Tiep tuc\t2. Quay lai");
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        XoaHangHoaScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        ManagerScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        /// <summary>
        /// Màn hình sửa hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void SuaHangHoaScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear man hinh, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Sửa hàng hóa";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t******     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Sua hang hoa");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ******\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Gọi hàm thực hiện chức năng sửa hàng hóa
            ShowListProduct(listHangHoa);
            SuaHangHoa(listHangHoa);

            // Lựa chọn sau khi thực hiện xong
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\t\t1. Tiep tuc\t2. Quay lai");
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        SuaHangHoaScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        ManagerScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        /// <summary>
        /// Màn hình xử lí đơn hàng
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        /// <param name="listAdmin"></param>
        static void XuLiDonHangScreen(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            // Clear man hinh, hiển thị title tương ứng
            Console.Clear();
            Console.Title = "Xử lí đơn hàng";

            // Tiêu đề của màn hình
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n");
            Console.Write("\t\t\t\t\t\t\t******     ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Xu ly don hang");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ******\n");
            Console.WriteLine("\t\t\t\t\t\t\t***********************************\n\n");

            // Gọi hàm thực hiện chức năng xử lí đơn hàng
            XuLiDonHang(listDonHang);

            // Lựa chọn sau khi thực hiện xong
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t**********************************************************************************");
            Console.ResetColor();
            Console.WriteLine("\t\t1. Xu li don hang\t2. Quay lai");
            // chon chuc nang
            bool isValidFunction = false;
            do
            {
                Console.Write("\t\tChon chuc nang hoac nhan ESC de thoat: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine(); // Thêm dòng này để xuống dòng sau khi nhấn phím
                                     // Kiểm tra nếu người dùng nhấn phím Esc
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return;
                }

                string t = keyInfo.KeyChar.ToString(); // Chuyển đổi phím thành chuỗi
                switch (t)
                {
                    case "1":
                        listDonHang.Dequeue();
                        GhiFileDonHang(listDonHang);
                        XuLiDonHangScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    case "2":
                        ManagerScreen(listHangHoa, listDonHang, listAdmin);
                        isValidFunction = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\tVui long chon chuc nang hop le !");
                        Console.ResetColor();
                        break;
                }
            } while (isValidFunction == false);
        }

        //$$$$$$            Hết phần các màn hình        $$$$$$$$$$$$$$$$$$$$





        // CÁC HÀM CHỨC NĂNG
        /// <summary>
        /// Hàm thực hiện chức năng hiển thị danh sách hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        static void ShowListProduct(LinkedList<HangHoa> listHangHoa)
        {
            const int maHangWidth = 10;
            const int tenHangWidth = 50;
            const int noiSanXuatWidth = 20;
            const int mauSacWidth = 13;
            const int giaBanWidth = 13;
            const int ngayNhapKhoWidth = 15;
            const int soLuongWidth = 8;

            int dongHienTai = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            // ╔══════════╦═══════════════════╦══════════════╦═════════╦════════════╦═══════════════╦═════════╗
            Console.Write("╔");
            for (int i = 0; i < maHangWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < tenHangWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < noiSanXuatWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < mauSacWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < giaBanWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < ngayNhapKhoWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < soLuongWidth; i++)
                Console.Write("═");
            Console.Write("╗");
            Console.WriteLine();
            // In tiêu đề cột (vị trí tương ứng kích thước của nó)
            Console.WriteLine($"║{" Ma hang",0 - maHangWidth}║{"                Ten hang",0 - tenHangWidth}║{"    Noi san xuat",0 - noiSanXuatWidth}║{"   Mau sac",0 - mauSacWidth}║{"   Gia ban",0 - giaBanWidth}║{" Ngay nhap kho",0 - ngayNhapKhoWidth}║{"So luong",0 - soLuongWidth}║");
            // ╚══════════╩═══════════════════╩══════════════╩═════════╩════════════╩═══════════════╩═════════╝
            Console.Write("╠");
            for (int i = 0; i < maHangWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < tenHangWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < noiSanXuatWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < mauSacWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < giaBanWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < ngayNhapKhoWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < soLuongWidth; i++)
                Console.Write("═");
            Console.Write("╣");
            Console.WriteLine();

            foreach (var hangHoa in listHangHoa)
            {
                string maHang = hangHoa.MaHang;
                string tenHang = hangHoa.TenHang;
                string noiSanXuat = hangHoa.NoiSanXuat;
                string mauSac = hangHoa.MauSac;
                string giaBan = hangHoa.GiaBan.ToString("#,0");
                string ngayNhapKho = hangHoa.NgayNhapKho.ToString("dd/MM/yyyy");
                string soLuong = hangHoa.SoLuong.ToString();

                // Đổi màu cho mỗi dòng
                if (dongHienTai % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (dongHienTai == listHangHoa.Count - 1)
                {
                    Console.WriteLine($"║{" " + maHang,0 - maHangWidth} {" " + tenHang,0 - tenHangWidth} {" " + noiSanXuat,0 - noiSanXuatWidth} {" " + mauSac,0 - mauSacWidth} {" " + giaBan,0 - giaBanWidth} {"   " + ngayNhapKho,0 - ngayNhapKhoWidth} {" " + soLuong,0 - soLuongWidth}║");
                    Console.Write("╚");
                    for (int i = 0; i < maHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < tenHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < noiSanXuatWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < mauSacWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < giaBanWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < ngayNhapKhoWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < soLuongWidth; i++)
                        Console.Write("═");
                    Console.Write("╝");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"║{" " + maHang,0 - maHangWidth} {" " + tenHang,0 - tenHangWidth} {" " + noiSanXuat,0 - noiSanXuatWidth} {" " + mauSac,0 - mauSacWidth} {" " + giaBan,0 - giaBanWidth} {"   " + ngayNhapKho,0 - ngayNhapKhoWidth} {" " + soLuong,0 - soLuongWidth}║");
                    Console.Write("╠");
                    for (int i = 0; i < maHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < tenHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < noiSanXuatWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < mauSacWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < giaBanWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < ngayNhapKhoWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < soLuongWidth; i++)
                        Console.Write("═");
                    Console.Write("╣");
                    Console.WriteLine();
                }
                Console.ResetColor();
                dongHienTai++;
            }
        }

        static void ShowListDonHang(Queue<DonHang> listDonHang)
        {
            const int STTWidth = 4;
            const int maHangWidth = 10;
            const int soLuongWidth = 5;
            const int tongTienWidth = 15;
            const int tenKhachHangWidth = 25;
            const int diaChiKhachHangWidth = 35;
            const int soDienThoaiWidth = 15;
            const int ngayDatHangWidth = 15;

            int dongHienTai = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            // ╔══════════╦═══════════════════╦══════════════╦═════════╦════════════╦═══════════════╦═════════╗
            Console.Write("╔");
            for (int i = 0; i < STTWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < maHangWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < soLuongWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < tongTienWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < tenKhachHangWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < diaChiKhachHangWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < soDienThoaiWidth; i++)
                Console.Write("═");
            Console.Write("╦");
            for (int i = 0; i < ngayDatHangWidth; i++)
                Console.Write("═");
            Console.Write("╗");
            Console.WriteLine();

            // In tiêu đề cột (vị trí tương ứng kích thước của nó)
            Console.WriteLine($"║{"STT",0 - STTWidth}║{" Ma hang",0 - maHangWidth}║{" SL",0 - soLuongWidth}║{"  Tong tien",0 - tongTienWidth}║{"   Ten khach hang",0 - tenKhachHangWidth}║{"     Dia chi khach hang",0 - diaChiKhachHangWidth}║{" So dien thoai",0 - soDienThoaiWidth}║{"  Ngay dat hang",0 - ngayDatHangWidth}║");
            // ╚══════════╩═══════════════════╩══════════════╩═════════╩════════════╩═══════════════╩═════════╝

            // In ra cac dong du lieu
            Console.Write("╠");
            for (int i = 0; i < STTWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < maHangWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < soLuongWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < tongTienWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < tenKhachHangWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < diaChiKhachHangWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < soDienThoaiWidth; i++)
                Console.Write("═");
            Console.Write("╬");
            for (int i = 0; i < ngayDatHangWidth; i++)
                Console.Write("═");
            Console.Write("╣");
            Console.WriteLine();

            foreach (var donHang in listDonHang)
            {
                string stt = donHang.SoThuTu.ToString();
                string maHang = donHang.MaHang;
                string soLuong = donHang.SoLuong.ToString();
                string tongTien = donHang.TongTien.ToString("#,0");
                string tenKH = donHang.TenKhachHang;
                string diaChi = donHang.DiaChiKhachHang;
                string soDienThoai = donHang.SoDienThoai;
                string ngayDatHang = donHang.NgayDatHang.ToString("dd/MM/yyyy");

                // Đổi màu cho mỗi dòng
                if (dongHienTai % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (dongHienTai == listDonHang.Count - 1)
                {
                    Console.WriteLine($"║{" " + stt,0 - STTWidth} {" " + maHang,0 - maHangWidth} {" " + soLuong,0 - soLuongWidth} {" " + tongTien,0 - tongTienWidth} {" " + tenKH,0 - tenKhachHangWidth} {" " + diaChi,0 - diaChiKhachHangWidth} {"   " + soDienThoai,0 - soDienThoaiWidth} {" " + ngayDatHang,0 - ngayDatHangWidth}║");
                    Console.Write("╚");
                    for (int i = 0; i < STTWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < maHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < soLuongWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < tongTienWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < tenKhachHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < diaChiKhachHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < soDienThoaiWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < ngayDatHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╝");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"║{" " + stt,0 - STTWidth} {" " + maHang,0 - maHangWidth} {" " + soLuong,0 - soLuongWidth} {" " + tongTien,0 - tongTienWidth} {" " + tenKH,0 - tenKhachHangWidth} {" " + diaChi,0 - diaChiKhachHangWidth} {"   " + soDienThoai,0 - soDienThoaiWidth} {" " + ngayDatHang,0 - ngayDatHangWidth}║");
                    Console.Write("╠");
                    for (int i = 0; i < STTWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < maHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < soLuongWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < tongTienWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < tenKhachHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < diaChiKhachHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < soDienThoaiWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < ngayDatHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╣");
                    Console.WriteLine();
                }
                Console.ResetColor();
                dongHienTai++;
            }
        }

        /// <summary>
        /// Hàm thực hiện chức năng tìm kiếm hàng hóa
        /// </summary>
        /// <param name="danhSachHangHoa"></param>
        static void FindProduct(LinkedList<HangHoa> listHangHoa)
        {
            // nhap ten hang hoa va tim kiem
            Console.Write("\tNhap ten hang hoa can tim: ");
            string th = Console.ReadLine();
            bool timDuoc = false;
            foreach (HangHoa hh in listHangHoa)
            {
                if (hh.TenHang.ToLower() == th.ToLower())
                {
                    timDuoc = true;
                    // hien thi bang
                    string maHang = hh.MaHang;
                    string tenHang = hh.TenHang;
                    string noiSanXuat = hh.NoiSanXuat;
                    string mauSac = hh.MauSac;
                    string giaBan = hh.GiaBan.ToString("#,0");
                    string ngayNhapKho = hh.NgayNhapKho.ToString("dd/MM/yyyy");
                    string soLuong = hh.SoLuong.ToString();
                    const int maHangWidth = 10;
                    const int tenHangWidth = 50;
                    const int noiSanXuatWidth = 20;
                    const int mauSacWidth = 13;
                    const int giaBanWidth = 13;
                    const int ngayNhapKhoWidth = 15;
                    const int soLuongWidth = 8;

                    // in dong tieu de bang
                    Console.ForegroundColor = ConsoleColor.Green;
                    // ╔══════════╦═══════════════════╦══════════════╦═════════╦════════════╦═══════════════╦═════════╗
                    Console.Write("╔");
                    for (int i = 0; i < maHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╦");
                    for (int i = 0; i < tenHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╦");
                    for (int i = 0; i < noiSanXuatWidth; i++)
                        Console.Write("═");
                    Console.Write("╦");
                    for (int i = 0; i < mauSacWidth; i++)
                        Console.Write("═");
                    Console.Write("╦");
                    for (int i = 0; i < giaBanWidth; i++)
                        Console.Write("═");
                    Console.Write("╦");
                    for (int i = 0; i < ngayNhapKhoWidth; i++)
                        Console.Write("═");
                    Console.Write("╦");
                    for (int i = 0; i < soLuongWidth; i++)
                        Console.Write("═");
                    Console.Write("╗");
                    Console.WriteLine();
                    // In tiêu đề cột (vị trí tương ứng kích thước của nó)
                    Console.WriteLine($"║{" Ma hang",0 - maHangWidth}║{"                Ten hang",0 - tenHangWidth}║{"    Noi san xuat",0 - noiSanXuatWidth}║{"   Mau sac",0 - mauSacWidth}║{"   Gia ban",0 - giaBanWidth}║{" Ngay nhap kho",0 - ngayNhapKhoWidth}║{"So luong",0 - soLuongWidth}║");
                    // ╚══════════╩═══════════════════╩══════════════╩═════════╩════════════╩═══════════════╩═════════╝
                    Console.Write("╠");
                    for (int i = 0; i < maHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < tenHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < noiSanXuatWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < mauSacWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < giaBanWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < ngayNhapKhoWidth; i++)
                        Console.Write("═");
                    Console.Write("╬");
                    for (int i = 0; i < soLuongWidth; i++)
                        Console.Write("═");
                    Console.Write("╣");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    // in noi dung hang hoa
                    Console.WriteLine($"║{" " + maHang,0 - maHangWidth} {" " + tenHang,0 - tenHangWidth} {" " + noiSanXuat,0 - noiSanXuatWidth} {" " + mauSac,0 - mauSacWidth} {" " + giaBan,0 - giaBanWidth} {"   " + ngayNhapKho,0 - ngayNhapKhoWidth} {" " + soLuong,0 - soLuongWidth}║");
                    Console.Write("╚");
                    for (int i = 0; i < maHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < tenHangWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < noiSanXuatWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < mauSacWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < giaBanWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < ngayNhapKhoWidth; i++)
                        Console.Write("═");
                    Console.Write("╩");
                    for (int i = 0; i < soLuongWidth; i++)
                        Console.Write("═");
                    Console.Write("╝");
                    Console.WriteLine();
                    break;
                }
            }
            if (timDuoc == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tKhong tim thay hang hoa !!!");
                Console.ResetColor();
            }
        }

        // Hàm tìm kiếm hàng hóa bằng mã và trả về hàng hóa tìm thấy
        static HangHoa Find(LinkedList<HangHoa> listHangHoa, string maHang)
        {
            foreach (HangHoa hh in listHangHoa)
            {
                if (hh.MaHang.ToLower() == maHang.ToLower())
                {
                    return hh;
                }
            }
            return null;
        }

        /// <summary>
        ///  Hàm thực hiện chức năng đăng nhập
        /// </summary>
        /// <param name="listAdmin"></param>
        static void Login(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang, LinkedList<Admin> listAdmin)
        {
            bool thanhCong = false;
            string user="", pass="";
            int soLanDangNhap = 0;
            Console.WriteLine("\n\n\n");

            do
            {
                user = "";
                pass = "";
                soLanDangNhap++;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t\t\t\t\t\tUSERNAME:\t");
                Console.ForegroundColor = ConsoleColor.Yellow;
                user = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\t\t\t\t\t\tPASSWORD:\t");
                Console.ForegroundColor = ConsoleColor.Yellow;

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, pass.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (char.IsLetterOrDigit(keyInfo.KeyChar))
                    {
                        pass += keyInfo.KeyChar;
                        Console.Write("*");
                    }
                }

                foreach (Admin a in listAdmin)
                {
                    if (string.Compare(a.Username, user) == 0 && string.Compare(a.Password, pass) == 0)
                    {
                        thanhCong = true;
                        break;
                    }
                }

                if (thanhCong == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\tThong tin dang nhap sai, Ban con {0} lan dang nhap !\n", 3 - soLanDangNhap);
                }

            } while (thanhCong == false && soLanDangNhap < 3);

            if (thanhCong == true)
            {
                Console.WriteLine(); // Xuống dòng để tách thông báo đăng nhập sai và màn hình quản lý
                ManagerScreen(listHangHoa, listDonHang, listAdmin);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tDang nhap that bai !!!");
                Console.ReadKey();
                HomeScreen(listHangHoa, listDonHang, listAdmin);
            }
        }
        

        // ************************************* COPY
        /// <summary>
        /// Thêm hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        static void ThemHangHoa(LinkedList<HangHoa> listHangHoa)
        {
            HangHoa hh = new HangHoa();
            string maHang = "", tenHang = "", noiSX = "", mauSac = "";
            int giaBan = 0, soLuong = 0;
            do
            {
                Console.Write($"{"Nhap ma hang(4 ki tu):",-30}");
                maHang = Console.ReadLine();
            } while (!isValidMaHang(listHangHoa, maHang));
            do
            {
                Console.Write($"{"Nhap ten hang:",-30}");
                tenHang = Console.ReadLine();
            } while ( KTKTDB(tenHang) == false);
            do
            {
                Console.Write($"{"Nhap noi san xuat:",-30}");
                noiSX = Console.ReadLine();
            } while (KTKTDB(noiSX) == false);

            Console.Write($"{"Nhap mau sac:",-30}");
            mauSac = Console.ReadLine();
            if(mauSac == "" )
            {
                mauSac = "None";
            }

            bool isValid = false;
            do
            {
                Console.Write($"{"Nhap gia ban:",-30}");
                string input = Console.ReadLine();

                if (int.TryParse(input, out giaBan) && giaBan >= 0)
                {
                    isValid = true;
                }
            } while (!isValid);

            isValid = false;
            do
            {
                Console.Write($"{"Nhap so luong:",-30}");
                string input = Console.ReadLine();

                if (int.TryParse(input, out soLuong) && soLuong >= 0)
                {
                    isValid = true;
                }
            } while (!isValid);
            

            DateTime ngayNhap = DateTime.Now;

            hh = new HangHoa(maHang, tenHang, noiSX, mauSac, giaBan, soLuong, ngayNhap);
            listHangHoa.AddLast(hh);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Them thanh cong");
            Console.ResetColor();
            GhiFileHangHoa(listHangHoa);
        }

        /// <summary>
        /// Xóa hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        static void XoaHangHoa(LinkedList<HangHoa> listHangHoa)
        {
            string maHangCanXoa = "";
            do
            {
                Console.Write("Nhap ma hang can Xoa: ");              
                maHangCanXoa = Console.ReadLine();
            } while (KTMaHang(listHangHoa,maHangCanXoa) == false);
            bool daXoa = false;
            for (LinkedListNode<HangHoa> p = listHangHoa.First; p != null; p = p.Next)
            {
                if (string.Compare(maHangCanXoa, p.Value.MaHang) == 0)
                {
                    listHangHoa.Remove(p);
                    GhiFileHangHoa(listHangHoa);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Xoa thanh cong");
                    Console.ResetColor();
                    daXoa = true;
                    break;
                }
            }
            if(daXoa == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Khong tim thay hang hoa !");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Sửa hàng hóa
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <returns></returns>
        static bool SuaHangHoa(LinkedList<HangHoa> listHangHoa)
        {
            string maHang = "";
            do
            {
                Console.Write("Nhap ma hang can Sua: ");
                maHang = Console.ReadLine();
            } while (KTMaHang(listHangHoa,maHang) == false);
    
            Console.WriteLine("Nhap 1 de cap nhat Ten Hang");
            Console.WriteLine("Nhap 2 de cap nhat Noi San Xuat");
            Console.WriteLine("Nhap 3 de cap nhat Mau Sac");
            Console.WriteLine("Nhap 4 de cap nhat Gia Ban");
            Console.WriteLine("Nhap 5 de cap nhat So Luong");
            Console.WriteLine("Nhap 6 de cap nhat Ngay nhap kho");
            Console.Write("\n\tLua chon cua ban la:\t");
            string luaChon = "";
            int count = 0;
            do
            {
                if (count > 0) Console.Write("Lua chon cua ban phai > 0 va < 7 !!!!!\nMoi ban nhap lai: ");
                luaChon = Console.ReadLine();
                count++;
            } while (luaChon != "1" && luaChon != "2" && luaChon != "3" && luaChon != "4" && luaChon != "5" && luaChon != "6");
            for (LinkedListNode<HangHoa> p = listHangHoa.First; p != null; p = p.Next)
            {
                if (string.Compare(maHang, p.Value.MaHang) == 0)
                {
                    switch (luaChon)
                    {
                        case "1":
                            Console.Write("Cap nhat lai Ten Hang: ");
                            p.Value.TenHang = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cap nhat thanh cong");
                            Console.ResetColor();
                            GhiFileHangHoa(listHangHoa);
                            break;
                        case "2":
                            Console.Write("Cap nhat lai Noi San Xuat ");
                            p.Value.NoiSanXuat = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cap nhat thanh cong");
                            Console.ResetColor();
                            GhiFileHangHoa(listHangHoa);
                            break; 
                        case "3":
                            Console.Write("Cap nhat lai Mau Sac ");
                            p.Value.MauSac = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cap nhat thanh cong");
                            Console.ResetColor();
                            GhiFileHangHoa(listHangHoa);
                            break;
                        case "4":
                            Console.Write("Cap nhat lai Gia Ban ");
                            p.Value.GiaBan = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cap nhat thanh cong");
                            Console.ResetColor();
                            GhiFileHangHoa(listHangHoa);
                            break;
                        case "5":
                            Console.Write("Cap nhat lai So Luong ");
                            p.Value.SoLuong = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cap nhat thanh cong");
                            Console.ResetColor();
                            GhiFileHangHoa(listHangHoa);
                            break;
                        case "6":
                            Console.Write("Cap nhat lai Ngay Nhap Kho ");
                            string s = Console.ReadLine();
                            string[] d1 = s.Split('/');
                            p.Value.NgayNhapKho = new DateTime(int.Parse(d1[2]), int.Parse(d1[1]), int.Parse(d1[0]));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Cap nhat thanh cong");
                            Console.ResetColor();
                            GhiFileHangHoa(listHangHoa);
                            break;
                        default: break;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Đặt hàng
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="listDonHang"></param>
        static void DatHang(LinkedList<HangHoa> listHangHoa, Queue<DonHang> listDonHang)
        {
            string maHang = "", tenKH = "", diaChi = "", sDT = "";
            int soLg = 0, tongTien = 0;
            do
            {
                Console.Write($"{"\t\t\tNhap ma hang (4 ky tu):\t",10}");
                maHang = Console.ReadLine();
                if (KTMaHang(listHangHoa, maHang) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tMa Hang khong ton tai");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!isValidMaHang(maHang));

            //kiem tra so luong hang con trong kho hay ko?
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{"\t\t\tNhap so luong:\t\t",10}");
                int.TryParse(Console.ReadLine(), out soLg);
                if(soLg > Find(listHangHoa, maHang).SoLuong)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tVuot qua so luong hien co cua san pham !");
                    Console.ResetColor();
                }
            } while (soLg <= 0 || KTSoLg(listHangHoa, maHang, soLg) == false);
            
            // Nhap ho ten hop le
            do
            {
                Console.Write($"{"\t\t\tTen khach hang:\t\t",10}");
                tenKH = Console.ReadLine();
            } while (!isValidHoTen(tenKH));

            // Nhap dia chi khong duoc de trong
            do
            {
                Console.Write($"{"\t\t\tDia chi khach hang:\t",10}");
                diaChi = Console.ReadLine();
            } while (diaChi.Length <= 0);

            int temp = TraVeGia(listHangHoa, maHang);
            if (temp != -1)
            {
                tongTien = temp * soLg;
            }

            do
            {
                Console.Write($"{"\t\t\tSo dien thoai:\t\t",10}");
                sDT = Console.ReadLine();
            } while (isValidSDT(sDT) == false);

            DateTime ngayDat = DateTime.Now;
            DonHang donHang = new DonHang(listDonHang.Count+1, maHang, soLg, tenKH, diaChi, tongTien, sDT, ngayDat);
            // Cập nhật lại số lượng cho hàng hóa
            Find(listHangHoa, maHang).SoLuong -= soLg;

            // Thêm đơn hàng vào danh sách đơn hàng
            listDonHang.Enqueue(donHang);

            // Thông báo thành công
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tDat hang thanh cong !");
            Console.ResetColor();
            GhiFileHangHoa(listHangHoa);
            GhiFileDonHang(listDonHang);
        }

        /// <summary>
        /// Xử lí đơn hàng
        /// </summary>
        /// <param name="listDonHang"></param>
        static void XuLiDonHang(Queue<DonHang> listDonHang)
        {
            // Hien thi cac don hang dang cho xu li
            if (listDonHang.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tKhong co don hang nao can xu li !");
                Console.ResetColor();
            }
            else
            {
                ShowListDonHang(listDonHang);
            }
        }

        /// <summary>
        /// Các hàm kiểm tra tính hợp lệ
        /// </summary>
        /// <param name="maHang"></param>
        /// <returns></returns>
        static bool isValidMaHang(string maHang)
        {
            if (maHang.Contains(" ") || maHang.Length != 4)
                return false;
            return true;
        }
        /// <summary>
        /// Kiểm tra nếu chuỗi không chứa ký tự đặc biệt hoặc số
        /// Sử dụng biểu thức chính quy: chỉ chấp nhận chữ cái và khoảng trắng
        /// </summary>
        /// <param name="hoTen"></param>
        /// <returns></returns>
        static bool isValidHoTen(string hoTen)
        {
           
            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
            return regex.IsMatch(hoTen);
        }
        /// <summary>
        /// Kiểm tra độ dài của chuỗi ma hang
        /// </summary>
        /// <param name="listHangHoa"></param>
        /// <param name="maHang"></param>
        /// <returns></returns>
        static bool isValidMaHang(LinkedList<HangHoa> listHangHoa, string maHang)
        {
            
            if (maHang.Length != 4)
            {
                return false;
            }

            // Sử dụng Regular Expression để kiểm tra chuỗi chỉ chứa chữ và số
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(maHang);
        }
        /// <summary>
        /// Kiểm tra độ dài của chuỗi SDT
        /// </summary>
        /// <param name="sdt"></param>
        /// <returns></returns>
        static bool isValidSDT(string sdt)
        {
            
            if (sdt.Length != 10 && sdt.Length != 11)
            {
                return false;
            }

            // Sử dụng Regular Expression để kiểm tra chuỗi chỉ chứa số
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(sdt);
        }
        /// <summary>
        /// Kiển tra mã hàng có tồn tại hay không
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        static bool KTMaHang(LinkedList<HangHoa> arr, string s)
        {
            for (LinkedListNode<HangHoa> p = arr.First; p != null; p = p.Next)
            {
                if (p.Value.MaHang == s)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Trả về giá của hàng hóa trong DS Hàng Hóa
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        static int TraVeGia(LinkedList<HangHoa> arr, string s)
        {
            for (LinkedListNode<HangHoa> p = arr.First; p != null; p = p.Next)
            {
                if (p.Value.MaHang == s)
                {
                    return p.Value.GiaBan;
                }
            }
            return -1;
        }
        /// <summary>
        /// KT Só Lượng Hàng Hóa
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="s"></param>
        /// <param name="sl"></param>
        /// <returns></returns>
        static bool KTSoLg(LinkedList<HangHoa> arr, string s, int sl)
        {
            for (LinkedListNode<HangHoa> p = arr.First; p != null; p = p.Next)
            {
                if (p.Value.MaHang == s)
                {
                    if (sl < p.Value.SoLuong)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        static bool KTKTDB(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '!'|| s[i] == '@'|| s[i] == '#'|| s[i] == '$'|| s[i] == '%'|| s[i] == '^'|| s[i] == '&'|| s[i] == '*'|| s[i] == '('|| s[i] == ')'|| s[i] == '-'|| s[i] == '=')
                {
                    return false;
                }
            }
            return true;
        }
        

        //********** Đọc ghi file ***********
        /// <summary>
        /// Đọc file Admin.txt
        /// </summary>
        static LinkedList<Admin> DocFileAdmin()
        {
            LinkedList<Admin> L = new LinkedList<Admin>();
            try
            {
                using (StreamReader sr = new StreamReader("Admin.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t = line.Split('#');
                        // new admin(username, password)
                        Admin ad = new Admin(t[0], t[1]);
                        L.AddLast(ad);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Khong tim thay file Admin.txt !");
            }
            return L;
        }
        
        /// <summary>
        /// Đọc file HangHoa.txt
        /// </summary>
        /// <param name="arrHH"></param>
        static LinkedList<HangHoa> DocFileHangHoa()
        {
            LinkedList<HangHoa> L = new LinkedList<HangHoa>();
            try
            {
                using (StreamReader sr = new StreamReader("HangHoa.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t = line.Split('#');
                        if (t.Length == 7) // Kiểm tra đúng định dạng của hàng hóa
                        {
                            if (int.TryParse(t[4], out int giaBan) && int.TryParse(t[5], out int soLuong) && DateTime.TryParse(t[6], out DateTime ngayNhapKho))
                            {
                                HangHoa hh = new HangHoa(t[0], t[1], t[2], t[3], giaBan, soLuong, ngayNhapKho);
                                L.AddLast(hh);
                            }
                            else
                            {
                                Console.WriteLine($"Khong doc duoc dong hang hoa: {line}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Khong doc duoc dong hang hoa: {line}");
                        }
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Khong tim thay file HangHoa.txt !");
            }
            return L;
        }

        /// <summary>
        /// Đọc file DonHang.txt
        /// </summary>
        static Queue<DonHang> DocFileDonHang()
        {
            Queue<DonHang> L = new Queue<DonHang>();
            try
            {
                using (StreamReader sr = new StreamReader("DonHang.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // soThuTu, maHang, soLuong, tenKhachHang, diaChi, tongTien, soDienThoai, ngayDat
                        string[] t = line.Split('#');
                        if (t.Length == 8) // Kiểm tra đúng định dạng của đơn hàng
                        {
                            if (int.TryParse(t[0], out int soThuTu) && int.TryParse(t[2], out int soLuong) && int.TryParse(t[5], out int tongTien) && DateTime.TryParse(t[7], out DateTime ngayDat))
                            {
                                DonHang dh = new DonHang(soThuTu, t[1], soLuong, t[3], t[4], tongTien, t[6], ngayDat);
                                L.Enqueue(dh);
                            }
                            else
                            {
                                Console.WriteLine($"Khong doc duoc dong don hang: {line}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Khong doc duoc dong don hang: {line}");
                        }
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Khong tim thay file DonHang.txt !");
            }
            return L;
        }

        /// <summary>
        /// Ghi lại dữ liệu vào file HangHoa.txt
        /// </summary>
        /// <param name="listHangHoa"></param>
        static void GhiFileHangHoa(LinkedList<HangHoa> listHangHoa)
        {
            try
            {
                // Xóa nội dung của file "HangHoa.txt"
                File.WriteAllText("HangHoa.txt", string.Empty);

                // Ghi dữ liệu của tất cả các HangHoa vào file "HangHoa.txt"
                using (StreamWriter sw = new StreamWriter("HangHoa.txt", true))
                {
                    foreach (HangHoa hh in listHangHoa)
                    {
                        string line = hh.ToLine();
                        sw.WriteLine(line);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Ghi file thất bại!");
            }
        }

        /// <summary>
        /// Ghi lại dữ liệu vào file DonHang.txt
        /// </summary>
        /// <param name="listDonHang"></param>
        static void GhiFileDonHang(Queue<DonHang> listDonHang)
        {
            try
            {
                // Xóa nội dung của file "DonHang.txt"
                File.WriteAllText("DonHang.txt", string.Empty);

                // Ghi dữ liệu của tất cả các HangHoa vào file "HangHoa.txt"
                using (StreamWriter sw = new StreamWriter("DonHang.txt", true))
                {
                    int stt = 1;
                    foreach (DonHang dh in listDonHang)
                    {
                        dh.SoThuTu = stt;
                        string line = dh.ToLine();
                        sw.WriteLine(line);
                        stt++;
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Ghi file thất bại!");
            }
        }
    }
}
