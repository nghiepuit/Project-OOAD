using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLinhKienMayTinh.Service
{

    public interface IKhachHangService
    {
        void ThemMoi(KhachHang item);
        void CapNhat(KhachHang item);
        void Xoa(int Ma);
        IEnumerable<KhachHang> LayTatCa();
        IEnumerable<KhachHang> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);
        KhachHang LayTheoMa(int Ma);
        void luu();
        IEnumerable<KhachHang> LayKhachHangTheoMaThanhVien(int MaTV);
    }

    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepository _KhachHangRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public KhachHangService(IKhachHangRepository KhachHangRepository, IUnitOfWork unitOfWork)
        {
            this._KhachHangRepository = KhachHangRepository;
            this._unitOfWork = unitOfWork;
        }

        public void CapNhat(KhachHang item)
        {
            _KhachHangRepository.Update(item);
        }

        public IEnumerable<KhachHang> LayKhachHangTheoMaThanhVien(int MaTV)
        {
            return _KhachHangRepository.LayKhachHangTheoMaThanhVien(MaTV);
        }

        public IEnumerable<KhachHang> LayTatCa()
        {
            return _KhachHangRepository.GetAll();
        }

        public IEnumerable<KhachHang> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _KhachHangRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public KhachHang LayTheoMa(int Ma)
        {
            return _KhachHangRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

        public void ThemMoi(KhachHang item)
        {
            _KhachHangRepository.Add(item);
        }

        public void Xoa(int Ma)
        {
            _KhachHangRepository.Delete(Ma);
        }
    }
}
