using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface ILoaiSanPhamService
    {
        void ThemMoi(LoaiSanPham item);

        void CapNhat(LoaiSanPham item);

        void Xoa(int Ma);

        IEnumerable<LoaiSanPham> LayTatCa();

        IEnumerable<LoaiSanPham> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        LoaiSanPham LayTheoMa(int Ma);

        void luu();
    }

    public class LoaiSanPhamService : ILoaiSanPhamService
    {
        private ILoaiSanPhamRepository _loaiSanPhamRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public LoaiSanPhamService(ILoaiSanPhamRepository loaiSanPhamRepository, IUnitOfWork unitOfWork)
        {
            this._loaiSanPhamRepository = loaiSanPhamRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(LoaiSanPham item)
        {
            _loaiSanPhamRepository.Add(item);
        }

        public void CapNhat(LoaiSanPham item)
        {
            _loaiSanPhamRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _loaiSanPhamRepository.Delete(Ma);
        }

        public IEnumerable<LoaiSanPham> LayTatCa()
        {
            return _loaiSanPhamRepository.GetAll();
        }

        public IEnumerable<LoaiSanPham> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _loaiSanPhamRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public LoaiSanPham LayTheoMa(int Ma)
        {
            return _loaiSanPhamRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }
    }
}