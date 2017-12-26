using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface ISanPhamService
    {
        void ThemMoi(SanPham item);

        void CapNhat(SanPham item);

        void Xoa(int Ma);

        IEnumerable<SanPham> LayTatCa();

        IEnumerable<SanPham> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        SanPham LayTheoMa(int Ma);

        void luu();

        // Custom
        IEnumerable<SanPham> LaySanPhamSapHetHang(int SoLuongTon);

        IEnumerable<SanPham> LayDienThoaiMoiNhat(int limit);

        IEnumerable<SanPham> LayLaptopMoiNhat(int limit);

        IEnumerable<SanPham> LayTabletMoiNhat(int limit);

        IEnumerable<SanPham> LayLinhKienMoiNhat(int limit);

        IEnumerable<SanPham> LaySanPhamTheoDanhMuc(int LoaiSP, int MaNSX, int page, int pageSize, string sort, out int totalRow);
    }

    public class SanPhamService : ISanPhamService
    {
        private ISanPhamRepository _sanPhamRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public SanPhamService(ISanPhamRepository sanPhamRepository, IUnitOfWork unitOfWork)
        {
            this._sanPhamRepository = sanPhamRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(SanPham item)
        {
            _sanPhamRepository.Add(item);
        }

        public void CapNhat(SanPham item)
        {
            _sanPhamRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _sanPhamRepository.Delete(Ma);
        }

        public IEnumerable<SanPham> LayTatCa()
        {
            return _sanPhamRepository.GetAll();
        }

        public IEnumerable<SanPham> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _sanPhamRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public SanPham LayTheoMa(int Ma)
        {
            return _sanPhamRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<SanPham> LaySanPhamSapHetHang(int SoLuongTon)
        {
            return _sanPhamRepository.LaySanPhamSapHetHang(SoLuongTon);
        }

        public IEnumerable<SanPham> LayDienThoaiMoiNhat(int limit)
        {
            return _sanPhamRepository.LaySanPhamMoiNhat(1, limit);
        }

        public IEnumerable<SanPham> LayLaptopMoiNhat(int limit)
        {
            return _sanPhamRepository.LaySanPhamMoiNhat(2, limit);
        }

        public IEnumerable<SanPham> LayTabletMoiNhat(int limit)
        {
            return _sanPhamRepository.LaySanPhamMoiNhat(3, limit);
        }

        public IEnumerable<SanPham> LayLinhKienMoiNhat(int limit)
        {
            return _sanPhamRepository.LaySanPhamMoiNhat(4, limit);
        }

        public IEnumerable<SanPham> LaySanPhamTheoDanhMuc(int LoaiSP, int MaNSX, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _sanPhamRepository.GetMulti(x => x.DaXoa == false && x.MaLSP == LoaiSP);
            if (MaNSX != -1)
            {
                query = query.Where(x => x.MaNSX == MaNSX);
            }
            switch (sort)
            {
                case "pho-bien":
                    query = query.OrderByDescending(x => x.LuotXem);
                    break;

                case "gia-tang":
                    query = query.OrderBy(x => x.DonGia);
                    break;

                case "gia-giam":
                    query = query.OrderByDescending(x => x.DonGia);
                    break;

                default:
                    query = query.OrderByDescending(x => x.Ten);
                    break;
            }

            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}