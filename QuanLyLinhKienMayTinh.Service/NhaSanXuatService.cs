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

    public interface INhaSanXuatService
    {
        void ThemMoi(NhaSanXuat item);
        void CapNhat(NhaSanXuat item);
        void Xoa(int Ma);
        IEnumerable<NhaSanXuat> LayTatCa();
        IEnumerable<NhaSanXuat> LayTatCaPhanTrang(int page, int pageSize, out int totalRow);
        NhaSanXuat LayTheoMa(int Ma);
        void luu();
    }

    public class NhaSanXuatService : INhaSanXuatService
    {
        private INhaSanXuatRepository _nhaSanXuatRepository;
        private IUnitOfWork _unitOfWork;

        // Dependency Injection
        public NhaSanXuatService(INhaSanXuatRepository nhaSanXuatRepository, IUnitOfWork unitOfWork)
        {
            this._nhaSanXuatRepository = nhaSanXuatRepository;
            this._unitOfWork = unitOfWork;
        }

        public void CapNhat(NhaSanXuat item)
        {
            _nhaSanXuatRepository.Update(item);
        }

        public IEnumerable<NhaSanXuat> LayTatCa()
        {
            return _nhaSanXuatRepository.GetAll();
        }

        public IEnumerable<NhaSanXuat> LayTatCaPhanTrang(int page, int pageSize, out int totalRow)
        {
            return _nhaSanXuatRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public NhaSanXuat LayTheoMa(int Ma)
        {
            return _nhaSanXuatRepository.GetSingleById(Ma);
        }

        public void luu()
        {
            _unitOfWork.Commit();
        }

        public void ThemMoi(NhaSanXuat item)
        {
            _nhaSanXuatRepository.Add(item);
        }

        public void Xoa(int Ma)
        {
            _nhaSanXuatRepository.Delete(Ma);
        }
    }
}
