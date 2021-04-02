using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string MaintenanceTime = "Zaman hatası";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarsListed = "Arabalar listelendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorsListed = "Renkler listelendi";

        public static string RentalAdded = "Kira eklendi";
        public static string RentalDeleted = "Kira silindi";
        public static string RentalUpdated = "Kira güncellendi";
        public static string RentalsListed = "Kiralar listelendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler lsitelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi.";

        public static string CardAdded = "Kart eklendi";
        public static string CardDeleted = "Kart silindi";
        public static string CardUpdated = "Kart Güncellendi";
        public static string CardsListed = "Kartlar listelendi";

        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string CarImagesListed = "Resim listelendi.";
        public static string CarImagesLimitExceeded = "Resim limiti aşıldı.";

        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserRegistered = "Kayıt oldu";
        public static string PasswordError = "Parola hatası";
        public static string UserNotFound = "Kullanıcı bulanamadı.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı Mevcut.";
        public static string AccessTokenCreated = "Token Oluşturuldu.";

        public static string CarNameAlreadyExists = "Aynı isimde araba zaten mevcut";

        public static string FailedCarListed = "Araba listelenmesi başarısız."; 
    }
}
