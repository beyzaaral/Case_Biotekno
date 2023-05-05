using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedSuccessMessage = "Ekleme işlemi başarılı";
        public static string UpdatedSuccessMessage = "Güncelleme işlemi başarılı";
        public static string AddedErrorMessage = "Ekleme işlemi başarısız";
        public static string UpdatedErrorMessage = "Güncelleme işlemi başarısız";
        public static string SuccessGetAllMessage = "Veri Listeleme Başarılı";
        public static string ErrorGetAllMessage = "Veri Listeleme Başarısız";
        public static string ErrorEmpityMessage = "Boş değer bırakmayınız.";
        public static string ErrorOrderMessage = "Firma şuan sipariş almıyor";
        public static string ErrorNullMessage = "Lütfen geçerli bir değer giriniz";
        public static string ErrorIsActiveMessage = "Firma Onaylı Değil,";
    }
}
