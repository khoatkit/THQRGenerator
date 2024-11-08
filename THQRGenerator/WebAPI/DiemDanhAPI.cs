using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THQRGenerator.Models;

namespace THQRGenerator.WebAPI
{
    class DiemDanhAPI
    {
        private static string subPath = "qrdiemdanh/";
        private static string _username = "khachhang";
        private static string _password = "TM7}1Ixd;1Y!{qTB";
        public static string Error { get { return WebAPIHelper.Error; } }
        private static async Task<bool> Login()
        {
            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
                return false;
            await WebAPIHelper.LoginAsync(_username, _password, "khachhang");
            if (!string.IsNullOrEmpty(Error))
                return false;
            return true;
        }
        public static async Task<List<DiemDanh>> GetListDiemDanh()
        {
            if (!await Login()) return null;
            var result = await WebAPIHelper.GetDataAsync<List<DiemDanh>>("GET", $"{subPath}diemdanh", "");
            return result;
        }
        public static async Task<DiemDanh> GetDiemDanh(int id)
        {
            if (!await Login()) return null;
            var result = await WebAPIHelper.GetDataAsync<DiemDanh>("GET", $"{subPath}diemdanh/{id}", "");
            return result;
        }
        public static async Task<bool> InsertDiemDanh(DiemDanh value)
        {
            if (!await Login()) return false;
            var result = await WebAPIHelper.GetDataAsync<bool>("POST", $"{subPath}diemdanh", value);
            return result;
        }
        public static async Task<bool> UpdateDiemDanh(DiemDanh value)
        {
            if (!await Login()) return false;
            var result = await WebAPIHelper.GetDataAsync<bool>("PUT", $"{subPath}diemdanh", value);
            return result;
        }
        public static async Task<bool> DeleteDiemDanh(int id)
        {
            if (!await Login()) return false;
            var result = await WebAPIHelper.GetDataAsync<bool>("DELETE", $"{subPath}diemdanh", id);
            return result;
        }
        public static async Task<bool> CheckDiemDanh(int id, bool value)
        {
            if (!await Login()) return false;
            bool result;
            if (value)
                result = await WebAPIHelper.GetDataAsync<bool>("GET", $"{subPath}checkoutdiemdanh/{id}", ""); 
            else
                result = await WebAPIHelper.GetDataAsync<bool>("GET", $"{subPath}checkdiemdanh/{id}", "");
            return result;
        }
        public static async Task<bool> UnCheckDiemDanh(int id)
        {
            if (!await Login()) return false;
            var result = await WebAPIHelper.GetDataAsync<bool>("GET", $"{subPath}uncheckdiemdanh/{id}", "");
            return result;
        }
    }
}