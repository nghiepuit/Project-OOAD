using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface IThanhVienService
    {
        void ThemMoi(ThanhVien item);

        void CapNhat(ThanhVien item);

        void Xoa(int Ma);

        IEnumerable<ThanhVien> LayTatCa();

        IEnumerable<ThanhVien> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        ThanhVien LayTheoMa(int Ma);

        int TongSoPhanTu();

        void luu();
    }

    public class ThanhVienService : IThanhVienService
    {
        private IThanhVienRepository _ThanhVienRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public ThanhVienService(IThanhVienRepository ThanhVienRepository, IUnitOfWork unitOfWork)
        {
            this._ThanhVienRepository = ThanhVienRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(ThanhVien item)
        {
            _ThanhVienRepository.Add(item);
        }

        public void CapNhat(ThanhVien item)
        {
            _ThanhVienRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _ThanhVienRepository.Delete(Ma);
        }

        public IEnumerable<ThanhVien> LayTatCa()
        {
            return _ThanhVienRepository.GetAll();
        }

        public IEnumerable<ThanhVien> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _ThanhVienRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public ThanhVien LayTheoMa(int Ma)
        {
            return _ThanhVienRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

        public int TongSoPhanTu()
        {
            return _ThanhVienRepository.Count(x => x.DaXoa == false);
        }
    }
}