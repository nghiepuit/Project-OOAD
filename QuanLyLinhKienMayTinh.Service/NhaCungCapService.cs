using QuanLyLinhKienMayTinh.Data.Infrastructure;
using QuanLyLinhKienMayTinh.Data.Repositories;
using QuanLyLinhKienMayTinh.Entities;
using System.Collections.Generic;

namespace QuanLyLinhKienMayTinh.Service
{
    public interface INhaCungCapService
    {
        void ThemMoi(NhaCungCap item);

        void CapNhat(NhaCungCap item);

        void Xoa(int Ma);

        IEnumerable<NhaCungCap> LayTatCa();

        IEnumerable<NhaCungCap> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);

        NhaCungCap LayTheoMa(int Ma);

        void luu();
    }

    public class NhaCungCapService : INhaCungCapService
    {
        private INhaCungCapRepository _nccRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public NhaCungCapService(INhaCungCapRepository nccRepository, IUnitOfWork unitOfWork)
        {
            this._nccRepository = nccRepository;
            this._unitOfWork = unitOfWork;
        }

        public void ThemMoi(NhaCungCap item)
        {
            _nccRepository.Add(item);
        }

        public void CapNhat(NhaCungCap item)
        {
            _nccRepository.Update(item);
        }

        public void Xoa(int Ma)
        {
            _nccRepository.Delete(Ma);
        }

        public IEnumerable<NhaCungCap> LayTatCa()
        {
            return _nccRepository.GetAll();
        }

        public IEnumerable<NhaCungCap> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _nccRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public NhaCungCap LayTheoMa(int Ma)
        {
            return _nccRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }
    }
}