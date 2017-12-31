using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface IQuyenService
    {
        void ThemMoi(Quyen item);

        void CapNhat(Quyen item);

        void Xoa(string Ma);

        IEnumerable<Quyen> LayTatCa();

        IEnumerable<Quyen> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        Quyen LayTheoMa(int Ma);

        void luu();

        //custom
    }

    public class QuyenService : IQuyenService
    {
        private IQuyenRepository _QuyenRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public QuyenService(IQuyenRepository QuyenRepository, IUnitOfWork unitOfWork)
        {
            this._QuyenRepository = QuyenRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(Quyen item)
        {
            _QuyenRepository.Add(item);
        }

        public void CapNhat(Quyen item)
        {
            _QuyenRepository.Update(item);
        }

        public void Xoa(string Ma)
        {
            _QuyenRepository.DeleteByIdString(Ma);
        }

        public IEnumerable<Quyen> LayTatCa()
        {
            return _QuyenRepository.GetAll();
        }

        public IEnumerable<Quyen> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _QuyenRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public Quyen LayTheoMa(int Ma)
        {
            return _QuyenRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

    }
}