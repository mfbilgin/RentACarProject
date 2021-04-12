using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Constants
{
    public static class Messages
    {
        // # Message of Car # //
        public const string CarAdded = "Araç Sisteme Eklendi";
        public const string CarDeleted = "Araç Sistemden Silindi";
        public const string CarUpdated = "Araç Bilgileri Güncellendi";
        public const string CarMissmatch = "Eşleşme Bulunamadı";


        // # Message of Brand # //
        public const string BrandAdded = "Marka Sisteme Eklendi";
        public const string BrandDeleted = "Marka Sistemden Silindi";


        // # Message of Color # //
        public const string ColorAdded = "Renk Sisteme Eklendi";
        public const string ColorDeleted = "Renk Sistemden Silindi";


        // # Messages of Rental # //
        public const string RentalSuccess = "Araç Kiralandı";
        public const string RentalUpdated = "Kiralama Bilgileri Güncellendi";
        public const string RentalDeleted = "Kiralama Sistemden Silindi";


        // # Messages of Image # //
        public const string CarImagesCountExceded = "Bir aracın en fazla 5 resmi olabilir.";
        public const string ImageAdded = "Resim Eklendi";


        // # Messages of User # //
        public const string PasswordSame = "Eski şifre ile yeni şifre aynı";
        public const string PasswordError = "Parola Hatalı";
        public const string ChangePassword = "Şifre Başarıyla Değiştirildi";
        public const string SuccessfulLogin = "Giriş Yapıldı";
        public const string UserAlreadyExists = "Bu kullanıcı zaten var.";
        public const string UserRegistered = "Kayıt Oluşturuldu";
        public const string UserNotFound = "Kullanıcı Bulunamadı";
        public const string AccessTokenCreated = "Giriş Başarılı";
        public const string AuthorizationDenied = "Bu işlem için yetkiniz bulunmuyor";
        public const string UserUpdated = "Kullanıcı Bilgileriniz Güncellendi";


        // # Messages pf Customer # //
        public const string CustomerAdded = "Müşteri Listesine Eklendiniz";
        public const string CustomerUpdated = "Müşteri Bilgileriniz Güncellendi";


        // # Messages of SavedCard # //
        public const string CardExist = "Kart Zaten Kayıtlı";
        public const string SavedCardAdded = "Kart Sisteme Kaydedildi";


        // #Messages of DebitCard # //
        public const string CardAdded = "Kart Sisteme Eklendi";
        public const string CardDeleted = "Kart Sistemden Silindi";
        public const string CardInfoSuccess = "Kart Bilgileri Doğrulandı";
        public const string CardInfoError = "Kart Bilgileri Hatalı";
        public const string CardUpdated = "Kart Bilgileri Güncellendi";
        public const string BalanceAdded = "Karta Bakiye Yüklendi";
        public const string InsufficientBalance = "Yetersiz bakiye";
        public const string BalanceDecrased = "Kart Bakiyesi Azaldı";


        // # Messages of Payment # //
        public const string FindexPointAdd = "20 Findex Puan Eklendi";
        public const string FindexPointMax = "Findex Puanınız 1900";
        public const string ReturnDateError = "Araç Teslim Edilmemiş";
    }
}