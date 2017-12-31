using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;
using System;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface ILoaiThanhVien_QuyenService
    {
        void ThemMoi(LoaiThanhVien_Quyen item);

        void CapNhat(LoaiThanhVien_Quyen item);

        void Xoa(int Ma);

        void XoaNhieu(IEnumerable<LoaiThanhVien_Quyen> list);

        IEnumerable<LoaiThanhVien_Quyen> LayTatCa();

        IEnumerable<LoaiThanhVien_Quyen> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        LoaiThanhVien_Quyen LayTheoMa(int Ma);

        void luu();

        //custom
        IEnumerable<LoaiThanhVien_Quyen> LayDanhSachQuyenTheoLoaiThanhVien(int MaLTV);
    }

    public class LoaiThanhVien_QuyenService : ILoaiThanhVien_QuyenService
    {
        private ILoaiThanhVien_QuyenRepository _LoaiThanhVien_QuyenRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public LoaiThanhVien_QuyenService(ILoaiThanhVien_QuyenRepository LoaiThanhVien_QuyenRepository, IUnitOfWork unitOfWork)
        {
            this._LoaiThanhVien_QuyenRepository = LoaiThanhVien_QuyenRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(LoaiThanhVien_Quyen item)
        {
            _LoaiThanhVien_QuyenRepository.Add(item);
        }

        public void CapNhat(LoaiThanhVien_Quyen item)
        {
            _LoaiThanhVien_QuyenRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _LoaiThanhVien_QuyenRepository.Delete(Ma);
        }

        public IEnumerable<LoaiThanhVien_Quyen> LayTatCa()
        {
            return _LoaiThanhVien_QuyenRepository.GetAll();
        }

        public IEnumerable<LoaiThanhVien_Quyen> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _LoaiThanhVien_QuyenRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public LoaiThanhVien_Quyen LayTheoMa(int Ma)
        {
            return _LoaiThanhVien_QuyenRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<LoaiThanhVien_Quyen> LayDanhSachQuyenTheoLoaiThanhVien(int MaLTV)
        {
            return _LoaiThanhVien_QuyenRepository.GetMulti(x => x.MaLoaiTV == MaLTV);
        }

        public void XoaNhieu(IEnumerable<LoaiThanhVien_Quyen> list)
        {
            _LoaiThanhVien_QuyenRepository.DeleteMulti(list);
        }
    }
}