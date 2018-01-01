using System;

namespace QuanLyLinhKienMayTinh.Common
{
    public class UploadHelper
    {
        public static string RenameImage(string Extension)
        {
            return Guid.NewGuid().ToString() + "_" + DateTime.Now.Millisecond + Extension;
        }
    }
}