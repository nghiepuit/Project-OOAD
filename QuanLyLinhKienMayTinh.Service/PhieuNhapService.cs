using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface IPhieuNhapService
    {
        void ThemMoi(PhieuNhap item);

        void CapNhat(PhieuNhap item);

        void Xoa(int Ma);

        IEnumerable<PhieuNhap> LayTatCa();

        IEnumerable<PhieuNhap> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        PhieuNhap LayTheoMa(int Ma);

        void luu();
    }

    public class PhieuNhapService : IPhieuNhapService
    {
        private IPhieuNhapRepository _pnRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public PhieuNhapService(IPhieuNhapRepository pnRepository, IUnitOfWork unitOfWork)
        {
            this._pnRepository = pnRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(PhieuNhap item)
        {
            _pnRepository.Add(item);
        }

        public void CapNhat(PhieuNhap item)
        {
            _pnRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _pnRepository.Delete(Ma);
        }

        public IEnumerable<PhieuNhap> LayTatCa()
        {
            return _pnRepository.GetAll();
        }

        public IEnumerable<PhieuNhap> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _pnRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public PhieuNhap LayTheoMa(int Ma)
        {
            return _pnRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }
    }
}