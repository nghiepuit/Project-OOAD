using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface IChiTietPhieuNhapService
    {
        void ThemMoi(ChiTietPhieuNhap item);

        void CapNhat(ChiTietPhieuNhap item);

        void Xoa(int Ma);

        IEnumerable<ChiTietPhieuNhap> LayTatCa();

        IEnumerable<ChiTietPhieuNhap> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        ChiTietPhieuNhap LayTheoMa(int Ma);

        void luu();
    }

    public class ChiTietPhieuNhapService : IChiTietPhieuNhapService
    {
        private IChiTietPhieuNhapRepository _ctpnRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public ChiTietPhieuNhapService(IChiTietPhieuNhapRepository ctpnRepository, IUnitOfWork unitOfWork)
        {
            this._ctpnRepository = ctpnRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(ChiTietPhieuNhap item)
        {
            _ctpnRepository.Add(item);
        }

        public void CapNhat(ChiTietPhieuNhap item)
        {
            _ctpnRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _ctpnRepository.Delete(Ma);
        }

        public IEnumerable<ChiTietPhieuNhap> LayTatCa()
        {
            return _ctpnRepository.GetAll();
        }

        public IEnumerable<ChiTietPhieuNhap> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            var query = _ctpnRepository.GetAll();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public ChiTietPhieuNhap LayTheoMa(int Ma)
        {
            return _ctpnRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }
    }
}