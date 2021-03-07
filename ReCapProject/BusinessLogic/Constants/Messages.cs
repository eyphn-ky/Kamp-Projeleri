using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün Eklendi";
        public static string CarDailyPriceInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Bakım arası";
        public static string CarsListed = "Araçlar Listelendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandNameInvalid = "Marka İsmi Hatalı";
        public static string BrandDeleted = "Marka Silme Başarılı";
        public static string BrandListed = "Markalar Listelendi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string CanNotRent = "Araç bir başka müşteride";
        public static string SuccessRental = "Kiralama Başarılı";
        public static string UpdateSuccesful = "Araç Başarılı bir şekilde teslim edildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccesfulLogin = "Giriş başarılı";
        public static string UserExists = "Bu email kullanılıyor";
        public static string SuccesfulRegister = "Kayıt Başarılı";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
