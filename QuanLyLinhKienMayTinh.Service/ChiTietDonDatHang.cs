using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface IChiTietDonDatHangService
    {
        void ThemMoi(ChiTietDonDatHang item);

        void CapNhat(ChiTietDonDatHang item);

        void Xoa(int Ma);

        IEnumerable<ChiTietDonDatHang> LayTatCa();

        IEnumerable<ChiTietDonDatHang> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        ChiTietDonDatHang LayTheoMa(int Ma);

        void luu();

        //custom
        decimal ThongKeDoanhThu();
    }

    public class ChiTietDonDatHangService : IChiTietDonDatHangService
    {
        private IChiTietDonDatHangRepository _ctddhRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public ChiTietDonDatHangService(IChiTietDonDatHangRepository ctddhRepository, IUnitOfWork unitOfWork)
        {
            this._ctddhRepository = ctddhRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(ChiTietDonDatHang item)
        {
            _ctddhRepository.Add(item);
        }

        public void CapNhat(ChiTietDonDatHang item)
        {
            _ctddhRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _ctddhRepository.Delete(Ma);
        }

        public IEnumerable<ChiTietDonDatHang> LayTatCa()
        {
            return _ctddhRepository.GetAll();
        }

        public IEnumerable<ChiTietDonDatHang> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            var query = _ctddhRepository.GetAll();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public ChiTietDonDatHang LayTheoMa(int Ma)
        {
            return _ctddhRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

        public decimal ThongKeDoanhThu()
        {
            var result = _ctddhRepository.GetAll().Sum(x => x.SoLuong * x.DonGia);
            return result > 0 ? result : 0;
        }
    }
}