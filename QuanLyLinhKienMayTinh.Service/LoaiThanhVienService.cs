using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface ILoaiThanhVienService
    {
        void ThemMoi(LoaiThanhVien item);

        void CapNhat(LoaiThanhVien item);

        void Xoa(int Ma);

        IEnumerable<LoaiThanhVien> LayTatCa();

        IEnumerable<LoaiThanhVien> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        LoaiThanhVien LayTheoMa(int Ma);

        void luu();

        //custom
    }

    public class LoaiThanhVienService : ILoaiThanhVienService
    {
        private ILoaiThanhVienRepository _LoaiThanhVienRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public LoaiThanhVienService(ILoaiThanhVienRepository LoaiThanhVienRepository, IUnitOfWork unitOfWork)
        {
            this._LoaiThanhVienRepository = LoaiThanhVienRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(LoaiThanhVien item)
        {
            _LoaiThanhVienRepository.Add(item);
        }

        public void CapNhat(LoaiThanhVien item)
        {
            _LoaiThanhVienRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _LoaiThanhVienRepository.Delete(Ma);
        }

        public IEnumerable<LoaiThanhVien> LayTatCa()
        {
            return _LoaiThanhVienRepository.GetAll();
        }

        public IEnumerable<LoaiThanhVien> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _LoaiThanhVienRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public LoaiThanhVien LayTheoMa(int Ma)
        {
            return _LoaiThanhVienRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }
    }
}