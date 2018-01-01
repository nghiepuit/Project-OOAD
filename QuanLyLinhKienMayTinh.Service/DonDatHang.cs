using QuanLyLinhKienMayTinh.Common.ViewModels;
using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface IDonDatHangService
    {
        void ThemMoi(DonDatHang item);

        void CapNhat(DonDatHang item);

        void Xoa(int Ma);

        IEnumerable<DonDatHang> LayTatCa();

        IEnumerable<DonDatHang> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        DonDatHang LayTheoMa(int Ma);

        void luu();

        IEnumerable<ThongKeDoanhThuLoiNhuan> ThongKeDoanhThuLoiNhuan(string TuNgay, string DenNgay);
    }

    public class DonDatHangService : IDonDatHangService
    {
        private IDonDatHangRepository _ctddhRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public DonDatHangService(IDonDatHangRepository ctddhRepository, IUnitOfWork unitOfWork)
        {
            this._ctddhRepository = ctddhRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(DonDatHang item)
        {
            _ctddhRepository.Add(item);
        }

        public void CapNhat(DonDatHang item)
        {
            _ctddhRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _ctddhRepository.Delete(Ma);
        }

        public IEnumerable<DonDatHang> LayTatCa()
        {
            return _ctddhRepository.GetAll();
        }

        public IEnumerable<DonDatHang> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            var query = _ctddhRepository.GetAll();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public DonDatHang LayTheoMa(int Ma)
        {
            return _ctddhRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ThongKeDoanhThuLoiNhuan> ThongKeDoanhThuLoiNhuan(string TuNgay, string DenNgay)
        {
            return _ctddhRepository.ThongKeDoanhThuLoiNhuan(TuNgay, DenNgay);
        }
    }
}